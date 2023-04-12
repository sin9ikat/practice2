using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Subject
    {
        public int Id { get; set; }
        string Name { get; set; }
        string Lections { get; set; }
        string Practice { get; set; }
        string Labs { get; set; }
        public Subject(int id, string name, string lections, string practice, string labs)
        {
            Id = id;
            Name = name;
            Lections = lections;
            Practice = practice;
            Labs = labs;
        }
        public void Show()
        {
            Console.WriteLine($"Код предмета {Id}\n" +
                              $"Название {Name}\n" +
                              $"Объем лекций {Lections}\n" +
                              $"Объем практик {Practice}\n" +
                              $"Объем лабораторных работ {Labs}\n");
        }
        public string ToString()
        {
            return $"{Id},{Name},{Lections},{Practice},{Labs}";
        }
        public static Subject ToClass(string line)
        {
            string[] mas = line.Split(',');
            Subject subject = new Subject(int.Parse(mas[0]), mas[1], mas[2], mas[3], mas[4]);
            return subject;
        }
    }
}
