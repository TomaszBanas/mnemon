using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.Samples.Models
{
    public class CreateSampleDto
    {
        public Guid Type { get; set; }
        public string Name { get; set; }
        public string PictureFile { get; set; }
        public string ModelFile { get; set; }
    }
}
