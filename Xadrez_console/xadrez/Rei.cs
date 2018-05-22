using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez partida;

        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor) {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }
        //VERIFICA SE A POSICAO ESTA VAZIA OU TEM UMA PECA INIMIGA
        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != this.cor;
        }


        private bool testaTorreRoque(Posicao pos) {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.cor == cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            //POSICAO É HERDADA DA CLASSE PEÇA
            //cima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;
            //baixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;
            //esquerda
            pos.definirValores(posicao.linha , posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;
            //direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;


            //no
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;
            //ne
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;
            //so
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;
            //se
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;





                //JOGADA ESPECIAL ROQUE
                if (qteMovimentos == 0 && !partida.xeque)
                {
                    //ROQUE PEQUENO
                    Posicao posT1 = new Posicao(posicao.linha, posicao.coluna + 3);
                    if (testaTorreRoque(posT1))
                    {
                        Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                        Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                        if (tab.peca(p1) == null && tab.peca(p2) == null)
                            mat[posicao.linha, posicao.coluna + 2 ] = true;
                    }

                //ROQUE GRANDE
                Posicao posT2 = new Posicao(posicao.linha, posicao.coluna - 4);
                if (testaTorreRoque(posT2))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna -1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna -2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna -3);
                    if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3) == null)
                        mat[posicao.linha, posicao.coluna - 2] = true;
                }
            }































            return mat;
        }












    }
}
