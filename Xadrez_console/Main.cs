using System;
using tabuleiro;
using xadrez;
namespace Xadrez_console
{
    class main
    {
        static void Main(string[] args) {

            try {
                PartidaDeXadrez partida = new PartidaDeXadrez();
                while (!partida.terminada)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Tela.imprimirTabuleiro(partida.tab);
                    Console.WriteLine();
                    Console.WriteLine("turno " + partida.turno);
                    Console.WriteLine("aguardando jogador "+ partida.jogadorAtual);



                    Console.Write("origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();





                    bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                    Console.Clear();
                    Console.WriteLine();

                    Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);




                    Console.Write("destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                    partida.realizaJogada(origem, destino);
                }

            }
            catch (TabuleiroException t) {
                Console.WriteLine(t.Message);
            }
         

            





            Console.ReadKey();

        }
    }
}
