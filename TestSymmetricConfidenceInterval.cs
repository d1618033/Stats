using NUnit.Framework;
using System;

namespace Stats
{
	[TestFixture]
	public class TestSymmetricConfidenceInterval
	{
		[Test]
		public void TestStandard95 ()
		{
			SymmetricConfidenceInterval<double> sci = new SymmetricConfidenceInterval<double>(new NormalRandomVariable(0, 1), 0.95);
			Assert.AreEqual (1.96, sci.High (), 0.01);
			Assert.AreEqual (-1.96, sci.Low (), 0.01);
		}
		[Test]
		public void TestNonStandard95 ()
		{
			SymmetricConfidenceInterval<double> nci = new SymmetricConfidenceInterval<double>(new NormalRandomVariable(1, 4), 0.95);
			Assert.AreEqual (8.84, nci.High (), 0.01);
			Assert.AreEqual (-6.84, nci.Low (), 0.01);
		}
		[Test]
		public void TestThrowsErrorIfConfidenceIsGreaterThan1()
		{
			Assert.Throws(typeof(ArgumentException), () => new SymmetricConfidenceInterval<double>(new NormalRandomVariable(0, 1), 1.1));
		}
		[Test]
		public void TestThrowsErrorIfConfidenceIsLessThan0()
		{
			Assert.Throws(typeof(ArgumentException), () => new SymmetricConfidenceInterval<double>(new NormalRandomVariable(0, 1), -0.1));
		}
	}
}

