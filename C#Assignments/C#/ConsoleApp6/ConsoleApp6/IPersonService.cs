namespace ConsoleApp6;

using System;
using System.Collections.Generic;
using System.Linq;

// Interfaces
public interface IPersonService
{
    string Name { get; set; }
    DateTime DateOfBirth { get; set; }
    List<Address> Addresses { get; set; }
    int CalculateAge();
    void AddAddress(Address address);
    List<Address> GetAddresses();

}

public interface IStudentService : IPersonService
{
    List<Course> Courses { get; set; }
    void EnrollInCourse(Course course);
    double CalculateGPA();
}

public interface IInstructorService : IPersonService
{
    Department Department { get; set; }
    DateTime JoinDate { get; set; }
    decimal Salary { get; set; }
    decimal CalculateSalary();
    decimal AddedBonus { get; set; }
    bool IsHeadOfDepartment { get; set; }
    int CalculateYearsOfExperience();
}

public interface ICourseService
{
    string CourseName { get; set; }
    List<Student> EnrolledStudents { get; set; }
    void AddStudent(Student student);
    void AssignGrade(Student student, char grade); // Assign grade to student for this course
    char GetGrade(Student student); // Get grade of student for this course
}

public interface IDepartmentService
{
    string DepartmentName { get; set; }
    Instructor HeadOfDepartment { get; set; }
    List<Course> OfferedCourses { get; set; }
    DateTime BudgetStartDate { get; set; }
    DateTime BudgetEndDate { get; set; }
    decimal Budget { get; set; }
    void AddCourse(Course course);
}


// Classes
public class Person : IPersonService
{
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<Address> Addresses { get; set; } = new List<Address>();

    public int CalculateAge()
    {
        int age = DateTime.Now.Year - DateOfBirth.Year;
        if (DateTime.Now.Month < DateOfBirth.Month || (DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day < DateOfBirth.Day))
        {
            age--;
        }
        return age;
    }

    public void AddAddress(Address address)
    {
        Addresses.Add(address);
    }

    public List<Address> GetAddresses()
    {
        return Addresses;
    }
}

public class Student : Person, IStudentService
{
    public List<Course> Courses { get; set; } = new List<Course>();
    private Dictionary<Course, char> Grades { get; set; } = new Dictionary<Course, char>(); // Store grades for each course

    public void EnrollInCourse(Course course)
    {
        Courses.Add(course);
        course.AddStudent(this); // Add student to course's enrolled list
    }

    public double CalculateGPA()
    {
        if (Courses.Count == 0) return 0;

        double totalGradePoints = 0;
        foreach (var course in Courses)
        {
            char grade = GetGrade(course); // Retrieve from Grades dictionary
            switch (grade)
            {
                case 'A': totalGradePoints += 4.0; break;
                case 'B': totalGradePoints += 3.0; break;
                case 'C': totalGradePoints += 2.0; break;
                case 'D': totalGradePoints += 1.0; break;
                case 'F': totalGradePoints += 0.0; break;
                default:  break; // Handle invalid grades if needed
            }
        }

        return totalGradePoints / Courses.Count;
    }

    public void AssignGrade(Course course, char grade)
    {
        Grades[course] = grade;
    }

    public char GetGrade(Course course)
    {
        if (Grades.ContainsKey(course))
        {
            return Grades[course];
        }
        return ' '; // Or handle the case where the grade isn't assigned yet
    }
}

public class Instructor : Person, IInstructorService
{
    public Department Department { get; set; }
    public DateTime JoinDate { get; set; }
    private decimal _salary;

    public decimal Salary
    {
        get => _salary;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Salary cannot be negative.");
            }
            _salary = value;
        }
    }
    public decimal AddedBonus { get; set; }

    public bool IsHeadOfDepartment { get; set; }

    public decimal CalculateSalary()
    {
        return Salary + AddedBonus;
    }

    public int CalculateYearsOfExperience()
    {
        int years = DateTime.Now.Year - JoinDate.Year;
        if (DateTime.Now.Month < JoinDate.Month || (DateTime.Now.Month == JoinDate.Month && DateTime.Now.Day < JoinDate.Day))
        {
            years--;
        }
        return years;
    }
}

public class Course : ICourseService
{
    public string CourseName { get; set; }
    public List<Student> EnrolledStudents { get; set; } = new List<Student>();

    public void AddStudent(Student student)
    {
        EnrolledStudents.Add(student);
    }
    public void AssignGrade(Student student, char grade)
    {
        //Delegate to student to assign grade.
        student.AssignGrade(this, grade);
    }

    public char GetGrade(Student student)
    {
       return student.GetGrade(this);
    }
}

public class Department : IDepartmentService
{
    public string DepartmentName { get; set; }
    public Instructor HeadOfDepartment { get; set; }
    public List<Course> OfferedCourses { get; set; } = new List<Course>();
    public DateTime BudgetStartDate { get; set; }
    public DateTime BudgetEndDate { get; set; }
    public decimal Budget { get; set; }

    public void AddCourse(Course course)
    {
        OfferedCourses.Add(course);
    }
}

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
}