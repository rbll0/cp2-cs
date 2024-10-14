using CP2.API.Application.Interfaces;
using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;

namespace CP2.API.Application.Services
{
    public class VendedorApplicationService : IVendedorApplicationService
    {
        private readonly IVendedorRepository _repository;

        public VendedorApplicationService(IVendedorRepository repository)
        {
            _repository = repository;
        }

        // Método para obter vendedor por ID
        public async Task<VendedorEntity> GetByIdAsync(int id)
        {
            return await _repository.ObterPorIdAsync(id);
        }

        // Método para obter todos os vendedores
        public async Task<IEnumerable<VendedorEntity>> GetAllAsync()
        {
            return await _repository.ObterTodosAsync();
        }

        // Método para adicionar um novo vendedor
        public async Task AddAsync(VendedorEntity vendedor)
        {
            await _repository.AdicionarAsync(vendedor);
        }

        // Método para atualizar os dados de um vendedor
        public async Task UpdateAsync(VendedorEntity vendedor)
        {
            await _repository.AtualizarAsync(vendedor);
        }

        // Método para deletar um vendedor pelo ID
        public async Task DeleteAsync(int id)
        {
            await _repository.DeletarAsync(id);
        }
    }
}
