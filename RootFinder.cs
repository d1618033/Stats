using System;

namespace Stats
{
	public static class RootFinder
	{
		public static double solve(Func<double, double> f, double a, double b)
		{
			if (f (a) * f (b) > 0)
				throw new ArgumentException ("f(a) and f(b) must have opposite signs");
			return 0;
		}
	}
}

