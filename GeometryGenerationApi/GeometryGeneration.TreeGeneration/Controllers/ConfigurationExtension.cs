using GeometryGeneration.Interfaces;
using GeometryGeneration.Interfaces.Routing;
using GeometryGeneration.TreeGeneration.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using ParametersManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.TreeGeneration.Controllers
{
    public static class ConfigurationExtension
    {
        private static readonly ItemConfigStaticData _itemConfigStaticData = new ItemConfigStaticData
        {
            GenerateEndpoint = "TreeGenerator/Generate",
            ValidateEndpoint = "TreeGenerator/Validate",
        };
        public static void ConfigureTreeEndpoints(this IEndpointManager app)
        {
            app.MapPost(_itemConfigStaticData.GenerateEndpoint, (TreeGenerationParameters data) => new TreeGenerator().Generate(data));
            app.MapPost(_itemConfigStaticData.ValidateEndpoint, (TreeGenerationParameters data) => true);
        }
        
        public static void ConfigureTreeModels(this ICacheRegistration app)
        {
            app.Register(typeof(TreeGenerationParameters), _itemConfigStaticData);
        }
    }
}
