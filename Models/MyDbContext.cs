using Microsoft.EntityFrameworkCore;

namespace MarcosEduardo.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            NotasDeVendas = Set<NotaDeVenda>();
            Clientes = Set<Cliente>();
            Vendedores = Set<Vendedor>();
            Transportadoras = Set<Transportadora>();
            Pagamentos = Set<Pagamento>();
            TiposDePagamento = Set<TipoDePagamento>();
            PagamentosComCartao = Set<PagamentoComCartao>();
            PagamentosComCheque = Set<PagamentoComCheque>();
            Itens = Set<Item>();
            Produtos = Set<Produto>();
            Marcas = Set<Marca>();
        }

        public DbSet<NotaDeVenda> NotasDeVendas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Transportadora> Transportadoras { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<TipoDePagamento> TiposDePagamento { get; set; }
        public DbSet<PagamentoComCartao> PagamentosComCartao { get; set; }
        public DbSet<PagamentoComCheque> PagamentosComCheque { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
    }
}

/* 
gerando controller com views
dotnet-aspnet-codegenerator controller -name NotasDeVendasController -m NotaDeVenda -dc MyDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
dotnet restore
dotnet build
dotnet-aspnet-codegenerator controller -name ClientesController -m Cliente -dc MyDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
dotnet restore
dotnet build
dotnet-aspnet-codegenerator controller -name VendedoresController -m Vendedor -dc MyDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
dotnet restore
dotnet build
dotnet-aspnet-codegenerator controller -name TransportadorasController -m Transportadora -dc MyDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
dotnet restore
dotnet build
dotnet-aspnet-codegenerator controller -name PagamentosController -m Pagamento -dc MyDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
dotnet restore
dotnet build
dotnet-aspnet-codegenerator controller -name TiposDePagamentosController -m TipoDePagamento -dc MyDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
dotnet restore
dotnet build
dotnet-aspnet-codegenerator controller -name PagamentosComCartaoController -m PagamentoComCartao -dc MyDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
dotnet restore
dotnet build
dotnet-aspnet-codegenerator controller -name PagamentosComChequeController -m PagamentoComCheque -dc MyDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
dotnet restore
dotnet build
dotnet-aspnet-codegenerator controller -name ItensController -m Item -dc MyDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
dotnet restore
dotnet build
dotnet-aspnet-codegenerator controller -name MarcasController -m Marca -dc MyDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
dotnet restore
dotnet build
dotnet-aspnet-codegenerator controller -name ProdutosController -m Produto -dc MyDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
dotnet restore
dotnet build
*/