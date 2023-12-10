using System.ComponentModel.DataAnnotations;

namespace MarcosEduardo.Models
{
    public class NotaDeVenda
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public StatusNotaDeVenda Status { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        // exibir o nome do cliente ao invés do id ao adicionar uma nota de venda
        // no banco de dados, o id do cliente é armazenado, mas na interface, o nome
        // do cliente é exibido
        // para isso, é necessário adicionar o seguinte código no arquivo
        // Controllers/NotaDeVendaController.cs:
        // ViewBag.ClienteId = new SelectList(_context.Clientes, "Id", "Nome");
        // e no arquivo Views/NotaDeVenda/Create.cshtml:
        // <div class="form-group">
        //     <label asp-for="ClienteId" class="control-label"></label>
        //     <select asp-for="ClienteId" class="form-control" asp-items="ViewBag.ClienteId"></select>
        // </div>
        // e no arquivo Views/NotaDeVenda/Edit.cshtml:
        // <div class="form-group">
        //    <label asp-for="ClienteId" class="control-label"></label>
        //   <select asp-for="ClienteId" class="form-control" asp-items="ViewBag.ClienteId"></select>
        // </div>
        // e no arquivo Views/NotaDeVenda/Details.cshtml:
        // <div class="form-group">
        //    <label asp-for="ClienteId" class="control-label"></label>
        //   <select asp-for="ClienteId" class="form-control" asp-items="ViewBag.ClienteId"></select>
        // </div>
        // e no arquivo Views/NotaDeVenda/Index.cshtml:
        // <th>
        //    @Html.DisplayNameFor(model => model.Cliente)
        // </th>

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Vendedor")]
        public int VendedorId { get; set; }
        public Vendedor? Vendedor { get; set; }

        [Display(Name = "Transportadora")]
        public int? TransportadoraId { get; set; }
        public Transportadora? Transportadora { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Tipo De Pagamento")]
        public int TipoDePagamentoId { get; set; }
        public TipoDePagamento? TipoDePagamento { get; set; }

        // public virtual ICollection<Item> Items { get; set; } // para criar a relação entre NotaDeVenda e Item

        public NotaDeVenda(
            int ClienteId,
            int VendedorId,
            int TipoDePagamentoId,
            int? TransportadoraId = null
        )
        {
            Data = DateTime.Now;
            Status = StatusNotaDeVenda.Ativo;
            this.ClienteId = ClienteId;
            Cliente = null;
            this.VendedorId = VendedorId;
            Vendedor = null;
            this.TransportadoraId = TransportadoraId;
            Transportadora = null;
            this.TipoDePagamentoId = TipoDePagamentoId;
            TipoDePagamento = null;
            // Items = new List<Item>();

        }

        public NotaDeVenda()
        {
            Data = DateTime.Now;
            Status = StatusNotaDeVenda.Ativo;
            ClienteId = 0;
            Cliente = null;
            VendedorId = 0;
            Vendedor = null;
            TransportadoraId = null;
            Transportadora = null;
            TipoDePagamentoId = 0;
            TipoDePagamento = null;
            // Items = new List<Item>();
        } // construtor sem parâmetros
    }
}
//ef migrations remove
