using System.Collections.Generic;

public interface IService<T>
{
    List<T> GetAll();
    void Add(T item);
}