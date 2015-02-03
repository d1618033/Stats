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
	}
}

