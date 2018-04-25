﻿namespace tabuleiro
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
        //ACESSA UMA PECA DO TABULEIRO
        public Peca peca(int linha, int coluna) {
            return pecas[linha, coluna];
        }
    }
}
