namespace AcademicManagement;

public class Student
{
    private string _lastName = string.Empty;
    private string _firstName = string.Empty;
    private string _middleName = string.Empty;
    private DateTime _birthDate;
    private string _address = string.Empty;
    private string _phoneNumber = string.Empty;

    private List<int> _creditGrades = [];
    private List<int> _courseworkGrades = [];
    private List<int> _examGrades = [];
    
    public string LastName
    {
        get => _lastName;
        set => _lastName = !string.IsNullOrWhiteSpace(value) ? value : "Undefined";
    }

    public string FirstName
    {
        get => _firstName;
        set => _firstName = !string.IsNullOrWhiteSpace(value) ? value : "Undefined";
    }

    public string MiddleName
    {
        get => _middleName;
        set => _middleName = !string.IsNullOrWhiteSpace(value) ? value : "Undefined";
    }

    public DateTime BirthDate
    {
        get => _birthDate;
        set => _birthDate = value;
    }

    public string Address
    {
        get => _address;
        set => _address = !string.IsNullOrWhiteSpace(value) ? value : "Unknown";
    }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set => _phoneNumber = !string.IsNullOrWhiteSpace(value) ? value : "Unknown";
    }

    public List<int> CreditGrades
    {
        get => new(_creditGrades);
        set => _creditGrades = value;
    }

    public List<int> CourseworkGrades
    {
        get => new(_courseworkGrades);
        set => _courseworkGrades = value;
    }

    public List<int> ExamGrades
    {
        get => new(_examGrades);
        set => _examGrades = value;
    }
    
    public Student() 
        : this("Невідомо", "Невідомо", "Невідомо", DateTime.MinValue, "Невідомо", "Невідомо")
    {
    }
    public Student(string lastName, string firstName, string middleName, DateTime birthDate)
        : this(lastName, firstName, middleName, birthDate, "Не вказано", "Не вказано")
    {
    }
    
    public Student(string lastName, string firstName, string middleName, 
                   DateTime birthDate, string address, string phoneNumber)
    {
        LastName = lastName;
        FirstName = firstName;
        MiddleName = middleName;
        BirthDate = birthDate;
        Address = address;
        PhoneNumber = phoneNumber;
    }
    public Student(Student other)
    {
        ArgumentNullException.ThrowIfNull(other);

        _lastName = other._lastName;
        _firstName = other._firstName;
        _middleName = other._middleName;
        _birthDate = other._birthDate;
        _address = other._address;
        _phoneNumber = other._phoneNumber;

        _creditGrades = new List<int>(other._creditGrades);
        _courseworkGrades = new List<int>(other._courseworkGrades);
        _examGrades = new List<int>(other._examGrades);
    }
    public void AddCreditGrade(int grade) => _creditGrades.Add(grade);
    public void AddCourseworkGrade(int grade) => _courseworkGrades.Add(grade);
    public void AddExamGrade(int grade) => _examGrades.Add(grade);
    public double GetAverageGrade()
    {
        var allGrades = _creditGrades.Concat(_courseworkGrades).Concat(_examGrades).ToList();
        return allGrades.Count > 0 ? allGrades.Average() : 0.0;
    }
    public bool HasPassedSession()
    {
        var allGrades = _creditGrades.Concat(_courseworkGrades).Concat(_examGrades).ToList();
        return allGrades.Count == 0 || allGrades.All(grade => grade >= 60);
    }
    
    public void ShowInfo()
    {
        Console.WriteLine($"ПІБ: {LastName} {FirstName} {MiddleName}");
        Console.WriteLine($"Дата народження: {BirthDate:dd.MM.yyyy}");
        Console.WriteLine($"Адреса: {Address}");
        Console.WriteLine($"Телефон: {PhoneNumber}");
        Console.WriteLine($"Заліки: {string.Join(", ", _creditGrades)}");
        Console.WriteLine($"Курсові: {string.Join(", ", _courseworkGrades)}");
        Console.WriteLine($"Іспити: {string.Join(", ", _examGrades)}");
        Console.WriteLine($"Середній бал: {GetAverageGrade():F2}");
        Console.WriteLine(new string('-', 40));
    }
}