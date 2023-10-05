namespace CSharpLearnTracker.Abstract;

public abstract class Lesson
{
    public string LessonName { get; init; }
    public Lesson(string name)
    {
        LessonName = name;
        Console.WriteLine(name);
        StartLesson();
    }

    protected abstract void StartLesson();

    public void PrintName()
    {
        Console.WriteLine($"Lesson id: {LessonName}");
    }
}
