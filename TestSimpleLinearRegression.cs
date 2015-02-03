using NUnit.Framework;
using System;

namespace Stats
{
	[TestFixture]
	public class TestSimpleLinearRegression
	{
		private SimpleLinearRegression slr;
		[SetUp]
		public void setUp()
		{
			slr = new SimpleLinearRegression ();
		}
		[Test]
		public void TestFitNotSameSizeThrowsError ()
		{
			double[] x = { 1, 5, 7 };
			double[] y = { 2, 3 };
			Assert.Throws (typeof(ArgumentException), () => slr.fit (x, y));
		}
		[Test]
		public void TestFitOfSize0ThrowsError ()
		{
			double[] x = {};
			double[] y = {};
			Assert.Throws (typeof(ArgumentException), () => slr.fit (x, y));
		}
		[Test]
		public void TestFitOfSize1ThrowsError ()
		{
			double[] x = {5};
			double[] y = {7};
			Assert.Throws (typeof(ArgumentException), () => slr.fit (x, y));
		}
		[Test]
		public void TestFitOfSize2ReturnsSamePredict ()
		{
			double[] x = {5, 6};
			double[] y = {7, 100};
			slr.fit (x, y);
			for (int i=0; i<x.Length; i++)
				Assert.AreEqual (y [i], slr.predict (x [i]), 1e-10);

		}
		[Test]
		public void TestCallingPredictBeforeFitThrowsError ()
		{
			Assert.Throws (typeof(ArgumentException), () => slr.predict (10));
		}

		[Test]
		public void TestSize10 ()
		{
			double[] x = { 10.0, 2.0, 2.0, 7.0, 2.0, 7.0, 4.0, 4.0, 5.0, 1.0 };
			double[] y = { 3.0, 1.0, 5.0, 5.0, 6.0, 2.0, 3.0, 8.0, 6.0, 6.0 };
			slr.fit (x, y);
			const double x0 = 17;
			const double expected = 1.9596774193548385;
			Assert.AreEqual (expected, slr.predict (x0), 1e-10);

		}

	}
}

