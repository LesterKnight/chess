using System;
using tabuleiro;
using xadrez;
namespace Xadrez_console
{
    class Tela
    {
        //IMPRIME TABULEIRO NA TELA
        public static void imprimirTabuleiro(Tabuleiro tab) {
            for (int i = 0; i < tab.linhas; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++) {
                    if (tab.peca(i, j) == null)
                        Console.Write("- ");
                    else {
                        imprimirPeca(tab.peca(i, j));
                    }


                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                        Console.BackgroundColor = fundoAlterado;
                    else
                        Console.BackgroundColor = fundoOriginal;


                    if (tab.peca(i, j) == null)
                        Console.Write("- ");
                    else
                    {
                        imprimirPeca(tab.peca(i, j));
                    }


                }
                Console.BackgroundColor = fundoOriginal;
                Console.WriteLine();
            }
            //Console.BackgroundColor = fundoOriginal;
            Console.WriteLine("  A B C D E F G H");
            
        }














        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char linha = s[0];
            int coluna = int.Parse(s[1]+"");
            return new PosicaoXadrez(linha, coluna);
        }

        public static void imprimirPeca(Peca peca) {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else {
                if (peca.cor == Cor.Branca)
                    Console.Write(peca);
                else
                {//SE A PECA FOR PRETA
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
            }
            Console.Write(" ");














            
        }
    }
}
