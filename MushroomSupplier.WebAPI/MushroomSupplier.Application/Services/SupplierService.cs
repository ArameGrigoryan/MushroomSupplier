using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MushroomSupplier.Core.DTOs;
using MushroomSupplier.Core.Interfaces;
using MushroomSupplier.Core.Models;
using MushroomSupplier.Infrastructure.Data;

namespace MushroomSupplier.Application.Services;

public class SupplierService : ISupplierService
{
    private readonly MushroomContext _context;
    private readonly IMapper _mapper;

    public SupplierService(MushroomContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<SupplierDto> CreateSupplier(CreateSupplierDto dto)
    {
        var supplier = _mapper.Map<Supplier>(dto);
        _context.Suppliers.Add(supplier);
        await _context.SaveChangesAsync();
        return _mapper.Map<SupplierDto>(supplier);
    }

    public async Task<IEnumerable<SupplierDto>> GetAll()
    {
        var suppliers = await _context.Suppliers.ToListAsync();
        return _mapper.Map<IEnumerable<SupplierDto>>(suppliers);
    }

    public async Task<SupplierDto?> GetId(int id)
    {
        var supplier = await _context.Suppliers.FindAsync(id);
        if (supplier == null) return null;

        return _mapper.Map<SupplierDto>(supplier);
    }

    public async Task<SupplierDto> CreateSupplier(SupplierDto supplierDto)
    {
        var supplier = _mapper.Map<Supplier>(supplierDto);
        _context.Suppliers.Add(supplier);
        await _context.SaveChangesAsync();
        return _mapper.Map<SupplierDto>(supplier);
    }

    public async Task UpdateSupplier(SupplierDto supplierDto)
    {
        var supplier = await _context.Suppliers.FindAsync(supplierDto.Id);
        if (supplier == null)
            throw new KeyNotFoundException($"Supplier with Id {supplierDto.Id} not found");

        _mapper.Map(supplierDto, supplier);
        _context.Suppliers.Update(supplier);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSupplier(int id)
    {
        var supplier = await _context.Suppliers.FindAsync(id);
        if (supplier == null)
            throw new KeyNotFoundException($"Supplier with Id {id} not found");

        _context.Suppliers.Remove(supplier);
        await _context.SaveChangesAsync();
    }
}