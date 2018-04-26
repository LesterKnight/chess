namespace tabuleiro
{
   abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor) {
            this.posicao = null;//POSICAO DA PECA E NULA QUANDO CRIADA, O TABULEIRO COLOCA A POSICAO
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = qteMovimentos = 0;
        }
        public void incrementarMovimentos() {
            this.qteMovimentos++;
        }
        public abstract bool[,] movimentosPossiveis();
    }
}
