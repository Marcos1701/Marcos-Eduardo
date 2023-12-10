using System.ComponentModel.DataAnnotations;

namespace MarcosEduardo.Models
{
    public class PagamentoComCheque : TipoDePagamento
    {
        [Display(Name = "Nome do Banco")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string? NomeDoBanco { get; set; }

        public PagamentoComCheque(string nomeDoBanco, string nomeDoCobrado, string? informacoesAdicionais) : base(nomeDoCobrado, informacoesAdicionais)
        {
            NomeDoBanco = nomeDoBanco;
        }

        public PagamentoComCheque()
        {
        }
    }
}