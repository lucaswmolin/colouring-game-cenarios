#include <string.h>
#include <stdio.h>

char imagem[1024][1024];
char linha[1024];

int queueX[1048576];
int queueY[1048576];

void ColorirImagem(int x, int y, int n, int m, char cor)
{
    int pf = 1;
    int tf = 0;

    queueX[0] = x;
    queueY[0] = y;

    while (pf > tf)
    {
        x = queueX[tf];
        y = queueY[tf++];

        imagem[x][y] = cor;

        if (x - 1 > -1 && x - 1 < n)
        {
            if (imagem[x - 1][y] == '.')
            {
                queueX[pf] = x - 1;
                queueY[pf++] = y;
                imagem[x - 1][y] = cor;
            }
        }

        if (y - 1 > -1 && y - 1 < m)
        {
            if (imagem[x][y - 1] == '.')
            {
                queueX[pf] = x;
                queueY[pf++] = y - 1;
                imagem[x][y - 1] = cor;
            }
        }

        if (x + 1 > -1 && x + 1 < n)
        {
            if (imagem[x + 1][y] == '.')
            {
                queueX[pf] = x + 1;
                queueY[pf++] = y;
                imagem[x + 1][y] = cor;
            }
        }

        if (y + 1 > -1 && y + 1 < m)
        {
            if (imagem[x][y + 1] == '.')
            {
                queueX[pf] = x;
                queueY[pf++] = y + 1;
                imagem[x][y + 1] = cor;
            }
        }
    }
}

int ProcessarImagem(int n, int m)
{
    int cor = 0;

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            if (imagem[i][j] == '.')
            {
                ColorirImagem(i, j, n, m, 'c');

                cor += 1;
            }
        }
    }

    return cor;
}

int main(void) {
	int i = 0;
	int n, m;
	scanf("%d %d", &n, &m);
	
    for (i = 0; i < n; i++)
        scanf("%s", imagem[i]);

    int r = ProcessarImagem(n, m);
	
	printf("%d\n", r);
}
