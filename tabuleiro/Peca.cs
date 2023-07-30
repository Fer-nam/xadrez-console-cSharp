

namespace tabuleiro
{
    internal abstract class Peca
    {

        public Posicao Posicao { get; set; }

        public Cor Coloracao { get; protected set; }

        public int QteMovimento { get; protected set; }

        public Tabuleiro Tab { get; protected set; }

        public Peca(Cor coloracao, Tabuleiro tab)
        {
            Posicao = null;
            Coloracao = coloracao;
            Tab = tab;
            QteMovimento = 0;
        }

        public void IncrementarQteMovimentos()
        {
            QteMovimento++;
        }

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();

            for (int i = 0; i < Tab.Linhas; i++)
            {
                for (int j = 0; j < Tab.Colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();

    }
}
