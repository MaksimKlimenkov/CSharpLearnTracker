using System.ComponentModel.DataAnnotations;

namespace CSharpLearnTracker.ModelValidation;

public class ValidationLesson : Lesson
{
    public ValidationLesson(string name) : base(name)
    {
    }

    protected override void StartLesson()
    {
        User.CreateUser("", -4);
        Console.WriteLine();
        User.CreateUser("sndjfnsdjkfndsnfkj", 15);
        Console.WriteLine();
        User.CreateUser("Bob", 37);
    }

    public class User
    {
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string Name { get; set; }
        [Range(1, 110)]
        public int Age { get; set; }

        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public static User? CreateUser(string name, int age)
        {
            User user = new(name, age);
            var context = new ValidationContext(user);
            var result = new List<ValidationResult>();
            if (!Validator.TryValidateObject(user, context, result, true))
            {
                Console.WriteLine("Can't create User object");
                foreach (var error in result)
                    Console.WriteLine(error.ErrorMessage);
                return null;
            }
            Console.WriteLine("Create User object");
            return user;
        }
    }
}
