using RootPower;
using System;

namespace NewtonMethodUI
{
    class Program
    {
        static void Main(string[] args)
        {

            float e = .0000000000000001f;
            double x = RootPower.RootPower.NewtonMethod(number: 5, n: 3, e);
            double y = RootPower.RootPower.Standrd(number: 5, n: 3);

            Console.WriteLine("Results {0} {1}", x, y);

            if (Math.Abs(x - y) < e)
            {
                Console.WriteLine("Results are equal with accuracy {0}", e);
            }
            else
            {
                Console.WriteLine("Results are not equal with accuracy {0}", e);
            }

        }

        private static void InputNumbers(int value, int degree, int accuracy)
        {

        }
    }
}
