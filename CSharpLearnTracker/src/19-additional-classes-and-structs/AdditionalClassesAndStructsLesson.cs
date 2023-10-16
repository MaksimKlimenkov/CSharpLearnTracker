namespace CSharpLearnTracker.AdditionalClassesAndStructs;

public class AdditionalClassesAndStructsLesson : Lesson
{
    public AdditionalClassesAndStructsLesson(string name) : base(name)
    {
    }

    protected override void StartLesson()
    {
        Reader reader = new();
        reader.ReadEBook();
        reader.ReadBook();

        int[] temperatures =
            {
                10, 12, 13, 14, 15, 11, 13, 15, 16, 17,
                18, 16, 15, 16, 17, 14,  9,  8, 10, 11,
                12, 14, 15, 15, 16, 15, 13, 12, 12, 11
            };

        Span<int> temperaturesSpan = temperatures;

        Span<int> firstDecade = temperaturesSpan[..10];
        Span<int> lastDecade = temperaturesSpan[20..30];
        Console.WriteLine();
        //Span does not take up memory space

        Index start = 0;
        Index end = ^1;
        string[] people = { "Tom", "Bob", "Sam", "Kate", "Alice" };
        Console.WriteLine(people[start]);
        Console.WriteLine(people[end]);
        Console.WriteLine();


    }
}