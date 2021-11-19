using System;

namespace RootPower
{
	public class RootPower
	{
		public static double NewtonMethod(double number, int n, float accuracy)
		{
			if (number <= 0 || n <= 0 || accuracy <= 0)
			{
				throw new ArgumentOutOfRangeException("Values must be greater than zero");
			}

			if (accuracy > .11f)
			{
				throw new ArgumentOutOfRangeException(nameof(accuracy), "Accuracy must be less than 0.11");
			}

			double past = n + 1;
			double current = StepNewtonMethod(number, n, past);

			while (Math.Abs(past - current) >= accuracy)
			{
				past = current;
				current = StepNewtonMethod(number, n, past);
			}

			return current;
		}

		private static double StepNewtonMethod(double number, int degree, double current)
		{
			return current - (Math.Pow(current, degree) - number) / Derivative(current, degree);
		}

		private static double Derivative(double value, int degree)
		{
			return degree * Math.Pow(value, degree - 1);
		}

		public static double Standrd(double number, int n)
		{
			if (number <= 0 || n <= 0)
			{
				throw new ArgumentOutOfRangeException("Values must be greater than zero");
			}

			return Math.Pow(number, 1d / n);
		}
	}
}
