using NUnit.Framework;
using System;

namespace Stats
{
	[TestFixture ()]
	public class TestLinearInterpolation
	{
		private LinearInterpolation li;
		[SetUp]
		public void setUp()
		{
			li = new LinearInterpolation ();
		}
		[Test]
		public void TestFitNotSameSizeThrowsError ()
		{
			double[] x = { 1, 5, 7 };
			double[] y = { 2, 3 };
			Assert.Throws (typeof(ArgumentException), () => li.fit (x, y));
		}
		[Test]
		public void TestFitOfSize0ThrowsError ()
		{
			double[] x = {};
			double[] y = {};
			Assert.Throws (typeof(ArgumentException), () => li.fit (x, y));
		}
		[Test]
		public void TestFitOfSize1ReturnsSameY ()
		{
			double[] x = {1};
			double[] y = {10};
			li.fit (x, y);
			Assert.AreEqual (10, li.predict (1));
		}
		[Test]
		public void TestFitOfSize1ThrowsErrorForOutOfBounds ()
		{
			double[] x = {1};
			double[] y = {10};
			li.fit (x, y);
			Assert.Throws(typeof(ArgumentException), () => li.predict (2));
			Assert.Throws(typeof(ArgumentException), () => li.predict (0));
		}
	}
}

