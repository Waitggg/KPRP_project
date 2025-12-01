using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Person
    {
        string name;
        string surname;
        DateTime dateOfBirth;

        public Person()
        {
            this.name = "Bob";
            this.surname = "Bobov";
            this.dateOfBirth = DateTime.Now;
        }

        public Person(string name, string surname, DateTime dateOfBirth)
        {
            this.name = name;
            this.surname = surname;
            this.dateOfBirth = dateOfBirth;
        }

        public string Name { get => name; set => name = value == null ? "Bob" : value; }
        public string Surname { get => surname; set => surname = value == null ? "Bobov" : value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }

        public int YearOfBirth
        {
            get => dateOfBirth.Year;
            set => dateOfBirth = new DateTime(value, dateOfBirth.Month, dateOfBirth.Day);
        }

        public override string ToString()
        {
            return $"Имя: {name} , Фамилия: {surname}\nДата рождения: {dateOfBirth}";
        }

        public virtual string ToShortString()
        {
            return $"Имя: {name} , Фамилия: {surname}";
        }
    }
}
