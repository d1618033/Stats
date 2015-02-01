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
			Assert.AreEqual (standard.cdf (1.96), 0.975, 0.001);
		}
		[Test]
		public void TestiCDF05StandardReturns0()
		{
			Assert.AreEqual (standard.icdf (0.5), 0, 1e-3);
		}
		[Test]
		public void TestiCDF95StandardReturns164()
		{
			Assert.AreEqual (standard.icdf (0.95), 1.64, 0.01);
		}
		[Test]
		public void TestiCDF975StandardReturns196()
		{
			Assert.AreEqual (standard.icdf (0.975), 1.96, 0.01);
		}
		[Test]
		public void TestiCDF05StandardReturnsMinus164()
		{
			Assert.AreEqual (standard.icdf (0.05), -1.64, 0.01);
		}
		[Test]
		public void TestiCDF025StandardReturnsMinus196()
		{
			Assert.AreEqual (standard.icdf (0.025), -1.96, 0.01);
		}
		[Test]
		public void TestiCDFeM10StandardReturnsMinus196()
		{
			Assert.AreEqual (standard.icdf (1e-10, 0.0001), -6.36134, 0.0001);
		}
		[Test]
		public void TestMean3Std2CDF692Returns975 ()
		{
			Assert.AreEqual ((new NormalRandomVariable(3, 2)).cdf (6.92), 0.975, 0.001);
		}
	}
}

