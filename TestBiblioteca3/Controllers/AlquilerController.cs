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
    public class AlquilerController : Controller
    {
        private readonly BibliotecaDBContext _context;

        public AlquilerController(BibliotecaDBContext context)
        {
            _context = context;
        }

        // GET: Alquiler
        public async Task<IActionResult> Index()
        {
            var bibliotecaDBContext = _context.alquileres.Include(a => a.libro).Include(a => a.usuario);
            return View(await bibliotecaDBContext.ToListAsync());
        }

        // GET: Alquiler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquiler = await _context.alquileres
                .Include(a => a.libro)
                .Include(a => a.usuario)
                .FirstOrDefaultAsync(m => m.IdAlquiler == id);
            if (alquiler == null)
            {
                return NotFound();
            }

            return View(alquiler);
        }

        // GET: Alquiler/Create
        public IActionResult Create()
        {
            ViewData["nombre"] = new SelectList(_context.libros, "nombre", "nombre");
            ViewData["idUser"] = new SelectList(_context.usuarios, "IdUser", "IdUser");
            return View();
        }

        // POST: Alquiler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlquiler,Inicio,Fin,nombre,idUser")] Alquiler alquiler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alquiler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["nombre"] = new SelectList(_context.libros, "nombre", "nombre", alquiler.nombre);
            ViewData["idUser"] = new SelectList(_context.usuarios, "IdUser", "IdUser", alquiler.idUser);
            return View(alquiler);
        }

        // GET: Alquiler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquiler = await _context.alquileres.FindAsync(id);
            if (alquiler == null)
            {
                return NotFound();
            }
            ViewData["nombre"] = new SelectList(_context.libros, "nombre", "nombre", alquiler.nombre);
            ViewData["idUser"] = new SelectList(_context.usuarios, "IdUser", "IdUser", alquiler.idUser);
            return View(alquiler);
        }

        // POST: Alquiler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAlquiler,Inicio,Fin,nombre,idUser")] Alquiler alquiler)
        {
            if (id != alquiler.IdAlquiler)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alquiler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlquilerExists(alquiler.IdAlquiler))
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
            ViewData["nombre"] = new SelectList(_context.libros, "nombre", "nombre", alquiler.nombre);
            ViewData["idUser"] = new SelectList(_context.usuarios, "IdUser", "IdUser", alquiler.idUser);
            return View(alquiler);
        }

        // GET: Alquiler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquiler = await _context.alquileres
                .Include(a => a.libro)
                .Include(a => a.usuario)
                .FirstOrDefaultAsync(m => m.IdAlquiler == id);
            if (alquiler == null)
            {
                return NotFound();
            }

            return View(alquiler);
        }

        // POST: Alquiler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alquiler = await _context.alquileres.FindAsync(id);
            _context.alquileres.Remove(alquiler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlquilerExists(int id)
        {
            return _context.alquileres.Any(e => e.IdAlquiler == id);
        }
    }
}
