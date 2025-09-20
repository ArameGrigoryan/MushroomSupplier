using MushroomSupplier.Core.Models;

namespace MushroomSupplier.Core.Interfaces;
public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetId(int id);
    Task Add(Product entity);
    void Update(Product entity);
    void Delete(Product entity); 
}