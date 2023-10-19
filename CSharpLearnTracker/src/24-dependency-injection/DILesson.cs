using Microsoft.Extensions.DependencyInjection;

namespace CSharpLearnTracker.DI;

public class DILesson : Lesson
{
    public DILesson(string name) : base(name)
    {

    }

    interface IServiceLogger
    {
        void Write(string message);
    }

    class SimpleLoggerService : IServiceLogger
    {
        int Counter = 0;
        public void Write(string message) => Console.WriteLine($"[{++Counter}] [{DateTime.Now}] {message}");
    }

    class GreenLoggerService : IServiceLogger
    {
        int Counter = 0;
        public void Write(string message)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write($"[{++Counter}] [{DateTime.Now}] {message}");
            Console.ResetColor();
            Console.Write('\n');
        }
    }

    class Logger
    {
        private IServiceLogger? LoggerService;
        public Logger(IServiceLogger? loggerService) => LoggerService = loggerService;
        public void Log(string message) => LoggerService?.Write(message);

    }

    protected override void StartLesson()
    {
        IServiceCollection Services = new ServiceCollection();
        Services = Services.AddTransient<IServiceLogger, SimpleLoggerService>();
        Services.AddSingleton<IServiceLogger, GreenLoggerService>();
        using var ServiceProvider = Services.BuildServiceProvider();


        for (int i = 0; i < 3; i++)
        {
            var services = ServiceProvider.GetServices<IServiceLogger>();
            foreach (var service in services)
            {
                Logger logger = new(service);
                logger.Log($"Test Message");
            }
        }
    }
}
