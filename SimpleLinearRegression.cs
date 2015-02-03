using System;
using System.Collections.Generic;
using System.Linq;


namespace Stats
{
	public class SimpleLinearRegression: ICurveFit
	{
		private double intercept;
		private double slope;
		private bool fitWasRun;

		public SimpleLinearRegression ()
		{
			fitWasRun = false;
		}

		#region ICurveFit implementation

		public void fit (IList<double> x, IList<double> y)
		{
			if (x.Count != y.Count)
				throw new ArgumentException ("X and Y must be of the same size");
			if (x.Count <= 1)
				throw new ArgumentException ("X and Y's size must be greater than 1");
			if (x.Distinct().Count() == 1)
				throw new ArgumentException ("Multicollinearity: X must not be all the same value");
			slope = BasicStats.cov (x, y) / BasicStats.variance (x);
			intercept = BasicStats.mean (y) - BasicStats.mean (x) * slope;
			fitWasRun = true;
		}

		public double predict (double x0)
		{
			if (!fitWasRun)
				throw new ArgumentException ("Fit must be run before predict");
			return slope * x0 + intercept;

		}

		#endregion
	}
}

