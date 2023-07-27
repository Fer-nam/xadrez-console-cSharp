
using tabuleiro;

namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        private Peca[,] _Pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            _Pecas = new Peca[Linhas, Colunas];
        }

        public Peca Pecas(int linha, int coluna)
        {
            return _Pecas[linha, coluna];
        }

        public bool ExistePosicao(Posicao pos)
        {
            ValidarPosicao(pos); 
            return Pecas(pos) != null;
        }

        public Peca Pecas(Posicao pos)
        {
            return _Pecas[pos.Linha, pos.Coluna];
        }

        public void ColocandoPeca(Peca p, Posicao pos)
        {
            if (ExistePosicao(pos))
            {
                throw new TabuleiroException("Ja existe uma peça nessa posição!");
            }
            _Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;

        }

        public bool PosicaoValida(Posicao pos)
        {
        if(pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna< 0 || pos.Coluna >= Colunas)
            {
                return false;
            }

            return true;
        }

        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException(" Posição inválida! ");
            }
        }


    }
}
