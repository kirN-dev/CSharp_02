using Converter;
using System;

namespace ConverterUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumberSystemConverter.ToBase64(5));
            Console.WriteLine(NumberSystemConverter.ToBase64Standard(5));
        }
    }
}
