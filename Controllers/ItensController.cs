#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarcosEduardo.Models;

namespace MarcosEduardo.Controllers
{
    public class ItensController : Controller
    {
        private readonly MyDbContext _context;

        public ItensController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Itens
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Itens.Include(i => i.NotaDeVenda).Include(i => i.Produto);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Itens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Itens
                .Include(i => i.NotaDeVenda)
                .Include(i => i.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Itens/Create
        public IActionResult Create()
        {

            ViewBag.NotaDeVendaId = new SelectList(_context.NotasDeVendas, "Id", "Id");
            ViewBag.ProdutoId = new SelectList(_context.Produtos, "Id", "Descricao");
            ViewBag.Quantidade = 1;
            // Preco inicial é igual ao valor do produto
            ViewBag.Preco = _context.Produtos.Any() ? _context.Produtos.FirstOrDefault().Preco : 0;

            ViewBag.Percentual = 0;

            return View();
        }

        // POST: Itens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Preco,Percentual,Quantidade,NotaDeVendaId,ProdutoId")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NotaDeVendaId"] = new SelectList(_context.NotasDeVendas, "Id", "Id", item.NotaDeVendaId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Descricao", item.ProdutoId);
            return View(item);
        }

        // GET: Itens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Itens.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["NotaDeVendaId"] = new SelectList(_context.NotasDeVendas, "Id", "Id", item.NotaDeVendaId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Descricao", item.ProdutoId);
            return View(item);
        }

        // POST: Itens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Preco,Percentual,Quantidade,NotaDeVendaId,ProdutoId")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
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
            ViewData["NotaDeVendaId"] = new SelectList(_context.NotasDeVendas, "Id", "Id", item.NotaDeVendaId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Descricao", item.ProdutoId);
            return View(item);
        }

        // GET: Itens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Itens
                .Include(i => i.NotaDeVenda)
                .Include(i => i.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Itens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Itens.FindAsync(id);
            _context.Itens.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Itens.Any(e => e.Id == id);
        }
    }
}
