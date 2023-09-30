namespace CSharpLearnTracker.Structs;

public class StructsLesson
{
    public StructsLesson()
    {
        Console.WriteLine("Lesson 2: Structs");

        Person tom = new()
        {
            Name = "Tom",
            Age = 15
        };
        Person bob = tom with { Name = "Bob" };
        Person tamara = new("Tamara", 37);
        Console.WriteLine(tom);
        Console.WriteLine(bob);
        Console.WriteLine(tamara);
        Console.WriteLine();
    }
}
