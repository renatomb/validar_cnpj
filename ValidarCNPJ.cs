/*
Função para validação de CNPJ numérico ou alfanumérico em C#
Autor: Eng. Renato Monteiro Batista
Versão: 1.0 - 11/07/2024
URL: https://github.com/renatomb/validar_cnpj

@param string cnpj
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
*/

using System;
using System.Text.RegularExpressions;

public class CNPJValidator
{
    public static bool ValidarCNPJ(string cnpj)
    {
        // Remove da string cnpj tudo que não for número 0-9 ou letra maiuscula A-Z
        cnpj = Regex.Replace(cnpj, "[^0-9A-Z]", "");
        
        // Valida se existe caracteres alfanuméricos maiúsculos somente na raiz do CNPJ seguidos de 6 números
        if (!Regex.IsMatch(cnpj, "^[0-9A-Z]{8}[0-9]{6}$"))
        {
            return false;
        }

        int[] soma = new int[2];
        int multiplicador = 2;

        for (int n = 0; n < 2; n++)
        {
            soma[n] = 0;
            multiplicador = 2;

            for (int i = (11 + n); i >= 0; i--)
            {
                if (multiplicador > 9)
                {
                    multiplicador = 2;
                }

                // obtem o codigo ascii do caractere, 0 a 9 permanece, A 17, B 18, etc conforme Nota Técnica Cocad/Suara/RFB nº 49/2024
                soma[n] += multiplicador * (cnpj[i] - 48);
                multiplicador++;
            }

            int resto = soma[n] % 11;
            int digito = (resto < 2) ? 0 : 11 - resto;

            if (digito != (cnpj[12 + n] - '0'))
            {
                return false;
            }
        }

        return true;
    }
}