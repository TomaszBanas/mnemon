using GeometryGeneration.GeneratorBase.Models;
using GeometryGeneration.Model;
using GeometryGeneration.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.GeneratorBase.States
{
    public class BaseGenerationState
    {
        internal IGeometry _geometry { get; set; }

        public BaseGenerationState(IGeometry geometry)
        {
            _geometry = geometry;
        }

        public void CreateInsideTriangles(List<Vector> start, List<Vector> end)
        {
            if (start.Count != end.Count)
                throw new Exception("wrong number of points");

            for (int j = 0; j < start.Count - 1; j++)
            {
                _geometry.AddTriangle(start[j], end[j], start[((j + 1) % start.Count)]);
                _geometry.AddTriangle(end[j], end[((j + 1) % start.Count)], start[((j + 1) % start.Count)]);
            }
        }
        public void CreateOutsideTriangles(List<Vector> start, List<Vector> end)
        {
            if (start.Count != end.Count)
                throw new Exception("wrong number of points");

            for (int j = 0; j < start.Count - 1; j++)
            {
                _geometry.AddTriangle(end[j], start[j], start[((j + 1) % start.Count)]);
                _geometry.AddTriangle(end[((j + 1) % start.Count)], end[j], start[((j + 1) % start.Count)]);
            }
        }
    }
}
