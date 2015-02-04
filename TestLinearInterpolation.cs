using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;


namespace Stats
{
	[TestFixture]
	public class TestLinearInterpolation
	{
		LinearInterpolation li;
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
		[Test]
		public void TestSameXValueDifferentYValuesThrowsError()
		{
			double[] x = {5, 5};
			double[] y = {7, 19};
			Assert.Throws (typeof(ArgumentException), () => li.fit (x, y));
		}
		[Test]
		public void TestSameXValueSameYValuesReturnsTheSameYForX()
		{
			double[] x = {5, 5};
			double[] y = {7, 7};
			li.fit (x, y);
			Assert.AreEqual(7, li.predict(5));
		}
		[Test]
		public void TestSameXValueSameYValuesThrowsErrorForOutOfBoundsX()
		{
			double[] x = {5, 5};
			double[] y = {7, 7};
			li.fit (x, y);
			Assert.Throws (typeof(ArgumentException), () => li.predict(6));
			Assert.Throws (typeof(ArgumentException), () => li.predict(4));
		}
		[Test]
		public void TestThreePointsAtXPointsReturnY()
		{
			double[] x = {5, 6, 11};
			double[] y = {7, 100, 300};
			li.fit (x, y);
			for (int i=0; i<x.Length; i++)
				Assert.AreEqual (y [i], li.predict (x [i]), 1e-10);
		}
		[Test]
		public void TestThreePointsThrowsErrorForOutOfBoundsX()
		{
			double[] x = {5, 6, 11};
			double[] y = {7, 100, 300};
			li.fit (x, y);
			Assert.Throws (typeof(ArgumentException), () => li.predict(4));
			Assert.Throws (typeof(ArgumentException), () => li.predict(12));
		}
		[Test]
		public void TestThreePointsDuplicatesXNoDuplicatesY()
		{
			double[] x = {5, 5, 11};
			double[] y = {7, 100, 300};
			Assert.Throws (typeof(ArgumentException), () => li.fit (x, y));
		}
		[Test]
		public void TestThreePointsDuplicatesXDuplicatesYButNotInPlaceWhereDuplicatesInX()
		{
			double[] x = {5, 5, 11};
			double[] y = {7, 100, 100};
			Assert.Throws (typeof(ArgumentException), () => li.fit (x, y));
		}
		[Test]
		public void TestThreePointsDuplicatesXDuplicatesYtInPlaceWhereDuplicatesInXReturnsCorrectYForX()
		{
			double[] x = {5, 5, 11};
			double[] y = {100, 100, 100};
			li.fit (x, y);
			for (int i=0; i<x.Length; i++)
				Assert.AreEqual (y [i], li.predict (x [i]), 1e-10);
		}
		[Test]
		public void TestUnsortedX()
		{
			double[] x = {11, 5, 3};
			double[] y = {100, 17, 1000};
			li.fit (x, y);
			for (int i=0; i<x.Length; i++)
				Assert.AreEqual (y [i], li.predict (x [i]), 1e-10);
		}
		[Test]
		public void TestRandomLinearArray()
		{
			Random rng = new Random ();
			int size = rng.Next (1, 100);
			List<double> x = new List<double>();
			for (int i = 0; i < size; i++)
				x.Add(rng.Next (1, 1000));
			x = x.Distinct ().ToList ();
			double a = rng.NextDouble () * rng.Next(1, 1000);
			double b = rng.NextDouble () * rng.Next(1, 1000);
			List<double> y = x.Select(X => a * X + b).ToList();
			li.fit (x, y);
			for (int i=0; i<x.Count; i++)
				Assert.AreEqual (y [i], li.predict (x [i]), 1e-10);
			for (double i=x.Min(); i<=x.Max(); i+=(x.Max()-x.Min())/100)
				Assert.AreEqual (a * i + b, li.predict (i), 1e-10);
		}
	}
}


