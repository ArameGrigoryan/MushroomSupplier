using Microsoft.AspNetCore.Mvc;
using MushroomSupplier.Core.DTOs;
using MushroomSupplier.Core.Interfaces;
using MushroomSupplier.Core.Models;

namespace MushroomSupplier.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
    {
        var products = await _productService.GetAll();
        if (products is null)
            return Ok(Enumerable.Empty<ProductDto>());
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetById(int id)
    {
        var product = await _productService.GetId(id);
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] CreateProductDto dto)
    {
        var createdProduct = await _productService.CreateProduct(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdProduct.Id },
            createdProduct
        );
    }



    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] ProductDto productDto)
    {
        if (id != productDto.Id)
            return BadRequest("Id mismatch");

        await _productService.UpdateProduct(productDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _productService.DeleteProduct(id);
        return NoContent();
    }
}