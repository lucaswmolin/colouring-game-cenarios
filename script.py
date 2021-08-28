import io
import os

input = io.BytesIO(os.read(0, os.fstat(0).st_size)).readline

imagem = []

queue_x = []
queue_y = []
for c in range(1048576):
    queue_x.append(0)
    queue_y.append(0)


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
        imagem.append(list(ln))

    rs = processarImagem(n, m)

    print(str(rs))


main()

