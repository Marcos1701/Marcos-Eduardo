using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarcosEduardo.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Preço")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Percentual de Desconto")]
        public int Percentual { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Quantidade de Itens")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Nota de Venda")]
        [ForeignKey("NotaDeVenda")]
        public int NotaDeVendaId { get; set; }
        public NotaDeVenda? NotaDeVenda { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Produto")]
        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        public Item(double preco, int percentual, int quantidade, int notaDeVendaId, int produtoId)
        {
            Preco = preco;
            Percentual = percentual;
            Quantidade = quantidade;
            NotaDeVendaId = notaDeVendaId;
            ProdutoId = produtoId;
            NotaDeVenda = null; // para evitar erro de referência nula
            Produto = null; // para evitar erro de referência nula
        }

        public Item()
        {
        }

    }
}