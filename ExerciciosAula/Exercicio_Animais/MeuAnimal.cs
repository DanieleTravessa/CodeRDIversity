/*using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;*/
using System;

namespace ExercicioAula
{
    public abstract class MeuAnimal : Animal
    {
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
        public string Cor { get; set; } = string.Empty;

        public virtual void Comer()
        {
            Console.WriteLine($"{Nome} está comendo.");
        }

        public virtual void Dormir()
        {
            Console.WriteLine($"{Nome} está dormindo.");
        }

        public abstract void EmitirSom(); // Método abstrato, implementado nas classes derivadas
    }
}

