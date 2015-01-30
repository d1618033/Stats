using System;
using System.Linq;
using System.Collections.Generic;

namespace Stats
{
	public static class BasicStats
	{
		public static double mean(ICollection<double> array)
		{
			return array.Sum() / array.Count();
		}
		public static double variance(ICollection<double> array)
		{
			if (!array.Any())
			{
				return double.NaN;
			}
			double m = mean (array);
			return array.Sum (a => (a-m) * (a-m)) / (array.Count() - 1);
		}
		public static double std(ICollection<double> array)
		{
			return Math.Sqrt (variance (array));
		}
		public static double cov(ICollection<double> array1, ICollection<double> array2)
		{
			if (array1.Count() != array2.Count())
			{
				throw new System.ArgumentException ("Arrays must be of equal size");
			}
			if (array1.Count() <= 1) 
			{
				return double.NaN;
			}
			double m1 = mean (array1);
			double m2 = mean (array2);
			double res = array1.Zip(array2, (a1, a2) => (a1 - m1) * (a2 - m2)).Sum() / (array1.Count() - 1);
			return res;
		}
		public static double pearson(ICollection<double> array1, ICollection<double> array2)
		{
			if (array1.Count() != array2.Count())
			{
				throw new System.ArgumentException ("Arrays must be of equal size");
			}
			if (array1.Count() <= 1) 
			{
				return double.NaN;
			}
			return cov(array1, array2) / (std(array1) * std(array2));
		}
	}
}

