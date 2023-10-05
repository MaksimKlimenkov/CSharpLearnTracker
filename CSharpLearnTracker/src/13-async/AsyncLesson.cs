namespace CSharpLearnTracker;

public class AsyncLesson : Lesson
{
    public AsyncLesson(string name) : base(name)
    {
    }


    async Task<int> Print(string message)
    {
        if (message.Length > 20)
            throw new ArgumentException($"Invalid string length: {message.Length}");
        await Task.Delay(new Random().Next(100, 200));
        Console.WriteLine(message);
        return 10;
    }

    protected override async void StartLesson()
    {
        Console.WriteLine(1);
        Console.WriteLine(Print("Hello World"));
        Console.WriteLine(2);
        Console.WriteLine(await Print("Hello World"));
        Console.WriteLine(3);

        Console.WriteLine();

        var task1 = Print("First Message");
        var task2 = Print("Second Message");
        var task3 = Print("Thrird Message");

        await Task.WhenAll(task1, task2, task3);
        Console.WriteLine("All messages sended");

        Console.WriteLine();

        task1 = Print("First Message");
        task2 = Print("Second Message");
        task3 = Print("Thrird Message");

        await Task.WhenAny(task1, task2, task3);
        Console.WriteLine("One message sended");
        await Task.WhenAll(task1, task2, task3);

        Console.WriteLine();

        var task = Print("012345678901234567890");
        try
        {
            await task;
        }
        catch
        {
            Console.WriteLine(task.Exception?.Message);
            Console.WriteLine(task.IsFaulted);
            Console.WriteLine(task.Status);
        }
        Console.WriteLine();

        Console.WriteLine("Async Stream:");
        // App stops before stream is ending
        await foreach (int num in GetNumbersAsync())
            Console.WriteLine(num);

    }

    public async IAsyncEnumerable<int> GetNumbersAsync()
    {
        for (int i = 0; i < 10; i++)
        {
            await Task.Delay(100);
            yield return i;
        }
    }
}
