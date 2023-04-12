using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Plan
    {
        public int Id { get; set; }
        int StudentId { get; set; }
        int SubjectId { get; set; }
        int Mark { get; set; }
        public Plan(int id, int studentId, int subjectId, int mark)
        {
            Id = id;
            StudentId = studentId;
            SubjectId = subjectId;
            Mark = mark;
        }
        public void Show()
        {
            Console.WriteLine($"Код учебного плана {Id}\n" +
                              $"Код студента {StudentId}\n" +
                              $"Код предмета {SubjectId}\n" +
                              $"Оценка {Mark}\n");
        }
        public string ToString()
        {
            return $"{Id},{StudentId},{SubjectId},{Mark}";
        }
        public static Plan ToClass(string line)
        {
            string[] mas = line.Split(',');
            Plan plan = new Plan(int.Parse(mas[0]), int.Parse(mas[1]), int.Parse(mas[2]), int.Parse(mas[3]));
            return plan;
        }
    }
}
