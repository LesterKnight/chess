﻿using System;
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

                    try
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Tela.imprimirPartida(partida);
                        Console.Write("origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);
                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();
                        Console.Clear();
                        Console.WriteLine();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);
                        Console.Write("destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);
                        partida.realizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    } 
                }
                Console.Clear();
                Tela.imprimirPartida(partida);
            }
            catch (TabuleiroException t) {
                Console.WriteLine(t.Message);
            }
            Console.ReadKey();
        }
    }
}
