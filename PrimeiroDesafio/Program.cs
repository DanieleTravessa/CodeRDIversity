/*
Atividade relacionada a primeira semana do Programa CoderDiversity;
Alunas: 
 Daniele Travessa Brito
 Tais Rocha Ribeiro
*/

using System;
using System.Collections;
using static System.Console;
using System.Collections.Generic;

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
                prateleiras[i].ImprimirItens(i);
                WriteLine();
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
                WriteLine($"  Container {i}:");
                for (int j = 0; j < containers[i].Posicoes.Length; j++)
                {
                    WriteLine($"    Posição {j}: {containers[i].Posicoes[j]}");
                }
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