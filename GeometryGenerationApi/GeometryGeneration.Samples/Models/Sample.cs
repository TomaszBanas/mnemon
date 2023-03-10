using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.Samples.Models
{
    public class Sample
    {
        public Guid Id { get; set; }
        public Guid Type { get; set; }
        public string Name { get; set; }
        public string PictureFilePath { get; set; }
        public string ModelFilePath { get; set; }
    }
}
