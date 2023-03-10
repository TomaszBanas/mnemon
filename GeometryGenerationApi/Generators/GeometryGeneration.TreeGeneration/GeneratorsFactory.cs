using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryGeneration.TreeGeneration.Generators;
using GeometryGeneration.TreeGeneration.Interfaces;
using GeometryGeneration.Model;
using GeometryGeneration.TreeGeneration.Models;

namespace GeometryGeneration.TreeGeneration
{
    internal class GeneratorsFactory
    {
        public List<IItemGenerator> Create(List<TreeModelType> types)
        {
            if(types == null) return new List<IItemGenerator> { };
            return types.Select(type => Create(type)).Where(x => x != null).OrderBy(x => x.Order).ToList();
        }

        public IItemGenerator Create(TreeModelType type)
        {
            switch (type)
            {
                case TreeModelType.Trunk:
                    return new TrunkGenerator();
                case TreeModelType.Root:
                    break;
                case TreeModelType.Leaves:
                    break;
                case TreeModelType.Flowers:
                    break;
                default:
                    break;
            }
            return null;
        }
    }
}
