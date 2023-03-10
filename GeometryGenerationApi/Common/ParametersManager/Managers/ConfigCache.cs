using ParametersManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametersManager.Managers
{
    public class ConfigCache
    {
        public static ConfigCache Instance = new ConfigCache();
        private Dictionary<Guid, JSchema> _data { get; set; }

        public ConfigCache()
        {
            _data = new Dictionary<Guid, JSchema>();
        }

        public void Register(Guid id, JSchema item)
        {
            if(_data.ContainsKey(id))
            {
                throw new ArgumentException($"Item with id: {id} already exist!");
            }
            _data.Add(id, item);
        }

        public List<JSchemaDto> GetConfigs()
        {
            return _data.Select(item => new JSchemaDto
            {
                Id = item.Key,
                Title = item.Value.Title,
                Description = item.Value.Description
            }).ToList();
        }

        public JSchema GetConfig(Guid id)
        {
            return _data[id];
        }
    }
}
