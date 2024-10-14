﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2.API.Domain.Entities
{
    [Table("Vendedores")]
    public class VendedorEntity
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telefone { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Endereco { get; set; }

        public DateTime DataContratacao { get; set; }

        public decimal ComissaoPercentual { get; set; }

        public decimal MetaMensal { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
