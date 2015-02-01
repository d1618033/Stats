using System;

namespace Stats
{
	public interface IConfidenceInterval
	{
		double Low();
		double High();

	}
	public class NormalConfidenceInterval: IConfidenceInterval
	{
		public double Alpha {
			set {
				if (value < 0 || value > 1)
					throw new ArgumentException ("Alpha must be between 0 and 1");
				alpha = value;
			}
		}

		#region IConfidenceInterval implementation

		double IConfidenceInterval.Low ()
		{
			return nrv.icdf (alpha/2);
		}

		double IConfidenceInterval.High ()
		{
			return nrv.icdf (1 - alpha/2);
		}

		#endregion

		private double alpha;
		private NormalRandomVariable nrv;
		public NormalConfidenceInterval (double mean, double std, double alpha)
		{
			this.Alpha = alpha;
			nrv = new NormalRandomVariable (mean, std);
		}
	}
}

