namespace CSharpLearnTracker.ParallelLINQ;

public class ParallelLINQLesson : Lesson
{
    public ParallelLINQLesson(string name) : base(name)
    {
    }

    protected override void StartLesson()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var squares = from n in numbers.AsParallel().AsOrdered()
                      select Square(n);
        Console.WriteLine(string.Join(", ", squares));

        var query = from n in squares.AsUnordered()
                    where n > 4
                    select n;
        Console.WriteLine(string.Join(", ", query));

        object[] objects = { 1, 2, 3, 4, 5, "6" };
        var fiveobjects = from o in objects.AsParallel()
                          select 5 * (int)o;

        try
        {
            Console.WriteLine(string.Join(", ", fiveobjects));
        }
        catch (AggregateException ex)
        {
            foreach (var e in ex.InnerExceptions)
            {
                Console.WriteLine(e.Message);
            }
        }

    }

    int Square(int n) => n * n;
}
