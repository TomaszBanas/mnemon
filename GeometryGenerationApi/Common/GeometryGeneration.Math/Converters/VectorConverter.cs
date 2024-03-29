﻿using GeometryGeneration.MathCalculations.Models;
using GeometryGeneration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.MathCalculations.Converters
{
    public static class VectorConverter
    {
        public static Vector3D ToVector3D(this Vector v)
        {
            return new Vector3D(v.X, v.Y, v.Z);
        }

        public static Vector ToVector(this Vector3D v)
        {
            return new Vector(v.X, v.Y, v.Z);
        }
    }
}
