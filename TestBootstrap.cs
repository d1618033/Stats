using NUnit.Framework;
using System;

namespace Stats
{
	[TestFixture]
	public class TestBootstrapAverage
	{
		private Bootstrap<double> b;

		[SetUp]
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
				Assert.AreEqual (17, r);
		}

		[Test]
		public void TestTwoDataPoints()
		{
			double[] data = { 17 , 10};
			const int numSimulations = 4;
			MockRandom rng = new MockRandom ();
			rng.Seeds = new int[] { 0, 0, 0, 1, 1, 0, 1, 1 };
			double[] result = b.simulate (data, numSimulations, rng);
			double[] expected = { 17, 13.5, 13.5, 10 };
			Assert.AreEqual (expected, result);
		}
			
	}
}

