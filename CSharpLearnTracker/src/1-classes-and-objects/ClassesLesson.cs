namespace CSharpLearnTracker.Classes;

public class ClassesLesson : Lesson
{
    public ClassesLesson(string name) : base(name)
    {
    }

    protected override void StartLesson()
    {
        Person person = new("Maksim", "test@mail.com", new DateTime(2005, 7, 10));
        Person personWithIntializator = new Person { Name = "Maksim", Email = "test@mail.com", DateOfBirth = new DateTime(2005, 7, 10) };
        Console.WriteLine($"Person age: {person.Age}");
        Console.WriteLine($"Initalizator person age: {personWithIntializator.Age}");
        (string name, int age) = person;
        Console.WriteLine($"Person deconstructed data: {name}/{age}\n");
    }
}