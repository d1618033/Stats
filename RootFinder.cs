using System;

namespace Stats
{
	public static class RootFinder
	{
		public static double solve(Func<double, double> f, double a=double.NaN, double b=double.NaN, double tol=1e-10)
		{
			bool fix = false;
			if (double.IsNaN (a)) {
				a = -10;
				fix = true;
			}
			if (double.IsNaN (b)) {
				b = 10;
				fix = true;
			}
			if (fix) {
				while (f(a) * f(b) > 0)
				{
					a *= 2;
					b *= 2;
				}
			}

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

