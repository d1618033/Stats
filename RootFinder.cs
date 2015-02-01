using System;

namespace Stats
{
	public static class RootFinder
	{
		public static double solve(Func<double, double> f, double a, double b, double tol)
		{
			double fa = f (a);
			double fb = f (b);
			if (fa * fb > 0)
				throw new ArgumentException ("f(a) and f(b) must have opposite signs");
			double c;
			while (true){
				c = (a + b) / 2;
				if (b - a < tol)
					return c;
				double fc = f (c);
				if (fc * fa > 0) {
					a = c;
					fa = fc;
				} else {
					b = c;
					fb = fc;
				}
			};
		}
	}
}

