using System;
using tabuleiro;

namespace xadrez
{
    internal class PartidaXadrez
    {

        public Tabuleiro Tab { get; private set; }
        private int _Turno;
        private Cor _JogadorAtual;
        public bool Terminada { get; set; }



        public PartidaXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            _Turno = 1;
            _JogadorAtual = Cor.Branca;
            ColocarPecas();
            Terminada = false;
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocandoPeca(p, destino);
        }

        private void ColocarPecas()
        {
            Tab.ColocandoPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('c', 1).ToPosicao());
            Tab.ColocandoPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('c', 2).ToPosicao());
            Tab.ColocandoPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('d', 2).ToPosicao());
            Tab.ColocandoPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('e', 2).ToPosicao());
            Tab.ColocandoPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('e', 1).ToPosicao());
            Tab.ColocandoPeca(new Rei(Cor.Branca, Tab), new PosicaoXadrez('d', 1).ToPosicao());

            Tab.ColocandoPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('c', 7).ToPosicao());
            Tab.ColocandoPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('c', 8).ToPosicao());
            Tab.ColocandoPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('d', 7).ToPosicao());
            Tab.ColocandoPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('e', 7).ToPosicao());
            Tab.ColocandoPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('e', 8).ToPosicao());
            Tab.ColocandoPeca(new Rei(Cor.Preta, Tab), new PosicaoXadrez('d', 8).ToPosicao());

        }
    }
}
