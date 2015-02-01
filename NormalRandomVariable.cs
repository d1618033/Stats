using System;

namespace Stats
{
	public class NormalRandomVariable: IRandomVariable<double>
	{
		#region IRandomVariable implementation

		public double cdf (double x)
		{
			throw new NotImplementedException ();
		}

		public double pdf (double x)
		{
			throw new NotImplementedException ();
		}

		public double icdf (double p)
		{
			throw new NotImplementedException ();
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

