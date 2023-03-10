using GeometryGeneration.Samples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.Samples.Mappers
{
    internal class SampleMappers
    {
        public Sample FromDto(SampleDto dto)
        {
            return new Sample
            {
                Id = dto.Id,
                Name = dto.Name,
                Type = dto.Type,
            };
        }

        public SampleDto ToDto(Sample model)
        {
            return new SampleDto
            {
                Id = model.Id,
                Name = model.Name,
                Type = model.Type,
            };
        }
    }
}
