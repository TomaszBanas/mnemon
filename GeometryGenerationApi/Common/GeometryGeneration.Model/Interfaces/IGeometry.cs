using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryGeneration.Model.Interfaces
{
    public interface IGeometry
    {
        void AddTriangle(Vector p1, Vector p2, Vector p3);
        void AddTriangle(Vector p1, Vector p2, Vector p3, Vector color);
    }
}
