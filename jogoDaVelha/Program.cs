using System;


namespace jogoDaVelha
{
    class Program
    {
        static void printGame(int ordemMatriz, char[,] mat)
        {
            int qtdCaractere = ordemMatriz * 4;
            var texto = "";

            for (int i = 1; i < qtdCaractere; i++)
            {
                if (i % 4 == 0)
                {
                    texto += "+";
                }
                else
                {
                    texto += "-";
                }
            }

            for (int i = 0; i < ordemMatriz; i++)
            {
                for (int j = 0; j < ordemMatriz; j++)
                {

                    if (mat[i, j] == 'X' || mat[i, j] == 'O')
                        Console.Write($" {mat[i, j]} ");
                    else
                        Console.Write(" - ");

                    if (j != ordemMatriz - 1)
                    {
                        Console.Write($"|");
                    }
                }

                Console.WriteLine();

                if (i != ordemMatriz - 1)
                {
                    Console.WriteLine(texto);
                }
            }
        }


        static bool verificarLinha(char[,] mat, int linha, int ordemMatriz, char caractere)
        {
            int cont = 0;

            for (int j = 0; j < ordemMatriz; j++)
            {
                if (mat[linha, j] == caractere)
                    cont++;

                if (cont == ordemMatriz)
                    return true;
            }

            return false;
        }

        static bool verificarColuna(char[,] mat, int coluna, int ordemMatriz, char caractere)
        {
            int cont = 0;

            for (int i = 0; i < ordemMatriz; i++)
            {
                if (mat[i, coluna] == caractere)
                    cont++;

                if (cont == ordemMatriz)
                    return true;
            }

            return false;
        }

        static bool verificarDiagonalPrincipal(char[,] mat, int ordemMatriz, char caractere)
        {
            int cont = 0;

            for (int i = 0; i < ordemMatriz; i++)
            {
                if (mat[i, i] == caractere)
                    cont++;

                if (cont == ordemMatriz)
                    return true;
            }

            return false;
        }

        static bool verificarDiagonalSecundaria(char[,] mat, int ordemMatriz, char caractere)
        {
            int cont = 0;
            int coluna = ordemMatriz - 1;

            for (int i = 0; i < ordemMatriz; i++)
            {
                if (mat[i, coluna] == caractere)
                    cont++;

                if (cont == ordemMatriz)
                    return true;

                coluna--;
            }

            return false;
        }

        static void Main()
        {
            int vitoriasPlayer1 = 0, vitoriasPlayer2 = 0, empates = 0, op;

            while (true)
            {
                int flag = 0;

                Console.Write("Informe o tamanho do Game: ");
                int ordemMatriz = int.Parse(Console.ReadLine());

                Console.WriteLine();
                char[,] mat = new char[ordemMatriz, ordemMatriz];

                Console.WriteLine("Player 01 começa com 'X'");
                Console.WriteLine("Player 01 começa com 'O'");
                Console.Write("\nInforme o caractere do primeiro jogador: ");

                char option = char.Parse(Console.ReadLine());

                char player1 = option;
                char player2;

                if (player1 == 'X')
                    player2 = 'O';
                else
                    player2 = 'X';

                char caractere = ' ';

                for (int i = 0; i < ordemMatriz * ordemMatriz; i++)
                {
                    Console.WriteLine($"\nPlayer 1 - [{player1}]");
                    Console.WriteLine($"Player 2 - [{player2}]\n");
                    printGame(ordemMatriz, mat);

                    Console.WriteLine();

                    if (i % 2 == 0)
                    {
                        Console.WriteLine("Vez do player 01");
                        caractere = player1;
                    }
                    else
                    {
                        Console.WriteLine("Vez do player 02");
                        caractere = player2;
                    }

                    Console.WriteLine();

                    Console.Write("Informe a posição da linha: ");
                    int linha = int.Parse(Console.ReadLine());

                    Console.Write("Informe a posição da coluna: ");
                    int coluna = int.Parse(Console.ReadLine());

                    mat[linha, coluna] = caractere;

                    if (verificarColuna(mat, coluna, ordemMatriz, caractere))
                    {
                        flag = 1;
                        break;
                    }

                    if (verificarLinha(mat, linha, ordemMatriz, caractere))
                    {
                        flag = 1;
                        break;
                    }

                    if (linha == coluna)
                    {
                        if (verificarDiagonalPrincipal(mat, ordemMatriz, caractere))
                        {
                            flag = 1;
                            break;
                        }
                    }

                    if (linha + coluna == ordemMatriz - 1)
                    {
                        if (verificarDiagonalSecundaria(mat, ordemMatriz, caractere))
                        {
                            flag = 1;
                            break;
                        }
                    }

                    Console.Clear();
                }


                Console.Clear();

                printGame(ordemMatriz, mat);

                if (flag == 0)
                {
                    Console.WriteLine("EMPATE!!");
                    empates++;
                }
                else if (player1 == caractere)
                {
                    Console.WriteLine("\nPLAYER 1 GANHOU!!\n");
                    vitoriasPlayer1++;
                }
                else
                {
                    Console.WriteLine("\nPLAYER 2 GANHOU!!\n");
                    vitoriasPlayer2++;
                }

                Console.WriteLine("Placar: ");
                Console.WriteLine($"Player 1: {vitoriasPlayer1} vitórias");
                Console.WriteLine($"Player 2: {vitoriasPlayer2} vitórias");
                Console.WriteLine($"Empates: {empates} empates");

                Console.WriteLine();

                int flagGame = 0;

                do
                {
                    Console.WriteLine("Deseja jogar novamente?\n1 - SIM\n2 - NÃO\n");
                    Console.Write("Informe sua resposta: ");

                    op = int.Parse(Console.ReadLine());

                    Console.Clear();

                    switch (op)
                    {
                        case 1:
                            Console.WriteLine("VAMOS CONTINUAR COM O GAME\n");
                            break;
                        case 2:
                            Console.WriteLine("ENCERRANDO O GAME...");
                            flagGame = 1;
                            break;
                        default:
                            Console.WriteLine("Informe uma opção correta\n");
                            break;
                    }
                } while (op != 1 && op != 2);

                if (flagGame == 1)
                    break;
            }
        }
    }
}
