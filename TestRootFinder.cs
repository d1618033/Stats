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
			Assert.Throws (typeof(ArgumentException), () => RootFinder.solve (x => x * x - 1, -10, -5));
			Assert.Throws (typeof(ArgumentException), () => RootFinder.solve (x => x * x - 1, 10, 5));
			Assert.Throws (typeof(ArgumentException), () => RootFinder.solve (x => x * x - 1, -0.5, 0.5));
		}
	}
}


