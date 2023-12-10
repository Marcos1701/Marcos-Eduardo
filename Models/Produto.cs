using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarcosEduardo.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Nome do Produto")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Descrição do Produto")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Preço do Produto")]
        [DataType(DataType.Currency)]
        // formatar, para exibir no formato:  R$ 0,00
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public double Preco { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Marca do Produto")]
        [ForeignKey("Marca")]
        public int MarcaId { get; set; }
        public Marca? Marca { get; set; }

        public Produto(string nome, string descricao, double preco, int quantidade, int marcaId)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Quantidade = quantidade;
            MarcaId = marcaId;
            Marca = null; // para evitar erro de referência nula
        }

        public Produto()
        {
        }
    }
}