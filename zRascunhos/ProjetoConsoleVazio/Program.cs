using System;
using System.Collections.Generic;

namespace NovaGeladeiraIOT
{
    class Program
    {
        public static void Main()
        {
            // Definição dos itens guardados na geladeira
            string[] hortifruti = { "Acelga", "Alface", "Batata", "Beterraba", "Cenoura", "Couve", "Pepino", "Tomate" };
            string[] laticiniosEnlatados = { "Atum em lata", "Leite", "Queijo", "Manteiga", "Requeijão", "Creme de leite", "Milho em conserva", "Ervilha em conserva" };
            string[] carnesCharcutariaOvos = { "Carne Moída", "Frango", "Carne bovina", "Ovos", "Salame", "Bacon", "Linguiça", "Peito de Peru" };
            
            // Itens para retirar
            var retirarItem = Console.ReadLine();

            // Itens a adicionar
            var inserirItem = Console.ReadLine();

            // Criação do objeto geladeira com 3 prateleiras
            Geladeira geladeira = new Geladeira();
            geladeira.AdicionarItens(0, hortifruti);
            geladeira.AdicionarItens(1, laticiniosEnlatados);
            geladeira.AdicionarItens(2, carnesCharcutariaOvos);

            // Testando as novas funcionalidades
            geladeira.RemoverItemDePosicao(0, 0, 0); // Remove item da prateleira 0, container 0, posição 0
            geladeira.AdicionarItemEmPosicao(0, 0, 0, inserirItem); // Adiciona item na prateleira 0, container 0, posição 0
            geladeira.AdicionarItemEmPosicao(0, 0, 0, inserirItem); // Tenta adicionar em posição ocupada
            geladeira.RemoverItensDeContainer(1, 0); // Remove todos os itens do container 0 da prateleira 1
            geladeira.AdicionarItensEmContainer(1, 0, new string[] { inserirItem, inserirItem }); // Adiciona itens no container 0 da prateleira 1

            // Imprimindo os itens da geladeira
            geladeira.ImprimirItens();
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

        public void AdicionarItens(int numeroPrateleira, string[] itens)
        {
            prateleiras[numeroPrateleira].AdicionarItens(itens);
        }

        public void ImprimirItens()
        {
            for (int i = 0; i < prateleiras.Length; i++)
            {
                Console.WriteLine($"Prateleira {i}:");
                prateleiras[i].ImprimirItens(i);
                Console.WriteLine();
            }
        }

        // Função para remover item de uma posição específica
        public void RemoverItemDePosicao(int numeroPrateleira, int numeroContainer, int numeroPosicao)
        {
            //geladeira.ImprimirItens();
            prateleiras[numeroPrateleira].RemoverItemDePosicao(numeroContainer, numeroPosicao);
        }

        // Função para adicionar item em uma posição específica
        public void AdicionarItemEmPosicao(int numeroPrateleira, int numeroContainer, int numeroPosicao, string item)
        {
            prateleiras[numeroPrateleira].AdicionarItemEmPosicao(numeroContainer, numeroPosicao, item);
        }

        // Função para remover todos os itens de um container
        public void RemoverItensDeContainer(int numeroPrateleira, int numeroContainer)
        {
            prateleiras[numeroPrateleira].RemoverItensDeContainer(numeroContainer);
        }

        // Função para adicionar itens em um container
        public void AdicionarItensEmContainer(int numeroPrateleira, int numeroContainer, string itens)
        {
            prateleiras[numeroPrateleira].AdicionarItensEmContainer(numeroContainer, itens);
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

        public void AdicionarItens(string[] itens)
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

        public void ImprimirItens(int numeroPrateleira)
        {
            for (int i = 0; i < containers.Length; i++)
            {
                Console.WriteLine($"  Container {i}:");
                for (int j = 0; j < containers[i].Posicoes.Length; j++)
                {
                    Console.WriteLine($"    Posição {j}: {containers[i].Posicoes[j]}");
                }
            }
        }

        // Função para remover item de uma posição específica
        public void RemoverItemDePosicao(int numeroContainer, int numeroPosicao)
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

        // Função para adicionar item em uma posição específica
        public void AdicionarItemEmPosicao(int numeroContainer, int numeroPosicao, string item)
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

        // Função para remover todos os itens de um container
        public void RemoverItensDeContainer(int numeroContainer)
        {
            for (int i = 0; i < containers[numeroContainer].Posicoes.Length; i++)
            {
                containers[numeroContainer].Posicoes[i] = null;
            }
            Console.WriteLine($"Todos os itens foram removidos do container {numeroContainer}.");
        }

        // Função para adicionar itens em um container
        public void AdicionarItensEmContainer(int numeroContainer, string item)
        {
            int itemIndex = 0;

            for (int i = 0; i < containers[numeroContainer].Posicoes.Length; i++)
            {
                if (containers[numeroContainer].Posicoes[i] == null && itemIndex < itens.Length)
                {
                    containers[numeroContainer].Posicoes[i] = itens[itemIndex];
                    itemIndex++;
                }
                else if (containers[numeroContainer].Posicoes[i] != null)
                {
                    Console.WriteLine($"Posição {i} no container {numeroContainer} já está ocupada.");
                }
            }
            if (itemIndex < itens.Length)
            {
                Console.WriteLine($"Não foi possível adicionar todos os itens ao container {numeroContainer}.");
            }
        }
    }

    public class Container
    {
        public string[] Posicoes { get; private set; }

        public Container()
        {
            Posicoes = new string[4];
        }
    }
}
