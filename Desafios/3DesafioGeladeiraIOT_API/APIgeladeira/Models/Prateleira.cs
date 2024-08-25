using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIgeladeira.Models
{
    public class Prateleira
    {
        public string Nome { get; private set; }
        public List<Container> Containers { get; private set; }

        public Prateleira(string nome)
        {
            Nome = nome;
            Containers = new List<Container>
            {
                new Container(),
                new Container()
            };
        }
    }
}
