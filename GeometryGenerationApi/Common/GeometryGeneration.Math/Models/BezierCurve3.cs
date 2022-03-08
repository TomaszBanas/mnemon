using GeometryGeneration.MathCalculations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.MathCalculations.Models
{
    public class BezierCurve3 : Curve
    {
        private List<Vector3D> P { get; set; }
        private int n => P.Count-1;

        public BezierCurve3(List<Vector3D> p)
        {
            P = p;
        }

        public override List<Matrix4> GetPoints(int divisions = 200)
        {
            //return GetRMF(divisions);
            return new double[divisions+1].Select((i, index) => GetPoint((double)index / divisions)).ToList();

            //var uValues = new double[divisions].Select(i => (double)i / divisions).ToList();
            //var origins = uValues.Select(x => Origin(x)).ToList();
            //var derivatives = uValues.Select(x => Derivative(x)).ToList();


            //var result = new List<Matrix4>();
            //for (int i = 0; i < divisions; i++)
            //{
            //    result.Add(new Matrix4(derivatives[i], derivatives[i], derivatives[i], origins[i]));
            //}
            //return result;
        }

        List<Matrix4> GetRMF(int steps)
        {
            var frames = new List<Matrix4>();
            double c1, c2, step = 1.0 / steps, t0, t1;
            Vector3D v1, v2, riL, tiL, riN, siN;
            Matrix4 x0, x1;

            // Start off with the standard tangent/axis/normal frame
            // associated with the curve just prior the Bezier interval.
            t0 = -step;
            frames.Add(GetPoint(t0));

            // start constructing RM frames
            for (; t0 < 1.0; t0 += step)
            {
                // start with the previous, known frame
                x0 = frames[frames.Count() - 1];

                // get the next frame: we're going to throw away its axis and normal
                t1 = t0 + step;
                x1 = GetPoint(t1);

                // First we reflect x0's tangent and axis onto x1, through
                // the plane of reflection at the point midway x0--x1
                v1 = x1.Origin.Clone().Substract(x0.Origin);
                c1 = v1.Clone().Dot(v1);
                riL = x0.BaseX.Clone().Substract(v1.Clone().MultiplyScalar(2.0 / c1 * v1.Dot(x0.BaseX)));
                tiL = x0.BaseY.Clone().Substract(v1.Clone().MultiplyScalar(2 / c1 * v1.Dot(x0.BaseY)));

                // Then we reflection a second time, over a plane at x1
                // so that the frame tangent is aligned with the curve tangent:
                v2 = x1.BaseY.Clone().Substract(tiL);
                c2 = v2.Dot(v2);
                riN = riL.Clone().Substract(v2.Clone().MultiplyScalar(2 / c2 * v2.Dot(riL)));
                siN = x1.BaseY.Clone().Cross(riN);
                //x1.n = siN;
                //bar BaseX = riN;

                //// we record that frame, and move on
                //frames.add(x1);

                var baseZ = siN;
                var baseY = x1.BaseY;
                var baseX = riN;
                var origin = x1.Origin;

                // we record that frame, and move on
                frames.Add(new Matrix4(baseX, baseY, baseZ, origin));
            }

            // and before we return, we throw away the very first frame,
            // because it lies outside the Bezier interval.
            frames.RemoveAt(0);

            return frames;
        }



        private Matrix4 GetPoint(double u)
        {
            var a = FirstDerivative(u);
            var b = SecondDerivative(u);
            if(a.Clone().Cross(b).LengthSq() == 0)
            {
                b = new Vector3D(0, 0, 1);
            }
            if (a.Clone().Cross(b).LengthSq() == 0)
            {
                b = new Vector3D(0, 1, 0);
            }

            var c = a.Clone().Add(b);
            var r = c.Clone().Cross(a);
            var n = r.Clone().Cross(a);
            c = r.Clone().Cross(n);
            var origin = Origin(u);

            c.Normalize().MultiplyScalar(-1);
            r.Normalize().MultiplyScalar(-1);
            n.Normalize().MultiplyScalar(-1);

            return new Matrix4(c, r, n, origin);
        }

        private Vector3D Normal(double u)
        {
            var result = new Vector3D(0, 0, 1);

            return result;
        }

        private Vector3D Rotational(double u, Vector3D origin, Vector3D derivative)
        {
            //var v1 = 

            var riL = new Vector3D();
            var v2 = new Vector3D();
            var c2 = new Vector3D(1, 1, 1);
            var result = new Vector3D
            {
                X = 0,
                Y = 1,
                Z = 0,
            };
            return result;
        }

        private Vector3D FirstDerivative(double u)
        {
            var result = new Vector3D();
            for (int i = 0; i <= n-1; i++)
            {
                var point = BezierOriginPoint(n-1, i, u);
                result.X += point * ( P[i+1].X - P[i].X );
                result.Y += point * ( P[i+1].Y - P[i].Y );
                result.Z += point * ( P[i+1].Z - P[i].Z );
            }

            return result;
        }

        private Vector3D SecondDerivative(double u)
        {
            var result = new Vector3D();
            for (int i = 0; i <= n - 2; i++)
            {
                var point = BezierOriginPoint(n - 2, i, u);
                result.X += point * (P[i + 2].X - ( 2 * P[i + 1].X) + P[i].X) * n * (n - 1);
                result.Y += point * (P[i + 2].Y - ( 2 * P[i + 1].Y) + P[i].Y) * n * (n - 1);
                result.Z += point * (P[i + 2].Z - ( 2 * P[i + 1].Z) + P[i].Z) * n * (n - 1);
            }

            return result;
        }

        private Vector3D Origin(double u)
        {
            var result = new Vector3D();
            for (int i = 0; i <= n; i++)
            {
                var point = BezierOriginPoint(n, i, u);
                result.X += P[i].X * point;
                result.Y += P[i].Y * point;
                result.Z += P[i].Z * point;
            }

            return result;
        }

        private double BezierOriginPoint(int n, int i, double u)
        {
            var part1 = Factorial(n) / (Factorial(i) * Factorial(n - i));
            var part2 = Math.Pow(u, i) * Math.Pow((1-u), (n-i));
            return part1 * part2;
        }

        private int Factorial(int n)
        {
            if (n == 0) return 1;
            return n * Factorial(n - 1);
        }

    }
}
