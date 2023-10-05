namespace CSharpLearnTracker.Structs;

public class StructsLesson : Lesson
{
    public StructsLesson(string name) : base(name)
    {
    }

    protected override void StartLesson()
    {
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
