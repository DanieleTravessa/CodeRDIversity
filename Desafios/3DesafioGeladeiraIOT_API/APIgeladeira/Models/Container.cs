using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIgeladeira.Models
{
    public class Container
    {
        public string[] Posicoes { get; private set; }

        public Container()
        {
            Posicoes = new string[4];
        }
    }
}
