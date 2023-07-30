// See https://aka.ms/new-console-template for more information


using tabuleiro;
using Xadrez_Console;
using xadrez;
try { 
PartidaXadrez partida = new PartidaXadrez();

    while (!partida.Terminada)
    {
        Console.Clear();
        Tela.ImprimirTela(partida.Tab);
        
        Console.WriteLine();
        Console.Write("Origem: ");
        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

        bool[,] posicoesPossiveis = partida.Tab.Pecas(origem).MovimentosPossiveis();

        Console.Clear();
        Tela.ImprimirTela(partida.Tab, posicoesPossiveis);


        
        Console.Write("Destino: ");
        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

        partida.ExecutaMovimento(origem, destino);
    }
} catch (Exception e) {
    Console.WriteLine(e.Message);
}
Console.WriteLine("Fim do programa!");
