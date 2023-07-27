using System;
using tabuleiro;

namespace xadrez
{
    internal class PartidaXadrez
    {

        public Tabuleiro Tab { get; private set; }
        private int _Turno;
        private Cor _JogadorAtual;


        public PartidaXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            _Turno = 1;
            _JogadorAtual = Cor.Branca;
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada =Tab.RetirarPeca(destino);
        }

        private void ColocarPecas()
        {
            
            
        }
    }
}
