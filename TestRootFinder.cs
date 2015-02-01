using NUnit.Framework;
using System;

namespace Stats
{
	[TestFixture]
	public class TestRootFinder
	{
		[Test]
		public void TestThrowsErrorIfFunctionAtArgumentsHaveSameSign ()
		{
			Assert.Throws (typeof(ArgumentException), () => RootFinder.solve (x => x * x - 1, -10, -5, 1e-10));
			Assert.Throws (typeof(ArgumentException), () => RootFinder.solve (x => x * x - 1, 10, 5, 1e-10));
			Assert.Throws (typeof(ArgumentException), () => RootFinder.solve (x => x * x - 1, -0.5, 0.5, 1e-10));
		}
		[Test]
		public void TestQuadartic()
		{
			Assert.AreEqual(1, RootFinder.solve(x => x * x - 1, 0.5, 10, 1e-10), 1e-10);
			Assert.AreEqual(-1, RootFinder.solve(x => x * x - 1, -30, 0.5, 1e-10), 1e-10);
		}
		[Test]
		public void TestLinear()
		{
			Assert.AreEqual(0.5, RootFinder.solve(x => x * 2 - 1, -10, 10, 1e-10), 1e-10);
		}
	}
}


