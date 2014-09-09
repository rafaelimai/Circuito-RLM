'''
Exemplo simples de uma aplicacao do rascunho
'''

from porta import *
from interpretador import *



p02 = Porta(' and ', [True, False])
p03 = Porta(' not ', [False])
p01 = Porta(' or ', [p02, p03])

out = interpretar(str(p01))
