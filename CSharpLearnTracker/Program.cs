global using CSharpLearnTracker.Abstract;
using CSharpLearnTracker.Classes;
using CSharpLearnTracker.DelegateCovariance;
using CSharpLearnTracker.Delegates;
using CSharpLearnTracker.Exceptions;
using CSharpLearnTracker.Generics;
using CSharpLearnTracker.Inheritance;
using CSharpLearnTracker.Structs;

namespace CSharpLearnTracker;
public static class Program
{
    public static void Main()
    {
        ClassesLesson classesLesson = new(1);
        StructsLesson structsLesson = new(2);
        InheritanceLesson inheritanceLesson = new(3);
        AbstractClassesLesson abstractClassesLesson = new(4);
        GenericsLesson genericsLesson = new(5);
        ExceptionsLesson exceptionsLesson = new(6);
        DelegatesLesson delegatesLesson = new(7);
        DelegateCovarianceLesson delegateCovarianceLesson = new(8);
    }
}