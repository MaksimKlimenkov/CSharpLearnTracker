namespace CSharpLearnTracker.Delegates;

public class DelegatesLesson : Lesson
{
    public DelegatesLesson(string name) : base(name)
    {
    }

    protected override void StartLesson()
    {
        //Delegates
        Operation operation = Add;
        operation += Multiply;
        // operation += delegate (int x, int y) // Anonymous Delegate
        // {
        //     return x - y;
        // };
        operation += (int x, int y) => x - y; // Lambda (Anonymous Delegate)
        DoOperation(2, 7, Add);
        DoOperation(2, 7, Multiply);
        DoOperation(2, 7, operation);

        //Events
        Account account = new(0);
        account.Put(100); // Put without event
        account.Notify += Console.WriteLine;
        account.Put(100); // Put with event
        account.Take(150);
        account.Take(150);
        Console.WriteLine();
    }

    void DoOperation(int x, int y, Operation op)
    {
        Console.WriteLine(op(x, y));
    }
    int Add(int x, int y) => x + y;
    int Multiply(int x, int y) => x * y;

    delegate int Operation(int x, int y);
}
