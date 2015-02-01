using System;

namespace Stats
{
	public class NormalRandomVariable: IRandomVariable<double>
	{
		#region IRandomVariable implementation

		public double cdf (double x)
		{
			//algorithm taken from: http://en.wikipedia.org/wiki/Normal_distribution
			double value=x, sum=x;
			for (int i = 1; i <= 100; i++) 
			{
				value *= x * x / (2 * i + 1);
				sum += value;
			}
			return 0.5 + (sum / Math.Sqrt (2 * Math.PI)) * Math.Exp (-(x * x) / 2);
		}

		public double pdf (double x)
		{
			throw new NotImplementedException ();
		}

		public double icdf (double p)
		{
			return icdf (p, 1e-3);
		}
		public double icdf (double p, double tol)
		{
			return RootFinder.solve (x => cdf(x) - p, tol: tol);
		}


		#endregion

		public NormalRandomVariable ()
		{
			Mu = 0;
			Sigma = 1;
		}
		public NormalRandomVariable (double mu, double sigma)
		{
			Mu = mu;
			Sigma = sigma;
		}
		private double sigma;
		public double Mu{ get; set;}
		public double Sigma{ 
			get {
				return sigma;
			}
			set {
				if (value <= 0)
					throw new ArgumentException ("Sigma must be positive");
				sigma = value;
			}
		}
	}
}

