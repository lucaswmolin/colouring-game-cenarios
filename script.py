import io
import os
import time
from ctypes import c_wchar, c_int

input = io.BytesIO(os.read(0, os.fstat(0).st_size)).readline

imagem = (c_wchar * 1025 * 1025)()
queue_x = (c_int * 1048576)(*[i for i in range(1048576)])
queue_y = (c_int * 1048576)(*[i for i in range(1048576)])


def BFS(x, y, n, m):
    global imagem
    global queue_x
    global queue_y

    pf = 1
    tf = 0
    c = 'o'

    queue_x[0] = x
    queue_y[0] = y

    while pf > tf:
        x = queue_x[tf]
        y = queue_y[tf]

        tf += 1

        imagem[x][y] = c

        if -1 < x - 1 < n:
            if imagem[x - 1][y] == '.':
                queue_x[pf] = x - 1
                queue_y[pf] = y
                imagem[x - 1][y] = c

                pf += 1

        if -1 < y - 1 < m:
            if imagem[x][y - 1] == '.':
                queue_x[pf] = x
                queue_y[pf] = y - 1
                imagem[x][y - 1] = c

                pf += 1

        if -1 < x + 1 < n:
            if imagem[x + 1][y] == '.':
                queue_x[pf] = x + 1
                queue_y[pf] = y
                imagem[x + 1][y] = c

                pf += 1

        if -1 < y + 1 < m:
            if imagem[x][y + 1] == '.':
                queue_x[pf] = x
                queue_y[pf] = y + 1
                imagem[x][y + 1] = c

                pf += 1


def processarImagem(n, m):
    global imagem

    cor = 0
    for r in range(n):
        for c in range(m):
            if imagem[r][c] == '.':
                BFS(r, c, n, m)
                cor += 1

    return cor


def main():
    global imagem

    li = input().decode().split(' ')

    n = int(li[0])
    m = int(li[1])

    for r in range(n):
        ln = input().decode()
        for c in range(m):
            imagem[r][c] = ln[c]

    rs = processarImagem(n, m)

    print(str(rs))


def lerArquivo(path):
    ini = time.time()

    global imagem

    f = open(path, 'r')

    i = 0
    for line in f:
        j = 0
        for col in line:
            imagem[i][j] = col

            j += 1

        i += 1

    rs = processarImagem(i, j)

    print("\nM: " + str(i) + ' x ' + str(j))

    print("R: " + str(rs))

    fim = time.time()

    diff = fim-ini

    print("T: " + str(diff))


def validar():
    ini = time.time()

    arqs = ['URI1_6x9p.txt', 'URI1_1x8p.txt', 'URI1_1x1p.txt', 'URI2_1x1p.txt', 'URI1_80x80p.txt', 'URI2_80x80p.txt', 'URI1_1024x1024p.txt', 'URI2_1024x1024p.txt', 'URI3_1024x1024p.txt', 'URI4_1024x1024p.txt']
    for arq in arqs:
        lerArquivo(arq)

    fim = time.time()

    diff = fim - ini

    print("\nTT: " + str(diff))


# main()
validar()
