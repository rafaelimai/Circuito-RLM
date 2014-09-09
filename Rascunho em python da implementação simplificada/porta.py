class porta:
    '''
    Abstração simples de uma porta lógica, repesenta apenas o tipo de operação
    ("e", "ou", "não" etc) e o que está conectado à sua entrada.
    '''

    def __init__(self, operação, entradas):
        self.operação = operação
        self.entradas = entradas

        
