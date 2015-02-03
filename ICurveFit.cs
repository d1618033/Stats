using System;
using System.Collections.Generic;

namespace Stats
{
	public interface ICurveFit
	{
		void fit(IList<double> x, IList<double> y);
		double predict(double x0);
	}
}

