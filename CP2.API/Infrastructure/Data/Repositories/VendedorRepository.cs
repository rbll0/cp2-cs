using CP2.API.Infrastructure.Data.AppData;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CP2.API.Infrastructure.Data.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly ApplicationContext _context;

        public VendedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        // Implementação do método ObterPorIdAsync
        public async Task<VendedorEntity?> ObterPorIdAsync(int id)
        {
            return await _context.Vendedor.FindAsync(id);
        }

        // Implementação do método ObterTodosAsync
        public async Task<IEnumerable<VendedorEntity>> ObterTodosAsync()
        {
            return await _context.Vendedor.ToListAsync();
        }

        // Implementação do método AdicionarAsync
        public async Task AdicionarAsync(VendedorEntity vendedor)
        {
            _context.Vendedor.Add(vendedor);
            await _context.SaveChangesAsync();
        }

        // Implementação do método AtualizarAsync
        public async Task AtualizarAsync(VendedorEntity vendedor)
        {
            _context.Vendedor.Update(vendedor);
            await _context.SaveChangesAsync();
        }

        // Implementação do método DeletarAsync
        public async Task DeletarAsync(int id)
        {
            var vendedor = await ObterPorIdAsync(id);
            if (vendedor != null)
            {
                _context.Vendedor.Remove(vendedor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
