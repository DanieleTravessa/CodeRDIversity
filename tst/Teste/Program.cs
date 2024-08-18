using System;
using System.Collections.Generic;

namespace Geladeiraiot
{
    class Program
    {
        public static void Main()
        {
            // Definição dos itens guardados na geladeira
            string[] hortifruti = { "Acelga", "Alface", "Batata", "Beterraba", "Cenoura", "Couve", "Pepino", "Tomate" };
            string[] laticiniosEnlatados = { "Atum em lata", "Leite", "Queijo", "Manteiga", "Requeijão", "Creme de leite", "Milho em conserva", "Ervilha em conserva" };
            string[] carnesCharcutariaOvos = { "Carne Moída", "Frango", "Carne bovina", "Ovos", "Salame", "Bacon", "Linguiça", "Peito de Peru" };

            
            // Criação do objeto geladeira com 3 prateleiras
            Geladeira geladeira = new Geladeira();

            while (true)
            {
                Console.WriteLine("Escolha uma ação:");
                Console.WriteLine("1. Guardar as compras");
                Console.WriteLine("2. Adicionar itens");
                Console.WriteLine("3. Remover itens");
                Console.WriteLine("4. Imprimir conteúdo da geladeira");
                Console.WriteLine("5. Sair");

                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        GuardarCompras(geladeira);
                        break;
                    case "2":
                        AdicionarItens(geladeira);
                        break;
                    case "3":
                        RemoverItens(geladeira);
                        break;
                    case "4":
                        geladeira.ImprimirItens();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void AdicionarItens(Geladeira geladeira)
        {
            Console.WriteLine("Em qual prateleira (0, 1, 2)?");
            int prateleira = int.Parse(Console.ReadLine());

            Console.WriteLine("Em qual container (0, 1)?");
            int container = int.Parse(Console.ReadLine());

            Console.WriteLine("Quantos itens deseja adicionar?");
            int quantidade = int.Parse(Console.ReadLine());

            string[] itens = new string[quantidade];
            for (int i = 0; i < quantidade; i++)
            {
                Console.WriteLine($"Informe o item {i + 1}:");
                itens[i] = Console.ReadLine();
            }

            geladeira.AdicionarItensNaPosicao(prateleira, container, itens);
        }

        static void RemoverItens(Geladeira geladeira)
        {
            Console.WriteLine("Em qual prateleira (0, 1, 2)?");
            int prateleira = int.Parse(Console.ReadLine());

            Console.WriteLine("Em qual container (0, 1)?");
            int container = int.Parse(Console.ReadLine());

            Console.WriteLine("Quantos itens deseja remover?");
            int quantidade = int.Parse(Console.ReadLine());

            geladeira.RemoverItensDaPosicao(prateleira, container, quantidade);
        }
    }

    public class Geladeira
    {
        private Prateleira[] prateleiras;

        public Geladeira()
        {
            prateleiras = new Prateleira[3];
            for (int i = 0; i < prateleiras.Length; i++)
            {
                prateleiras[i] = new Prateleira();
            }
        }

        public void AdicionarItensNaPosicao(int numeroPrateleira, int numeroContainer, string[] itens)
        {
            prateleiras[numeroPrateleira].AdicionarItensNaPosicao(numeroContainer, itens);
        }

        public void RemoverItensDaPosicao(int numeroPrateleira, int numeroContainer, int quantidade)
        {
            prateleiras[numeroPrateleira].RemoverItensDaPosicao(numeroContainer, quantidade);
        }

        public void ImprimirItens()
        {
            for (int i = 0; i < prateleiras.Length; i++)
            {
                Console.WriteLine($"Prateleira {i}:");
                prateleiras[i].ImprimirItens();
                Console.WriteLine();
            }
        }
    }

    public class Prateleira
    {
        private Container[] containers;

        public Prateleira()
        {
            containers = new Container[2];
            for (int i = 0; i < containers.Length; i++)
            {
                containers[i] = new Container();
            }
        }

        public void AdicionarItensNaPosicao(int numeroContainer, string[] itens)
        {
            containers[numeroContainer].AdicionarItens(itens);
        }

        public void RemoverItensDaPosicao(int numeroContainer, int quantidade)
        {
            containers[numeroContainer].RemoverItens(quantidade);
        }

        public void ImprimirItens()
        {
            for (int i = 0; i < containers.Length; i++)
            {
                Console.WriteLine($"  Container {i}:");
                containers[i].ImprimirItens();
            }
        }
    }

    public class Container
    {
        private List<string> Posicoes;

        public Container()
        {
            Posicoes = new List<string>(new string[4]);
        }

        public void AdicionarItens(string[] itens)
        {
            try
            {
                int itemIndex = 0;

                for (int i = 0; i < Posicoes.Count; i++)
                {
                    if (Posicoes[i] == null && itemIndex < itens.Length)
                    {
                        Posicoes[i] = itens[itemIndex];
                        itemIndex++;
                    }
                    else if (Posicoes[i] != null)
                    {
                        Console.WriteLine($"Posição {i} no container já está ocupada.");
                    }
                }

                if (itemIndex < itens.Length)
                {
                    Console.WriteLine("Não foi possível adicionar todos os itens.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar itens no container: {ex.Message}");
            }
        }

        public void RemoverItens(int quantidade)
        {
            try
            {
                int removido = 0;

                for (int i = 0; i < Posicoes.Count; i++)
                {
                    if (Posicoes[i] != null && removido < quantidade)
                    {
                        Posicoes[i] = null;
                        removido++;
                    }
                }

                if (removido < quantidade)
                {
                    Console.WriteLine("Não havia itens suficientes para remover.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao remover itens do container: {ex.Message}");
            }
        }

        public void ImprimirItens()
        {
            for (int i = 0; i < Posicoes.Count; i++)
            {
                Console.WriteLine($"    Posição {i}: {(Posicoes[i] ?? "Vazia")}");
            }
        }
    }
}

