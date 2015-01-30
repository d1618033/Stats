using NUnit.Framework;
using System;
using System.Collections.Generic;

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
		[Test]
		public void TestSize10Arrays()
		{
			double[] array1 = { 3.0, 9.0, 8.0, 9.0, 4.0, 3.0, 1.0, 10.0, 5.0, 1.0 };
			double[] array2 = { 1.0, 8.0, 9.0, 10.0, 7.0, 7.0, 5.0, 7.0, 6.0, 9.0 };
			double expected = 3.8111111111111122;
			double actual = BasicStats.cov (array1, array2);
			Assert.AreEqual (expected, actual);
		}

	}
	[TestFixture]
	public class TestPearson
	{
		[Test]
		public void TestUnequalArraySizesRaisesException()
		{
			double[] array1 = { 1, 2 };
			double[] array2 = { 3, 4, 5 };
			Assert.Throws (typeof(System.ArgumentException), delegate {
				BasicStats.pearson(array1, array2);
			});
		}
		[Test]
		public void TestSize0ArraysReturnsNaN()
		{
			double[] array1 = { };
			double[] array2 = { };
			double expected = double.NaN;
			double actual = BasicStats.pearson (array1, array2);
			Assert.AreEqual (expected, actual);
		}
		[Test]
		public void TestSize1ArraysReturnsNaN()
		{
			double[] array1 = { 5 };
			double[] array2 = { 6 };
			double expected = double.NaN;
			double actual = BasicStats.pearson (array1, array2);
			Assert.AreEqual (expected, actual);
		}
		[Test]
		public void TestSize2Arrays()
		{
			double[] array1 = { 1, 2 };
			double[] array2 = { 1, 4 };
			double expected = 1;
			double actual = BasicStats.pearson (array1, array2);
			Assert.AreEqual (expected, actual, 1e-15);
		}
		[Test]
		public void TestSize10Arrays()
		{
			double[] array1 = { 3.0, 9.0, 8.0, 9.0, 4.0, 3.0, 1.0, 10.0, 5.0, 1.0 };
			double[] array2 = { 1.0, 8.0, 9.0, 10.0, 7.0, 7.0, 5.0, 7.0, 6.0, 9.0 };
			double expected = 0.4338891405782417;
			double actual = BasicStats.pearson (array1, array2);
			Assert.AreEqual (expected, actual, 1e-15);
		}
	}
	[TestFixture]
	public class TestRank
	{
		[Test]
		public void TestSize0ReturnsSize0()
		{
			double[] array = { };
			int expectedLength = 0;
			int actualLength = BasicStats.rank (array).Count;
			Assert.AreEqual (expectedLength, actualLength);
		}
		[Test]
		public void TestSize1Returns1()
		{
			double[] array = { 17 };
			int[] expected = { 1 };
			IList<int> actual = BasicStats.rank (array);
			Assert.AreEqual (expected, actual);
		}
		[Test]
		public void TestSize2Decreasing()
		{
			double[] array = { 17 , 5};
			int[] expected = { 2, 1 };
			IList<int> actual = BasicStats.rank (array);
			Assert.AreEqual (expected, actual);
		}
		[Test]
		public void TestSize2Increasing()
		{
			double[] array = { 5, 17 };
			int[] expected = { 1, 2 };
			IList<int> actual = BasicStats.rank (array);
			Assert.AreEqual (expected, actual);
		}
		[Test]
		public void TestSize3Increasing()
		{
			double[] array = { 5, 17, 21 };
			int[] expected = { 1, 2, 3 };
			IList<int> actual = BasicStats.rank (array);
			Assert.AreEqual (expected, actual);
		}
		[Test]
		public void TestSize3Decreasing()
		{
			double[] array = { 21, 17, 5 };
			int[] expected = { 3, 2, 1 };
			IList<int> actual = BasicStats.rank (array);
			Assert.AreEqual (expected, actual);
		}
		[Test]
		public void TestSize3Perms1()
		{
			double[] array = { 5, 21, 17 };
			int[] expected = { 1, 3, 2 };
			IList<int> actual = BasicStats.rank (array);
			Assert.AreEqual (expected, actual);
		}
		[Test]
		public void TestSize3Perms2()
		{
			double[] array = { 21, 5, 17 };
			int[] expected = { 3, 1, 2 };
			IList<int> actual = BasicStats.rank (array);
			Assert.AreEqual (expected, actual);
		}
		[Test]
		public void TestSize3Perms3()
		{
			double[] array = { 17, 21, 5 };
			int[] expected = { 2, 3, 1 };
			IList<int> actual = BasicStats.rank (array);
			Assert.AreEqual (expected, actual);
		}
		[Test]
		public void TestSize3Perms4()
		{
			double[] array = { 17, 5, 21 };
			int[] expected = { 2, 1, 3 };
			IList<int> actual = BasicStats.rank (array);
			Assert.AreEqual (expected, actual);
		}
	}
}

