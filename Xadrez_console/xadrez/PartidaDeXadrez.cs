﻿using System;
using xadrez;
using tabuleiro;
using System.Collections.Generic;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        public bool xeque { get; private set; }
        public Peca vulneravelEnPassant { get; private set; }


        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez() {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public HashSet<Peca> pecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas) {
                if (x.cor == cor)
                    aux.Add(x);
            }
            return aux;
        }



        public HashSet<Peca> pecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                    aux.Add(x);
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }



        public void colocarNovaPeca(char coluna, int linha,Peca peca) {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }

        public void colocarPecas() {
            //INSTANCIANDO PECAS
            //PRETO

            colocarNovaPeca('a', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('b', 8, new Cavalo(tab, Cor.Preta));
            colocarNovaPeca('c', 8, new Bispo(tab, Cor.Preta));
            colocarNovaPeca('d', 8, new Rainha(tab, Cor.Preta));
            colocarNovaPeca('e', 8, new Rei(tab, Cor.Preta, this));
            colocarNovaPeca('f', 8, new Bispo(tab, Cor.Preta));
            colocarNovaPeca('g', 8, new Cavalo(tab, Cor.Preta));
            colocarNovaPeca('h', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('a', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('b', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('c', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('d', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('e', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('f', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('g', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('h', 7, new Peao(tab, Cor.Preta, this));


            
            colocarNovaPeca('a', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('b', 1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('c', 1, new Bispo(tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Rainha(tab, Cor.Branca));
            colocarNovaPeca('e', 1, new Rei(tab, Cor.Branca, this));
            colocarNovaPeca('f', 1, new Bispo(tab, Cor.Branca));
            colocarNovaPeca('g', 1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('h', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('a', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('b', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('c', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('d', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('e', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('f', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('g', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('h', 2, new Peao(tab, Cor.Branca, this));
        }

        //era void
        public Peca executaMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.retiraPeca(origem);
            p.incrementarMovimentos();
            Peca pecaCapturada = tab.retiraPeca(destino);
            tab.colocarPeca(p, destino);
            if (pecaCapturada != null)
                capturadas.Add(pecaCapturada);

            //JOGADA ESPECIAL
            //ROQUE PEQUENO
            if (p is Rei && destino.coluna == origem.coluna + 2) {
                Posicao origemT = new Posicao(origem.linha, origem.coluna + 3);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna + 1);
                Peca T = tab.retiraPeca(origemT);
                T.incrementarMovimentos();
                tab.colocarPeca(T, destinoT);
            }
            //ROQUE GRANDE
            if (p is Rei && destino.coluna == origem.coluna - 2)
            {
                Posicao origemT = new Posicao(origem.linha, origem.coluna -4);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna -1);
                Peca T = tab.retiraPeca(origemT);
                T.incrementarMovimentos();
                tab.colocarPeca(T, destinoT);
            }

            //JOGADA ESPECIAL EN PASSANT
            if (p is Peao) {
                if (origem.coluna != destino.coluna && pecaCapturada == null) {
                    Posicao posP;
                    if (p.cor == Cor.Branca)
                    {
                        posP = new Posicao(destino.linha + 1, destino.coluna);
                    }
                    else {
                        posP = new Posicao(destino.linha - 1, destino.coluna);
                    }
                    pecaCapturada = tab.retiraPeca(posP);
                    capturadas.Add(pecaCapturada);
                }
            }

            return pecaCapturada;
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada) {
            Peca p = tab.retiraPeca(destino);
            p.decrementarMovimentos();
            if (pecaCapturada != null) {
                tab.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.colocarPeca(p, origem);
            //ROQUE
            if (p is Rei && destino.coluna == origem.coluna + 2)
            {
                Posicao origemT = new Posicao(origem.linha, origem.coluna + 3);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna + 1);
                Peca T = tab.retiraPeca(destinoT);
                T.decrementarMovimentos();
                tab.colocarPeca(T, origemT);
            }

            if (p is Rei && destino.coluna == origem.coluna - 2)
            {
                Posicao origemT = new Posicao(origem.linha, origem.coluna -4);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna -1);
                Peca T = tab.retiraPeca(destinoT);
                T.decrementarMovimentos();
                tab.colocarPeca(T, origemT);
            }

            //JOGADA ESPECIAL EN PASSANT
            if (p is Peao) {
                if (origem.coluna != destino.coluna && pecaCapturada == vulneravelEnPassant) {
                    Peca peao = tab.retiraPeca(destino);
                    Posicao posP = null;
                    if (p.cor == Cor.Branca)
                    {
                        posP = new Posicao(3, destino.coluna);
                    }
                    else {
                        posP = new Posicao(4, destino.coluna);
                    }
                    tab.colocarPeca(peao, posP);
                }
            }
        }

        public void realizaJogada(Posicao origem, Posicao destino) {
            Peca pecaCapturada = executaMovimento(origem, destino);

            if (estaEmXeque(jogadorAtual)) {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("voce nao pode se colocar em xeque");
            }
            Peca p = tab.peca(destino);
            //JOGADA ESPECIAL PROMOCAO
            if (p is Peao) {
                if ((p.cor == Cor.Branca && destino.linha == 0) || (p.cor == Cor.Preta && destino.linha == 7)) {
                    p = tab.retiraPeca(destino);
                    pecas.Remove(p);
                    Rainha rainha = new Rainha(tab, p.cor);
                    tab.colocarPeca(rainha, destino);
                    pecas.Add(rainha);
                }
            }

            if (estaEmXeque(adversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else
                xeque = false;

            if (testaXequeMate(adversaria(jogadorAtual))) {
                terminada = true;
            }
            else {
                turno++;
                mudaJogador();
            }


            //JOGADA ESPECIAL
            if (p is Peao && (destino.linha == origem.linha - 2 || destino.linha == origem.linha + 2))
            {
                vulneravelEnPassant = p;
            }
            else {
                vulneravelEnPassant = null;
            }
        }

        private void mudaJogador() {
            if (jogadorAtual == Cor.Branca)
                jogadorAtual = Cor.Preta;
            else
                jogadorAtual = Cor.Branca;
        }

        public void validarPosicaoDeOrigem(Posicao pos) {
            if (tab.peca(pos) == null)
                throw new TabuleiroException("Não existe peça na posição de origem escolhida");

            if (jogadorAtual != tab.peca(pos).cor)
                throw new TabuleiroException("peça não pertence ao jogador");

            if(!tab.peca(pos).existeMovimentosPossiveis())
                throw new TabuleiroException("Não existem movimentos possiveis para essa peça");
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if (!tab.peca(origem).movimentosPossiveis(destino)) {
                throw new TabuleiroException("Posicao de destino invalida");
            }
        }

        private Cor adversaria(Cor cor) {
            if (cor == Cor.Branca)
                return Cor.Preta;

           else
                return Cor.Branca;
        }

        private Peca rei(Cor cor) {
            foreach (Peca x in pecasEmJogo(cor)) {
                if (x is Rei)
                    return x;
            }
            return null;
        }

        public bool estaEmXeque(Cor cor) {
            Peca R = rei(cor);
            if (R == null)
                throw new TabuleiroException("NAO EXISTE REI DA COR "+cor+"!");
            foreach (Peca x in pecasEmJogo(adversaria(cor))) {
                bool[,] mat = x.movimentosPossiveis();
                if (mat[R.posicao.linha, R.posicao.coluna])
                    return true;
            }
            return false;
        }

        public bool testaXequeMate(Cor cor) {
            if (!estaEmXeque(cor))
                return false;
            foreach (Peca x in pecasEmJogo(cor)) {
                bool[,] mat = x.movimentosPossiveis();
                for (int i = 0; i < tab.linhas; i++) {
                    for (int j = 0; j < tab.colunas; j++) {
                        if (mat[i, j]) {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = executaMovimento(x.posicao, destino);
                            bool testeXeque = estaEmXeque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque) {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}
