namespace CSharpLearnTracker;

public class Reader
{
    static Semaphore sem = new(3, 3);
    Thread currentThread;
    int count = 3;

    public Reader(int i)
    {
        currentThread = new(Read) { Name = $"Поток {i}" };
        currentThread.Start();
    }

    public void Read()
    {
        while (count > 0)
        {
            sem.WaitOne();

            Console.WriteLine($"{currentThread.Name} come in library");

            Thread.Sleep(500);

            Console.WriteLine($"{currentThread.Name} come out");

            sem.Release();

            count--;
            Thread.Sleep(500);
        }
    }
}
