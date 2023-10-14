namespace CSharpLearnTracker.PatternMatching;

public class PatternMatchingLesson : Lesson
{
    public PatternMatchingLesson(string name) : base(name)
    {
    }

    protected override void StartLesson()
    {
        // Type Pattern
        Employee emp = new Manager();
        Employee? notemp = null;

        UseEmployee(emp);
        UseEmployee(notemp);

        // Constant Pattern
        var hello = "hello";
        if (hello is "hello") Console.WriteLine(hello);

        Console.WriteLine();

        // Properties Pattern
        Person tom = new("english", "user", "Tom");
        Person pierre = new("french", "user", "Pierre");
        Person admin = new("german", "admin", "Admin");

        Console.WriteLine(SayHello(tom));
        Console.WriteLine(SayHello(pierre));
        Console.WriteLine(SayHello(admin));
        Console.WriteLine(SayHello(null));
        Console.WriteLine();

        // Tuple Pattern
        Console.WriteLine(GetWelcome("english", "evening", "user"));
        Console.WriteLine(GetWelcome("german", "morning", "user"));
        Console.WriteLine(GetWelcome("french", "morning", "admin"));
        Console.WriteLine();

        // Positional Pattern
        MessageDetails messageDetails1 = new() { Language = "english", DayTime = "evening", Status = "user" };
        MessageDetails messageDetails2 = new() { Language = "german", DayTime = "morning", Status = "user" };
        MessageDetails messageDetails3 = new() { Language = "french", DayTime = "morning", Status = "admin" };

        Console.WriteLine(GetWelcome(messageDetails1));
        Console.WriteLine(GetWelcome(messageDetails2));
        Console.WriteLine(GetWelcome(messageDetails3));
        Console.WriteLine();


        // Relational and Logic Patterns
        Console.WriteLine(CheckAge(-10));
        Console.WriteLine(CheckAge(10));
        Console.WriteLine(CheckAge(20));
        Console.WriteLine();

        Console.WriteLine(GetNumber(new int[] { 1, 2, 3, 4, 5 }));
        Console.WriteLine(GetNumber(new int[] { 1, 2, 3, -1 }));
        Console.WriteLine(GetNumber(new int[] { 1, 23, 52, 3, 5 }));
        Console.WriteLine(GetNumber(new int[] { }));
        Console.WriteLine(GetNumber(null));

    }

    int GetNumber(int[]? arr) => arr switch
    {
    [1, 2, 3, 4, 5] => 1,
    [1, 2, 3, _] => 2,
    [1, .., 3, _] => 3,
    [..] => 4,
        _ => -1
    };

    string CheckAge(int age) => age switch
    {
        < 1 or > 110 => "Недействительный возраст",
        >= 1 and < 18 => "Доступ запрещён",
        _ => "Доступ разрешён"
    };

    string GetWelcome(string lang, string daytime, string status) => (lang, daytime, status) switch
    {
        ("english", "morning", _) => "Good Morning",
        ("english", "evening", _) => "Good evening",
        ("german", "morning", _) => "Guten Morgen",
        ("german", "evening", _) => "Guten Abend",
        (_, _, "admin") => "Hello Admin",
        _ => "Здрасьть"
    };
    string GetWelcome(MessageDetails details) => details switch
    {
        ("english", "morning", _) => "Good Morning",
        ("english", "evening", _) => "Good evening",
        ("german", "morning", _) => "Guten Morgen",
        ("german", "evening", _) => "Guten Abend",
        (_, _, "admin") => "Hello Admin",
        _ => "Здрасьть"
    };

    string SayHello(Person? person) => person switch
    {
        { Language: "english", Status: "admin" } => "Hallo, admin!",
        { Language: "english" } => "Hello!",
        { Language: "french" } => "Salut!",
        { Language: var lang } => $"Undefined Language: {lang}",
        null => "null"
    };

    class MessageDetails
    {
        public string Language { get; set; } = "";
        public string DayTime { get; set; } = "";
        public string Status { get; set; } = "";
        public void Deconstruct(out string lang, out string daytime, out string status)
        {
            lang = Language;
            daytime = DayTime;
            status = Status;
        }
    }

    record Person(string Language, string Status, string Name);

    class Employee
    {
        public virtual void Work() => Console.WriteLine("Employee works");
    }

    class Manager : Employee
    {
        public override void Work() => Console.WriteLine("Manager works");
        public bool IsOnVacation { get; set; }
    }

    void UseEmployee(Employee? emp)
    {
        switch (emp)
        {
            case Manager manager when !manager.IsOnVacation:
                manager.Work();
                break;
            case null:
                Console.WriteLine("Employee is null");
                break;
            default:
                Console.WriteLine("Employee does not work");
                break;
        }
    }
}
