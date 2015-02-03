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
		public void TestFitOfSize1NotEqualToXThrowsErrorForOutOfBounds ()
		{
			double[] x = {1};
			double[] y = {10};
			li.fit (x, y);
			Assert.Throws(typeof(ArgumentException), () => li.predict (2));
			Assert.Throws(typeof(ArgumentException), () => li.predict (0));
		}
		[Test]
		public void TestFitOfSize2ForXsReturnsSameY ()
		{
			double[] x = {5, 6};
			double[] y = {7, 100};
			li.fit (x, y);
			for (int i=0; i<x.Length; i++)
				Assert.AreEqual (y [i], li.predict (x [i]), 1e-10);

		}
		[Test]
		public void TestFitOfSize2InTheMiddle ()
		{
			double[] x = {5, 6};
			double[] y = {7, 17};
			li.fit (x, y);
			Assert.AreEqual (12, li.predict (5.5), 1e-10);

		}
		[Test]
		public void TestFitOfSize2ThreeQuarters ()
		{
			double[] x = {5, 9};
			double[] y = {7, 19};
			li.fit (x, y);
			Assert.AreEqual (16, li.predict (8), 1e-10);

		}

	}
}

