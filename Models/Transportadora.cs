using System.ComponentModel.DataAnnotations;

namespace MarcosEduardo.Models
{
    public class Transportadora
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Nome da Transportadora")]
        public string? Nome { get; set; }

        public Transportadora(string nome)
        {
            Nome = nome;
        }

        public Transportadora()
        {
        }

    }
}