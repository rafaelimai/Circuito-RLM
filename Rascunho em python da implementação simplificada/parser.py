'''
Parser para resolver os circuitos combinatórios do jogo.


Recebe a "última" porta do circuito, e resolve o valor final da saída.
Nesse rascunho, utiliza uma string para represetar a expressão, e a executa.
'''

def resolver (porta):
    string = ''
    for i in porta.entradas:
        if not string == '':
            string.append porta.operacao
        string.append str(i)
    string

def parser (string):
    for i in range(len(string))
        if string[i] == 'p':
            string = string[:i] + resolver(string[i:i+3]) + string[i+3:]
            if ispure:
                ispure = False
    if ispure:
        saida = eval(string)

    else:
        saida = parser(string)
    return saida
            
