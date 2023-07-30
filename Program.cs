// See https://aka.ms/new-console-template for more information


using tabuleiro;
using xadrez;
using Xadrez_Console;


try
{
    PartidaXadrez partida = new PartidaXadrez();

    while (!partida.Terminada)
    {
        try
        {
            Console.Clear();
            Tela.ImprimirTela(partida.Tab);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            Console.WriteLine("Jogado atual: " + partida.JogadorAtual);
            Console.WriteLine();

            Console.Write("Origem: ");
            Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
            partida.ValidaPosicaoOrigem(origem);

            bool[,] posicoesPossiveis = partida.Tab.Pecas(origem).MovimentosPossiveis();

            Console.Clear();
            Tela.ImprimirTela(partida.Tab, posicoesPossiveis);


            Console.WriteLine();
            Console.Write("Destino: ");
            Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
            partida.ValidarPosicaoDestino(origem, destino);

            partida.RealizaJogada(origem, destino);

        }
        catch (TabuleiroException e)
        {
            Console.WriteLine(e.Message);
            Console.Write("Pressione [ENTER] para repetir a jogada");
            Console.ReadLine();
        }
    }
}
catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);

}
Console.WriteLine("Fim do programa!");
