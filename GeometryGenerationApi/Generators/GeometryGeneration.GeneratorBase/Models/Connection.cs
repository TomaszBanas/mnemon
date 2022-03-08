using GeometryGeneration.MathCalculations.Models;
using GeometryGeneration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.GeneratorBase.Models
{
    public class Connection
    {

        public List<Vector3D> Points { get; set; }
        public Vector3D Origin { get; set; }
        public Vector3D Direction { get; set; }
        public Connection(Matrix4 matrix, double radius, int noOfPoints)
        {
            Points = new List<Vector3D>();
            Origin = matrix.Origin;
            Direction = matrix.BaseX;

            var rotationPart = 2 * Math.PI / (noOfPoints - 1);
            for (int i = 0; i < noOfPoints; i++)
            {
                var rotated = matrix.BaseY.Clone();
                var rM = Matrix4.MakeRotationAxis(Direction.Clone(), i * rotationPart);
                rotated.ApplyMatrix4(rM);
                rotated.Normalize();
                rotated.MultiplyScalar(radius);
                Points.Add( Origin.Clone().Add(rotated) );
            }
        }
    }
}
