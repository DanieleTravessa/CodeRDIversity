// See https://aka.ms/new-console-template for more information
using ExercicioAula;

class Program
{
    static void Main(string[] args)
    {
        Cachorro meuCachorro = new Cachorro
        {
            Nome = "Meri",
            Idade = 5,
            Cor = "Caramelo Dourado",
            Raca = "Brazilian Golden Dog"
        };

        Console.WriteLine($"Nome: {meuCachorro.Nome}");
        Console.WriteLine($"Idade: {meuCachorro.Idade}");
        Console.WriteLine($"Cor: {meuCachorro.Cor}");
        Console.WriteLine($"Raça: {meuCachorro.Raca}");

        meuCachorro.Comer();
        meuCachorro.Dormir();
        meuCachorro.EmitirSom();
    }
}

