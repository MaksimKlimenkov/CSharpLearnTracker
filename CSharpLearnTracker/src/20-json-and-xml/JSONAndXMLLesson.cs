using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace CSharpLearnTracker.JSONAndXML;

public class JSONAndXMLLesson : Lesson
{
    Person[] People = { new("Tom", "Amazon", 18), new("Bob", "Spotify", 35) };

    public JSONAndXMLLesson(string name) : base(name)
    {
    }

    protected override void StartLesson()
    {
        JSON();
        Console.WriteLine();

        XmlDocument xDoc = new();
        string path = "static/people.xml";
        CreateXML(xDoc);
        xDoc.Save(path);
        ReadXML(xDoc);

        var serializer = new XmlSerializer(typeof(Person[]));
        StringWriter xml = new();
        serializer.Serialize(xml, People);
        Console.WriteLine(xml);

        StringReader xmlReader = new(xml.ToString());
        if (serializer.Deserialize(xmlReader) is not Person[] people)
        {
            Console.WriteLine("People array is null");
            return;
        }
        foreach (var person in people) Console.WriteLine(person);
    }

    private void JSON()
    {
        Person tom = new("Tom", "Google", 18);
        string json = JsonSerializer.Serialize(tom);
        Console.WriteLine(json);
        Person? restoredPerson = JsonSerializer.Deserialize<Person>(json);
        Console.WriteLine(restoredPerson);
    }

    private void ReadXML(XmlDocument xDoc)
    {
        var root = xDoc.DocumentElement;
        if (root == null)
        {
            Console.WriteLine("Root node not found");
            return;
        }
        foreach (XmlElement child in root.ChildNodes)
        {
            XmlNode? attr = child.Attributes.GetNamedItem("name");
            Console.WriteLine(attr?.Value);

            foreach (XmlElement childnode in child.ChildNodes)
            {
                if (childnode.Name == "company") Console.WriteLine($"Company: {childnode.InnerText}");
                if (childnode.Name == "age") Console.WriteLine($"Age: {childnode.InnerText}");
            }
            Console.WriteLine();
        }
    }

    private void CreateXML(XmlDocument xDoc)
    {
        xDoc.RemoveAll();
        XmlElement peopleElement = xDoc.CreateElement("people");
        foreach (Person person in People)
        {
            XmlElement personElement = xDoc.CreateElement("person");

            XmlAttribute nameAttribute = xDoc.CreateAttribute("name");
            XmlElement companyElement = xDoc.CreateElement("company");
            XmlElement ageElement = xDoc.CreateElement("age");

            XmlText nameText = xDoc.CreateTextNode(person.Name);
            XmlText companyText = xDoc.CreateTextNode(person.Company);
            XmlText ageText = xDoc.CreateTextNode(person.Age.ToString());

            nameAttribute.AppendChild(nameText);
            companyElement.AppendChild(companyText);
            ageElement.AppendChild(ageText);

            personElement.Attributes.Append(nameAttribute);
            personElement.AppendChild(companyElement);
            personElement.AppendChild(ageElement);

            peopleElement.AppendChild(personElement);
        }
        xDoc.AppendChild(peopleElement);
    }

    public class Person
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public int Age { get; set; }

        public Person() { }

        public Person(string name, string company, int age)
        {
            Name = name;
            Company = company;
            Age = age;
        }

        public override string ToString() => $"Name: {Name}, Company: {Company}, Age: {Age}";
    }
}
