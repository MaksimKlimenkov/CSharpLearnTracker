global using CSharpLearnTracker.Abstract;
using CSharpLearnTracker.Classes;
using CSharpLearnTracker.Collections;
using CSharpLearnTracker.Dates;
using CSharpLearnTracker.DelegateCovariance;
using CSharpLearnTracker.Delegates;
using CSharpLearnTracker.Exceptions;
using CSharpLearnTracker.Generics;
using CSharpLearnTracker.Inheritance;
using CSharpLearnTracker.Interfaces;
using CSharpLearnTracker.Strings;
using CSharpLearnTracker.Structs;

namespace CSharpLearnTracker;
public static class Program
{
    public static void Main()
    {
        ClassesLesson classesLesson = new("1. Classes and Objects");
        StructsLesson structsLesson = new("2. Structs");
        InheritanceLesson inheritanceLesson = new("3. Inheritance, Casting, Virtual");
        AbstractClassesLesson abstractClassesLesson = new("4. Abstract Classes");
        GenericsLesson genericsLesson = new("5. Generics");
        ExceptionsLesson exceptionsLesson = new("6. Exceptions");
        DelegatesLesson delegatesLesson = new("7. Delegates, Events");
        DelegateCovarianceLesson delegateCovarianceLesson = new("8. Delegate Covariance and Countervariance");
        InterfacesLesson interfacesLesson = new("9. Interfaces");
        CollectionsLesson collectionsLesson = new("10. Collections");
        StringsLesson stringsLesson = new("11. Strings");
        DatesLesson datesLesson = new("12. Dates");
        AsyncLesson asyncLesson = new("13. Async");
        Thread.Sleep(1000);
    }
}