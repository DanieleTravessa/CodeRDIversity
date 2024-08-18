using System;
using System.Collections.Generic;
/*Desafio da 2ª semana.
Aluna: Daniele Travessa Brito*/ 

namespace Geladeiraiot
{
    class Program
    {
        public static void Main()
        {
            try
            {
                // Definição dos itens guardados na geladeira
                string[] hortifruti = { "Acelga", "Alface", "Batata", "Beterraba", "Cenoura", "Couve", "Pepino", "Tomate" };
                string[] laticiniosEnlatados = { "Atum em lata", "Leite", "Queijo", "Manteiga", "Requeijão", "Creme de leite", "Milho em conserva", "Ervilha em conserva" };
                string[] carnesCharcutariaOvos = { "Carne Moída", "Frango", "Carne bovina", "Ovos", "Salame", "Bacon", "Linguiça", "Peito de Peru" };

                // Criação do objeto geladeira com 3 prateleiras
                Geladeira geladeira = new Geladeira();
                geladeira.AdicionarItens(0, hortifruti);
                geladeira.AdicionarItens(1, laticiniosEnlatados);
                geladeira.AdicionarItens(2, carnesCharcutariaOvos);

                while (true)
                {
                    Console.WriteLine("Escolha uma ação:");
                    Console.WriteLine("1. Adicionar item em uma posição específica");
                    Console.WriteLine("2. Remover item de uma posição específica");
                    Console.WriteLine("3. Remover todos os itens de um container");
                    Console.WriteLine("4. Imprimir conteúdo da geladeira");
                    Console.WriteLine("5. Sair");

                    string escolha = Console.ReadLine();

                    switch (escolha)
                    {
                        case "1":
                            AdicionarItem(geladeira);
                            break;
                        case "2":
                            RemoverItem(geladeira);
                            break;
                        case "3":
                            RemoverItensDeContainer(geladeira);       
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
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }

        static void AdicionarItem(Geladeira geladeira)
        {
            try
            {
                Console.WriteLine("Indique o número da prateleira:");
                Console.WriteLine("0 - Hortifruti");
                Console.WriteLine("1 - Laticínios");
                Console.WriteLine("2 - Carnes, Charcutaria, Ovos");
                int prateleira = int.Parse(Console.ReadLine());

                Console.WriteLine("Em qual container (0, 1)?");
                int container = int.Parse(Console.ReadLine());

                Console.WriteLine("Em qual posição (0, 1, 2, 3)?");
                int posicao = int.Parse(Console.ReadLine());

                Console.WriteLine("Informe o item:");
                string item = Console.ReadLine();

                geladeira.AdicionarItemEmPosicao(prateleira, container, posicao, item);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar item: {ex.Message}");
            }
        }

        static void RemoverItem(Geladeira geladeira)
        {
            try
            {
                Console.WriteLine("Indique o número da prateleira:");
                Console.WriteLine("0 - Hortifruti");
                Console.WriteLine("1 - Laticínios");
                Console.WriteLine("2 - Carnes, Charcutaria, Ovos");
                int prateleira = int.Parse(Console.ReadLine());

                Console.WriteLine("Em qual container (0, 1)?");
                int container = int.Parse(Console.ReadLine());

                Console.WriteLine("Em qual posição (0, 1, 2, 3)?");
                int posicao = int.Parse(Console.ReadLine());

                geladeira.RemoverItemDePosicao(prateleira, container, posicao);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao remover item: {ex.Message}");
            }
        }
        static void RemoverItensDeContainer(Geladeira geladeira)
{
    try
    {
        Console.WriteLine("Indique o número da prateleira:");
        Console.WriteLine("0 - Hortifruti");
        Console.WriteLine("1 - Laticínios");
        Console.WriteLine("2 - Carnes, Charcutaria, Ovos");
        int prateleira = int.Parse(Console.ReadLine());

        Console.WriteLine("Qual container (0, 1)?");
        int container = int.Parse(Console.ReadLine());

        geladeira.RemoverItensDeContainer(prateleira, container);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao remover itens do container: {ex.Message}");
    }
}

    }

    public class Geladeira
    {
        private Prateleira[] prateleiras;

        public Geladeira()
        {
            try
            {
                prateleiras = new Prateleira[3];
                for (int i = 0; i < prateleiras.Length; i++)
                {
                    prateleiras[i] = new Prateleira();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inicializar a geladeira: {ex.Message}");
            }
        }

        public void AdicionarItens(int numeroPrateleira, string[] itens)
        {
            try
            {
                prateleiras[numeroPrateleira].AdicionarItens(itens);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar itens na prateleira {numeroPrateleira}: {ex.Message}");
            }
        }

        public void ImprimirItens()
        {
            try
            {
                string[] nomesPrateleiras = { "Hortifruti", "Laticínios", "Carnes, Charcutaria, Ovos" };
                
                for (int i = 0; i < prateleiras.Length; i++)
                {
                    Console.WriteLine($"Prateleira {i} - {nomesPrateleiras[i]}:");
                    prateleiras[i].ImprimirItens(i);
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao imprimir os itens: {ex.Message}");
            }
        }

        public void RemoverItemDePosicao(int numeroPrateleira, int numeroContainer, int numeroPosicao)
        {
            try
            {
                prateleiras[numeroPrateleira].RemoverItemDePosicao(numeroContainer, numeroPosicao);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao remover item da posição {numeroPosicao} no container {numeroContainer} da prateleira {numeroPrateleira}: {ex.Message}");
            }
        }

        public void AdicionarItemEmPosicao(int numeroPrateleira, int numeroContainer, int numeroPosicao, string item)
        {
            try
            {
                prateleiras[numeroPrateleira].AdicionarItemEmPosicao(numeroContainer, numeroPosicao, item);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar item na posição {numeroPosicao} no container {numeroContainer} da prateleira {numeroPrateleira}: {ex.Message}");
            }
        }
           public void RemoverItensDeContainer(int numeroPrateleira, int numeroContainer)
        {
            try
            {
                prateleiras[numeroPrateleira].RemoverItensDeContainer(numeroContainer);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao remover itens do container {numeroContainer}: {ex.Message}");
            }
        }

    }          
    
    public class Prateleira
    {
        private Container[] containers;

        public Prateleira()
        {
            try
            {
                containers = new Container[2];
                for (int i = 0; i < containers.Length; i++)
                {
                    containers[i] = new Container();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inicializar a prateleira: {ex.Message}");
            }
        }

        public void AdicionarItens(string[] itens)
        {
            try
            {
                int itemIndex = 0;

                for (int i = 0; i < containers.Length; i++)
                {
                    for (int j = 0; j < containers[i].Posicoes.Length; j++)
                    {
                        if (itemIndex < itens.Length)
                        {
                            containers[i].Posicoes[j] = itens[itemIndex];
                            itemIndex++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar itens na prateleira: {ex.Message}");
            }
        }

        public void ImprimirItens(int numeroPrateleira)
        {
            try
            {
                for (int i = 0; i < containers.Length; i++)
                {
                    Console.WriteLine($"  Container {i}:");
                    for (int j = 0; j < containers[i].Posicoes.Length; j++)
                    {
                        Console.WriteLine($"    Posição {j}: {containers[i].Posicoes[j] ?? "Vazia"}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao imprimir itens da prateleira {numeroPrateleira}: {ex.Message}");
            }
        }

        public void RemoverItemDePosicao(int numeroContainer, int numeroPosicao)
        {
            try
            {
                if (containers[numeroContainer].Posicoes[numeroPosicao] != null)
                {
                    containers[numeroContainer].Posicoes[numeroPosicao] = null;
                    Console.WriteLine($"Item removido da posição {numeroPosicao} no container {numeroContainer}.");
                }
                else
                {
                    Console.WriteLine($"Posição {numeroPosicao} no container {numeroContainer} já está vazia.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao remover item da posição {numeroPosicao} no container {numeroContainer}: {ex.Message}");
            }
        }

        public void AdicionarItemEmPosicao(int numeroContainer, int numeroPosicao, string item)
        {
            try
            {
                if (containers[numeroContainer].Posicoes[numeroPosicao] == null)
                {
                    containers[numeroContainer].Posicoes[numeroPosicao] = item;
                    Console.WriteLine($"Item '{item}' adicionado na posição {numeroPosicao} no container {numeroContainer}.");
                }
                else
                {
                    Console.WriteLine($"Posição {numeroPosicao} no container {numeroContainer} já está ocupada.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar item na posição {numeroPosicao} no container {numeroContainer}: {ex.Message}");
            }
        }

        public void RemoverItensDeContainer(int numeroContainer)
        {
            try
            {
                for (int i = 0; i < containers[numeroContainer].Posicoes.Length; i++)
                {
                    containers[numeroContainer].Posicoes[i] = null;
                }
                Console.WriteLine($"Todos os itens foram removidos do container {numeroContainer}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao remover itens do container {numeroContainer}: {ex.Message}");
            }
        }
    }

    public class Container
    {
        public string[] Posicoes { get; private set; }

        public Container()
        {
            try
            {
                Posicoes = new string[4];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inicializar o container: {ex.Message}");
            }
        }
    }
}
