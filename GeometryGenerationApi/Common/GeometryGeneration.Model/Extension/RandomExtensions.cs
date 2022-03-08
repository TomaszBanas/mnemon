using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryGeneration.Model.Extension
{
    public static class RandomExtensions
    {
        public static float NextSingle(this Random rand, double from, double to)
        {
            var randDouble = rand.NextDouble();
            return (float) ((randDouble * (to - from)) + from);
        }
        
        public static int Next(this Random rand, GeometryGeneration.Model.Model.Range range)
        {
            if (range == null) return 0;
            return rand.Next(range.From, range.To);
        }
    }
}
