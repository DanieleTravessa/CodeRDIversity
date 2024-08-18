// See https://aka.ms/new-console-template for more information
using System;
using static System.Console;
namespace GeladeiraIOT
{
    class Program
    {
        public static void Main()
        {
            // Definição do itens guardados na geladeira
            string[] hortifruti = { "Acelga", "Alface", "Batata", "Beterraba", "Cenoura", "Couve", "Pepino", "Tomate" };
            string[] laticiniosEnlatados = { "Atum em lata", "Leite", "Queijo", "Manteiga", "Requeijão", "Creme de leite", "Milho em conserva", "Ervilha em conserva" };
            string[] carnesCharcutariaOvos = { "Carne Moída", "Frango", "Carne bovina", "Ovos", "Salame", "Bacon", "Linguiça", "Peito de Peru" };

            // Criação do objeto geladeira com 3 prateleiras
            Geladeira geladeira = new Geladeira();
            geladeira.AdicionarItens(0, hortifruti);
            geladeira.AdicionarItens(1, laticiniosEnlatados);
            geladeira.AdicionarItens(2, carnesCharcutariaOvos);

            // Imprimindo os itens da geladeira
            geladeira.ImprimirItens();

            // Testando as novas funcionalidades
            WriteLine("Removendo 'Batata' da prateleira 0:");
            geladeira.RemoverItem(0, "Batata");
            geladeira.ImprimirItens();

            WriteLine("Adicionando 'Batata' na posição 2 da prateleira 0:");
            geladeira.AdicionarItemNaPosicao(0, "Batata", 2);
            geladeira.ImprimirItens();

            WriteLine("Removendo itens do container 1 da prateleira 0:");
            geladeira.RemoverItensContainer(0, 1);
            geladeira.ImprimirItens();

            WriteLine("Adicionando itens no container 0 da prateleira 1:");
            geladeira.AdicionarItensContainer(1, 0, laticiniosEnlatados);
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
                WriteLine($"Prateleira {i}:");
                prateleiras[i].ImprimirItens();
                WriteLine();
            }
        }

        public void RemoverItem(int numeroPrateleira, string item)
        {
            prateleiras[numeroPrateleira].RemoverItem(item);
        }

        public void AdicionarItemNaPosicao(int numeroPrateleira, string item, int posicao)
        {
            prateleiras[numeroPrateleira].AdicionarItemNaPosicao(item, posicao);
        }

        public void RemoverItensContainer(int numeroPrateleira, int numeroContainer)
        {
            prateleiras[numeroPrateleira].RemoverItensContainer(numeroContainer);
        }

        public void AdicionarItensContainer(int numeroPrateleira, int numeroContainer, string[] itens)
        {
            prateleiras[numeroPrateleira].AdicionarItensContainer(numeroContainer, itens);
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

        public void ImprimirItens()
        {
            for (int i = 0; i < containers.Length; i++)
            {
                WriteLine($"  Container {i}:");
                for (int j = 0; j < containers[i].Posicoes.Length; j++)
                {
                    WriteLine($"    Posição {j}: {containers[i].Posicoes[j]}");
                }
            }
        }

        public void RemoverItem(string item)
        {
            foreach (var container in containers)
            {
                for (int i = 0; i < container.Posicoes.Length; i++)
                {
                    if (container.Posicoes[i] == item)
                    {
                        container.Posicoes[i] = null;
                        return;
                    }
                }
            }

            WriteLine($"Item '{item}' não encontrado na geladeira.");
        }

        public void AdicionarItemNaPosicao(string item, int posicao)
        {
            foreach (var container in containers)
            {
                if (posicao >= 0 && posicao < container.Posicoes.Length)
                {
                    if (container.Posicoes[posicao] == null)
                    {
                        container.Posicoes[posicao] = item;
                        return;
                    }
                    else
                    {
                        WriteLine($"Posição {posicao} já está ocupada.");
                        return;
                    }
                }
            }

            WriteLine("Posição inválida.");
        }

        public void RemoverItensContainer(int numeroContainer)
        {
            if (numeroContainer >= 0 && numeroContainer < containers.Length)
            {
                Array.Clear(containers[numeroContainer].Posicoes, 0, containers[numeroContainer].Posicoes.Length);
            }
            else
            {
                WriteLine("Número do container inválido.");
            }
        }

        public void AdicionarItensContainer(int numeroContainer, string[] itens)
        {
            if (numeroContainer >= 0 && numeroContainer < containers.Length)
            {
                Container container = containers[numeroContainer];
                int itemIndex = 0;

                for (int i = 0; i < container.Posicoes.Length; i++)
                {
                    if (itemIndex < itens.Length)
                    {
                        if (container.Posicoes[i] == null)
                        {
                            container.Posicoes[i] = itens[itemIndex];
                            itemIndex++;
                        }
                    }
                }

                if (itemIndex < itens.Length)
                {
                    WriteLine("O container não tem espaço suficiente para todos os itens.");
                }
            }
            else
            {
                WriteLine("Número do container inválido.");
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
