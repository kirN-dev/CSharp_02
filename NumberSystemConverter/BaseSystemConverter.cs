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

    public class BaseSystemConverter
    {
        public static string ToBase(int value, BaseSystem baseSystem, bool StandardMethod = false)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be greater than zero");
            }

            if (StandardMethod) return baseSystem switch
            {
                BaseSystem.Bin => ToBinStandard(value),
                BaseSystem.Oct => ToOctStandard(value),
                BaseSystem.Hex => ToHexStandard(value),
                BaseSystem.Base32 => null,
                BaseSystem.Base64 => ToBase64Standard(value),
                _ => throw new ArgumentOutOfRangeException(nameof(baseSystem), $"Not expected base system value: {baseSystem}"),
            };

            else return baseSystem switch
            {
                BaseSystem.Bin => ToBin(value),
                BaseSystem.Oct => ToOct(value),
                BaseSystem.Hex => ToHex(value),
                BaseSystem.Base32 => ToBase32(value),
                BaseSystem.Base64 => ToBase64(value),
                _ => throw new ArgumentOutOfRangeException(nameof(baseSystem), $"Not expected base system value: {baseSystem}"),
            };
        }

        private static string ToBin(int value)
        {
            string symbols = "01";
            int baseSystem = 2;

            return ConvertToBase(value, symbols.ToCharArray(), baseSystem);
        }

        private static string ToOct(int value)
        {
            string symbols = "01234567";
            int baseSystem = 8;

            return ConvertToBase(value, symbols.ToCharArray(), baseSystem);
        }

        private static string ToHex(int value)
        {
            string symbols = "0123456789ABCDEF";
            int baseSystem = 16;

            return ConvertToBase(value, symbols.ToCharArray(), baseSystem);
        }

        private static string ToBase32(int value)
        {
            string symbols = "0123456789ABCDEFGHJKMNPQRSTVWXYZ";
            int baseSystem = 32;

            return ConvertToBase(value, symbols.ToCharArray(), baseSystem);
        }

        private static string ToBase64(int value)
        {
            string symbols = "ABCDEFGHIJKLMNOPQRSTVWXYZabcdefghijklmnopqrstvwxyz0123456789+/";
            int baseSystem = 64;

            return ConvertToBase(value, symbols.ToCharArray(), baseSystem);
        }
        private static string ConvertToBase(int value, char[] symbols, int baseSystem)
        {
            if (value == 0)
            {
                return symbols[0].ToString();
            }

            StringBuilder result = new();

            while (value > 0)
            {
                int remainder = value % baseSystem;
                value /= baseSystem;
                result.Insert(0, symbols[remainder]);
            }

            return result.ToString();
        }

        private static string ToBinStandard(int value)
        {
            return Convert.ToString(value, 2);
        }

        private static string ToOctStandard(int value)
        {
            return Convert.ToString(value, 8);
        }

        private static string ToHexStandard(int value)
        {
            return Convert.ToString(value, 16);
        }

        private static string ToBase64Standard(int value)
        {
            var input = Encoding.UTF8.GetBytes(value.ToString());
            return Convert.ToBase64String(input);
        }
    }
}
