/*using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;*/
using System;

namespace ExercicioAula //-> Define os namespace do meu programa quue será usado em todas as classe
{
    public interface Animal //->Cria uma interface genérica que se aplica a todos os animais
    {
    string Nome { get; set; }
    int Idade { get; set; }
    string Cor { get; set; }

    public void Comer();
    public void Dormir();
    public void EmitirSom();        
    }
}
