using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryGeneration.Model;
using GeometryGeneration.TreeGeneration.Models;

namespace GeometryGeneration.TreeGeneration.Interfaces
{
    public interface ITreeGenerator
    {
        GeometryModel<TreeGenerationParameters> Generate(TreeGenerationParameters settings);
    }
}
