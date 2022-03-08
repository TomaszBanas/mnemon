using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.MathCalculations.Converters
{
    public static class NumberConverter
    {
        public static string ToPadString(this double number, int totalWidth = 15)
        {
            var round = totalWidth / 3;
            return Math.Round(number, round).ToString().PadLeft(totalWidth);
        }
    }
}
