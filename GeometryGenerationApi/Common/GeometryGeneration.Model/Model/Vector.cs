using ParametersManager.Attributes;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace GeometryGeneration.Model
{
    public class Vector
    {
        [JSchema(Title = "X")]
        public double X { get; set; }
        [JSchema(Title = "Y")]
        public double Y { get; set; }
        [JSchema(Title = "Z")]
        public double Z { get; set; }

        public Vector(double x = 0, double y = 0, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
