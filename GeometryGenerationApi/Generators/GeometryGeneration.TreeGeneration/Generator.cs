using GeometryGeneration.TreeGeneration.Interfaces;
using GeometryGeneration.Model;
using GeometryGeneration.TreeGeneration.Models;
using GeometryGeneration.Model.Model;

namespace GeometryGeneration.TreeGeneration
{
    public class TreeGenerator : ITreeGenerator
    {
        internal GeneratorsFactory Factory { get; set; } = new GeneratorsFactory();

        public GeometryModel<TreeGenerationParameters> Generate(TreeGenerationParameters settings)
        {
            settings.UpdateInternalValues();
            var model = new GeometryModel<TreeGenerationParameters>();
            model.Settings = settings;
            var generators = Factory.Create(settings.ComponentsToGenerate);
            foreach (var gen in generators)
            {
                gen.Handle(model);
            }
            return model;
        }
    }
}