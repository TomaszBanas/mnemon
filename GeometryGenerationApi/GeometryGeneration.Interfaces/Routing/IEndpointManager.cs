using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.Interfaces.Routing
{
    public interface IEndpointManager
    {
        void MapGet(string pattern, Delegate handler);
        void MapPost(string pattern, Delegate handler);
    }
}
