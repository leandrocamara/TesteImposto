using System.IO;
using Imposto.Configuration;
using Imposto.Core.Services;
using Imposto.Infrastructure.Template.Templates;

namespace Imposto.Infrastructure.Template
{
    public class TemplateService : ITemplateService
    {
        private readonly string _directoryPath;

        public TemplateService(ConfigurationAppSettings configuration)
        {
            _directoryPath = configuration.GetValue("DIRECTORY_PATH");

            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);
        }

        public void GenerateXml(object data, string fileName)
        {
            var xml = new Xml(data.GetType(), data, $"{FilePath(fileName)}.xml");
            xml.Serialize();
        }

        private string FilePath(string fileName) => $"{_directoryPath}/{fileName}";
    }
}