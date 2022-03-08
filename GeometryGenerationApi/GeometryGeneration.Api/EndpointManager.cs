using GeometryGeneration.BezierCurveGeneration.Controllers;
using GeometryGeneration.Interfaces;
using GeometryGeneration.Interfaces.Routing;
using GeometryGeneration.MEPElementGeneration.Controllers;
using GeometryGeneration.TreeGeneration.Controllers;
using ParametersManager.Controllers;
using ParametersManager.Managers;
using ParametersManager.Models;

namespace GeometryGeneration.Api
{
    public class EndpointManager : IEndpointManager, ICacheRegistration
    {
        private readonly IEndpointRouteBuilder _endpointRouteBuilder;

        public EndpointManager(IEndpointRouteBuilder endpointRouteBuilder)
        {
            _endpointRouteBuilder = endpointRouteBuilder;
        }

        public void MapGet(string pattern, Delegate handler)
        {
            _endpointRouteBuilder.MapGet(pattern, handler).WithTags(pattern.Split('/').First());
        }
        
        public void MapPost(string pattern, Delegate handler)
        {
            _endpointRouteBuilder.MapPost(pattern, handler).WithTags(pattern.Split('/').First());
        }
        public void Register(Type type, object data)
        {
            ConfigCache.Instance.Register(type, (ItemConfigStaticData)data);
        }

        public void Configure()
        {
            ConfigureEndPoints();
            ConfigureModels();
        }
        
        private void ConfigureEndPoints()
        {
            this.ConfigurePropertiesEndpoints();
            this.ConfigureBazierCurveEndpoints();
            this.ConfigureTreeEndpoints();
            this.ConfigureMEPEndpoints();
        }
        
        private void ConfigureModels()
        {
            this.ConfigureBazierCurveModels();
            this.ConfigureTreeModels();
            this.ConfigureMEPModels();
        }

    }
}
