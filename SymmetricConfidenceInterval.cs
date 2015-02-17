using System;

namespace Stats
{
	public class SymmetricConfidenceInterval<T>: IConfidenceInterval<T>
	{
		public T Low ()
		{
			return rv.icdf (alpha/2);
		}

		public T High ()
		{
			return rv.icdf (1 - alpha/2);
		}

		private readonly double alpha;
		private readonly IRandomVariable<T> rv;
		public SymmetricConfidenceInterval (IRandomVariable<T> rv, double confidence)
		{
			if (confidence < 0 || confidence > 1)
				throw new ArgumentException ("Confidence must be between 0 and 1");
			alpha = 1 - confidence;
			this.rv = rv;
		}
	}
}

