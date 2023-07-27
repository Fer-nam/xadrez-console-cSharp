

using tabuleiro;

namespace xadrez
{
    internal class Torre :Peca
    {

        public Torre(Cor colorocao, Tabuleiro tab) : base(colorocao, tab)
        {

        }

        public override string ToString()
        {
            return "T";
        }


    }
}
