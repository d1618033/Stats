﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace Stats
{
	public class PolynomialInterpolation: ICurveFit
	{
		private IList<double> x;
		private IList<double> y;
		private bool fitWasRun;

		public PolynomialInterpolation ()
		{
			fitWasRun = false;
		}

		#region ICurveFit implementation
		private class Point{
			public double x{ get; set; }
			public double y{ get; set; }
			public Point(double x, double y)
			{
				this.x = x;
				this.y = y;
			}
		}
		public void fit (IList<double> x, IList<double> y)
		{
			if (x.Count != y.Count)
				throw new ArgumentException ("X and Y must be of the same size");
			if (x.Count == 0)
				throw new ArgumentException ("X and Y must not be empty");
			fixDuplicates (x, y);
			fitWasRun = true;
		}
		private void fixDuplicates(IList<double> x, IList<double> y)
		{
			IList<Point> data = x.Select ((xi, i) => new Point(xi,y [i])).OrderBy (e => e.x).ToList ();
			IList<Point> newData = new List<Point> ();
			newData.Add (data.First ());
			for (int i = 1; i < data.Count; i++) {
				if (data [i].x == data [i - 1].x) {
					if (data [i].y != data [i - 1].y)
						throw new ArgumentException ("Same X value must have same Y value");
				} else {
					newData.Add (data[i]);
				}
			}
			this.x = newData.Select (p => p.x).ToList();
			this.y = newData.Select (p => p.y).ToList();

		}

		public double predict (double x0)
		{
			if (!fitWasRun)
				throw new ArgumentException ("Fit must be run before predict");
			if (this.x.Count == 1) {
				if (x0 > this.x[0] || x0 < this.x[0])
					throw new ArgumentException ("x0 is out of bounds");
				return this.y [0];
			}
			int index = Array.BinarySearch (x.ToArray(), x0);
			if (index > 0)
				return y [index];
			else {
				index = -index - 1;
				if (index == 0 || index >= x.Count)
					throw new ArgumentException ("x0 is out of bounds");
				double y0 = 0;
				for (int i = 0; i < x.Count; i++) {
					double p = 1;
					for (int j = 0; j < x.Count; j++) {
						if (j == i)
							continue;
						p *= (x0 - x [j]) / (x [i] - x [j]);
					}
					p *= y [i];
					y0 += p;
				}
				return y0;
			}
		}

		#endregion
	}
}
