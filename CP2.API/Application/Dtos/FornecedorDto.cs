using System.ComponentModel.DataAnnotations;

namespace CP2.API.Application.Dtos
{
    public class FornecedorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do fornecedor é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CNPJ do fornecedor é obrigatório")]
        public string CNPJ { get; set; }

        public string Endereco { get; set; }

        [Required(ErrorMessage = "O telefone do fornecedor é obrigatório")]
        [Phone(ErrorMessage = "O número de telefone não é válido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O email do fornecedor é obrigatório")]
        [EmailAddress(ErrorMessage = "O email informado não é válido")]
        public string Email { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
