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

        private Dictionary<string, ItemConfig> _data { get; set; }

        private readonly ConfigManager _configManager  = new ConfigManager();

        public ConfigCache()
        {
            _data = new Dictionary<string, ItemConfig>();
        }

        public void Register(Type type, ItemConfigStaticData itemConfigStaticData)
        {
            var data = _configManager.GetConfig(type);
            foreach (var item in data)
            {
                item.Data = itemConfigStaticData;
                _data[item.Id] = item;
            }
        }

        public Config GetConfig()
        {
            var types = _data.Select(item => new KeyValuePair<string, string>(item.Value.Id, item.Value.Name)).ToList();
            return new Config()
            {
                Types = types,
            };
        }

        public ItemConfig GetConfig(string id)
        {
            return _data[id];
        }
    }
}
