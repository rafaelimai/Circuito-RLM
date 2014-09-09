'''
Exemplo simples de uma aplicacao do rascunho
'''

from porta import *
from interpretador import *



p02 = Porta('p02', ' and ', [True, False])
p03 = Porta('p03', ' not ', [False])
p01 = Porta('p01', ' or ', [p02, p03])

out = interpretar(p01.nome)
