namespace CSharpLearnTracker.AdditionalClassesAndStructs;

public class Reader
{
    Lazy<Library> library = new();

    public void ReadBook()
    {
        library.Value.GetBook();
        Console.WriteLine("Read Book");
    }

    public void ReadEBook()
    {
        Console.WriteLine("Read EBook");
    }
}

public class Library
{
    private string[] books = new string[99];

    public void GetBook()
    {
        Console.WriteLine("Handing out the book to the reader");
    }
}
