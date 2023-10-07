namespace CSharpLearnTracker.AdditionalOOP;

class Person
{
    public string Name { get; }
    public Person(string name) => Name = name;
}
class Company
{
    Person[] personal;
    public Company(Person[] people) => personal = people;

    public Person this[int index]
    {
        get => personal[index];
        set => personal[index] = value;
    }
}