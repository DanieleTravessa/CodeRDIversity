using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIgeladeira.Models
{
    public class Prateleiras
    {
        public string Prateleira { get; private set; }
        public List<Container> Containers { get; private set; }

        public Prateleiras(string nome)
        {
            Prateleira = nome;
            Containers = new List<Container>
            {
                new Container(),
                new Container()
            };
        }
    }
}
