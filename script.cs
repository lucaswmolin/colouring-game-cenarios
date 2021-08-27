using System;
using System.Collections.Generic;

namespace uri1907
{
    class Program
    {
        static char[,] imagem = null;
        static int[] queueX = new int[1024 * 1024];
        static int[] queueY = new int[1024 * 1024];

        static void ColorirImagem(int x, int y, int n, int m, char cor)
        {
            int pf = 1;
            int tf = 0;

            queueX[0] = x;
            queueY[0] = y;

            while (pf > tf)
            {
                x = queueX[tf];
                y = queueY[tf++];

                imagem[x, y] = cor;

                if (x - 1 > -1 && x - 1 < n)
                {
                    if (imagem[x - 1, y] == '.')
                    {
                        queueX[pf] = x - 1;
                        queueY[pf++] = y;
                        imagem[x - 1, y] = cor;
                    }
                }

                if (y - 1 > -1 && y - 1 < m)
                {
                    if (imagem[x, y - 1] == '.')
                    {
                        queueX[pf] = x;
                        queueY[pf++] = y - 1;
                        imagem[x, y - 1] = cor;
                    }
                }

                if (x + 1 > -1 && x + 1 < n)
                {
                    if (imagem[x + 1, y] == '.')
                    {
                        queueX[pf] = x + 1;
                        queueY[pf++] = y;
                        imagem[x + 1, y] = cor;
                    }
                }

                if (y + 1 > -1 && y + 1 < m)
                {
                    if (imagem[x, y + 1] == '.')
                    {
                        queueX[pf] = x;
                        queueY[pf++] = y + 1;
                        imagem[x, y + 1] = cor;
                    }
                }
            }
        }

        static int ProcessarImagem(int n, int m)
        {
            int cor = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (imagem[i,j] == '.')
                    {
                        ColorirImagem(i, j, n, m, 'c');

                        cor += 1;
                    }
                }
            }

            return cor;
        }

        static void Main(string[] args)
        {
            string[] linha_inicial = Console.ReadLine().Split(' ');

            int n = Int32.Parse(linha_inicial[0]);
            int m = Int32.Parse(linha_inicial[1]);

            imagem = new char[n,m];
            for (int i = 0; i < n; i++)
            {
                var linha = Console.ReadLine().ToCharArray();
                for (int j = 0; j < m; j++)
                {
                    imagem[i,j] = linha[j];
                }
            }

            int r = ProcessarImagem(n, m);

            Console.WriteLine(r.ToString());
        }
    }
}
