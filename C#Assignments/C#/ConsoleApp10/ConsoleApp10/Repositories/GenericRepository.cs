using ConsoleApp10.DataModel;
using System.Collections.Generic;
using System.Linq;
using System;
namespace ConsoleApp10.Repositories;

public class GenericRepository<T> : IRepository<T> where T : Employee
{
    private readonly List<T> _dataStore = new List<T>();

    public void Add(T item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        _dataStore.Add(item);
    }

    public void Remove(T item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        _dataStore.Remove(item);
    }

    public void Save()
    {
        Console.WriteLine("Changes saved successfully.");
    }

    public IEnumerable<T> GetAll()
    {
        return _dataStore;
    }

    public T GetById(int id)
    {
        return _dataStore.FirstOrDefault(item => item.Id == id);
    }
}