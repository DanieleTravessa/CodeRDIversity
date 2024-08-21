/*using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;*/
using System;

namespace ExercicioAula
{
    public class Cachorro : MeuAnimal
{
    public string Raca { get; set; } = string.Empty;

    public override void EmitirSom()
    {
        Console.WriteLine($"{Nome} está latindo: Au Au!");
    }
}
}

