using GeometryGeneration.Samples.Models;
using GeometryGeneration.Samples.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeometryGeneration.Api.Controllers
{
    [Route("Samples")]
    public class SamplesController : Controller
    {
        private readonly SamplesService _samplesService;

        public SamplesController(SamplesService samplesService)
        {
            _samplesService = samplesService;
        }

        [HttpGet]
        [Route("All")]
        public IActionResult GetExamples()
        {
            var samples = _samplesService.GetAll();
            return Ok(samples);
        }
        [HttpPut]
        [Route("")]
        public IActionResult Create(CreateSampleDto createModel)
        {
            var sample = _samplesService.Create(createModel);
            return Ok(sample);
        }
        [HttpDelete]
        [Route("")]
        public IActionResult Delete(Guid sampleId)
        {
            _samplesService.Delete(sampleId);
            return Ok();
        }
        [HttpGet]
        [Route("Picture/{sampleId}")]
        public IActionResult GetPicture(Guid sampleId)
        {
            var samples = _samplesService.GetPictureFile(sampleId);
            return Ok(samples);
        }
        [HttpGet]
        [Route("Model/{sampleId}")]
        public IActionResult GetModel(Guid sampleId)
        {
            var samples = _samplesService.GetModelContent(sampleId);
            return Ok(samples);
        }
    }
}
