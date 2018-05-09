﻿using System;
using xadrez;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }

        public PartidaDeXadrez() {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            colocarPecas();
        }

        public void colocarPecas() {
            //INSTANCIANDO PECAS
            //PRETO
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 4).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 6).toPosicao());
            /* tab.colocarPeca(new Cavalo(tab, Cor.Preta), new PosicaoXadrez('b', 1).toPosicao());
             tab.colocarPeca(new Bispo(tab, Cor.Preta), new PosicaoXadrez('c', 1).toPosicao());
             tab.colocarPeca(new Rainha(tab, Cor.Preta), new PosicaoXadrez('d', 1).toPosicao());
             tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('e', 1).toPosicao());
             tab.colocarPeca(new Bispo(tab, Cor.Preta), new PosicaoXadrez('f', 1).toPosicao());
             tab.colocarPeca(new Cavalo(tab, Cor.Preta), new PosicaoXadrez('g', 1).toPosicao());
             tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('h', 1).toPosicao());
             */

            /*
            tab.colocarPeca(new Peao(tab, Cor.Preta), new PosicaoXadrez('a', 2).toPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Preta), new PosicaoXadrez('b', 2).toPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Preta), new PosicaoXadrez('c', 2).toPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Preta), new PosicaoXadrez('d', 2).toPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Preta), new PosicaoXadrez('e', 2).toPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Preta), new PosicaoXadrez('f', 2).toPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Preta), new PosicaoXadrez('g', 2).toPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Preta), new PosicaoXadrez('h', 2).toPosicao());
            */
            //BRANCO
            /*tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('a', 8).toPosicao());
            tab.colocarPeca(new Cavalo(tab, Cor.Branca), new PosicaoXadrez('b', 8).toPosicao());
            tab.colocarPeca(new Bispo(tab, Cor.Branca), new PosicaoXadrez('c', 8).toPosicao());
            tab.colocarPeca(new Rainha(tab, Cor.Branca), new PosicaoXadrez('d', 8).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('e', 8).toPosicao());
            tab.colocarPeca(new Bispo(tab, Cor.Branca), new PosicaoXadrez('f', 8).toPosicao());
            tab.colocarPeca(new Cavalo(tab, Cor.Branca), new PosicaoXadrez('g', 8).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('h', 8).toPosicao());
            
            tab.colocarPeca(new Peao(tab, Cor.Branca), new PosicaoXadrez('a', 7).toPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Branca), new PosicaoXadrez('b', 7).toPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Branca), new PosicaoXadrez('c', 7).toPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Branca), new PosicaoXadrez('d', 7).toPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Branca), new PosicaoXadrez('e', 7).toPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Branca), new PosicaoXadrez('f', 7).toPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Branca), new PosicaoXadrez('g', 7).toPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Branca), new PosicaoXadrez('h', 7).toPosicao());
            */

        }
        public void executaMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.retiraPeca(origem);
            p.incrementarMovimentos();
            Peca pecaCapturada = tab.retiraPeca(destino);
            tab.colocarPeca(p, destino);
        }


        public void realizaJogada(Posicao origem, Posicao destino) {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        private void mudaJogador() {
            if (jogadorAtual == Cor.Branca)
                jogadorAtual = Cor.Preta;
            else
                jogadorAtual = Cor.Branca;
        }

    }
}
