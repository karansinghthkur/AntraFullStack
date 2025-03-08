// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using ConsoleApp10;
using ConsoleApp10.DataModel;
using ConsoleApp10.Repositories;
Console.WriteLine("Program 1 Create a custom Stack class MyStack<T> that can be used with any data type which\nhas following methods");
MyStack<int> stack=new MyStack<int>(5);
stack.Push(1);
stack.Push(2);
stack.Push(3);
Console.WriteLine("Count"+stack.Count());
Console.WriteLine("Popped"+stack.Pop());
Console.WriteLine("Count"+stack.Count());


Console.WriteLine("Program 2 Create a Generic List data structure MyList<T> that can store any data type.");
Console.WriteLine("Adding Elements to the list");
MyList<int> list = new MyList<int>(5);
list.Add(1);
list.Add(2);
list.Add(3);
list.Add(4);
list.Add(5);
Console.WriteLine("\nRemoving element at index 2:");
int removedElement = list.Remove(2);
Console.WriteLine("Removed element: " + removedElement);
Console.WriteLine("\nList after removal:");
for (int i = 0; i < 4; i++) // size is now 4
{
    Console.WriteLine("Element at index " + i + ": " + list.Find(i));
}
Console.WriteLine("\nInserting 100 at index 1:");
list.InsertAt(100, 1);
Console.WriteLine("\nList after insertion:");
for (int i = 0; i < 5; i++) // size is now 5
{
    Console.WriteLine("Element at index " + i + ": " + list.Find(i));
}
Console.WriteLine("\nDeleting element at index 3:");
list.DeleteAt(3);
Console.WriteLine("\nList after deletion:");
for (int i = 0; i < 4; i++) // size is now 4
{
    Console.WriteLine("Element at index " + i + ": " + list.Find(i));
}
Console.WriteLine("\nClearing the list...");
list.Clear();


Console.WriteLine("Program 3 Implement a GenericRepository<T> class that implements IRepository<T> interface");

IRepository<Employee> employeeRepo = new GenericRepository<Employee>();
employeeRepo.Add(new Employee { Id = 1, Name = "John Doe", Age = 30 });
employeeRepo.Add(new Employee { Id = 2, Name = "Alice Smith", Age = 25 });

Console.WriteLine("All Employees:");
foreach (var employee in employeeRepo.GetAll())
{
    Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Age: {employee.Age}");
}

var fetchedEmployee = employeeRepo.GetById(1);
Console.WriteLine($"\nFetched Employee: ID: {fetchedEmployee.Id}, Name: {fetchedEmployee.Name}, Age: {fetchedEmployee.Age}");

employeeRepo.Remove(fetchedEmployee);
employeeRepo.Save();