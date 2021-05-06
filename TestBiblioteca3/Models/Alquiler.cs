using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestBiblioteca3.Models
{
    public class Alquiler
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAlquiler { get; set; }

        public DateTime Inicio { get; set; }

        public DateTime Fin { get; set; }
        public String nombre { get; set; }
        public Libro libro { get; set; }

        public int idUser { get; set; }
        public Usuario usuario { get; set; }
    }
}

