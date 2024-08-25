using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIgeladeira.Models
{
    public class Geladeira
    {
        public List<Prateleiras> Prateleiras { get; private set; }

        public Geladeira()
        {
            Prateleiras = new List<Prateleiras>
            {
                new Prateleiras("Hortifruti"),
                new Prateleiras("Laticínios"),
                new Prateleiras("Carnes, Charcutaria, Ovos")
            };
        }
    }
}
