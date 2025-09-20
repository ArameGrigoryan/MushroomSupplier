using AutoMapper;
using MushroomSupplier.Core.DTOs;
using MushroomSupplier.Core.Interfaces;
using MushroomSupplier.Core.Models;

namespace MushroomSupplier.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetAll()
    {
        var products = await _productRepository.GetAll();
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<ProductDto?> GetId(int id)
    {
        var product = await _productRepository.GetId(id);
        return _mapper.Map<ProductDto?>(product);
    }

    public async Task<ProductDto> CreateProduct(CreateProductDto dto) 
    {
        var product = _mapper.Map<Product>(dto);
        await _productRepository.Add(product);
        return _mapper.Map<ProductDto>(product); 
    }

    public async Task UpdateProduct(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        _productRepository.Update(product);
    }

    public async Task DeleteProduct(int id)
    {
        var product = await _productRepository.GetId(id);
        if (product != null)
            _productRepository.Delete(product);
    }
}