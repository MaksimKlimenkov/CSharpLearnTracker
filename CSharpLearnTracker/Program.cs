global using CSharpLearnTracker.Abstract;
using CSharpLearnTracker.AdditionalOOP;
using CSharpLearnTracker.Classes;
using CSharpLearnTracker.Collections;
using CSharpLearnTracker.Dates;
using CSharpLearnTracker.DelegateCovariance;
using CSharpLearnTracker.Delegates;
using CSharpLearnTracker.Exceptions;
using CSharpLearnTracker.Generics;
using CSharpLearnTracker.Inheritance;
using CSharpLearnTracker.Interfaces;
using CSharpLearnTracker.LINQ;
using CSharpLearnTracker.Multithreads;
using CSharpLearnTracker.ParallelLINQ;
using CSharpLearnTracker.PatternMatching;
using CSharpLearnTracker.Strings;
using CSharpLearnTracker.Structs;

namespace CSharpLearnTracker;
public static class Program
{
    public static void Main()
    {
        _ = new ClassesLesson("1. Classes and Objects");
        _ = new StructsLesson("2. Structs");
        _ = new InheritanceLesson("3. Inheritance, Casting, Virtual");
        _ = new AbstractClassesLesson("4. Abstract Classes");
        _ = new GenericsLesson("5. Generics");
        _ = new ExceptionsLesson("6. Exceptions");
        _ = new DelegatesLesson("7. Delegates, Events");
        _ = new DelegateCovarianceLesson("8. Delegate Covariance and Countervariance");
        _ = new InterfacesLesson("9. Interfaces");
        _ = new CollectionsLesson("10. Collections");
        _ = new StringsLesson("11. Strings");
        _ = new DatesLesson("12. Dates");
        _ = new AsyncLesson("13. Async");
        Thread.Sleep(2000);
        _ = new AdditionalOOPLesson("14. Additional OOP");
        _ = new LINQLesson("15. LINQ");
        _ = new ParallelLINQLesson("16. Parallel LINQ");
        _ = new MultithreadsLesson("17. Multithreads");
        Thread.Sleep(4000);
        _ = new PatternMatchingLesson("18. Pattern Matching");
    }
}