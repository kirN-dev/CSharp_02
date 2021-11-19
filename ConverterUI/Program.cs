using Converter;
using System;

namespace ConverterUI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Programm convert integer positive number in different base systems преобразовывает целое неотрицательное число в разные системы исчисления");
                
                Console.Write("Input integer number: ");
                int convertValue = int.Parse(Console.ReadLine());

                for (int i = 0; i < 5; i++)
                {
                    BaseSystem baseSystem = (BaseSystem)i;

                    string algorithm = BaseSystemConverter.ToBase(convertValue, baseSystem);
                    string standard = BaseSystemConverter.ToBase(convertValue, baseSystem, StandardMethod: true);

                    Console.WriteLine("{2}\nAlgorithm:{0}\nStandard: {1}", algorithm, standard, baseSystem);

                    string resultEqual = algorithm == standard ? "Results are equal." : "Results are not equal.";
                    Console.WriteLine(resultEqual);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
