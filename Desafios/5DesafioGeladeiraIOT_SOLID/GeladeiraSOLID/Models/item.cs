using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GeladeiraSOLID.Models
{
    public class Item
    {
        public int Id { get; set; }
         
        public required string Nome { get; set; }
                
        public required string Categoria { get; set; }

        public DateTime Validade { get; set; }
        
        

        [Range(1, 3, ErrorMessage = "A prateleira deve ser um valor entre 1 e 3.")]
        public int Prateleira { get; set; }

        [Range(1, 3, ErrorMessage = "O container deve ser um valor entre 1 e 3.")]
        public int Container { get; set; }
        
        [Range(1, 3, ErrorMessage = "A posição deve ser um valor entre 1 e 3.")]
        public int Posicao { get; set; }
    }
}
