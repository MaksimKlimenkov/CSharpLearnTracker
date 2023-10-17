using System.Data.Common;
using System.Reflection;

namespace CSharpLearnTracker.Reflection;

public class ReflectionLesson : Lesson
{
    public ReflectionLesson(string name) : base(name)
    {
    }

    public Dictionary<MemberTypes, int> MemberPriority = new()
    {
        { MemberTypes.Property, 1 },
        { MemberTypes.Field, 2 },
        { MemberTypes.Constructor, 3},
        { MemberTypes.Method, 4 },
        { MemberTypes.Event, 5 },
        { MemberTypes.TypeInfo, 6 },
        { MemberTypes.Custom, 7 },
        { MemberTypes.NestedType, 8 },
        { MemberTypes.All, 9 }

    };

    protected override void StartLesson()
    {
        PrintClass(typeof(Person));
    }

    public class Person
    {
        public string Name { get; private set; }
        public string Company { private get; set; }
        public int Age = 10;
        private static string _secret = "15";


        public Person(string name) => Name = name;
        public Person(string name, string company) => Company = company;
    }

    private void PrintClass(Type type)
    {
        Console.WriteLine($"{GetModificator(type)}{type.Name}\n{{");
        MemberInfo[] members = type.GetMembers(
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static
        )
            .OrderBy(member => member.MemberType, Comparer<MemberTypes>.Create((a, b) => MemberPriority[a] - MemberPriority[b]))
            .ToArray();

        foreach (var member in members)
        {
            if (
                member.Name.Contains("BackingField") ||
                member.Name.Contains("MemberwiseClone") ||
                member.Name.Contains("get_") ||
                member.Name.Contains("set_")
            )
                continue;

            var modificator = GetModificator(member);
            var name = "";
            if (member is PropertyInfo property)
            {
                name = $"{property.PropertyType.Name} {property.Name} ";
                var methods = "{ ";

                if (property.CanRead)
                {
                    var getMethod = type.GetMethod($"get_{property.Name}", BindingFlags.Instance | BindingFlags.NonPublic);
                    if (getMethod != null && getMethod.IsPrivate) methods += "private get; ";
                    else methods += "get; ";
                }
                if (property.CanWrite)
                {
                    var setMethod = type.GetMethod($"set_{property.Name}", BindingFlags.Instance | BindingFlags.NonPublic);
                    if (setMethod != null && setMethod.IsPrivate) methods += "private set; ";
                    else methods += "set; ";
                }
                methods += "} ";
                name += methods;
            }
            if (member is FieldInfo field)
                name = $"{field.FieldType.Name} {field.Name}";

            if (member is MethodInfo method)
            {
                name = $"{method.ReturnType.Name} {method.Name}(";
                ParameterInfo[] parameters = method.GetParameters();
                foreach (var param in parameters)
                {
                    name += $"{param.ParameterType.Name} {param.Name}, ";
                }
                if (name[^1] == ' ')
                    name = name[..^2];
                name += ") {}";
            }

            if (member is ConstructorInfo ctor)
            {
                name = $"{type.Name}(";
                ParameterInfo[] parameters = ctor.GetParameters();
                foreach (var param in parameters)
                {
                    name += $"{param.ParameterType.Name} {param.Name}, ";
                }
                if (name[^1] == ' ')
                    name = name[..^2];
                name += ") {}";
            }

            Console.WriteLine($"\t{modificator}{name}");
        }
        Console.WriteLine("}");
    }

    private string GetModificator(MemberInfo member)
    {
        string modificator = "";

        bool IsPublic = true,
            IsPrivate = false,
            IsAssembly = false,
            IsFamily = false,
            IsFamilyAndAssembly = false,
            IsFamilyOrAssembly = false,
            IsStatic = false,
            IsVirtual = false,
            IsAbstract = false,
            IsFinal = false,
            IsClass = false,
            IsEnum = false,
            IsInterface = false,
            IsSealed = false;



        if (member is FieldInfo field)
            (IsPublic, IsPrivate, IsAssembly, IsFamily, IsFamilyAndAssembly, IsFamilyOrAssembly, IsStatic) =
            (field.IsPublic, field.IsPrivate, field.IsAssembly, field.IsFamily, field.IsFamilyAndAssembly, field.IsFamilyOrAssembly, field.IsStatic);
        else if (member is MethodInfo method)
            (IsPublic, IsPrivate, IsAssembly, IsFamily, IsFamilyAndAssembly, IsFamilyOrAssembly, IsStatic, IsVirtual, IsAbstract, IsFinal) =
            (method.IsPublic, method.IsPrivate, method.IsAssembly, method.IsFamily, method.IsFamilyAndAssembly, method.IsFamilyOrAssembly, method.IsStatic, method.IsVirtual, method.IsAbstract, method.IsFinal);
        else if (member is TypeInfo type)
            (IsPublic, IsAbstract, IsClass, IsEnum, IsInterface, IsSealed) =
                (type.IsPublic, type.IsAbstract, type.IsClass, type.IsEnum, type.IsInterface, type.IsSealed);

        // получаем модификатор доступа
        if (IsPublic)
            modificator += "public ";
        else if (IsPrivate)
            modificator += "private ";
        else if (IsStatic)
            modificator += "static ";
        else if (IsVirtual)
            modificator += "virtual ";
        else if (IsAbstract)
            modificator += "abstract ";
        else if (IsFinal)
            modificator += "final ";
        else if (IsClass)
            modificator += "class ";
        else if (IsEnum)
            modificator += "enum ";
        else if (IsInterface)
            modificator += "interface ";
        else if (IsSealed)
            modificator += "sealed ";
        else if (IsAssembly)
            modificator += "internal ";
        else if (IsFamily)
            modificator += "protected ";
        else if (IsFamilyAndAssembly)
            modificator += "private protected ";
        else if (IsFamilyOrAssembly)
            modificator += "protected internal ";

        return modificator;
    }
}
