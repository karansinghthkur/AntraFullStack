using ConsoleApp10.DataModel;

namespace ConsoleApp10.Repositories;

public interface IRepository<T> where T : Employee
{
    void Add(T item);
     void Remove(T item);
     void Save();
     IEnumerable<T> GetAll();
     T GetById(int id);
}

