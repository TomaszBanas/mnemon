using Microsoft.AspNetCore.Mvc;
using ParametersManager.Managers;

namespace GeometryGeneration.Api.Controllers
{
    [Route("Samples")]
    public class ConfigController : Controller
    {
        [HttpGet]
        [Route("All")]
        public IActionResult GetExamples()
        {
            var samples = ConfigCache.Instance.GetAll();
            return Ok(samples);
        }
        [HttpGet]
        [Route("Picture/{sampleId}")]
        public IActionResult GetPicture(Guid sampleId)
        {
            var samples = _samplesService.GetPictureFile(sampleId);
            return Ok(samples);
        }
    }
}
