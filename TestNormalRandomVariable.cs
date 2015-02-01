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
	}
}

