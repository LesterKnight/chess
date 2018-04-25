namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;


        //INSTANCIA O TABULEIRO
        public Tabuleiro(int linhas, int colunas) {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }
        //ACESSA UMA PECA DO TABULEIRO COM X Y
        public Peca peca(int linha, int coluna) {
            return pecas[linha, coluna];
        }

        //ACESSA UMA PECA DO TABULEIRO COM POSICAO DO TIPO POS
        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }

        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos)) {
                throw new TabuleiroException("Ja existe peca na posicao!");
            }

            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        //VALIDA SE ESTA FORA DOS LIMITES
        public bool posicaoValida(Posicao pos) {
            if (pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas) {
                return false;
            }
                return true;
        }

        public void validarPosicao(Posicao pos) {
            if (!posicaoValida(pos)) {
                throw new TabuleiroException("posicao invalida!");
            }
        }

        public bool existePeca(Posicao pos) {
            validarPosicao(pos);
            return peca(pos) != null;
        }
    }
}
