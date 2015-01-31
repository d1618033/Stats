using System;
using System.Linq;
using System.Collections.Generic;


namespace Stats
{
	public class Bootstrap<SampleType>
	{
		private Func<IList<SampleType>, double> getParameter;

		public Bootstrap (Func<IList<SampleType>, double> getParameter)
		{
			this.getParameter = getParameter;
		}
		public double[] simulate(IList<SampleType> data, int numSimulations)
		{
			simulate (data, numSimulations, new Random ());
		}
		public double[] simulate(IList<SampleType> data, int numSimulations, Random rnd)
		{
			double[] simulations = new double[numSimulations];
			for (int i = 0; i < numSimulations; i++)
			{
				simulations[i] = getParameter(generateSample(data, rnd));
			}
			return simulations;
		}
		private SampleType[] generateSample(IList<SampleType> d, Random rnd)
		{
			SampleType[] newSample = new SampleType[d.Count];
			for (int i = 0; i < d.Count; i++)
			{
				newSample[i] = d [rnd.Next (0, d.Count)];
			}
			return newSample;
		}

	}
}

