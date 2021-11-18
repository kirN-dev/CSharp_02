using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Converter
{
    public enum BaseSystem
    {
        Bin,
        Oct,
        Hex,
        Base32,
        Base64
    }

    public class NumberSystemConverter
    {
        public static string ToBase(int value, BaseSystem baseSystem) => baseSystem switch
        {
            BaseSystem.Bin => ToBin(value),
            BaseSystem.Oct => ToOct(value),
            _ => throw new NotImplementedException()
        };


        public static string ToBin(int value)
        {
            StringBuilder result = new();

            do
            {
                result.Append(value % 2);
                value /= 2;

            } while (value >= 2);

            result.Append(value);

            return string.Join(string.Empty, result.ToString().Reverse());
        }

        public static string ToBinStandard(int value)
        {
            return Convert.ToString(value, 2);
        }

        public static string ToOct(int value)
        {
            StringBuilder result = new();

            do
            {
                result.Append(value % 8);
                value /= 8;

            } while (value >= 8);

            result.Append(value);

            return string.Join(string.Empty, result.ToString().Reverse());
        }

        public static string ToOctStandard(int value)
        {
            return Convert.ToString(value, 8);
        }

        public static string ToHex(int value)
        {
            StringBuilder result = new();

            do
            {
                result.Append(ToHexSymbol(value));
                value /= 16;

            } while (value >= 16);

            result.Append(value);

            return string.Join(string.Empty, result.ToString().Reverse());
        }

        private static string ToHexSymbol(int value) => (value % 16) switch
        {
            10 => "a",
            11 => "b",
            12 => "с",
            13 => "d",
            14 => "e",
            15 => "f",
            _ => value.ToString(),
        };

        public static string ToHexStandard(int value)
        {
            return Convert.ToString(value, 16);
        }

        public static string ToBase32(int value)
        {
            StringBuilder result = new();

            do
            {
                result.Append(ToBase32Symbol(value % 32));
                value /= 32;

            } while (value >= 32);

            if (value != 0)
            {
                result.Append(value);
            }

            return string.Join(string.Empty, result.ToString().Reverse());
        }
        public static string ToBase32S(int value)
        {
            string symbols = "0123456789ABCDEFGHJKMNPQRSTVWXYZ";
            StringBuilder result = new();

            while (value > 0)
            {
                int remainder = value % 32;
                value /= 32;

                result.Append( symbols[remainder]);

            }

            return string.Join(string.Empty, result.ToString().Reverse());
        }

        private static string ToBase32Symbol(int value) => value switch
        {
            26 => "2",
            27 => "3",
            28 => "4",
            29 => "5",
            30 => "6",
            31 => "7",
            _ => Convert.ToChar(value + 97).ToString(),
        };

        public static string ToBase64(int value)
        {
            string symbols = "ABCDEFGHIJKLMNOPQRSTVWXYZabcdefghijklmnopqrstvwxyz0123456789+/";
            StringBuilder result = new();

            while (value > 0)
            {
                int remainder = value % 64;
                value /= 64;

                result.Append(symbols[remainder]);
            }

            return string.Join(string.Empty, result.ToString().Reverse());
        }

        public static string ToBase64Standard(int value)
        {
            var input = Encoding.UTF8.GetBytes(value.ToString());
            return Convert.ToBase64String(input);
        }
    }
}
