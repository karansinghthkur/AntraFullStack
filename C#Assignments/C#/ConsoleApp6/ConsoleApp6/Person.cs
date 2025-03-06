using System.Security.Principal;

namespace ConsoleApp6;

public abstract class Person
{
    private string name;
    private int age;

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public int Age
    {
        get
        {
            return age;
        }
        set
        {
            age = value;
        }
    }

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public abstract void DisplayBehaviour();

    public virtual double CalculateSalary()
    {
        return 0;
    }
}

class Student : Person
{
    private string major;

    public string Major
    {
        get
        {
            return major;
        }
        set
        {
            major = value;
        }
    }

    public Student(string name, int age, string major) : base(name, age)
    {
        this.major = major;
    }

    public override void DisplayBehaviour()
    {
        Console.WriteLine($"{Name} is a student Studying {Major}");
    }

    public override double CalculateSalary()
    {
        return 500;
    }
    
}

class Instructor : Person
{
    private string department;

    public string Department
    {
        get
        {
            return department;
        }
        set
        {
            department = value;
        }
    }

    private double hourlyRate;
    private int hoursWorked;

    public Instructor(string name, int age, string department,double hourlyRate, int hoursWorked) : base(name, age)
    {
        this.department = department;
        this.hourlyRate = hourlyRate;
        this.hoursWorked = hoursWorked;
    }
    
    public override void DisplayBehaviour()
    {
        Console.WriteLine($"{Name} is a instructor is of {Department} Department");
    }

    public override double CalculateSalary()
    {
        return hourlyRate * hoursWorked;
    }
}