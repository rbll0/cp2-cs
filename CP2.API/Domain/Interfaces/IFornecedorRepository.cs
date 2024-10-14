using CP2.API.Domain.Entities;

namespace CP2.API.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<FornecedorEntity?> ObterPorIdAsync(int id);
        Task<IEnumerable<FornecedorEntity>> ObterTodosAsync();
        Task AdicionarAsync(FornecedorEntity fornecedor);
        Task AtualizarAsync(FornecedorEntity fornecedor);
        Task DeletarAsync(int id);
    }
}
