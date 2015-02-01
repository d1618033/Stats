using NUnit.Framework;
using System;

namespace Stats
{
	[TestFixture]
	public class TestNormalRandomVariable
	{
		private NormalRandomVariable standard;
		[SetUp]
		public void setUp()
		{
			standard = new NormalRandomVariable ();
		}
		[Test]
		public void TestDefaultIsStandard ()
		{
			Assert.AreEqual (0, standard.Mu);
			Assert.AreEqual (1, standard.Sigma);
		}
		[Test]
		public void TestSigmaLessThan0ThrowsError ()
		{
			Assert.Throws (typeof(ArgumentException), () => new NormalRandomVariable (0, -1));
		}
		[Test]
		public void TestSigma0ThrowsError ()
		{
			Assert.Throws (typeof(ArgumentException), () => new NormalRandomVariable (10, 0));
		}
		[Test]
		public void TestCDF0StandardReturnsHalf()
		{
			Assert.AreEqual (standard.cdf (0), 0.5, 1e-10);
		}
		[Test]
		public void TestCDF164StandardReturns95()
		{
			Assert.AreEqual (standard.cdf (1.64), 0.95, 0.01);
		}
		[Test]
		public void TestCDF196StandardReturns975()
		{
			Assert.AreEqual (standard.cdf (1.96), 0.975, 0.001);
		}
		[Test]
		public void TestCDFMinus164StandardReturns5()
		{
			Assert.AreEqual (standard.cdf (-1.64), 0.05, 0.01);
		}
		[Test]
		public void TestCDFMinus196StandardReturns025()
		{
			Assert.AreEqual (standard.cdf (-1.96), 0.0255, 0.001);
		}

	}
}

