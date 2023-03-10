using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametersManager.Attributes
{
    public class JSchemaAttribute : Attribute
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? ReadOnly { get; set; }
        public bool? Regex { get; set; }
    }
}
