using System;
using tabuleiro;
using xadrez;
namespace Xadrez_console
{
    class main
    {
        static void Main(string[] args) {

            
            PartidaDeXadrez partida = new PartidaDeXadrez();

            Tela.imprimirTabuleiro(partida.tab);





            Console.ReadKey();

        }
    }
}
