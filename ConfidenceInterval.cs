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
		public double Low ()
		{
			return nrv.icdf (alpha/2);
		}

		public double High ()
		{
			return nrv.icdf (1 - alpha/2);
		}

		private readonly double alpha;
		private readonly NormalRandomVariable nrv;
		public NormalConfidenceInterval (double mean, double std, double confidence)
		{
			if (confidence < 0 || confidence > 1)
				throw new ArgumentException ("Confidence must be between 0 and 1");
			alpha = 1 - confidence;
			nrv = new NormalRandomVariable (mean, std);
		}
	}
}

