using Microsoft.AspNetCore.Mvc;
using MushroomSupplier.Core.DTOs;
using MushroomSupplier.Core.Interfaces;

namespace MushroomSupplier.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SuppliersController : ControllerBase
{
    private readonly ISupplierService _supplierService;

    public SuppliersController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SupplierDto>>> GetAll()
    {
        var suppliers = await _supplierService.GetAll();
        return Ok(suppliers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SupplierDto>> GetId(int id)
    {
        var supplier = await _supplierService.GetId(id);
        return Ok(supplier);
    }

    [HttpPost]
    public async Task<ActionResult<SupplierDto>> Create([FromBody] CreateSupplierDto dto)
    {
        var created = await _supplierService.CreateSupplier(dto);
        return CreatedAtAction(nameof(GetId), new { id = created.Id }, created);
    }


    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] SupplierDto supplierDto)
    {
        if (id != supplierDto.Id)
            return BadRequest("Id mismatch");

        await _supplierService.UpdateSupplier(supplierDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _supplierService.DeleteSupplier(id);
        return NoContent();
    }
}