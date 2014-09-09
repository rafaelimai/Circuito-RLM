class porta:
    '''
    Abstracao simples de uma porta logica, repesenta apenas o tipo de operação
    ("e", "ou", "nao" etc) e o que estao conectado a� sua entrada.
    '''

    def __init__(self, operacao, entradas):
        self.operacao = operacao
        self.entradas = entradas

        
