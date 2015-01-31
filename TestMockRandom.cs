using NUnit.Framework;
using System;

namespace Stats
{
	[TestFixture]
	public class TestMockRandom
	{
		private MockRandom mr;
		[SetUp]
		public void setUp ()
		{
			mr = new MockRandom ();
		}

		[Test]
		public void TestDefaultIs0()
		{
			for (int i = 0; i < 10; i++)
				Assert.AreEqual (0, mr.Next ());
		}
		[Test]
		public void TestSetSeeds()
		{
			mr.Seeds = new int[] { 1, 2 };
			Assert.AreEqual (1, mr.Next ());
			Assert.AreEqual (2, mr.Next ());
		}
		[Test]
		public void TestNextMax()
		{
			mr.Seeds = new int[] { 1, 5 };
			Assert.AreEqual (1, mr.Next (3));
			Assert.AreEqual (3, mr.Next (4));
		}
		[Test]
		public void TestNextMinMax()
		{
			mr.Seeds = new int[] { 1, 5, 7, 11};
			Assert.AreEqual (1, mr.Next (1, 10));
			Assert.AreEqual (4, mr.Next (4, 5), 4);
			Assert.AreEqual (3, mr.Next (2, 4));
			Assert.AreEqual (20, mr.Next (20, 23));
		}
		[Test] 
		public void TestCycles()
		{
			mr.Seeds = new int[] { 3, 4, 5 };
			for (int i = 0; i < 10; i++) 
			{
				Assert.AreEqual (3, mr.Next ());
				Assert.AreEqual (4, mr.Next ());
				Assert.AreEqual (5, mr.Next ());
			}
		}

	}
}

