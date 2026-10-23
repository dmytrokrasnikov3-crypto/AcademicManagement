using System.Text;

namespace AcademicManagement;

internal static class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Student s1 = new("Шевченко", "Тарас", "Григорович", new DateTime(2003, 3, 9));
        s1.AddExamGrade(95);
        s1.AddCreditGrade(90);
        s1.AddCourseworkGrade(100);

        Student s2 = new("Франко", "Іван", "Якович", new DateTime(2002, 8, 27));
        s2.AddExamGrade(45);
        s2.AddCreditGrade(50);

        Group groupA = new([s1, s2], "ПВ-211", "Software Engineering", 2);
        groupA.ShowAllStudents();

        Group groupB = new() { GroupName = "ПВ-212", Specialization = "Cybersecurity", CourseNumber = 2 };
        groupA.TransferStudent(s1, groupB);

        Console.WriteLine("\nГрупа А після переведення Шевченка:");
        groupA.ShowAllStudents();

        Console.WriteLine("\nГрупа Б після зарахування:");
        groupB.ShowAllStudents();

        Console.WriteLine("\nВідрахування за борги з Групи А:");
        groupA.RemoveFailedStudents();
        groupA.ShowAllStudents();
    }
}