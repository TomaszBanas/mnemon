using GeometryGeneration.Samples.Mappers;
using GeometryGeneration.Samples.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryGeneration.Samples.Services
{
    public class SamplesService
    {
        private readonly IOptions<SamplesConfig> _options;
        private readonly SampleMappers _sampleMigrator = new SampleMappers();

        private List<Sample> _samples;
        private List<Sample> Samples
        {
            get
            {
                if (_samples == null)
                    _samples = Load();
                return _samples;
            }
            set
            {
                _samples = value;
                Save();
            }
        }

        public SamplesService(IOptions<SamplesConfig> options)
        {
            _options = options;
        }

        public List<SampleDto> GetAll()
        {
            return GetConfig().Select(_sampleMigrator.ToDto).ToList();
        }

        public SampleDto Create(CreateSampleDto createModel)
        {
            var model = new Sample
            {
                Id = Guid.NewGuid(),
                Type = createModel.Type,
                Name = createModel.Name
            };
            var pictureFileGuid = Guid.NewGuid().ToString();
            File.WriteAllBytes(Path.Combine(_options.Value.PictureFilesPath, pictureFileGuid), Convert.FromBase64String(createModel.PictureFile));
            model.PictureFilePath = pictureFileGuid;

            var modelFileGuid = Guid.NewGuid().ToString();
            File.WriteAllBytes(Path.Combine(_options.Value.ModelFilesPath, modelFileGuid), Convert.FromBase64String(createModel.ModelFile));
            model.ModelFilePath = modelFileGuid;

            Samples.Add(model);
            Save();

            return _sampleMigrator.ToDto(model);
        }

        public void Delete(Guid sampleId)
        {
            var sample = Samples.Where(x => x.Id == sampleId).First();
            Samples.Remove(sample);
            File.Delete(Path.Combine(_options.Value.PictureFilesPath, sample.PictureFilePath));
            File.Delete(Path.Combine(_options.Value.ModelFilesPath, sample.ModelFilePath));
        }

        public List<Sample> Load()
        {
            var fileContent = File.ReadAllText(_options.Value.ConfigFilePath);
            return JsonConvert.DeserializeObject<List<Sample>>(fileContent);
        }
        public void Save()
        {
            var json = JsonConvert.SerializeObject(_samples);
            File.WriteAllText(_options.Value.ConfigFilePath, json);
        }

        public List<Sample> GetConfig()
        {
            var fileContent = File.ReadAllText(_options.Value.ConfigFilePath);
            return JsonConvert.DeserializeObject<List<Sample>>(fileContent);
        }

        public string GetModelContent(Guid exampleId)
        {
            var config = GetConfig().FirstOrDefault(x => x.Id == exampleId);
            return File.ReadAllText(Path.Combine(_options.Value.ModelFilesPath, config.ModelFilePath));
        }

        public byte[] GetPictureFile(Guid exampleId)
        {
            var config = GetConfig().FirstOrDefault(x => x.Id == exampleId);
            return File.ReadAllBytes(Path.Combine(_options.Value.PictureFilesPath, config.PictureFilePath));
        }
    }
}
