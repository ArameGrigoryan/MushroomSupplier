using MushroomSupplier.Core.DTOs;

namespace MushroomSupplier.Core.Interfaces;
public interface ISupplierService
{
    Task<IEnumerable<SupplierDto>> GetAll();
    Task<SupplierDto?> GetId(int id);

    Task<SupplierDto> CreateSupplier(CreateSupplierDto dto);

    Task UpdateSupplier(SupplierDto supplierDto);
    Task DeleteSupplier(int id);
}
