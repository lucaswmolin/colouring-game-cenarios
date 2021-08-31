using System;
using System.Collections.Generic;

namespace uri1907
{
    class Program
    {
        static char[,] imagem = null;
        static short[] queueX = new short[1048576];
        static short[] queueY = new short[1048576];

        static void ColorirImagem(short x, short y, short n, short m)
        {
            int pf = 1;
            int tf = 0;

            queueX[0] = x;
            queueY[0] = y;

            while (pf > tf)
            {
                x = queueX[tf];
                y = queueY[tf++];

                imagem[x, y] = 'o';

                x--;
                if (x > -1 && x < n)
                {
                    if (imagem[x, y] == '.')
                    {
                        queueX[pf] = x;
                        queueY[pf++] = y;
                        imagem[x, y] = 'o';
                    }
                }

                x += 2;

                if (x > -1 && x < n)
                {
                    if (imagem[x, y] == '.')
                    {
                        queueX[pf] = x;
                        queueY[pf++] = y;
                        imagem[x, y] = 'o';
                    }
                }
                x--;

                y--;
                if (y > -1 && y < m)
                {
                    if (imagem[x, y] == '.')
                    {
                        queueX[pf] = x;
                        queueY[pf++] = y;
                        imagem[x, y] = 'o';
                    }
                }

                y += 2;

                if (y > -1 && y < m)
                {
                    if (imagem[x, y] == '.')
                    {
                        queueX[pf] = x;
                        queueY[pf++] = y;
                        imagem[x, y] = 'o';
                    }
                }
            }
        }

        static int ProcessarImagem(short n, short m)
        {
            int c = 0;

            for (short i = 0; i < n; i++)
            {
                for (short j = 0; j < m; j++)
                {
                    if (imagem[i, j] == '.')
                    {
                        ColorirImagem(i, j, n, m);

                        c++;
                    }
                }
            }

            return c;
        }

        static void Main(string[] args)
        {
            string[] linha_inicial = Console.ReadLine().Split(' ');

            short n = (short) Int32.Parse(linha_inicial[0]);
            short m = (short) Int32.Parse(linha_inicial[1]);

            imagem = new char[n, m];
            for (short i = 0; i < n; i++)
            {
                char[] linha = Console.ReadLine().ToCharArray();
                for (short j = 0; j < m; j++)
                {
                    imagem[i, j] = linha[j];
                }
            }

            int r = ProcessarImagem(n, m);

            Console.WriteLine(r.ToString());
        }
    }
}