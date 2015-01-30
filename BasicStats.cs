using System;
using System.Linq;
using System.Collections.Generic;

namespace Stats
{
	public static class BasicStats
	{
		public static double mean(IList<double> array)
		{
			return array.Sum() / array.Count();
		}
		public static double variance(IList<double> array)
		{
			if (!array.Any())
			{
				return double.NaN;
			}
			double m = mean (array);
			return array.Sum (a => (a-m) * (a-m)) / (array.Count() - 1);
		}
		public static double std(IList<double> array)
		{
			return Math.Sqrt (variance (array));
		}
		public static double cov(IList<double> array1, IList<double> array2)
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
		public static double pearson(IList<double> array1, IList<double> array2)
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
		public static IList<int> rank(IList<double> array)
		{
			return array
				.Select ((a, i) => new {Elem=a, Index=i})
				.OrderBy (a => a.Elem)
				.Select ((a, i) => new {Rank=i+1, Elem=a.Elem, Index=a.Index})
				.OrderBy (a => a.Index)
				.Select (a => a.Rank)
				.ToList();
		}
		public static double spearman(IList<double> array)
		{
			if (array.Count == 1)
				return 1;
			return pearson (Array.ConvertAll(Enumerable.Range(1, array.Count).ToArray(), x => (double) x),  Array.ConvertAll(rank (array).ToArray(), x => (double) x));
		}
	}
}

