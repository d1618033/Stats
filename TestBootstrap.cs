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
		[Test]
		public void TestThreeDataPoints()
		{
			double[] data = { 17 , 10, 5};
			const int numSimulations = 27;
			MockRandom rng = new MockRandom ();
			rng.Seeds = new int[] {	0, 0, 0,
									0, 0, 1,
									0, 0, 2,
									0, 1, 0,
									0, 1, 1,
									0, 1, 2,
									0, 2, 0,
									0, 2, 1,
									0, 2, 2,
									1, 0, 0,
									1, 0, 1,
									1, 0, 2,
									1, 1, 0,
									1, 1, 1,
									1, 1, 2,
									1, 2, 0,
									1, 2, 1,
									1, 2, 2,
									2, 0, 0,
									2, 0, 1,
									2, 0, 2,
									2, 1, 0,
									2, 1, 1,
									2, 1, 2,
									2, 2, 0,
									2, 2, 1,
									2, 2, 2 };
			double[] result = b.simulate (data, numSimulations, rng);
			double[] expected = { 17.0, 14.666666666666666, 13.0, 14.666666666666666, 12.333333333333334, 10.666666666666666, 13.0, 10.666666666666666, 9.0, 14.666666666666666, 12.333333333333334, 10.666666666666666, 12.333333333333334, 10.0, 8.333333333333334, 10.666666666666666, 8.333333333333334, 6.666666666666667, 13.0, 10.666666666666666, 9.0, 10.666666666666666, 8.333333333333334, 6.666666666666667, 9.0, 6.666666666666667, 5.0 };
			int i = 0;
			foreach (double r in result)
			{
				double e = expected[i];
				Assert.AreEqual (e, r, 1e-15);
				i++;
			}
		}			
	}
}

