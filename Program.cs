// See https://aka.ms/new-console-template for more information


using tabuleiro;
using Xadrez_Console;
using xadrez;
try { 
Tabuleiro tab = new Tabuleiro(8, 8);

tab.ColocandoPeca(new Torre(Cor.Preta, tab), new Posicao(0, 0));
tab.ColocandoPeca(new Torre(Cor.Preta, tab) , new Posicao(0, 0));
tab.ColocandoPeca(new Rei(Cor.Preta, tab), new Posicao(2, 4));

Tela.ImprimirTela(tab);

} catch (Exception e) {
    Console.WriteLine(e.Message);
}
Console.WriteLine("Fim do programa!");
