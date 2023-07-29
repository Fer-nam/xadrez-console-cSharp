

using tabuleiro;
using xadrez;

namespace Xadrez_Console
{

    internal class Tela
    {
        public static void ImprimirTela(Tabuleiro tab)
        {
            for(int i = 0; i <tab.Linhas; i++)
            {
                Console.Write(8-i + " ");
                for(int j = 0 ; j <tab.Colunas; j++)
                {
                    if( tab.Pecas(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Tela.ImprimirPeca(tab.Pecas(i, j));
                        Console.Write(" ");
                    }

                }
                
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");

           
        }

        public static void ImprimirPeca(Peca peca)
        {
            if(peca.Coloracao == Cor.Branca)
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
