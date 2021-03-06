﻿using System;
using System.Linq;
using System.Collections.Generic;


namespace Stats
{
	public class Bootstrap<ObsType>
	{
		private Func<IList<ObsType>, double> getParameter;

		public Bootstrap (Func<IList<ObsType>, double> getParameter)
		{
			this.getParameter = getParameter;
		}
		public double[] simulate(IList<ObsType> data, int numSimulations)
		{
			return simulate (data, numSimulations, new Random ());
		}
		public double[] simulate(IList<ObsType> data, int numSimulations, Random rnd)
		{
			double[] simulations = new double[numSimulations];
			for (int i = 0; i < numSimulations; i++)
			{
				simulations[i] = getParameter(generateSample(data, rnd));
			}
			return simulations;
		}
		private ObsType[] generateSample(IList<ObsType> d, Random rnd)
		{
			ObsType[] newSample = new ObsType[d.Count];
			for (int i = 0; i < d.Count; i++)
			{
				newSample[i] = d [rnd.Next (0, d.Count)];
			}
			return newSample;
		}

	}
}

