using System;
using tabuleiro;
using xadrez;
namespace Xadrez_console
{
    class main
    {
        static void Main(string[] args) {
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.colocarPeca(new Rei(tab,Cor.Branca), new Posicao(0, 0));
            tab.colocarPeca(new Cavalo(tab,Cor.Preta), new Posicao(1, 3));
            tab.colocarPeca(new Cavalo(tab, Cor.Preta), new Posicao(1, 4));

            Tela.imprimirTabuleiro(tab);
            PosicaoXadrez pos = new PosicaoXadrez('a', 1);
            Console.WriteLine(pos.toPosicao());


            Console.ReadKey();

        }
    }
}
