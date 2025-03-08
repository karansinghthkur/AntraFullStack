namespace ConsoleApp10;

public class MyList<T>
{
    private  T[] ListArray;
    private int size;
    private int index1;

    public MyList(int capacity)
    {
        size = 0;
        ListArray = new T[capacity];
        index1 = 0;
    }

    public void Add(T element)
    {
        if (size == ListArray.Length)
        {
            Console.WriteLine("Array is full");
        }
        ListArray[index1] = element;
        index1++;
        size++;
    }

    public T Remove(int index)
    {
        if (index < 0 || index >= size)
        {
            Console.WriteLine("Index is out of range");
            return default(T);
        }
        T element = ListArray[index];
        for (int i = index; i < size - 1; i++)
        {
            ListArray[i] = ListArray[i + 1];
        }

        ListArray[size - 1] = default(T); // Clear the last element
        size--;
        index1--;
        return element;
    }

    public bool Contains(T element)
    {
        for (var i = 0; i < size; i++)
        {
            if (ListArray[i].Equals(element))
            {
                return true;
            }
        }
        return false;
    }

    public void Clear()
    {
        size = 0;
        index1 = 0;
    }

    public void InsertAt(T element, int index)
    {
        if (index < 0 || index > size)
        {
            Console.WriteLine("Index is out of range");
            return;
        }
        if (size == ListArray.Length)
        {
            Array.Resize(ref ListArray, ListArray.Length * 2);
        }
        
        for (int i = size; i > index; i--)
        {
            ListArray[i] = ListArray[i-1];
        }
        ListArray[index] = element;
        size++;
        index1++;
    }

    public void DeleteAt(int index)
    {
        if (index < 0 || index >= size)
        {
            Console.WriteLine("Index is out of range");
        }
        for (int i = index; i < size - 1; i++)
        {
            ListArray[i] = ListArray[i + 1];
        }
        ListArray[size - 1] = default(T);
        size--;
    }

    public T Find(int index)
    {
        return ListArray[index];
    }

}