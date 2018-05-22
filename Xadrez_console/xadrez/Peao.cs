using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor) {

        }

        public override string ToString()
        {
            return "P";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != this.cor;
        }

        private bool existeInimigo(Posicao pos) {

            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool livre(Posicao pos) {
            return tab.peca(pos) == null;
        }


        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);



            //PEAO PRETO
            if (cor == Cor.Preta)
            {
                if (qteMovimentos == 0) {
                    pos.definirValores(posicao.linha + 2, posicao.coluna);
                    if (tab.posicaoValida(pos) && livre(pos))//TODO LIVRE
                        mat[pos.linha, pos.coluna] = true;
                }

                pos.definirValores(posicao.linha + 1, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                    mat[pos.linha, pos.coluna] = true;

                pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                    mat[pos.linha, pos.coluna] = true;

                pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                    mat[pos.linha, pos.coluna] = true;

            }







            else {

                if (qteMovimentos == 0)
                {
                    pos.definirValores(posicao.linha - 2, posicao.coluna);
                    if (tab.posicaoValida(pos) && livre(pos))
                        mat[pos.linha, pos.coluna] = true;
                }
                //!existeInimigo(pos)
                pos.definirValores(posicao.linha - 1, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                    mat[pos.linha, pos.coluna] = true;

                pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                    mat[pos.linha, pos.coluna] = true;

                pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                    mat[pos.linha, pos.coluna] = true;
            }








            return mat;
        }
    }
}
