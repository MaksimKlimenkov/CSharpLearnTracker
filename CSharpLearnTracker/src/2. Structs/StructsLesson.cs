namespace CSharpLearnTracker.Structs;

public class StructsLesson : Lesson
{
    public StructsLesson(int id) : base(id)
    {
        Console.WriteLine($"{id}. Structs");

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
