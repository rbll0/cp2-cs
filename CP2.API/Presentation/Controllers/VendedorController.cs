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
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorApplicationService _applicationService;

        public VendedorController(IVendedorApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        // Método GET: Lista todos os vendedores
        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os vendedores", Description = "Este endpoint retorna uma lista completa de todos os vendedores cadastrados.")]
        [ProducesResponseType(typeof(IEnumerable<VendedorEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var vendedores = await _applicationService.GetAllAsync();

            if (vendedores != null)
                return Ok(vendedores);

            return BadRequest("Não foi possível obter os dados.");
        }

        // Método GET por ID: Retorna um vendedor específico
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VendedorEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPorId(int id)
        {
            var vendedor = await _applicationService.GetByIdAsync(id);

            if (vendedor != null)
                return Ok(vendedor);

            return BadRequest("Não foi possível obter os dados.");
        }

        // Método POST: Cria um novo vendedor
        [HttpPost]
        [ProducesResponseType(typeof(VendedorEntity), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] VendedorDto entity)
        {
            try
            {
                await _applicationService.AddAsync(new VendedorEntity
                {
                    Nome = entity.Nome,
                    Email = entity.Email,
                    Telefone = entity.Telefone,
                    Endereco = entity.Endereco,
                    DataNascimento = entity.DataNascimento,
                    DataContratacao = entity.DataContratacao,
                    ComissaoPercentual = entity.ComissaoPercentual,
                    MetaMensal = entity.MetaMensal,
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

        // Método PUT: Edita um vendedor existente
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(VendedorEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] VendedorDto entity)
        {
            try
            {
                var vendedor = await _applicationService.GetByIdAsync(id);

                if (vendedor == null)
                    return BadRequest("Vendedor não encontrado.");

                vendedor.Nome = entity.Nome;
                vendedor.Email = entity.Email;
                vendedor.Telefone = entity.Telefone;
                vendedor.Endereco = entity.Endereco;
                vendedor.DataNascimento = entity.DataNascimento;
                vendedor.DataContratacao = entity.DataContratacao;
                vendedor.ComissaoPercentual = entity.ComissaoPercentual;
                vendedor.MetaMensal = entity.MetaMensal;

                await _applicationService.UpdateAsync(vendedor);

                return Ok(vendedor);
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

        // Método DELETE: Exclui um vendedor existente
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(VendedorEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var vendedor = await _applicationService.GetByIdAsync(id);

                if (vendedor == null)
                    return BadRequest("Vendedor não encontrado.");

                await _applicationService.DeleteAsync(id);

                return Ok(vendedor);
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
