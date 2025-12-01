using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public enum TimeFrame { Year, TwoYears, Long }
    public class Paper
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
}
