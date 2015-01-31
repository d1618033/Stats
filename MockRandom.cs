using System;
using System.Collections.Generic;
using System.Linq;

namespace Stats
{
	public class MockRandom: Random
	{
		private IEnumerator<int> seeds;

		public MockRandom () : base()
		{
			IList<int> temp = new int[] { 0 };
			seeds = temp.GetEnumerator();
		}

		public IEnumerable<int> Seeds {
			set{
				IEnumerator<int> temp = value.GetEnumerator ();
				if (!temp.MoveNext())
					throw new ArgumentException ("Seeds cannot be empty");
				temp.Reset();
				seeds = temp;
			}
		}
		public override int Next(int minValue, int maxValue)
		{
			return clamp(getNextSeed(), minValue, maxValue-1);
		}
		public override int Next()
		{
			return getNextSeed ();
		}
		public override int Next (int maxValue)
		{
			return clamp (getNextSeed (), maxValue-1);
		}
		private int clamp(int x, int min, int max)
		{
			return x < min ? min : x > max ? max : x;
		}
		private int clamp(int x, int max)
		{
			return x > max ? max : x;
		}
		private int getNextSeed()
		{
			if (!seeds.MoveNext ()) {
				seeds.Reset ();
				seeds.MoveNext ();
			}
			return seeds.Current;
		}
	}
}


