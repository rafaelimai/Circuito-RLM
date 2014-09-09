class Porta:
    """
    Abstracao simples de uma porta logica, repesenta apenas o tipo de operacao
    ("e", "ou", "nao" etc) e o que esta conectado a  sua entrada.
    """

    def __init__(self, operacao, entradas):
        self.operacao = operacao #recebe uma string da forma ' operacao ', onde operacao representa a operacao realizada. Exemplo: ' ou '
        self.entradas = entradas

        
