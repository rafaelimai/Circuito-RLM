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
        
