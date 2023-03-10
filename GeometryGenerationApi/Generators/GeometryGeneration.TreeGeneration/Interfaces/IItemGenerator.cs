using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryGeneration.Model;
using GeometryGeneration.TreeGeneration.Models;

namespace GeometryGeneration.TreeGeneration.Interfaces
{
    internal interface IItemGenerator
    {
        int Order { get; }
        void Handle(GeometryModel<TreeGenerationParameters> model);
    }
}
