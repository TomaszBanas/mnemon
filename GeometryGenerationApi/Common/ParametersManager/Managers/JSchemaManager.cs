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
    public class JSchemaManager
    {
        public static JSchemaManager Instance { get; set; } = new JSchemaManager();

        public JSchema GetConfig<T>() => GetConfig(typeof(T), GetAttribute(typeof(T)));

        private JSchema GetConfig(Type type, JSchemaAttribute attr)
        {
            if(type == typeof(int))
            {
                return new JSchema
                {
                    Id = attr.Id,
                    Type = JSchemaType.Integer,
                    Title = attr.Title,
                    Description = attr.Description,
                    ReadOnly = attr.ReadOnly
                };
            }
            if (type == typeof(double) || type == typeof(float))
            {
                return new JSchema
                {
                    Id = attr.Id,
                    Type = JSchemaType.Number,
                    Title = attr.Title,
                    Description = attr.Description,
                    ReadOnly = attr.ReadOnly
                };
            }
            if (type == typeof(bool))
            {
                return new JSchema
                {
                    Id = attr.Id,
                    Type = JSchemaType.Boolean,
                    Title = attr.Title,
                    Description = attr.Description,
                    ReadOnly = attr.ReadOnly
                };
            }
            if(type.IsArray)
            {
                return new JSchema
                {
                    Id = attr.Id,
                    Type = JSchemaType.Array,
                    Title = attr.Title,
                    Description = attr.Description,
                    ReadOnly = attr.ReadOnly
                };
            }

            if (type.Name.Contains("List"))
            {
                return new JSchema
                {
                    Id = attr.Id,
                    Type = JSchemaType.Array,
                    Title = attr.Title,
                    Description = attr.Description,
                    ReadOnly = attr.ReadOnly,
                    Items = GetConfig(GetGenericType(type), attr)
                };
            }

            return new JSchema
            {
                Id = attr.Id,
                Type = JSchemaType.Object,
                Title = attr.Title,
                Description = attr.Description,
                ReadOnly = attr.ReadOnly,
                Properties = GetProperties(type)
            };
        }
                
        private JSchemaAttribute GetAttribute(MemberInfo type) => type.GetCustomAttributes(true).FirstOrDefault(x => x is JSchemaAttribute) as JSchemaAttribute;

        private IDictionary<string, JSchema> GetProperties(Type type)
        {
            var props = type.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(JSchemaAttribute)));
            return props.ToDictionary(item => item.Name, item => GetConfig(item.PropertyType, GetAttribute(item)));
        }
        private Type GetGenericType(Type type)
        {
            Type t = type;
            if (t.IsGenericType)
            {
                Type[] at = t.GetGenericArguments();
                t = at.First<Type>();
            }
            return t;
        }
    }
}
