namespace CSharpLearnTracker.Memory;

public class MemoryLesson : Lesson
{
    public MemoryLesson(string name) : base(name)
    {
    }

    protected override void StartLesson()
    {
        Test();
        GC.Collect();
        UnsafeMethod();
    }

    unsafe void UnsafeMethod()
    {
        Point point = new(0, 0);
        Console.WriteLine(point);
        Point* p = &point;
        p->X = 30;
        (*p).Y = 180;
        Console.WriteLine(point);
    }

    void Test()
    {
        using Person Andrey = new();  // Dispose after full func
        using (Person person = new()) // Multy using
        using (Person bob = new())    // Dispose after block
        {

        }
        Person tom = new();           // Finalize
    }

    struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            X = x; Y = y;
        }
        public override string ToString() => $"X: {X}  Y: {Y}";
    }

    public class Person : IDisposable
    {
        bool disposed = false;

        ~Person()
        {
            Dispose(false);
            Console.WriteLine("Person deleted");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                Console.WriteLine("Dispose Person");
            }
            disposed = true;
        }
    }
}
