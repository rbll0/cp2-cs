using CP2.API.Application.Interfaces;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CP2.API.Application.Services
{
    public class FornecedorApplicationService : IFornecedorApplicationService
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorApplicationService(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        // Método para obter fornecedor por ID
        public async Task<FornecedorEntity> GetByIdAsync(int id)
        {
            return await _repository.ObterPorIdAsync(id);
        }

        // Método para obter todos os fornecedores
        public async Task<IEnumerable<FornecedorEntity>> GetAllAsync()
        {
            return await _repository.ObterTodosAsync();
        }

        // Método para adicionar um novo fornecedor
        public async Task AddAsync(FornecedorEntity fornecedor)
        {
            await _repository.AdicionarAsync(fornecedor);
        }

        // Método para atualizar os dados de um fornecedor
        public async Task UpdateAsync(FornecedorEntity fornecedor)
        {
            await _repository.AtualizarAsync(fornecedor);
        }

        // Método para deletar um fornecedor
        public async Task DeleteAsync(int id)
        {
            await _repository.DeletarAsync(id);
        }
    }
}
