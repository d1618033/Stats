using NUnit.Framework;
using System;

namespace Stats
{
	[TestFixture]
	public class TestPolynomialInterpolation
	{
		PolynomialInterpolation pi;
		[SetUp]
		public void setUp()
		{
			pi = new PolynomialInterpolation ();
		}
		[Test]
		public void TestFitNotSameSizeThrowsError ()
		{
			double[] x = { 1, 5, 7 };
			double[] y = { 2, 3 };
			Assert.Throws (typeof(ArgumentException), () => pi.fit (x, y));
		}
		[Test]
		public void TestFitOfSize0ThrowsError ()
		{
			double[] x = {};
			double[] y = {};
			Assert.Throws (typeof(ArgumentException), () => pi.fit (x, y));
		}
		[Test]
		public void TestFitOfSize1ReturnsSameY ()
		{
			double[] x = {1};
			double[] y = {10};
			pi.fit (x, y);
			Assert.AreEqual (10, pi.predict (1));
		}
		[Test]
		public void TestFitOfSize1NotEqualToXThrowsErrorForOutOfBounds ()
		{
			double[] x = {1};
			double[] y = {10};
			pi.fit (x, y);
			Assert.Throws(typeof(ArgumentException), () => pi.predict (2));
			Assert.Throws(typeof(ArgumentException), () => pi.predict (0));
		}
		[Test]
		public void TestFitOfSize2ForXsReturnsSameY ()
		{
			double[] x = {5, 6};
			double[] y = {7, 100};
			pi.fit (x, y);
			for (int i=0; i<x.Length; i++)
				Assert.AreEqual (y [i], pi.predict (x [i]), 1e-10);

		}
		[Test]
		public void TestFitOfSize2InTheMiddle ()
		{
			double[] x = {5, 6};
			double[] y = {7, 17};
			pi.fit (x, y);
			Assert.AreEqual (12, pi.predict (5.5), 1e-10);

		}
		[Test]
		public void TestFitOfSize2ThreeQuarters ()
		{
			double[] x = {5, 9};
			double[] y = {7, 19};
			pi.fit (x, y);
			Assert.AreEqual (16, pi.predict (8), 1e-10);

		}
		[Test]
		public void TestSameXValueDifferentYValuesThrowsError()
		{
			double[] x = {5, 5};
			double[] y = {7, 19};
			Assert.Throws (typeof(ArgumentException), () => pi.fit (x, y));
		}
		[Test]
		public void TestSameXValueSameYValuesReturnsTheSameYForX()
		{
			double[] x = {5, 5};
			double[] y = {7, 7};
			pi.fit (x, y);
			Assert.AreEqual(7, pi.predict(5));
		}
		[Test]
		public void TestSameXValueSameYValuesThrowsErrorForOutOfBoundsX()
		{
			double[] x = {5, 5};
			double[] y = {7, 7};
			pi.fit (x, y);
			Assert.Throws (typeof(ArgumentException), () => pi.predict(6));
			Assert.Throws (typeof(ArgumentException), () => pi.predict(4));
		}
	}
}

