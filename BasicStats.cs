using System;
using System.Linq;

namespace Stats
{
	public static class BasicStats
	{
		public static double mean(double[] array)
		{
			return array.Sum() / array.Length;
		}
		public static double variance(double[] array)
		{
			if (array.Length == 0) 
			{
				return double.NaN;
			}
			double m = mean (array);
			return array.Sum (a => (a-m) * (a-m)) / (array.Length - 1);
		}
		public static double std(double[] array)
		{
			return Math.Sqrt (variance (array));
		}
		public static double cov(double[] array1, double[] array2)
		{
			if (array1.Length != array2.Length)
			{
				throw new System.ArgumentException ("Arrays must be of equal size");
			}
			if (array1.Length <= 1) 
			{
				return double.NaN;
			}
			double m1 = mean (array1);
			double m2 = mean (array2);
			double res = array1.Zip(array2, (a1, a2) => (a1 - m1) * (a2 - m2)).Sum();
			return res;
		}
	}
}

