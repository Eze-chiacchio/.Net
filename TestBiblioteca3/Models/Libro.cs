using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestBiblioteca3.Models
{
    public class Libro
    {
        [Key]
        public String nombre { get; set; }
        public Boolean disponible { get; set; }

        public String cate { get; set; }
        public Categoria categoria { get; set; }
    }
}
