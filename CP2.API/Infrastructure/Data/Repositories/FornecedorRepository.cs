using CP2.API.Infrastructure.Data.AppData;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CP2.API.Infrastructure.Data.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationContext _context;

        public FornecedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        // Implementação do método ObterPorIdAsync
        public async Task<FornecedorEntity?> ObterPorIdAsync(int id)
        {
            return await _context.Fornecedor.FindAsync(id);
        }

        // Implementação do método ObterTodosAsync
        public async Task<IEnumerable<FornecedorEntity>> ObterTodosAsync()
        {
            return await _context.Fornecedor.ToListAsync();
        }

        // Implementação do método AdicionarAsync
        public async Task AdicionarAsync(FornecedorEntity fornecedor)
        {
            _context.Fornecedor.Add(fornecedor);
            await _context.SaveChangesAsync();
        }

        // Implementação do método AtualizarAsync
        public async Task AtualizarAsync(FornecedorEntity fornecedor)
        {
            _context.Fornecedor.Update(fornecedor);
            await _context.SaveChangesAsync();
        }

        // Implementação do método DeletarAsync
        public async Task DeletarAsync(int id)
        {
            var fornecedor = await ObterPorIdAsync(id);
            if (fornecedor != null)
            {
                _context.Fornecedor.Remove(fornecedor);
                await _context.SaveChangesAsync();
            }
        }
    }
}

