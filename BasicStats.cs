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

	}
}

