using System.ComponentModel.DataAnnotations;

namespace MarcosEduardo.Models
{
    public class TipoDePagamento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Nome do Cobrado")]
        public string? NomeDoCobrado { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Informações Adicionais")]
        public string? InformacoesAdicionais { get; set; }

        public TipoDePagamento(string nomeDoCobrado, string? informacoesAdicionais)
        {
            NomeDoCobrado = nomeDoCobrado;
            if (informacoesAdicionais != null)
            {
                InformacoesAdicionais = informacoesAdicionais;
            }
        }

        public TipoDePagamento()
        {
        }
    }
}