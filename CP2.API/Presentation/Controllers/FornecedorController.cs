using CP2.API.Application.Interfaces;
using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

namespace CP2.API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorApplicationService _applicationService;

        public FornecedorController(IFornecedorApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        // Método GET: Lista todos os fornecedores
        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os fornecedores", Description = "Este endpoint retorna uma lista completa de todos os fornecedores cadastrados.")]
        [ProducesResponseType(typeof(IEnumerable<FornecedorEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var fornecedores = await _applicationService.GetAllAsync();

            if (fornecedores != null)
                return Ok(fornecedores);

            return BadRequest("Não foi possível obter os dados.");
        }

        // Método GET por ID: Retorna um fornecedor específico
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FornecedorEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPorId(int id)
        {
            var fornecedor = await _applicationService.GetByIdAsync(id);

            if (fornecedor != null)
                return Ok(fornecedor);

            return BadRequest("Não foi possível obter os dados.");
        }

        // Método POST: Cria um novo fornecedor
        [HttpPost]
        [ProducesResponseType(typeof(FornecedorEntity), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] FornecedorDto entity)
        {
            try
            {
                await _applicationService.AddAsync(new FornecedorEntity
                {
                    Nome = entity.Nome,
                    CNPJ = entity.CNPJ,
                    Telefone = entity.Telefone,
                    Email = entity.Email,
                    Endereco = entity.Endereco,
                    CriadoEm = DateTime.Now
                });

                return StatusCode((int)HttpStatusCode.Created, entity);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        // Método PUT: Edita um fornecedor existente
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(FornecedorEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] FornecedorDto entity)
        {
            try
            {
                var fornecedor = await _applicationService.GetByIdAsync(id);

                if (fornecedor == null)
                    return BadRequest("Fornecedor não encontrado.");

                fornecedor.Nome = entity.Nome;
                fornecedor.CNPJ = entity.CNPJ;
                fornecedor.Telefone = entity.Telefone;
                fornecedor.Email = entity.Email;
                fornecedor.Endereco = entity.Endereco;

                await _applicationService.UpdateAsync(fornecedor);

                return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        // Método DELETE: Exclui um fornecedor existente
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(FornecedorEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var fornecedor = await _applicationService.GetByIdAsync(id);

                if (fornecedor == null)
                    return BadRequest("Fornecedor não encontrado.");

                await _applicationService.DeleteAsync(id);

                return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }
    }
}
