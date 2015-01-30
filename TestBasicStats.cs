using NUnit.Framework;
using System;

namespace Stats
{
	[TestFixture]
	public class TestMean
	{
		[Test]
		public void TestEmptyArrayReturnsNaN ()
		{
			double[] x = new double[0];
			double expected = double.NaN;
			double actual = BasicStats.mean (x);
			Assert.AreEqual (expected, actual);
		}
		[Test]
		public void TestOneElementArrayReturnsThatElement()
		{
			double[] x = { 17 };
			double expected = 17;
			double actual = BasicStats.mean (x);
			Assert.AreEqual (expected, actual);
		}
		[Test]
		public void TestDoubleMeanIsNotFloored()
		{
			double[] x = { 17,  2};
			double expected = 9.5;
			double actual = BasicStats.mean (x);
			Assert.AreEqual (expected, actual);
		}
		[Test]
		public void TestWholeMean()
		{
			double[] x = { 17,  1};
			double expected = 9.0;
			double actual = BasicStats.mean (x);
			Assert.AreEqual (expected, actual);
		}
		[Test]
		public void TestTenElements()
		{
			double[] x = {3.0, 4.0, 9.0, 4.0, 7.0, 1.0, 8.0, 4.0, 9.0, 10.0};
			double expected = 5.9;
			double actual = BasicStats.mean (x);
			Assert.AreEqual (expected, actual);
		}
	}
	[TestFixture]
	public class TestVariance
	{
		[Test]
		public void TestVarianceOfEmptyReturnsNaN()
		{
			double[] x = { };
			double expected = double.NaN;
			double actual = BasicStats.variance (x);
			Assert.AreEqual (expected, actual);
		}
		[Test]
		public void TestVarOf1ElemReturnsNaN()
		{
			double[] x = {5};
			double expected = double.NaN;
			double actual = BasicStats.variance (x);
			Assert.AreEqual (expected, actual);
		}
		[Test]
		public void TestVarOf2Elem()
		{
			double[] x = {5, 7};
			double expected = 2;
			double actual = BasicStats.variance (x);
			Assert.AreEqual (expected, actual);
		}
		[Test]
		public void TestVarOf10Elem()
		{
			double[] x = {5.0, 7.0, 3.0, 2.0, 7.0, 8.0, 9.0, 10.0, 10.0, 7.0};
			double expected = 7.511111111111112;
			double actual = BasicStats.variance (x);
			Assert.AreEqual (expected, actual, 1e-15);
		}

	}
	[TestFixture]
	public class TestStd
	{
		[Test]
		public void TestStdOfEmptyReturnsNaN()
		{
			double[] x = { };
			double expected = double.NaN;
			double actual = BasicStats.std (x);
			Assert.AreEqual (expected, actual);
		}
		[Test]
		public void TestStdOf1ElemReturnsNaN()
		{
			double[] x = {5};
			double expected = double.NaN;
			double actual = BasicStats.std (x);
			Assert.AreEqual (expected, actual);
		}
		[Test]
		public void TestStdOf2Elem()
		{
			double[] x = {5, 7};
			double expected = Math.Sqrt(2);
			double actual = BasicStats.std (x);
			Assert.AreEqual (expected, actual);
		}
		[Test]
		public void TestStdOf10Elem()
		{
			double[] x = {5.0, 7.0, 3.0, 2.0, 7.0, 8.0, 9.0, 10.0, 10.0, 7.0};
			double expected = 2.7406406388125957;
			double actual = BasicStats.std (x);
			Assert.AreEqual (expected, actual, 1e-15);
		}

	}
	[TestFixture]
	public class TestCov
	{
		[Test]
		public void TestUnequalArraySizesRaisesException()
		{
			double[] array1 = { 1, 2 };
			double[] array2 = { 3, 4, 5 };
			Assert.Throws (typeof(System.ArgumentException), delegate {
				BasicStats.cov(array1, array2);
			});
		}
		[Test]
		public void TestSize0ArraysReturnsNaN()
		{
			double[] array1 = { };
			double[] array2 = { };
			double expected = double.NaN;
			double actual = BasicStats.cov (array1, array2);
			Assert.AreEqual (expected, actual);
		}
		[Test]
		public void TestSize1ArraysReturnsNaN()
		{
			double[] array1 = { 5 };
			double[] array2 = { 6 };
			double expected = double.NaN;
			double actual = BasicStats.cov (array1, array2);
			Assert.AreEqual (expected, actual);
		}
		[Test]
		public void TestSize2Arrays()
		{
			double[] array1 = { 1, 2 };
			double[] array2 = { 1, 4 };
			double expected = 1.5;
			double actual = BasicStats.cov (array1, array2);
			Assert.AreEqual (expected, actual);
		}

	}
}

