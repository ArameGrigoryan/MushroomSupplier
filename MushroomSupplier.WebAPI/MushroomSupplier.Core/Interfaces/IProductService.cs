using MushroomSupplier.Core.DTOs;

namespace MushroomSupplier.Core.Interfaces;
public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAll();
    Task<ProductDto?> GetId(int id);
    Task<ProductDto> CreateProduct(CreateProductDto dto); 
    Task UpdateProduct(ProductDto productDto);
    Task DeleteProduct(int id);
}