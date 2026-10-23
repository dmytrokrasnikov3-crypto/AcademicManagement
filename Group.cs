namespace AcademicManagement;

public class Group
{
    private readonly List<Student> _students;
    private string _groupName = "Нова група";
    private string _specialization = "Не визначено";
    private int _courseNumber = 1;

    public string GroupName
    {
        get => _groupName;
        set => _groupName = !string.IsNullOrWhiteSpace(value) ? value : "NoGroup";
    }

    public string Specialization
    {
        get => _specialization;
        set => _specialization = !string.IsNullOrWhiteSpace(value) ? value : "General";
    }

    public int CourseNumber
    {
        get => _courseNumber;
        set => _courseNumber = value is >= 1 and <= 6 ? value : 1;
    }

    public IReadOnlyList<Student> Students => _students.AsReadOnly();
    public Group()
    {
        _students = [];
    }
    public Group(IEnumerable<Student>? students, string groupName = "Група", string specialization = "Загальна", int courseNumber = 1)
    {
        GroupName = groupName;
        Specialization = specialization;
        CourseNumber = courseNumber;
        _students = students != null 
            ? students.Select(s => new Student(s)).ToList() 
            : [];
    }
    
    public Group(Group other)
    {
        ArgumentNullException.ThrowIfNull(other);

        _groupName = other._groupName;
        _specialization = other._specialization;
        _courseNumber = other._courseNumber;
        _students = other._students.Select(s => new Student(s)).ToList();
    }
    public void ShowAllStudents()
    {
        Console.WriteLine($"\n=== Назва групи: {GroupName} | Спеціалізація: {Specialization} | Курс: {CourseNumber} ===");
        
        if (_students.Count == 0)
        {
            Console.WriteLine("Група порожня.");
            return;
        }

        var sortedStudents = _students
            .OrderBy(s => s.LastName)
            .ThenBy(s => s.FirstName)
            .ToList();

        for (int i = 0; i < sortedStudents.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {sortedStudents[i].LastName} {sortedStudents[i].FirstName}");
        }
        Console.WriteLine(new string('=', 65));
    }
    
    public void AddStudent(Student student)
    {
        ArgumentNullException.ThrowIfNull(student);
        _students.Add(student);
    }
    
    public bool TransferStudent(Student? student, Group? targetGroup)
    {
        if (student == null || targetGroup == null) return false;

        if (_students.Remove(student))
        {
            targetGroup.AddStudent(student);
            return true;
        }

        return false;
    }
    public void RemoveFailedStudents()
    {
        int removedCount = _students.RemoveAll(s => !s.HasPassedSession());
        Console.WriteLine($"Відраховано студентів, що не склали сесію: {removedCount}");
    }
    
    public void RemoveWorstStudent()
    {
        if (_students.Count == 0)
        {
            Console.WriteLine("Неможливо відрахувати: група порожня.");
            return;
        }

        Student worstStudent = _students.OrderBy(s => s.GetAverageGrade()).First();
        _students.Remove(worstStudent);

        Console.WriteLine($"Відраховано найгіршого студента: {worstStudent.LastName} {worstStudent.FirstName} (Середній бал: {worstStudent.GetAverageGrade():F2})");
    }
}