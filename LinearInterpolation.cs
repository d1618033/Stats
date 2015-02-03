using System;
using System.Collections.Generic;

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
			if (x.Count <= 1)
				throw new ArgumentException ("X and Y must not be empty");
			this.x = x;
			this.y = y;
			fitWasRun = true;
		}

		public double predict (double x0)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

