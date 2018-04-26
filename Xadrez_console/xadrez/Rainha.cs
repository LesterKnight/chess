using tabuleiro;

namespace xadrez
{
    class Rainha : Peca
    {
        public Rainha(Tabuleiro tab, Cor cor) : base(tab, cor) {

        }

        public override string ToString()
        {
            return "A";
        }

        public override bool[,] movimentosPossiveis()
        {
            throw new System.NotImplementedException();
        }
    }
}
