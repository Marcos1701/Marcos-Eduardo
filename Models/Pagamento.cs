using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarcosEduardo.Models
{
    public class Pagamento
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Limite")]
        public DateTime DataLimite { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Valor do Pagamento")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true, NullDisplayText = "R$ 0,00")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Pagamento Realizado ?")]
        [DisplayFormat(DataFormatString = "{0:Sim;Não}", NullDisplayText = "Não")] // para exibir Sim ou Não ao invés de True ou False
        public bool Pago { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Nota de Venda")]
        [ForeignKey("NotaDeVenda")]
        public int NotaDeVendaId { get; set; }
        public NotaDeVenda? NotaDeVenda { get; set; }

        public Pagamento(DateTime dataLimite, double valor, bool pago, int notaDeVendaId)
        {
            DataLimite = dataLimite;
            Valor = valor;
            Pago = pago;
            NotaDeVendaId = notaDeVendaId;
            NotaDeVenda = null; // para evitar erro de referência nula
        }

        public Pagamento()
        {
        }
    }
}