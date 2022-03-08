using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using GeometryGeneration.GeometryGeneration.Models;
using GeometryGeneration.MathCalculations.Models;
using GeometryGeneration.Model;

namespace GeometryGeneration.TreeGeneration.Utils
{
    public class GeometryComponentsUtils
    {
        public static GeometryComponentsUtils Instance = new GeometryComponentsUtils();

        public IEnumerable<Vector3D> GenerateCircle(Vector3D origin, Vector3D direction, double radius, int points)
        {
            var radDir = GenerateAngled(direction);
            var angle = Math.PI * 2 / points;
            for (int i = 0; i < points; i++)
            {
                var matrix = Matrix4.MakeRotationAxis(direction, (angle * i));
                yield return origin.Clone().Add(radDir.Clone().ApplyMatrix4(matrix).Normalize().MultiplyScalar(radius));
            }
        }

        public Vector3D GenerateAngled(Vector3D direction)
        {
            Vector3D X = new Vector3D(1, 0, 0);
            var crossX = direction.Clone().Cross(X);
            if (crossX.Length() != 0)
                return direction.Clone().Cross(crossX);

            Vector3D Y = new Vector3D(0, 1, 0);
            var crossY = direction.Clone().Cross(Y);
            if (crossY.Length() != 0)
                return direction.Clone().Cross(crossY);

            Vector3D Z = new Vector3D(0, 0, 1);
            var crossZ = direction.Clone().Cross(Z);
            if (crossZ.Length() != 0)
                return direction.Clone().Cross(crossZ);

            return new Vector3D();
        }
        // create matrix where dir is baseX and other are some sort of random but thats OK :(
        public Matrix4 GenerateMatrix(Vector3D direction)
        {
            var baseX = direction;
            var baseY = GenerateAngled(direction);
            var baseZ = baseX.Clone().Cross(baseY);
            return new Matrix4(baseX, baseY, baseZ, new Vector3D());
        }

        public Quaternion GenerateAxisAngle(Vector3D direction, float angle)
        {
            var halfAngle = angle / 2;
            var s = Math.Sin(halfAngle);

            var x = direction.X * s;
            var y = direction.Y* s;
            var z = direction.Z * s;
            var w = Math.Cos(halfAngle);


            return new Quaternion((float)x, (float)y, (float)z, (float)w);
        }
        
        public Vector3D ApplyAxisAngle(Vector3D v, Vector3D direction, float angle)
        {
            var matrix = Matrix4.MakeRotationAxis(direction, angle);
            return v.Clone().ApplyMatrix4(matrix).Normalize();
        }
    }
}
