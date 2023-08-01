

using tabuleiro;
using xadrez;
using System.Collections.Generic;

namespace Xadrez_Console
{

    internal class Tela
    {

        public static void ImprimirPartida(PartidaXadrez partida)
        {
            ImprimirTela(partida.Tab);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            Console.WriteLine("Jogado atual: " + partida.JogadorAtual);
            
        }

        public static void ImprimirPecasCapturadas(PartidaXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.Write("Pretas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));

        }

        public static void ImprimirConjunto(HashSet<Peca> Conjunto)
        {
            Console.Write("[");
            foreach(Peca x in Conjunto)
            {
                Console.Write(x+ " ");
            }
            Console.Write("]");

        }
        public static void ImprimirTela(Tabuleiro tab)
        {
            for(int i = 0; i <tab.Linhas; i++)
            {
                Console.Write(8-i + " ");
                for(int j = 0 ; j <tab.Colunas; j++)
                {
                    ImprimirPeca(tab.Pecas(i, j));
                }
                
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");

           
        }

        public static void ImprimirTela(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;



            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posicoesPossiveis[i,j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimirPeca(tab.Pecas(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }

                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;



        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {

                if (peca.Coloracao == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna,linha);

        }
        
        

    }
}
