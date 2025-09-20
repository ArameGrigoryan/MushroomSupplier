using Microsoft.EntityFrameworkCore;
using MushroomSupplier.Core.Interfaces;
using MushroomSupplier.Core.Models;
using MushroomSupplier.Infrastructure.Data;

namespace MushroomSupplier.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly MushroomContext _context;

    public ProductRepository(MushroomContext context)
    {
        _context = context;
    }

    public async Task Add(Product entity)
    {
        _context.Products.Add(entity);
        await _context.SaveChangesAsync();
    }


    

    public async Task<Product> GetId(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

    public void Update(Product entity)
    {
        _context.Products.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(Product entity)
    {
        _context.Products.Remove(entity);
        _context.SaveChanges();
    }
}
