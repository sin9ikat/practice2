namespace Classes
{
    public class Student
    {
        public int Id { get; set; }
        string FirstName { get; set; }
        string SecondName { get; set; }
        string LastName { get; set; }
        string Adres { get; set; }
        string Phone { get; set; }
        public Student(int id, string firstName, string secondName, string lastName, string adres, string phone)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            Adres = adres;
            Phone = phone;
        }
        public void Show()
        {
            Console.WriteLine($"Код студента {Id}\n" +
                              $"Фамилия {FirstName}\n" +
                              $"Имя {SecondName}\n" +
                              $"Отчество {LastName}\n" +
                              $"Адрес {Adres}\n" +
                              $"Номер телефона {Phone}\n");
        }
        public string ToString()
        {
            return $"{Id},{FirstName},{SecondName},{LastName},{Adres},{Phone}";
        }
        public static Student ToClass(string line)
        {
            string[] mas = line.Split(',');
            Student student = new Student(int.Parse(mas[0]), mas[1], mas[2], mas[3], mas[4], mas[5]);
            return student;
        }
    }
}