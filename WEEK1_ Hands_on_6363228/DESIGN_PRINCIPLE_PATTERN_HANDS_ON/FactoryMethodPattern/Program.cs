using FactoryMethodPatternExample.Factories;
using FactoryMethodPatternExample.Documents;

class Program
{
    static void Main()
    {
        List<DocumentFactory> factories = new List<DocumentFactory>
        {
            new WordDocumentFactory(),
            new PdfDocumentFactory(),
            new ExcelDocumentFactory()
        };

        foreach (var factory in factories)
        {
            IDocument doc = factory.CreateDocument();
            doc.Open();
        }
    }
}
