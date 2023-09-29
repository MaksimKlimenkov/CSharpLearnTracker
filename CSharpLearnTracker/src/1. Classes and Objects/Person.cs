using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpLearnTracker.Classes;

class Person {
    public string Name { get; init; }
    public string Email { get; init; }
    public DateTime DateOfBirth { get; init; }

    public int Age { 
        get {
            TimeSpan interval = DateTime.Now - DateOfBirth;
            DateTime zero = new(1,1,1);
            return (zero + interval).Year - 1;
        }
    }
    public Person(string name, string email, DateTime dob) {
        Name = name;
        Email = email;
        DateOfBirth = dob;
    } 
    public Person() {}

    public void Deconstruct(out string name, out int age) {
        name = Name;
        age = Age;
    }
}