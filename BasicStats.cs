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
				throw new ArgumentException ("Arrays must be of equal size");
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
				throw new ArgumentException ("Arrays must be of equal size");
			}
			if (array1.Count() <= 1) 
			{
				return double.NaN;
			}
			return cov(array1, array2) / (std(array1) * std(array2));
		}
		class RankElem
		{
			public RankElem(double Rank, double Elem, int Index)
			{
				this.Rank = Rank;
				this.Elem = Elem;
				this.Index = Index;
			}
			public double Rank{get; set;}
			public double Elem{get; set;}
			public int Index{ get; set;}
		}
		public static ICollection<double> rank(ICollection<double> array, bool averageRanks = false)
		{
			RankElem[] sortedArray = array
				.Select ((a, i) => new RankElem(0, a, i))
				.OrderBy (a => a.Elem)
				.ToArray();
			for (int i = 0; i < sortedArray.Length; i++)
				sortedArray[i].Rank = i + 1;
			if (averageRanks) {
				sortedArray = sortedArray
					.GroupBy (a => a.Elem)
					.SelectMany (g => {double m = g.Average (ga => ga.Rank); 
						return g.Select (a => {a.Rank = m; return a;});})
					.ToArray();
			}
			var ret = new double[sortedArray.Length];
			foreach (RankElem r in sortedArray)
				ret [r.Index] = r.Rank;
			return ret;
		}
		public static double spearman(ICollection<double> array, bool averageRanks = false)
		{
			return (array.Count == 1) ? 1 : pearson (Array.ConvertAll(Enumerable.Range(1, array.Count).ToArray(), x => (double) x),  rank (array, averageRanks).ToArray());
		}
	}
}

