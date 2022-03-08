using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryGeneration.Model.Model
{
    public class Transformation
    {

        public Vector BaseX { get; set; }
        public Vector BaseY { get; set; }
        public Vector BaseZ { get; set; }
        public Vector Origin { get; set; }

        public Transformation(Vector baseX, Vector baseY, Vector baseZ, Vector origin)
        {
            BaseX = baseX;
            BaseY = baseY;
            BaseZ = baseZ;
            Origin = origin;
        }
    }
}
