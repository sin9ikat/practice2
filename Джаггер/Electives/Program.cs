using Classes;

Menu();
static void Menu()
{
    Console.Clear();
    Console.WriteLine("--------------------------------------------------------------------------------\n" +
                      "|  Студенты(1)  |  Предметы(2)  |  Учебные планы(3)  |  Выход из программы(4)  |\n" +
                      "--------------------------------------------------------------------------------");
    Console.Write("Введите код операции: ");
    char Code = Console.ReadKey(true).KeyChar;
    switch (Code)
    {
        case '1':
            StudentMenu();
            break;
        case '2':
            SubjectMenu();
            break;
        case '3':
            PlanMenu();
            break;
        case '4':
            Environment.Exit(0);
            break;

    }
}

static void StudentMenu()
{
    ICollection<Student> _Students = new List<Student>();
    int Student_id = -1;

    using (StreamReader reader = new StreamReader("Students.txt"))
    {
        while (!reader.EndOfStream)
        {
            _Students.Add(Student.ToClass(reader.ReadLine()));
        }
    }
    if (_Students.Count > 0) { Student_id = _Students.Last().Id; }
    Console.Clear();
    Console.WriteLine("-------------------------------------------------------------------------------------------------------\n" +
                      "|  Показать студентов(1)  |  Добавить студента(2)  |  Удалить студента(3)  |  Выход в главное меню(4)  |\n" +
                      "-------------------------------------------------------------------------------------------------------");
    Console.Write("Введите код операции: ");
    char Code = Console.ReadKey(true).KeyChar;
    switch (Code)
    {
        case '1':
            ShowStudents(_Students);
            break;
        case '2':
            AddStudent(_Students, Student_id);
            break;
        case '3':
            DeleteStudent(_Students);
            break;
        case '4':
            Menu();
            break;

    }
}

static void ShowStudents(ICollection<Student> _Students)
{
    Console.Clear();
    if (_Students.Count == 0)
    {
        Console.WriteLine("Студентов нет");
    }
    else
    {
        foreach (Student Student in _Students)
        {
            Student.Show();
        }
    }
    Console.ReadKey();
    StudentMenu();
}

static void AddStudent(ICollection<Student> _Students, int Student_id)
{
    Console.Clear();
    Console.WriteLine("Введите фамилию");
    string FirstName = Console.ReadLine();
    Console.WriteLine("Введите имя");
    string SecondName = Console.ReadLine();
    Console.WriteLine("Введите отчество");
    string LastName = Console.ReadLine();
    Console.WriteLine("Введите адрес");
    string Adres = Console.ReadLine();
    Console.WriteLine("Введите номер телефона");
    string Phone = Console.ReadLine();
    Student_id++;
    Student Student = new Student(Student_id, FirstName,SecondName,LastName,Adres,Phone);
    _Students.Add(Student);
    using (StreamWriter writer = new StreamWriter("Students.txt", false))
    {
        foreach (Student _Student in _Students)
        {
            writer.WriteLine(_Student.ToString());
        }
    }
    StudentMenu();
}

static void DeleteStudent(ICollection<Student> _Students)
{
    Console.Clear();
    Console.WriteLine("Введите код студента");
    int id = int.Parse(Console.ReadLine());
    var temp = _Students.Where(d => d.Id == id).First();
    if (temp is not null)
    {
        _Students.Remove(temp);
        using (StreamWriter writer = new StreamWriter("Students.txt", false))
        {
            foreach (Student _Student in _Students)
            {
                writer.WriteLine(_Student.ToString());
            }
        }
    }
    else
    {
        Console.WriteLine("Студента с таким кодом не существует");
        Console.ReadKey();
    }
    StudentMenu();
}

static void SubjectMenu()
{
    ICollection<Subject> _Subjects = new List<Subject>();
    int Subjects_id = -1;

    using (StreamReader reader = new StreamReader("Subjects.txt"))
    {
        while (!reader.EndOfStream)
        {
            _Subjects.Add(Subject.ToClass(reader.ReadLine()));
        }
    }
    if (_Subjects.Count > 0)
    {
        Subjects_id = _Subjects.Last().Id;
    }
    Console.Clear();
    Console.WriteLine("-----------------------------------------------------------------------------------------------------\n" +
                      "|  Показать предметы(1)  |  Добавить предмет(2)  |  Удалить предмет(3)  |  Выход в главное меню(4)  |\n" +
                      "-----------------------------------------------------------------------------------------------------");
    Console.Write("Введите код операции: ");
    char Code = Console.ReadKey(true).KeyChar;
    switch (Code)
    {
        case '1':
            ShowSubjects(_Subjects);
            break;
        case '2':
            AddSubject(_Subjects, Subjects_id);
            break;
        case '3':
            DeleteSubject(_Subjects);
            break;
        case '4':
            Menu();
            break;

    }
}

static void ShowSubjects(ICollection<Subject> Subjects)
{
    Console.Clear();
    if (Subjects.Count == 0)
    {
        Console.WriteLine("Учебных предметов нет");
    }
    else
    {
        foreach (Subject Subject in Subjects)
        {
            Subject.Show();
        }
    }
    Console.ReadKey();
    SubjectMenu();
}

static void AddSubject(ICollection<Subject> Subjects, int Subject_id)
{
    Console.WriteLine("Введите название предмета");
    string Name = Console.ReadLine();
    Console.WriteLine("Введите объём лекций");
    string Lections = Console.ReadLine();
    Console.WriteLine("Введите объём практик");
    string Practice = Console.ReadLine();
    Console.WriteLine("Введите объём лабораторных работ");
    string Labs = Console.ReadLine();
    Subject_id++;
    Subject Subject = new Subject(Subject_id, Name, Lections, Practice, Labs);
    Subjects.Add(Subject);
    using (StreamWriter writer = new StreamWriter("Subjects.txt", false))
    {
        foreach (Subject _Subject in Subjects)
        {
            writer.WriteLine(_Subject.ToString());
        }
    }
    SubjectMenu();
}

static void DeleteSubject(ICollection<Subject> Subjects)
{
    Console.Clear();
    Console.WriteLine("Введите код предмета");
    int id = int.Parse(Console.ReadLine());
    var temp = Subjects.Where(d => d.Id == id).First();
    if (temp is not null)
    {
        Subjects.Remove(temp);
        using (StreamWriter writer = new StreamWriter("Subjects.txt", false))
        {
            foreach (Subject _Subject in Subjects)
            {
                writer.WriteLine(_Subject.ToString());
            }
        }
    }
    else
    {
        Console.WriteLine("Предмета с таким кодом не существует");
        Console.ReadKey();
    }
    SubjectMenu();
}

static void PlanMenu()
{
    ICollection<Plan> _Plans = new List<Plan>();
    int Plan_id = -1;

    using (StreamReader reader = new StreamReader("Plans.txt"))
    {
        while (!reader.EndOfStream)
        {
            _Plans.Add(Plan.ToClass(reader.ReadLine()));
        }
    }
    if (_Plans.Count > 0) { Plan_id = _Plans.Last().Id; }
    Console.Clear();
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------\n" +
                      "|  Показать учебные предметы(1)  |  Добавить учебный предмет(2)  |  Удалить учебный предмет(3)  |  Выход в главное меню(4)  |\n" +
                      "-----------------------------------------------------------------------------------------------------------------------------");
    Console.Write("Введите код операции: ");
    char Code = Console.ReadKey(true).KeyChar;
    switch (Code)
    {
        case '1':
            PlansShow(_Plans);
            break;
        case '2':
            PlanAdd(_Plans, Plan_id);
            break;
        case '3':
            PlanDelete(_Plans);
            break;
        case '4':
            Menu();
            break;

    }
}

static void PlansShow(ICollection<Plan> Plans)
{
    Console.Clear();
    if (Plans.Count == 0)
    {
        Console.WriteLine("Учебных планов нет");
    }
    else
    {
        foreach (Plan Plan in Plans)
        {
            Plan.Show();
        }
    }
    Console.ReadKey();
    PlanMenu();
}
static void PlanAdd(ICollection<Plan> Plans, int Plan_id)
{
    ICollection<Subject> _Subjects = new List<Subject>();

    using (StreamReader reader = new StreamReader("Subjects.txt"))
    {
        while (!reader.EndOfStream)
        {
            _Subjects.Add(Subject.ToClass(reader.ReadLine()));
        }
    }

    ICollection<Student> _Students = new List<Student>();

    using (StreamReader reader = new StreamReader("Students.txt"))
    {
        while (!reader.EndOfStream)
        {
            _Students.Add(Student.ToClass(reader.ReadLine()));
        }
    }
    Console.Clear();
    if (_Subjects.Count == 0)
    {
        Console.WriteLine("Предметов нет");
        Console.ReadKey();
        PlanMenu();
    }
    else
    {
        foreach (Subject Subject in _Subjects)
        {
            Subject.Show();
            Console.WriteLine("Введите код предмета");
        }
        int s_code = int.Parse(Console.ReadLine());
        int s_temp = _Subjects.Where(d => d.Id == s_code).First().Id;
        if (s_temp != null)
        {
            Console.Clear();
            if (_Students.Count == 0)
            {
                Console.WriteLine("Студентов нет");
                Console.ReadKey();
                PlanMenu();
            }
            else
            {
                foreach (Student Student in _Students)
                {
                    Student.Show();
                }
                int st_code = int.Parse(Console.ReadLine());
                int st_temp = _Students.Where(d => d.Id == st_code).First().Id;
                if (st_temp != null)
                {
                    Console.Clear();
                    Console.WriteLine("Введите оценку");
                    int Mark = int.Parse(Console.ReadLine());
                    Plan_id++;
                    Plan Plan = new Plan(Plan_id, st_temp, s_temp, Mark);
                    Plans.Add(Plan);
                    using (StreamWriter writer = new StreamWriter("Plans.txt", false))
                    {
                        foreach (Plan _Plan in Plans)
                        {
                            writer.WriteLine(_Plan.ToString());
                        }
                    }
                }
            }
        }
    }
    PlanMenu();
}
static void PlanDelete(ICollection<Plan> Plans)
{
    Console.Clear();
    Console.WriteLine("Введите код учебного предмета");
    int id = int.Parse(Console.ReadLine());
    var temp = Plans.Where(d => d.Id == id).First();
    if (temp != null)
    {
        Plans.Remove(temp);
        using (StreamWriter writer = new StreamWriter("Plans.txt", false))
        {
            foreach (Plan Plan in Plans)
            {
                writer.WriteLine(Plan.ToString());
            }
        }
    }
    PlanMenu();
}