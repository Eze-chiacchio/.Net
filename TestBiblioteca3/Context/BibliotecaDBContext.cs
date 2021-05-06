using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TestBiblioteca3.Models;

namespace TestBiblioteca3.Context
{
    public class BibliotecaDBContext : DbContext
    {
        public
        BibliotecaDBContext(DbContextOptions<BibliotecaDBContext> options) : base(options) { }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Libro> libros { get; set; }
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Alquiler> alquileres { get; set; }
    }
}
