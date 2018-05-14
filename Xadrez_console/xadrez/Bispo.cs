using tabuleiro;

namespace xadrez
{
    class Bispo : Peca
    {
        public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor) {

        }

        public override string ToString()
        {
            return "B";
        }

        //VERIFICA SE A POSICAO ESTA VAZIA OU TEM UMA PECA INIMIGA
        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != this.cor;
        }


        //GERA MATRIZ DE MOVIMENTOS POSSIVEIS PARA A PEÇA
        public override bool[,] movimentosPossiveis()
        {
            //CRIA A MATRIZ BOOLEANA
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);
            //NE

            //POSICAO É HERDADA DA CLASSE PEÇA
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                    break;
                pos.linha = pos.linha - 1;
                pos.coluna = pos.coluna - 1;
            }

            //NO
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                    break;
                pos.linha = pos.linha - 1;
                pos.coluna = pos.coluna + 1;
            }

            //SE
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                    break;
                pos.linha = pos.linha + 1;
                pos.coluna = pos.coluna - 1;
            }

            //SO
            pos.definirValores(posicao.linha +1, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                    break;
                pos.linha = pos.linha + 1;
                pos.coluna = pos.coluna + 1;
            }
            

            return mat;
        }











    }
}
