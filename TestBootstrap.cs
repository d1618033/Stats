using NUnit.Framework;
using System;

namespace Stats
{
	[TestFixture]
	public class TestBootstrapAverage
	{
		private Bootstrap<double> b;

		[TestFixtureSetUp]
		public void setUp()
		{
			b = new Bootstrap<double> (BasicStats.mean);
		}

		[Test]
		public void TestOneDataPoint()
		{
			double[] data = { 17 };
			const int numSimulations = 100;
			double[] result = b.simulate (data, numSimulations);
			foreach (double r in result)
				Assert.AreEqual (r, 17);
		}

			
	}
}

