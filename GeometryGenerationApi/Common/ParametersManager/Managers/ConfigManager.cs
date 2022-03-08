using GeometryGeneration.Model.Extension;
using Newtonsoft.Json;
using ParametersManager.Attributes;
using ParametersManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ParametersManager.Managers
{
    public class ConfigManager
    {
        public List<ItemConfig> GetConfig(Type type)
        {
            var data = GetClassType(type);
            var properties = GetProperties(data);
            return data.Attributes.Select(x => new ItemConfig 
            {
                Id = x.Id,
                Name = x.Name,
                Properties = properties,
            }).ToList();
        }
                
        private List<ItemConfigProperty> GetProperties(ConfigInternalData<ParameterClassAttribute> data)
        {
            var props = data.Type.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(ParameterPropertyAttribute)));
            return props.Select(item => MapProperty(item)).Where(x => x != null).ToList();
        }
        
        public ItemConfigProperty MapProperty(PropertyInfo item)
        {
            var attr = Attribute.GetCustomAttributes(item).FirstOrDefault(x => x is ParameterPropertyAttribute) as ParameterPropertyAttribute;
            if (attr == null)
                return null;
            return CreateConfig(attr, item);
        }


        private ItemConfigProperty CreateConfig(ParameterPropertyAttribute attr, PropertyInfo item)
        {
            var property = item.Name;
            var propAtt = item.GetCustomAttributes(true).FirstOrDefault(x => x is JsonPropertyNameAttribute);
            if (propAtt != null)
            {
                property = ((JsonPropertyNameAttribute)propAtt).Name;
            }
                if (item.PropertyType.IsGenericType && item.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
            {
                Type itemType = item.PropertyType.GetGenericArguments()[0];
                if (itemType.IsEnum)
                {
                    return new ItemConfigProperty
                    {
                        Name = attr.Name,
                        Property = property,
                        Type = "MultiSelect",
                        Metadata = JsonConvertUtils.SerializeObjectToCamelCase(CreateEnumMetadata(itemType))
                    };
                }
                var subConfigs = GetConfig(itemType);
                if(subConfigs.Count == 1)
                {
                    return new ItemConfigProperty
                    {
                        Name = attr.Name,
                        Property = property,
                        Type = "ObjectList",
                        SubData = subConfigs.First()
                    };
                }

            }
            if (item.PropertyType.IsEnum)
            {
                return new ItemConfigProperty
                {
                    Name = attr.Name,
                    Property = property,
                    Type = "Select",
                    Metadata = JsonConvertUtils.SerializeObjectToCamelCase(CreateEnumMetadata(item.PropertyType))
                };
            }
            if(item.CustomAttributes.Any(x => x.AttributeType == typeof(GroupParameterPropertyAttribute)))
            {
                Type itemType = item.PropertyType;
                var subConfigs = GetConfig(itemType);
                if (subConfigs.Count == 1)
                {
                    return new ItemConfigProperty
                    {
                        Name = attr.Name,
                        Property = property,
                        Type = "Group",
                        SubData = subConfigs.First()
                    };
                }
            }
            return new ItemConfigProperty
            {
                Name = attr.Name,
                Property = property,
                Type = item.PropertyType.Name
            };
        }

        private IEnumerable<KeyValuePair<int, string>> CreateEnumMetadata(Type type)
        {
            var values = Enum.GetValues(type);
            foreach (var value in values)
            {
                yield return new KeyValuePair<int, string>((int)value, value.ToString());
            }
        }

        private ConfigInternalData<ParameterClassAttribute> GetClassType(Type type)
        {
            var attr = type.GetCustomAttributes(typeof(ParameterClassAttribute), true);
            if (attr.Length == 0)
                throw new Exception("WrongModel");

            return new ConfigInternalData<ParameterClassAttribute>
            {
                Type = type,
                Attributes = attr.Select(x => x as ParameterClassAttribute).Where(x => x != null).ToList()
            };
        }
    }
}
