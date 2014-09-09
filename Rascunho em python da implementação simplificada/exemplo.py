'''
Exemplo simples de uma aplicacao do rascunho
'''

from porta import Porta
from parser import parse, resolver

p01 = Porta(' or ', [p02, p03])
p02 = Porta(' and ', [True, False])
p03 = Porta(' not ', [False])

parse(str(p01))
