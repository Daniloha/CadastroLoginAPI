using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APICadastro.Models
{
    [Table("pessoas")]
    public class Pessoa
    {
        public long ID { get; set; }

        public string? Nome { get; set; }

        public string? Sobrenome { get; set; }

        public string? Genero { get; set; }

        public DateTime DataNascimento { get; set; }

        public string? Email { get; set; }

        public string? Telefone { get; set; } = "Sem telefone";

        public string? Cpf { get; set; }

        public string? senha { get; set; }
    }
}