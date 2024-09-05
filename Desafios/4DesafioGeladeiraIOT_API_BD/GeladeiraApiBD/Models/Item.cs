using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeladeiraApiBD.Models
{
    public class Item
    {
        public int Id { get; set; }
        
        public required string Nome { get; set; } 
        
        public required string Categoria { get; set; }
        
        public int Prateleira { get; set; }
        
        public int Container { get; set; }
        
        public int Posicao { get; set; }
    }
}
