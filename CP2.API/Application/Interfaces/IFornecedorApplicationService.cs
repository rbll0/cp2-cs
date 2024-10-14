using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;

namespace CP2.API.Application.Interfaces
{
    public interface IFornecedorApplicationService
    {
        Task<FornecedorEntity> GetByIdAsync(int id);
        Task<IEnumerable<FornecedorEntity>> GetAllAsync();
        Task AddAsync(FornecedorEntity fornecedor);
        Task UpdateAsync(FornecedorEntity fornecedor);
        Task DeleteAsync(int id);
    }
}
