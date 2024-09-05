using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIgeladeira.Models
{
    public class Geladeira
    {
        public List<Prateleiras> Prateleiras { get; private set; }
        string[] hortifruti = { "Acelga", "Alface", "Batata", "Beterraba", "Cenoura", "Couve", "Pepino", "Tomate" };
        string[] laticiniosEnlatados = { "Atum em lata", "Leite", "Queijo", "Manteiga", "Requeijão", "Creme de leite", "Milho em conserva", "Ervilha em conserva" };
        string[] carnesCharcutariaOvos = { "Carne Moída", "Frango", "Carne bovina", "Ovos", "Salame", "Bacon", "Linguiça", "Peito de Peru" };
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
