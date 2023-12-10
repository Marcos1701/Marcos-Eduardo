using System.ComponentModel.DataAnnotations;

namespace MarcosEduardo.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Nome do Cliente")]
        public string? Nome { get; set; }

        public Cliente(string nome)
        {
            Nome = nome;
        }

        public Cliente()
        {
        }
    }
}