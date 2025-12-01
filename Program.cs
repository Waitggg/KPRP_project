using System;
using System.Linq;

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

    public enum TimeFrame { Year, TwoYears, Long }

    class Paper
    {
        public string Title { get; set; }
        public Person Auth { get; set; }
        public DateTime Date { get; set; }

        public Paper()
        {
            this.Title = "Good";
            this.Auth = new Person();
            this.Date = new DateTime(1990, 3, 25);
        }

        public Paper(string Title, Person Auth, DateTime Date)
        {
            this.Title = Title;
            this.Auth = Auth;
            this.Date = Date;
        }

        public override string ToString()
        {
            return $"Title {this.Title}, Person {this.Auth}, DateTime {Date}";
        }
    }

    class ResearchTeam
    {
        public string title { get; set; }
        public string name { get; set; }
        public int RegNumber { get; set; }
        public TimeFrame Info { get; set; }
        private Paper[] mas;
        public Paper[] Mas
        {
            get => mas;
            set => mas = value;
        }

        public ResearchTeam()
        {
            this.title = null;
            this.name = null;
            this.RegNumber = 0;
            this.mas = new Paper[0];
        }

        public ResearchTeam(string title, string name, int RegNumber, TimeFrame Info)
        {
            this.title = title;
            this.name = name;
            this.RegNumber = RegNumber;
            this.Info = Info;
            this.mas = new Paper[0];
        }

        public Paper LatestPaper
        {
            get
            {
                if (mas == null || mas.Length == 0) { return null; }
                DateTime maxPublicationDate = mas.Max(p => p.Date);
                foreach (Paper i in mas)
                {
                    if (i.Date == maxPublicationDate)
                    {
                        return i;
                    }
                }
                return null;
            }
        }

        public bool this[TimeFrame tf]
        { get => tf == Info ? true : false; }

        public void AddPapers(params Paper[] newPapers)
        {
            if (newPapers == null) return;

            foreach (Paper i in newPapers)
            {
                Array.Resize(ref mas, mas.Length + 1);
                mas[mas.Length - 1] = i;
            }
        }

        public override string ToString()
        {
            string jj = $"title {title}, name {name}, RegNumber {RegNumber}, Info {Info}";
            if (mas != null)
            {
                foreach (Paper i in mas)
                {
                    jj += i.ToString();
                }
            }
            return jj;
        }

        public string ToShortString()
        {
            return $"title {title}, name {name}, RegNumber {RegNumber}, Info {Info}";
        }
    }
