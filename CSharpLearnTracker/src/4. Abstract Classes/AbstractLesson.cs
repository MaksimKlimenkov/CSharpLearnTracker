namespace CSharpLearnTracker.Abstract;

public abstract class Lesson
{
    public int LessonId { get; init; }
    public Lesson(int id)
    {
        LessonId = id;
    }

    public void PrintID()
    {
        Console.WriteLine($"Lesson id: {LessonId}");
    }
}
