using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPIs.Models.Enums;

namespace livrariaAPIs.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quant { get; set; }
        public EnumCategoria CategoriaLivro { get; set; }
        public string Img { get; set; }
    }
}