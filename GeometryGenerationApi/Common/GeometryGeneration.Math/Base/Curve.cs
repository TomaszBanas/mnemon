using GeometryGeneration.MathCalculations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.MathCalculations.Base
{
	public abstract class Curve
    {
        public abstract List<Matrix4> GetPoints(int divisions = 200);

		private double GetUtoTmapping(double u)
		{

			var arcLengths = GetLengths();

			var i = 0;
			var il = arcLengths.Count;

			var targetArcLength = u * arcLengths[il - 1];


			var low = 0.0;
			var high = il - 1;

			while (low <= high)
			{

				i = Convert.ToInt32(Math.Floor(low + (high - low) / 2));

				var comparison = arcLengths[i] - targetArcLength;

				if (comparison < 0)
				{
					low = i + 1;
				}
				else if (comparison > 0)
				{
					high = i - 1;
				}
				else
				{
					high = i;
					break;
				}
			}
			i = high;
			if (arcLengths[i] == targetArcLength)
			{
				return i / (il - 1);
			}
			var lengthBefore = arcLengths[i];
			var lengthAfter = arcLengths[i + 1];
			var segmentLength = lengthAfter - lengthBefore;
			var segmentFraction = (targetArcLength - lengthBefore) / segmentLength;
			var t = (i + segmentFraction) / (il - 1);

			return t;

		}

		public double GetLength()
		{
			return GetLengths().Last();
		}

		public List<double> GetLengths(int divisions = 200)
		{
			var result = new List<double>();
			var points = GetPoints(divisions);
			
			var last = points.First().Origin;
			var sum = 0.0;
			result.Add(0);
			for (var p = 1; p <= divisions; p++)
			{
				var current = points[p].Origin;
				sum += current.DistanceTo(last);
				result.Add(sum);
				last = current;
			}
			return result;

		}

	}
}
