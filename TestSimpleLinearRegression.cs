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
	}
}

