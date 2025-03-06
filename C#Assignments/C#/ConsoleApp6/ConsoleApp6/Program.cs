// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using ConsoleApp6;

Console.WriteLine("=============================================");
Console.WriteLine("1.Reverse of elements in an array Program ");
int[] numbers=GenerateNumbers();
Reverse( numbers);
PrintNumbers(numbers);

int[] GenerateNumbers()
{   int[] num=Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
    return num;
}

void Reverse(int[] numbers)
{ 
    int length = numbers.Length;
    for (int i = 0; i < length / 2; i++)
    {
        int temp = numbers[i];
        numbers[i] = numbers[length - i - 1];
        numbers[length - i - 1] = temp;
    }
    
}

void PrintNumbers(int[] numbers)
{
    for (int i = 0; i < numbers.Length; i++)
    {
        Console.Write(numbers[i] + " ");
    }
}

Console.WriteLine("\n=============================================");
Console.WriteLine("2.Fibonacci of elements in an array Program ");
Console.WriteLine("First n Fibonacci numbers Enter n:");
int n = int.Parse(Console.ReadLine());
for (int i = 1; i <= n; i++)
{
    Console.Write(Fibonacci(i) + " ");
}


int Fibonacci(int n)
{
    if (n == 1||n==2)
    {
        return 1;
    }
    return Fibonacci(n - 1) + Fibonacci(n - 2);
}

Console.WriteLine("\n==================================================================");
Console.WriteLine("1st+ 2nd Question Abstraction Designing and Building Classes");
Person student = new Student("Karan", 20,"CS");
Person instructor = new Instructor("Narak", 20,"Physics",300,100);
student.DisplayBehaviour();
instructor.DisplayBehaviour();

Console.WriteLine("\n==================================================================");
Console.WriteLine("1st+ 3rd Question Encapsulation Designing and Building Classes");

Person student2 = new Student("Alice", 20, "Computer Science");
Person instructor2 = new Instructor("Dr. Smith", 45, "Mathematics",300,20);
Console.WriteLine("Before accessessing and modifying private fields with the help of public properties");
student2.DisplayBehaviour(); 
instructor2.DisplayBehaviour();
Console.WriteLine("After accessessing and modifying private fields with the help of public properties");
student2.Name = "Myself";
student2.Age = 99;
((Student)student2).Major="Data Science";
((Instructor)instructor2).Department = "Scoiology";
student2.DisplayBehaviour();
instructor2.DisplayBehaviour();
Console.WriteLine("\n===================================================");
Console.WriteLine("1st+4th Question Inheritance Designing and Building Classes");
Person student3 = new Student("Antony", 16, "Arts");
Person instructor3 = new Instructor("Willian Smith", 45, "Mathematics",1,200);
student3.DisplayBehaviour(); 
instructor3.DisplayBehaviour();
Console.WriteLine("=============================================");
Console.WriteLine("1st+5thUsing Polymorphism to Implement Salary Calculation");
Person student4 = new Student("KaranThakur", 25, "Computer Science");
Person instructor4 = new Instructor("Andrea", 35, "Sociology", 50, 160);
Console.WriteLine($"{student4.Name}'s stipend: ${student4.CalculateSalary()}");
Console.WriteLine($"{instructor4.Name}'s salary: ${instructor4.CalculateSalary()}");
student4.DisplayBehaviour();
instructor4.DisplayBehaviour();
Console.WriteLine("\n============================================");
Console.WriteLine("6th Problem refer to the IPersonService Class for interface");
Console.WriteLine("\n============================================");
Console.WriteLine("7th Problem");
Color redColor = new Color(255, 0, 0);
Ball myBall = new Ball(10, redColor);
myBall.Throw();
myBall.Throw(); 
Console.WriteLine($"Throws: {myBall.GetThrowCount()}"); 
myBall.Pop();   
myBall.Throw(); 
Console.WriteLine($"Throws: {myBall.GetThrowCount()}");
Console.WriteLine(myBall);
Ball greenBall = new Ball(5, 0, 255, 0);
Console.WriteLine(greenBall);



