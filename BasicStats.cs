using System;

namespace Stats
{
	public class BasicStats
	{
		public static double sum(double[] x)
		{
			double s = 0;
			for (int i=0; i < x.Length; i++)
				s += x[i];
			return s;
		}
		public static double mean(double[] x)
		{
			return sum(x) / x.Length;
		}
	}
}

