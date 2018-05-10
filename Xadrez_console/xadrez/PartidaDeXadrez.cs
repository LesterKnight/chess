using System;
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

        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez() {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;

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



        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.cor == cor)
                    aux.Add(x);
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }



        public void colocarNovaPeca(char coluna, int linha,Peca peca) {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
        }

        public void colocarPecas() {
            //INSTANCIANDO PECAS
            //PRETO
            colocarNovaPeca('c', 4, new Torre(tab, Cor.Branca));
            colocarNovaPeca('c', 5, new Torre(tab, Cor.Branca));
            colocarNovaPeca('c', 6, new Torre(tab, Cor.Branca));
            colocarNovaPeca('c', 7, new Torre(tab, Cor.Branca));

        }
        public void executaMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.retiraPeca(origem);
            p.incrementarMovimentos();
            Peca pecaCapturada = tab.retiraPeca(destino);
            tab.colocarPeca(p, destino);
            if (pecaCapturada != null)
                capturadas.Add(pecaCapturada);
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

        public void validarPosicaoDeOrigem(Posicao pos) {
            if (tab.peca(pos) == null)
                throw new TabuleiroException("Não existe peça na posição de origem escolhida");

            if (jogadorAtual != tab.peca(pos).cor)
                throw new TabuleiroException("peça não pertence ao jogador");

            if(!tab.peca(pos).existeMovimentosPossiveis())
                throw new TabuleiroException("Não existem movimentos possiveis para essa peça");
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if (!tab.peca(origem).podeMoverPara(destino)) {
                throw new TabuleiroException("Posicao de destino invalida");
            }
        }



    }
}
