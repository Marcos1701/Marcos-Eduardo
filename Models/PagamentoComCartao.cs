using System.ComponentModel.DataAnnotations;

namespace MarcosEduardo.Models
{
    public class PagamentoComCartao : TipoDePagamento
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Número do Cartão")]
        public string? NumeroDoCartao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Bandeira do Cartão")]
        public string? Bandeira { get; set; }

        public PagamentoComCartao(string numeroDoCartao, string bandeira, string nomeDoCobrado, string? informacoesAdicionais) : base(nomeDoCobrado, informacoesAdicionais)
        {
            NumeroDoCartao = numeroDoCartao;
            Bandeira = bandeira;
        }

        public PagamentoComCartao()
        {
        }

    }
}