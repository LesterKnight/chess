using tabuleiro;

namespace xadrez
{
    class PosicaoXadrez
    {
        public char coluna { get; set; }
        public int linha { get; set; }

        public PosicaoXadrez(char coluna, int linha) {
            this.coluna = coluna;
            this.linha = linha;
        }

        public override string ToString()
        {
            return "" + coluna + linha;
        }
        //CONVERTE A POSICAO COM LETRA PARA UMA POSICAO REAL NA MATRIZ
        public Posicao toPosicao() {
            return new Posicao(8-linha, coluna - 'a');
        }
    }
}
