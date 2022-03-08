using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.MathCalculations.Interfaces
{
    public interface IModel<T>
    {
        T Clone();
    }
}
