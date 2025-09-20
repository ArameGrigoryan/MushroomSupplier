namespace MushroomSupplier.Core.Interfaces;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>?> GetAll();
    Task<T> GetId(int id);
    Task Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}