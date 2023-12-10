using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarcosEduardo.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Nome do Vendedor")]
        public string? Nome { get; set; }

        public Vendedor(string nome)
        {
            Nome = nome;
        }

        public Vendedor()
        {
        }
    }
}