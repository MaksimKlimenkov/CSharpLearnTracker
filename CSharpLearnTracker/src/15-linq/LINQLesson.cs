namespace CSharpLearnTracker.LINQ;

public class LINQLesson : Lesson
{
    public LINQLesson(string name) : base(name)
    {
    }

    protected override void StartLesson()
    {
        string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };

        var selectedPeople = from p in people
                             where p.ToLower().StartsWith('t')
                             orderby p
                             select p;

        Console.WriteLine(string.Join(", ", selectedPeople));

        Person[] people1 = { new("Chumba", 23), new("Tim", 37), new("Tom", 37), new("Bob", 17), new("Ded", 18), };
        var personnel = from p in people1
                        where p.Age >= 18
                        let name = $"Mr. {p.Name}"
                        let year = DateTime.Now.Year - p.Age
                        orderby year, p.Name descending
                        select new
                        {
                            Name = name,
                            Year = year
                        };

        foreach (var p in personnel)
            Console.WriteLine($"{p.Name} - {p.Year}");

        Console.WriteLine();
        Student[] students = { new("Maksim"), new("Egor") };
        Course[] courses = { new("C#"), new("ASP.NET Core") };
        var enrollments = from s in students
                          from c in courses
                          select new { Student = s, Course = c };
        foreach (var e in enrollments)
            Console.WriteLine($"{e.Student} - {e.Course}");

        Console.WriteLine();

        int[] numbers = { 1, 4, 6, -5, 5 };
        Console.WriteLine($"Array Sum: {numbers.Aggregate((x, y) => x + y)}");

        Console.WriteLine();
    }

    record class Person(string Name, int Age);
    record class Student(string Name);
    record class Course(string Title);
}
