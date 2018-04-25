using System;
using xadrez;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; set; }
        private int turno;
        private Cor jogadorAtual;

        public PartidaDeXadrez() {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            colocarPecas();
           
        }

        public void colocarPecas() {
            //INSTANCIANDO PECAS
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('h', 1).toPosicao());

        }
        public void executaMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.retiraPeca(origem);
            p.incrementarMovimentos();
            Peca pecaCapturada = tab.retiraPeca(destino);
            tab.colocarPeca(p, destino);
        }
    }
}
