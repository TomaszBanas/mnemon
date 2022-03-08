using GeometryGeneration.MathCalculations.Models;
using GeometryGeneration.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.MathCalculations.Converters
{
    public static class MatrixConverter
    {
        public static Matrix4 ToMatrix4(this Transformation t)
        {
            return new Matrix4(t.BaseX.ToVector3D(), t.BaseY.ToVector3D(), t.BaseZ.ToVector3D(), t.Origin.ToVector3D());
        }

        public static Transformation ToTransformation(this Matrix4 m)
        {
            return new Transformation(m.BaseX.ToVector(), m.BaseY.ToVector(), m.BaseZ.ToVector(), m.Origin.ToVector());
        }
    }
}
