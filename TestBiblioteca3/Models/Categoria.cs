using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestBiblioteca3.Models
{
    public class Categoria
    {
        [Key]
        public String cate { get; set; }
    }
}
