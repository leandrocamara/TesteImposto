namespace Imposto.Core.Services
{
    public interface ITemplateService
    {
        void GenerateXml(object data, string fileName);
    }
}