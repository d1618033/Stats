using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;


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
		[Test]
		public void TestOutOfBoundsSize2()
		{
			double[] x = { 1, 2};
			double[] y = { -1, 4};
			pi.fit (x, y);
			Assert.Throws (typeof(ArgumentException), () => pi.predict (0));
			Assert.Throws (typeof(ArgumentException), () => pi.predict (3));
		}
		[Test]
		public void TestThreePoints()
		{
			double[] x = { 1, 2, 3};
			double[] p = { 5, 3, 4 };
			double[] y = x.Select (X => p[0] + p[1] * X + p[2] * X * X).ToArray();
			pi.fit (x, y);
			for (double x0=x.Min(); x0 <= x.Max(); x0+=(x.Max() - x.Min())/100)
				Assert.AreEqual(p[0]+p[1]*x0+p[2]*x0*x0, pi.predict(x0), 1e-5);
		}
		[Test]
		public void TestRandomLinearArraySameXYieldsSameY()
		{
			Random rng = new Random ();
			int size = rng.Next (1, 100);
			List<double> x = new List<double>();
			List<double> y = new List<double>();
			for (int i = 0; i < size; i++) {
				x.Add (rng.Next (1, 1000));
			}
			x = x.Distinct ().ToList ();
			y = x.Select (X => (double) rng.Next (1, 1000)).ToList();
			pi.fit (x, y);
			for (int i=0; i<x.Count; i++)
				Assert.AreEqual (y [i], pi.predict (x [i]), 1e-10);
		}
		[Test]
		public void TestRandomLinearArrayFitsPoly()
		{
			Random rng = new Random ();
			int size = rng.Next (1, 10);
			List<double> x = new List<double>();
			List<double> y = new List<double>();
			List<double> p = new List<double>();
			for (int i = 0; i < size; i++) {
				x.Add (rng.Next (1, 5));
			}
			x = x.Distinct ().ToList ();
			p = x.Select(X => (double) rng.Next(1, 5)).ToList();
			y = x.Select (X => p.Select((P, i) => P * Math.Pow(X, i)).Sum()).ToList();
			pi.fit (x, y);
			for (int i=0; i<x.Count; i++)
				Assert.AreEqual (y [i], pi.predict (x [i]), 1e-10);
			for (double x0=x.Min(); x0 <= x.Max(); x0+=(x.Max() - x.Min())/100)
				Assert.AreEqual(p.Select((P, i) => P * Math.Pow(x0, i)).Sum(), pi.predict(x0), 1e-5);
		}
	}
}


