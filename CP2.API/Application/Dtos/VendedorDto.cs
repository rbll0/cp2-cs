using System.ComponentModel.DataAnnotations;

namespace CP2.API.Application.Dtos
{
    public class VendedorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do vendedor é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email do vendedor é obrigatório")]
        [EmailAddress(ErrorMessage = "O email informado não é válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone do vendedor é obrigatório")]
        [Phone(ErrorMessage = "O número de telefone não é válido")]
        public string Telefone { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Endereco { get; set; }

        public DateTime DataContratacao { get; set; }

        [Range(0, 100, ErrorMessage = "A comissão deve ser entre 0 e 100%")]
        public decimal ComissaoPercentual { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "A meta mensal deve ser um valor positivo")]
        public decimal MetaMensal { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
