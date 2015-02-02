using System;

namespace Stats
{
	public interface IRandomVariable<T>
	{
		double cdf(T x);
		T icdf(double p);
	}
}

