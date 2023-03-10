using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.Interfaces
{
    public interface ICacheRegistration
    {
        void Register(Type type, object data);
    }
}
