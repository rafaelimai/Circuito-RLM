'''
Exemplo simples de uma aplicacao do rascunho
'''

import porta.py
import parser.py

p01 = porta.porta(' or ', [p02, p03])
p02 = porta.porta(' and ', [True, False])
p03 = porta.porta(' not ', [False])

parser.parser(str(p01))
