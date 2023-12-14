using System.ComponentModel.DataAnnotations;

namespace MarcosEduardo.Models
{
    public class Marca
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Nome da Marca")]
        public string? Nome { get; set; }

        [Display(Name = "Descrição da Marca")]
        public string? Descricao { get; set; }

        public Marca(string nome, string? descricao)
        {
            Nome = nome;

            if (descricao != null)
            {
                Descricao = descricao;
            }
        }

        public Marca()
        {
        }

    }
}