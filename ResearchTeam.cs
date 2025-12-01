using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class ResearchTeam
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
}
