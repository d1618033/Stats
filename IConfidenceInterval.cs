using System;

namespace Stats
{
	public interface IConfidenceInterval<T>
	{
		T Low();
		T High();
	}
}

