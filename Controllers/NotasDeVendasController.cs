#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarcosEduardo.Models;

namespace MarcosEduardo.Controllers
{
    public class NotasDeVendasController : Controller
    {
        private readonly MyDbContext _context;

        public NotasDeVendasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: NotasDeVendas
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.NotasDeVendas.Include(n => n.Cliente).Include(n => n.TipoDePagamento).Include(n => n.Transportadora).Include(n => n.Vendedor);
            return View(await myDbContext.ToListAsync());
        }

        // GET: NotasDeVendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDeVenda = await _context.NotasDeVendas
                .Include(n => n.Cliente)
                .Include(n => n.TipoDePagamento)
                .Include(n => n.Transportadora)
                .Include(n => n.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notaDeVenda == null)
            {
                return NotFound();
            }

            return View(notaDeVenda);
        }

        // GET: NotasDeVendas/Create
        public IActionResult Create()
        {
            // Cria uma nova NotaDeVenda com Status definido como Ativo
            var notaDeVenda = new NotaDeVenda
            {
                Status = StatusNotaDeVenda.Ativo
            };

            // Cria o SelectList para Status
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(StatusNotaDeVenda)));
            ViewBag.ClienteId = _context.Clientes.Any() ? new SelectList(_context.Clientes, "Id", "Nome") : null;
            ViewBag.TipoDePagamentoId = _context.TiposDePagamento.Any() ? new SelectList(_context.TiposDePagamento, "Id", "Discriminator") : null;
            ViewBag.TransportadoraId = _context.Transportadoras.Any() ? new SelectList(_context.Transportadoras, "Id", "Nome") : null;
            ViewBag.VendedorId = _context.Vendedores.Any() ? new SelectList(_context.Vendedores, "Id", "Nome") : null;
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(StatusNotaDeVenda)), StatusNotaDeVenda.Ativo);
            // modelos para utilização nos models de cliente, vendedor, transportadora e tipo de pagamento
            ViewBag.ClienteModel = new Cliente();
            ViewBag.VendedorModel = new Vendedor();
            ViewBag.TransportadoraModel = new Transportadora();
            ViewBag.TipoDePagamentoModel = new TipoDePagamento();
            return View(notaDeVenda);
        }

        // POST: NotasDeVendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,Status,ClienteId,VendedorId,TransportadoraId,TipoDePagamentoId")] NotaDeVenda notaDeVenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notaDeVenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", notaDeVenda.ClienteId);
            ViewData["TipoDePagamentoId"] = new SelectList(_context.TiposDePagamento, "Id", "Discriminator", notaDeVenda.TipoDePagamentoId);
            ViewData["TransportadoraId"] = new SelectList(_context.Transportadoras, "Id", "Nome", notaDeVenda.TransportadoraId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "Id", "Nome", notaDeVenda.VendedorId);
            return View(notaDeVenda);
        }

        // GET: NotasDeVendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDeVenda = await _context.NotasDeVendas.FindAsync(id);
            if (notaDeVenda == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", notaDeVenda.ClienteId);
            ViewData["TipoDePagamentoId"] = new SelectList(_context.TiposDePagamento, "Id", "Discriminator", notaDeVenda.TipoDePagamentoId);
            ViewData["TransportadoraId"] = new SelectList(_context.Transportadoras, "Id", "Nome", notaDeVenda.TransportadoraId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "Id", "Nome", notaDeVenda.VendedorId);
            return View(notaDeVenda);
        }

        // POST: NotasDeVendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,Status,ClienteId,VendedorId,TransportadoraId,TipoDePagamentoId")] NotaDeVenda notaDeVenda)
        {
            if (id != notaDeVenda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notaDeVenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaDeVendaExists(notaDeVenda.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", notaDeVenda.ClienteId);
            ViewData["TipoDePagamentoId"] = new SelectList(_context.TiposDePagamento, "Id", "Discriminator", notaDeVenda.TipoDePagamentoId);
            ViewData["TransportadoraId"] = new SelectList(_context.Transportadoras, "Id", "Nome", notaDeVenda.TransportadoraId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "Id", "Nome", notaDeVenda.VendedorId);
            return View(notaDeVenda);
        }

        // GET: NotasDeVendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDeVenda = await _context.NotasDeVendas
                .Include(n => n.Cliente)
                .Include(n => n.TipoDePagamento)
                .Include(n => n.Transportadora)
                .Include(n => n.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notaDeVenda == null)
            {
                return NotFound();
            }

            return View(notaDeVenda);
        }

        // POST: NotasDeVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notaDeVenda = await _context.NotasDeVendas.FindAsync(id);
            _context.NotasDeVendas.Remove(notaDeVenda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotaDeVendaExists(int id)
        {
            return _context.NotasDeVendas.Any(e => e.Id == id);
        }
    }
}
