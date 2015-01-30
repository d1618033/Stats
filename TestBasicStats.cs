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
}

