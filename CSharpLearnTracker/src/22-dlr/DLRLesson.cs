using System.Dynamic;

namespace CSharpLearnTracker.DLR;

public class DLRLesson : Lesson
{
    public DLRLesson(string name) : base(name)
    {
    }

    protected override void StartLesson()
    {
        dynamic dyn = 5;
        dyn += 10;
        Console.WriteLine(dyn);
        dyn += "15";
        Console.WriteLine(dyn);
        dyn = dyn.Replace('1', '3');
        Console.WriteLine(dyn);
        dyn = int.Parse(dyn);
        dyn *= 2;
        Console.WriteLine(dyn);
        dyn = new ExpandoObject();
        dynamic person = new ExpandoObject();
        person.Name = "Tom";
        person.Age = 46;
        person.Languages = new List<string> { "english", "german", "french" };

        Console.WriteLine($"{person.Name} - {person.Age}");
        foreach (var lang in person.Languages)
            Console.WriteLine(lang);

        person.IncrementAge = (Action<int>)(x => person.Age += x);
        person.IncrementAge(6);
        Console.WriteLine($"{person.Name} - {person.Age}");
    }
}
