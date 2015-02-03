using System;
using System.Collections.Generic;
using System.Linq;


namespace Stats
{
	public class LinearInterpolation: ICurveFit
	{
		private IList<double> x;
		private IList<double> y;
		private bool fitWasRun;

		public LinearInterpolation ()
		{
			fitWasRun = false;
		}

		#region ICurveFit implementation

		public void fit (IList<double> x, IList<double> y)
		{
			if (x.Count != y.Count)
				throw new ArgumentException ("X and Y must be of the same size");
			if (x.Count == 0)
				throw new ArgumentException ("X and Y must not be empty");
			x = x.Distinct().ToList();
			y = y.Distinct().ToList();
			if (x.Count != y.Count)
				throw new ArgumentException ("When X is all the same value, Y must also be all the same");
			this.x = x;
			this.y = y;
			fitWasRun = true;
		}

		public double predict (double x0)
		{
			if (!fitWasRun)
				throw new ArgumentException ("Fit must be run before predict");
			if (this.x.Count == 1) {
				if (x0 > this.x[0] || x0 < this.x[0])
					throw new ArgumentException ("x0 is out of bounds");
				return this.y [0];
			}
			for (int i = 1; i < this.x.Count; i++) {
				if (x [i - 1] <= x0 && x0 <= x [i]) {
					SimpleLinearRegression slr = new SimpleLinearRegression ();
					slr.fit (new double[]{ x [i - 1], x [i] }, new double[]{ y [i - 1], y [i] });
					return slr.predict(x0);
				}
			}
			throw new ArgumentException ("x0 is out of bounds");
		}

		#endregion
	}
}

