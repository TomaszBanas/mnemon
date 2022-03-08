using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryGeneration.Model
{
    public class GeometryArray
    {
        public List<double> Array { get; set; }

        public int ItemSize { get; set; }
        public int Count { get; set; }

        public GeometryArray(int itemSize)
        {
            Array = new List<double>();
            ItemSize = itemSize;
            Count = 0;
        }
    }
}
