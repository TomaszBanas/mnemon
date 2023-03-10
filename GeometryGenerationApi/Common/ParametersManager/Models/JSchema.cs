using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametersManager.Models
{
    public enum JSchemaType
    {
        None,
        String,
        Number,
        Integer,
        Boolean,
        Object,
        Array,
        Null
    }

    public class JSchema
    {
        public Guid Id { get; set; }
        public JSchemaType Type { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public IDictionary<string, JSchema>? Properties { get; set; }
        public JSchema Items { get; set; }
        public IEnumerable<object>? Enum { get; set; }
        public bool? ReadOnly { get; set; }
        public string? Regex { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            sb.Append($"\"type\":\"{Type.ToString().ToLower()}\"");
            if(Id != Guid.Empty)
            {
                sb.Append(",");
                sb.Append($"\"id\":\"{Id}\"");
            }
            if(!string.IsNullOrWhiteSpace(Title))
            {
                sb.Append(",");
                sb.Append($"\"title\":\"{Title}\"");
            }
            if (!string.IsNullOrWhiteSpace(Description))
            {
                sb.Append(",");
                sb.Append($"\"description\":\"{Description}\"");
            }
            if (Properties != null)
            {
                sb.Append(",");
                sb.Append("\"properties\":{");
                foreach (var x in Properties.Select((x, i) => new { Property = x, Index = i }))
                {
                    if(x.Index > 0)
                        sb.Append(",");
                    sb.Append($"\"{FirstCharToLowwer(x.Property.Key)}\":{x.Property.Value.ToString()}");
                }
                sb.Append("}");
            }
            if (Items != null)
            {
                sb.Append(",");
                sb.Append($"\"items\":{Items.ToString()}");
            }
            if (Enum != null)
            {
                sb.Append(",");
                sb.Append($"\"enum\":[{string.Join(",", Enum.Select(Jsonyfie))}]");
            }
            if (ReadOnly.HasValue)
            {
                sb.Append(",");
                sb.Append($"\"readonly\":{(ReadOnly.Value? "true" : "false")}");
            }
            if (!string.IsNullOrWhiteSpace(Regex))
            {
                sb.Append(",");
                sb.Append($"\"regex\":\"{Regex}\"");
            }
            sb.Append("}");
            return sb.ToString();
        }

        private object Jsonyfie(object prop)
        {
            if (prop is string) return $"\"{prop}\"";
            if (prop is bool) return $"{((prop as Nullable<bool>).Value? "true" : "false" )}";
            return prop.ToString();
        }

        public string FirstCharToLowwer(string input) =>
        input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
            _ => string.Concat(input[0].ToString().ToLowerInvariant(), input.AsSpan(1))
        };
    }
}
