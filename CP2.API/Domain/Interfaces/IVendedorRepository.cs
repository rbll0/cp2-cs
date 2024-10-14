using CP2.API.Domain.Entities;

namespace CP2.API.Domain.Interfaces
{
    public interface IVendedorRepository
    {
        Task<VendedorEntity?> ObterPorIdAsync(int id);
        Task<IEnumerable<VendedorEntity>> ObterTodosAsync();
        Task AdicionarAsync(VendedorEntity vendedor);
        Task AtualizarAsync(VendedorEntity vendedor);
        Task DeletarAsync(int id);
    }
}
