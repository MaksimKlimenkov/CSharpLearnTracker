namespace CSharpLearnTracker;

public class MultithreadsLesson : Lesson
{
    int x = 0;
    object locker = new();
    AutoResetEvent waitHandler = new(true);
    Mutex mutex = new();
    public MultithreadsLesson(string name) : base(name)
    {
    }

    protected override void StartLesson()
    {
        for (int i = 0; i < 4; i++)
        {
            Thread thread = new(Print) { Name = $"Thread {i}" };
            thread.Start();
        }

        for (int i = 0; i < 4; i++)
            _ = new Reader(i);
    }

    private void Print()
    {
        // Synchronization by Mutext
        // mutex.WaitOne();

        // Synchronization by AutoResetEvent
        // waitHandler.WaitOne();

        // Synchronization by Monitor
        // var acquiredLock = false;
        // Monitor.Enter(locker, ref acquiredLock);
        // try
        // {

        // Synchronization by lock
        lock (locker)
        {
            x = 1;
            for (int i = 1; i < 3; i++)
            {

                Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                x++;
                Thread.Sleep(5);
            }
        }

        // }
        // finally
        // {
        //     if (acquiredLock) Monitor.Exit(locker);
        // }

        // waitHandler.Set();

        // mutex.ReleaseMutex();
    }
}
