using System;
using tabuleiro;
using System.Collections.Generic;

namespace xadrez
{
    internal class PartidaXadrez
    {

        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; set; }
        private HashSet<Peca> Pecs;
        private HashSet<Peca> Capturada;


        public PartidaXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            ColocarPecas();
            Terminada = false;
            Pecs = new HashSet<Peca>();
            Capturada = new HashSet<Peca>();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocandoPeca(p, destino);

            if(pecaCapturada != null)
            {
                Capturada.Add(pecaCapturada);
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        public void ValidaPosicaoOrigem(Posicao pos)
        {
            if(Tab.Pecas(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if(JogadorAtual != Tab.Pecas(pos).Coloracao)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!Tab.Pecas(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem!");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.Pecas(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida! ");
            }
        }

        public void MudaJogador()
        {
            if(JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in Capturada)
            {
                if(x.Coloracao == cor)
                {
                    aux.Add(x);
                }

            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Pecs)
            {
                if (x.Coloracao == cor)
                {
                    aux.Add(x);
                }

            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocandoPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecs.Add(peca);
        }
        private void ColocarPecas()
        {
            ColocarNovaPeca('c', 1, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca('c', 2, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca('d', 2, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca('e', 2, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca('e', 1, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca('d', 1, new Rei(Cor.Branca, Tab));

            ColocarNovaPeca('c', 7, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca('c', 8, new Rei(Cor.Branca, Tab));
            ColocarNovaPeca('d', 7, new Rei(Cor.Branca, Tab));
            ColocarNovaPeca('e', 7, new Rei(Cor.Branca, Tab));
            ColocarNovaPeca('e', 8, new Rei(Cor.Branca, Tab));
            ColocarNovaPeca('d', 8, new Rei(Cor.Branca, Tab));
            



        }
    }
}
