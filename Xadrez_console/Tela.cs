using System;
using tabuleiro;

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
                        Console.Write(" ");
                    }


                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void imprimirPeca(Peca peca) {
            if (peca.cor == Cor.Branca)
                Console.Write(peca);
            else {//SE A PECA FOR PRETA
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}
