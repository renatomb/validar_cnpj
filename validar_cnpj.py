"""
Função para validação de CNPJ numérico ou alfanumérico em Python
Autor: Eng. Renato Monteiro Batista
Versão: 1.0 - 11/07/2024
URL: https://github.com/renatomb/validar_cnpj

@param str cnpj
@return bool

Copyright (c) 2024 Renato Monteiro Batista

Redistribuição e uso em formatos de código-fonte e binário, com ou sem modificações, são permitidos desde que as seguintes condições sejam atendidas:
1. Redistribuições do código-fonte devem manter o aviso de copyright acima, esta lista de condições e a seguinte isenção de responsabilidade.
2. Redistribuições em formato binário devem reproduzir o aviso de copyright acima, esta lista de condições e a seguinte isenção de responsabilidade na documentação e/ou outros materiais fornecidos com a distribuição.
3. Nem o nome do autor, nem os nomes de seus colaboradores podem ser usados para endossar ou promover produtos derivados deste software sem permissão específica prévia por escrito.

ESTE SOFTWARE É FORNECIDO PELO DETENTORES DO COPYRIGHT E COLABORADORES "NO ESTADO EM QUE SE ENCONTRA"
E QUALQUER GARANTIA EXPRESSA OU IMPLÍCITA, INCLUINDO, MAS NÃO SE LIMITANDO A, GARANTIAS IMPLÍCITAS DE 
COMERCIALIZAÇÃO E ADEQUAÇÃO A UM DETERMINADO FIM SÃO REJEITADAS. EM NENHUM CASO O DETENTOR DO COPYRIGHT
OU OS COLABORADORES SERÃO RESPONSÁVEIS POR QUALQUER DANO DIRETO, INDIRETO, INCIDENTAL, ESPECIAL, EXEMPLAR 
OU CONSEQUENCIAL (INCLUINDO, MAS NÃO SE LIMITANDO A, AQUISIÇÃO DE BENS OU SERVIÇOS SUBSTITUTOS; PERDA DE 
USO, DADOS OU LUCROS; OU INTERRUPÇÃO DE NEGÓCIOS) CAUSADO E SOB QUALQUER TEORIA DE RESPONSABILIDADE, SEJA
EM CONTRATO, RESPONSABILIDADE ESTRITA OU DELITO (INCLUINDO NEGLIGÊNCIA OU OUTRO) DECORRENTE DE QUALQUER 
FORMA DO USO DESTE SOFTWARE, MESMO SE AVISADO DA POSSIBILIDADE DE TAIS DANOS.
"""

import re

def validar_cnpj(cnpj):
    # Remove da string cnpj tudo que não for número 0-9 ou letra maiuscula A-Z
    cnpj = re.sub(r'[^0-9A-Z]', '', cnpj)
    # Valida se existe caracteres alfanuméricos maiúsculos somente na raiz do CNPJ seguidos de 6 números
    if not re.match(r'^[0-9A-Z]{8}[0-9]{6}$', cnpj):
        return False
    soma = [0, 0]
    multiplicador = 2
    for n in range(2):
        soma[n] = 0
        multiplicador = 2
        for i in range(11 + n, -1, -1):
            if multiplicador > 9:
                multiplicador = 2
            # obtem o codigo ascii do caractere, 0 a 9 permanece, A 17, B 18, etc conforme Nota Técnica Cocad/Suara/RFB nº 49/2024
            soma[n] += multiplicador * (ord(cnpj[i]) - 48)
            multiplicador += 1
        resto = soma[n] % 11
        digito = 0 if resto < 2 else 11 - resto
        if digito != int(cnpj[12 + n]):
            return False
    return True
