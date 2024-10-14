﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2.API.Domain.Entities
{
    [Table("Fornecedores")]
    public class FornecedorEntity
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string CNPJ { get; set; }

        public string Endereco { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
