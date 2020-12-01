using System;
using System.IO;
using System.Xml.Serialization;

namespace Imposto.Infrastructure.Template.Templates
{
    public class Xml
    {
        private readonly Type _type;
        private readonly object _data;
        private readonly string _filePath;

        private XmlSerializer _xmlSerializer;

        public Xml(Type type, object data, string filePath)
        {
            _type = type;
            _data = data;
            _filePath = filePath;
        }

        public void Serialize()
        {
            using (var writer = new StreamWriter(_filePath))
            {
                GetSerializer().Serialize(writer, _data);
                writer.Close();
            }
        }

        public object Deserialize()
        {
            using (var reader = new StreamReader(_filePath))
            {
                var data = GetSerializer().Deserialize(reader);
                reader.Close();
                return data;
            }
        }

        private XmlSerializer GetSerializer()
        {
            return _xmlSerializer ?? (_xmlSerializer = new XmlSerializer(_type));
        }
    }
}