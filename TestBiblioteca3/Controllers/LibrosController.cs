using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestBiblioteca3.Context;
using TestBiblioteca3.Models;

namespace TestBiblioteca3.Controllers
{
    public class LibrosController : Controller
    {
        private readonly BibliotecaDBContext _context;

        public LibrosController(BibliotecaDBContext context)
        {
            _context = context;
        }

        // GET: Libros
        public async Task<IActionResult> Index()
        {
            var bibliotecaDBContext = _context.libros.Include(l => l.categoria);
            return View(await bibliotecaDBContext.ToListAsync());
        }

        // GET: Libros/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.libros
                .Include(l => l.categoria)
                .FirstOrDefaultAsync(m => m.nombre == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libros/Create
        public IActionResult Create()
        {
            ViewData["cate"] = new SelectList(_context.categorias, "cate", "cate");
            return View();
        }

        // POST: Libros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nombre,disponible,cate")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["cate"] = new SelectList(_context.categorias, "cate", "cate", libro.cate);
            return View(libro);
        }

        // GET: Libros/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["cate"] = new SelectList(_context.categorias, "cate", "cate", libro.cate);
            return View(libro);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("nombre,disponible,cate")] Libro libro)
        {
            if (id != libro.nombre)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.nombre))
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
            ViewData["cate"] = new SelectList(_context.categorias, "cate", "cate", libro.cate);
            return View(libro);
        }

        // GET: Libros/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.libros
                .Include(l => l.categoria)
                .FirstOrDefaultAsync(m => m.nombre == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var libro = await _context.libros.FindAsync(id);
            _context.libros.Remove(libro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(string id)
        {
            return _context.libros.Any(e => e.nombre == id);
        }
    }
}
