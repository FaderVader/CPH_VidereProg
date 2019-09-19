using System;

namespace tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Jakob", "Hansen");
            Student student = new Student("Per", "Ibsen", 12);
            Person teacher = new Teacher("Kim", "Møller", 100.0M); // notice Teacher-object -> Person-object !


            person.GetFullName();
            student.GetFullName();
            teacher.GetFullName(); // uses Teacher-member because override
            Console.ReadKey();
        }
    }


    public class Person
    {
        protected string fornavn; // use protected to allow derived classes to access fields
        protected string efternavn;

        public Person(string fornavn, string efternavn)
        {
            this.fornavn = fornavn;
            this.efternavn = efternavn;
        }

        public virtual string GetFullName()
        {
            Console.WriteLine($"{fornavn} {efternavn}");
            return $"{fornavn} {efternavn}";
        }
    }
    public class Teacher : Person
    {
        private decimal salary;

        public Teacher(string fornavn, string efternavn, decimal salary) : base(fornavn, efternavn)
        {
            this.salary = salary;
        }

        public override string GetFullName() // use override to allow Person-castet Teacher to access own method
        {
            Console.WriteLine($"Lærer {efternavn}");
            return $"Lærer {efternavn}";
        }
    }
    public class Student : Person
    {
        private int grade;

        public Student(string fornavn, string efternavn, int grade) : base(fornavn, efternavn)
        {
            this.grade = grade;
        }
    }
}
