using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;

namespace CP2.API.Application.Interfaces
{
    public interface IVendedorApplicationService
    {
        Task<VendedorEntity> GetByIdAsync(int id);
        Task<IEnumerable<VendedorEntity>> GetAllAsync();
        Task AddAsync(VendedorEntity vendedor);
        Task UpdateAsync(VendedorEntity vendedor);
        Task DeleteAsync(int id);
    }
}
