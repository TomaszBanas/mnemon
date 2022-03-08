using GeometryGeneration.MathCalculations.Converters;
using GeometryGeneration.MathCalculations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.MathCalculations.Models
{
    public class Matrix4 : IModel<Matrix4>
    {
        private List<double> _elements { get; set; } = new List<double>
        {
            1, 0, 0, 0,
            0, 1, 0, 0,
            0, 0, 1, 0,
            0, 0, 0, 1,
        };

        public Vector3D BaseX => new Vector3D(_elements[0], _elements[1], _elements[2]);
        public Vector3D BaseY => new Vector3D(_elements[4], _elements[5], _elements[6]);
        public Vector3D BaseZ => new Vector3D(_elements[8], _elements[9], _elements[10]);
        public Vector3D Origin => new Vector3D(_elements[12], _elements[13], _elements[14]);
        public Vector3D Scale => new Vector3D(_elements[3], _elements[7], _elements[11]);
        public double[] Elements => _elements.ToArray();


        public Matrix4(
            double n11 = 1, double n12 = 0, double n13 = 0, double n14 = 0,
            double n21 = 0, double n22 = 1, double n23 = 0, double n24 = 0,
            double n31 = 0, double n32 = 0, double n33 = 1, double n34 = 0,
            double n41 = 0, double n42 = 0, double n43 = 0, double n44 = 1
            )
        {
            this.Set(
                n11, n12, n13, n14,
                n21, n22, n23, n24,
                n31, n32, n33, n34,
                n41, n42, n43, n44
            );
        }

        public Matrix4(Vector3D baseX, Vector3D baseY, Vector3D baseZ, Vector3D origin)
        {
            this.Set(
                    baseX.X, baseY.X, baseZ.X, origin.X,
                    baseX.Y, baseY.Y, baseZ.Y, origin.Y,
                    baseX.Z, baseY.Z, baseZ.Z, origin.Z,
                    0, 0, 0, 1
            );
        }

        public Matrix4 Set(
            double n11 = 1, double n12 = 0, double n13 = 0, double n14 = 0, 
            double n21 = 0, double n22 = 1, double n23 = 0, double n24 = 0, 
            double n31 = 0, double n32 = 0, double n33 = 1, double n34 = 0, 
            double n41 = 0, double n42 = 0, double n43 = 0, double n44 = 1
            )
        {
            _elements[0] = n11; _elements[4] = n12; _elements[8] = n13; _elements[12] = n14;
            _elements[1] = n21; _elements[5] = n22; _elements[9] = n23; _elements[13] = n24;
            _elements[2] = n31; _elements[6] = n32; _elements[10] = n33; _elements[14] = n34;
            _elements[3] = n41; _elements[7] = n42; _elements[11] = n43; _elements[15] = n44;

            return this;
        }

        public Matrix4 Invert()
        {

            // based on http://www.euclideanspace.com/maths/algebra/matrix/functions/inverse/fourD/index.htm
            var te = _elements;

            var n11 = te[0];
            var n21 = te[1];
            var n31 = te[2];
            var n41 = te[3];

            var n12 = te[4];
            var n22 = te[5];
            var n32 = te[6];
            var n42 = te[7];

            var n13 = te[8];
            var n23 = te[9];
            var n33 = te[10];
            var n43 = te[11];

            var n14 = te[12];
            var n24 = te[13];
            var n34 = te[14];
            var n44 = te[15];


            var t11 = n23 * n34 * n42 - n24 * n33 * n42 + n24 * n32 * n43 - n22 * n34 * n43 - n23 * n32 * n44 + n22 * n33 * n44;

            var t12 = n14 * n33 * n42 - n13 * n34 * n42 - n14 * n32 * n43 + n12 * n34 * n43 + n13 * n32 * n44 - n12 * n33 * n44;

            var t13 = n13 * n24 * n42 - n14 * n23 * n42 + n14 * n22 * n43 - n12 * n24 * n43 - n13 * n22 * n44 + n12 * n23 * n44;

            var t14 = n14 * n23 * n32 - n13 * n24 * n32 - n14 * n22 * n33 + n12 * n24 * n33 + n13 * n22 * n34 - n12 * n23 * n34;

            var det = n11 * t11 + n21 * t12 + n31 * t13 + n41 * t14;

            if (det == 0) return Set(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

            var detInv = 1 / det;

            te[0] = t11 * detInv;
            te[1] = (n24 * n33 * n41 - n23 * n34 * n41 - n24 * n31 * n43 + n21 * n34 * n43 + n23 * n31 * n44 - n21 * n33 * n44) * detInv;
            te[2] = (n22 * n34 * n41 - n24 * n32 * n41 + n24 * n31 * n42 - n21 * n34 * n42 - n22 * n31 * n44 + n21 * n32 * n44) * detInv;
            te[3] = (n23 * n32 * n41 - n22 * n33 * n41 - n23 * n31 * n42 + n21 * n33 * n42 + n22 * n31 * n43 - n21 * n32 * n43) * detInv;

            te[4] = t12 * detInv;
            te[5] = (n13 * n34 * n41 - n14 * n33 * n41 + n14 * n31 * n43 - n11 * n34 * n43 - n13 * n31 * n44 + n11 * n33 * n44) * detInv;
            te[6] = (n14 * n32 * n41 - n12 * n34 * n41 - n14 * n31 * n42 + n11 * n34 * n42 + n12 * n31 * n44 - n11 * n32 * n44) * detInv;
            te[7] = (n12 * n33 * n41 - n13 * n32 * n41 + n13 * n31 * n42 - n11 * n33 * n42 - n12 * n31 * n43 + n11 * n32 * n43) * detInv;

            te[8] = t13 * detInv;
            te[9] = (n14 * n23 * n41 - n13 * n24 * n41 - n14 * n21 * n43 + n11 * n24 * n43 + n13 * n21 * n44 - n11 * n23 * n44) * detInv;
            te[10] = (n12 * n24 * n41 - n14 * n22 * n41 + n14 * n21 * n42 - n11 * n24 * n42 - n12 * n21 * n44 + n11 * n22 * n44) * detInv;
            te[11] = (n13 * n22 * n41 - n12 * n23 * n41 - n13 * n21 * n42 + n11 * n23 * n42 + n12 * n21 * n43 - n11 * n22 * n43) * detInv;

            te[12] = t14 * detInv;
            te[13] = (n13 * n24 * n31 - n14 * n23 * n31 + n14 * n21 * n33 - n11 * n24 * n33 - n13 * n21 * n34 + n11 * n23 * n34) * detInv;
            te[14] = (n14 * n22 * n31 - n12 * n24 * n31 - n14 * n21 * n32 + n11 * n24 * n32 + n12 * n21 * n34 - n11 * n22 * n34) * detInv;
            te[15] = (n12 * n23 * n31 - n13 * n22 * n31 + n13 * n21 * n32 - n11 * n23 * n32 - n12 * n21 * n33 + n11 * n22 * n33) * detInv;

            return this;

        }


        public Matrix4 Clone()
        {
            return new Matrix4(
                _elements[0], _elements[4], _elements[8], _elements[12], 
                _elements[1], _elements[5], _elements[9], _elements[13], 
                _elements[2], _elements[6], _elements[10], _elements[14], 
                _elements[3], _elements[7], _elements[11], _elements[15]
            );
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(_elements[0].ToPadString() + "|" + _elements[1].ToPadString() + "|" + _elements[2].ToPadString() + "|" + _elements[3].ToPadString());
            sb.AppendLine("".PadLeft(63, '-'));
            sb.AppendLine(_elements[4].ToPadString() + "|" + _elements[5].ToPadString() + "|" + _elements[6].ToPadString() + "|" + _elements[7].ToPadString());
            sb.AppendLine("".PadLeft(63, '-'));
            sb.AppendLine(_elements[8].ToPadString() + "|" + _elements[8].ToPadString() + "|" + _elements[10].ToPadString() + "|" + _elements[11].ToPadString());
            sb.AppendLine("".PadLeft(63, '-'));
            sb.AppendLine(_elements[12].ToPadString() + "|" + _elements[13].ToPadString() + "|" + _elements[14].ToPadString() + "|" + _elements[15].ToPadString());
            sb.AppendLine("".PadLeft(63, '-'));
            return sb.ToString();
        }

        public static Matrix4 MakeRotationAxis(Vector3D axis, double angle)
        {
            var matrix = new Matrix4();
            var c = Math.Cos(angle);
            var s = Math.Sin(angle);
            var t = 1 - c;
            var x = axis.X;
            var y = axis.Y;
            var z = axis.Z;
            var tx = t * x;
            var ty = t * y;

            matrix.Set(

                tx * x + c, tx * y - s * z, tx * z + s * y, 0,
                tx * y + s * z, ty * y + c, ty * z - s * x, 0,
                tx * z - s * y, ty * z + s * x, t * z * z + c, 0,
                0, 0, 0, 1

            );

            return matrix;

        }

    }
}
