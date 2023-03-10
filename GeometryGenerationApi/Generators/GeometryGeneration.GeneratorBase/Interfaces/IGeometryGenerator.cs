using GeometryGeneration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.GeneratorBase.Interfaces
{
    public interface IGeometryGenerator
    {

    }

    public interface IGeometryGenerator<T>
    {
        GeometryModel<T> Generate(T settings);
        bool Validate(T settings);
    }
}
