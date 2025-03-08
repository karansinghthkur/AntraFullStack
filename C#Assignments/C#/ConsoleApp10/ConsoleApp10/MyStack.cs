using Microsoft.CSharp.RuntimeBinder;

namespace ConsoleApp10;

public class MyStack<T>{
    /*
     * Create a custom Stack class MyStack<T> that can be used with any data type which
       has following methods
       1. int Count()
       2. T Pop()
       3. Void Push() 
     */
    private  T[] stackArray;
    private  int size;
    private  int top;

    public MyStack(int capacity)
    {
        stackArray = new T[capacity];
        size = 0;
        top = -1;

    }
    public int Count()
    {
        return size;
    }
    

    public T Pop()
    {
        if (size == 0)
        {
            Console.WriteLine("Stack is empty");
        }
        T element =(T) stackArray[top];
        stackArray[top] = default(T);
        top--;
        size--;
        return element;
    }

    public void Push(T item)
    {
        if (size == stackArray.Length)
        {
            Console.WriteLine("Stack is full");
        }

        top++;
        stackArray[top] = item;
        size++;
    }
}