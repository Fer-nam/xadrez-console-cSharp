

using tabuleiro;

namespace xadrez
{
    internal class Rei : Peca
    {
        public Rei(Cor colorcao, Tabuleiro tabu) : base(colorcao, tabu) { }

        public override string ToString()
        {
            return "R";
        }
    }
}
