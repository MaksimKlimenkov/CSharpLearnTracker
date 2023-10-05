using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Collections;
using CSharpLearnTracker.Interfaces;

namespace CSharpLearnTracker.Collections;

public class CollectionsLesson : Lesson
{
    public CollectionsLesson(string name) : base(name)
    {
    }

    protected override void StartLesson()
    {
        ListMethod();
        LinkedListMethod();
        QueueMethod();
        StackMethod();
        DictionaryMethod();
        ObservableCollectionMethod();
        IEnumerableMethod();
        YieldMethod();
    }

    void ListMethod()
    {
        Console.WriteLine("List:");
        List<int> list = new() { 3, 8, 1, 5 };
        list.Sort();
        list.Add(11);
        List<int> list2 = new List<int>(list);
        list2.RemoveAt(2);
        list.Reverse();
        Console.Write("[");
        foreach (var el in list) Console.Write($"{el}, ");
        Console.Write("]\n");
        Console.WriteLine($"Element 8 at index - {list2.BinarySearch(8)} by binary search");
        Console.WriteLine();

    }

    void LinkedListMethod()
    {
        Console.WriteLine("Linked List:");
        LinkedList<string> employees = new();
        var node = employees.AddFirst("Tom");
        node = employees.AddAfter(node, "Sam");
        employees.AddAfter(node, "Bob");
        Console.WriteLine(employees.Count);
        Console.WriteLine(employees.First?.Value);
        Console.WriteLine(employees.Last?.Value);
        Console.WriteLine();
    }

    void QueueMethod()
    {
        Console.WriteLine("Queue:");
        Queue<string> employees = new();
        employees.Enqueue("Tom");
        employees.Enqueue("Bob");
        employees.Enqueue("Sam");
        foreach (var employee in employees) Console.WriteLine(employee);
        Console.WriteLine();
    }

    void StackMethod()
    {
        Console.WriteLine("Stack:");
        Stack<string> employees = new();
        employees.Push("Tom");
        employees.Push("Bob");
        employees.Push("Sam");
        foreach (var employee in employees) Console.WriteLine(employee);
        Console.WriteLine();
    }

    void DictionaryMethod()
    {
        Console.WriteLine("Dictionary:");
        Dictionary<char, int> charsCount = new();
        string dict = "aabbccccdefffsss";
        foreach (var c in dict) charsCount[c] = charsCount.GetValueOrDefault(c, 0) + 1;
        foreach (var count in charsCount) Console.WriteLine($"{count.Key}: {count.Value}");
        Console.WriteLine();
    }

    void ObservableCollectionMethod()
    {
        Console.WriteLine("ObservableCollection:");
        ObservableCollection<string> employees = new();
        employees.CollectionChanged += (sender, ev) =>
        {
            if (ev.Action == NotifyCollectionChangedAction.Add)
                Console.WriteLine($"New items: {ev.NewItems?[0]}");
            else if (ev.Action == NotifyCollectionChangedAction.Remove)
                Console.WriteLine($"Deleted items: {ev.OldItems?[0]}");

        };
        employees.Add("Tom");
        employees.Add("Sam");
        employees.Add("Bob");
        employees.Remove("Sam");
        Console.WriteLine();
    }

    void IEnumerableMethod()
    {
        Console.WriteLine("IEnumerable Week:");
        Week week = new();
        foreach (var day in week)
        {
            Console.Write($"{day} ");
        }
        Console.WriteLine("\n");
    }

    void YieldMethod()
    {
        Console.WriteLine("Yield Factorial:");
        Factorial factorial = new();
        foreach (var num in factorial) Console.Write($"{num} ");
        Console.WriteLine("\n");
    }


    class Week : IEnumerable
    {
        string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday",
                         "Friday", "Saturday", "Sunday" };
        public IEnumerator GetEnumerator() => days.GetEnumerator();
    }

    class Factorial : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int x = 0;
            int last = 1;
            while (true)
            {
                x++;
                last = last * x;
                if (x == 10) yield break;
                yield return last;
            }
        }
    }
}
