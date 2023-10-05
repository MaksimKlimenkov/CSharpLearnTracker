namespace CSharpLearnTracker.Dates;

public class DatesLesson : Lesson
{
    public DatesLesson(int id) : base(id)
    {
        Console.WriteLine($"{id}. Dates");
        DateTime zeroDate = new(); // == DateTime.MinValue
        DateTime date = new(2007, 7, 15, 18, 30, 50);
        DateTime date1 = new(1970, 1, 1, 0, 0, 0);
        Console.WriteLine(zeroDate);
        Console.WriteLine(date);
        Console.WriteLine(DateTime.Now);
        Console.WriteLine(DateTime.Today);

        Console.WriteLine($"TimeSpan = {date - date1}");
        Console.WriteLine((date - date1).TotalMilliseconds);

        Console.WriteLine();
    }
}
