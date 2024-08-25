using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIgeladeira.Models
{
    public class Geladeira
    {
        public List<Prateleira> Prateleiras { get; private set; }

        public Geladeira()
        {
            Prateleiras = new List<Prateleira>
            {
                new Prateleira("Hortifruti"),
                new Prateleira("Laticínios"),
                new Prateleira("Carnes, Charcutaria, Ovos")
            };
        }
    }
}
