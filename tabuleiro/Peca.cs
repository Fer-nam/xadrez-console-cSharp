

namespace tabuleiro
{
    internal abstract class  Peca
    {

        public Posicao Posicao { get; set; }

        public Cor Coloracao { get; protected set; }

        public int QteMovimento {get; protected set;}

        public Tabuleiro Tab { get; protected set;}

        public Peca( Cor coloracao, Tabuleiro tab)
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

        public abstract bool[,] MovimentosPossiveis(); 

    }
}
