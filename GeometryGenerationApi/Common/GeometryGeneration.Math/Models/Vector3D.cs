using GeometryGeneration.MathCalculations.Converters;
using GeometryGeneration.MathCalculations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.MathCalculations.Models
{
    public class Vector3D : IModel<Vector3D>
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector3D(double x = 0, double y = 0, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Vector3D Add(Vector3D v)
        {
            X += v.X;
            Y += v.Y;
            Z += v.Z;
            return this;
        }
        public Vector3D Substract(Vector3D v)
        {
            X -= v.X;
            Y -= v.Y;
            Z -= v.Z;
            return this;
        }
        public Vector3D Multiply(Vector3D v)
        {
            X *= v.X;
            Y *= v.Y;
            Z *= v.Z;
            return this;
        }
                
        public double Dot(Vector3D v)
        {
            return X * v.X + Y * v.Y + Z * v.Z;
        }
        public Vector3D DivideScalar(double value)
        {
            X /= value;
            Y /= value;
            Z /= value;
            return this;
        }
        public Vector3D MultiplyScalar(double value)
        {
            X *= value;
            Y *= value;
            Z *= value;
            return this;
        }
        public Vector3D Cross(Vector3D v)
        {
            var ax = X;
            var ay = Y;
            var az = Z;
            var bx = v.X;
            var by = v.Y;
            var bz = v.Z;

            X = ay * bz - az * by;
            Y = az * bx - ax * bz;
            Z = ax * by - ay * bx;

            return this;
        }
        
        public double DistanceTo(Vector3D v)
        {
            return Clone().Substract(v).Length();
        }

        public Vector3D ApplyMatrix4(Matrix4 m)
        {

            var x = X;
            var y = Y;
            var z = Z;
            var e = m.Elements;

            var w = 1 / (e[3] * x + e[7] * y + e[11] * z + e[15]);

            X = (e[0] * x + e[4] * y + e[8] * z + e[12]) * w;
            Y = (e[1] * x + e[5] * y + e[9] * z + e[13]) * w;
            Z = (e[2] * x + e[6] * y + e[10] * z + e[14]) * w;

            return this;

        }

        public Vector3D Normalize()
        {
            var length = Length();
            if (length == 0)
                length = 1;
            return DivideScalar(length);
        }
        
        public double Length()
        {
            return Math.Sqrt(LengthSq());
        }
        
        public double LengthSq()
        {
            return X * X + Y * Y + Z * Z;
        }

        public Vector3D Clone()
        {
            return new Vector3D(X, Y, Z);
        }

        public override string ToString()
        {
            return $"X: {X.ToPadString()}; Y: {Y.ToPadString()}; Z: {Z.ToPadString()}";
        }
    }
}
