using GeometryGeneration.GeneratorBase.Models;
using GeometryGeneration.MathCalculations.Models;
using GeometryGeneration.Model;
using GeometryGeneration.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryGeneration.MathCalculations.Converters;

namespace GeometryGeneration.GeneratorBase.States
{
    public class ConnectionGenerationState : BaseGenerationState
    {
        public ConnectionGenerationState(IGeometry geometry) : base(geometry) { }

        public void CreateConnection(Connection start, Connection end)
        {
            List<Vector3D> pStart = start.Points;
            List<Vector3D> pEnd = end.Points;
            for (int i = 0; i < start.Points.Count-1; i++)
            {
                //INSIDE
                _geometry.AddTriangle(
                   pStart[i].ToVector(),
                   pEnd[i].ToVector(),
                   pStart[i + 1].ToVector(),
                   new Vector(0.1, 0.1, 0.1));


                _geometry.AddTriangle(
                   pStart[i + 1].ToVector(),
                   pEnd[i].ToVector(),
                   pEnd[i + 1].ToVector(),
                   new Vector(0.1, 0.1, 0.1));

                //OUTSIDE
                _geometry.AddTriangle(
                   pEnd[i].ToVector(),
                   pStart[i].ToVector(),
                   pStart[i + 1].ToVector(),
                   new Vector(0, 0, 0));

                _geometry.AddTriangle(
                   pEnd[i].ToVector(),
                   pStart[i + 1].ToVector(),
                   pEnd[i + 1].ToVector(),
                   new Vector(0, 0, 0));
            }
        }
    }
}
