namespace FactoryMethodPatternExample.Documents;

public class WordDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening a Word document.");
    }
}
