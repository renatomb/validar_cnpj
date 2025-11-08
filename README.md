# Validar CNPJ

Biblioteca multiplataforma para validação de CNPJ numérico e alfanumérico conforme **Nota Técnica conjunta COCAD/SUARA/RFB nº 49 de 14 de maio de 2024**.

[![License](https://img.shields.io/badge/License-BSD_3--Clause-blue.svg)](LICENSE)

## 📋 Descrição

Este projeto oferece implementações da função de validação de CNPJ (Cadastro Nacional da Pessoa Jurídica) em múltiplas linguagens de programação. A validação suporta tanto CNPJs numéricos tradicionais quanto os novos CNPJs alfanuméricos, conforme as regras estabelecidas pela Receita Federal do Brasil.

### Novidade: CNPJ Alfanumérico

A partir de 2024, a Receita Federal do Brasil passou a permitir CNPJs alfanuméricos para ampliar a capacidade de cadastros. As implementações neste repositório seguem as especificações técnicas oficiais para validação desses novos formatos.

## 🌐 Linguagens Suportadas

- **Python** (`validar_cnpj.py`)
- **JavaScript** (`validar_cnpj.js`)
- **PHP** (`validar_cnpj.php`)
- **Perl** (`validar_cnpj.pl`)
- **C#** (`ValidarCNPJ.cs`)

## 🚀 Como Usar

### Python

```python
from validar_cnpj import validar_cnpj

# Validar CNPJ numérico
if validar_cnpj("11.222.333/0001-81"):
    print("CNPJ válido")

# Validar CNPJ alfanumérico
if validar_cnpj("A1B2C3D4000195"):
    print("CNPJ alfanumérico válido")
```

### JavaScript

```javascript
// Validar CNPJ numérico
if (validar_cnpj("11.222.333/0001-81")) {
    console.log("CNPJ válido");
}

// Validar CNPJ alfanumérico
if (validar_cnpj("A1B2C3D4000195")) {
    console.log("CNPJ alfanumérico válido");
}
```

### PHP

```php
<?php
require_once 'validar_cnpj.php';

// Validar CNPJ numérico
if (validar_cnpj("11.222.333/0001-81")) {
    echo "CNPJ válido";
}

// Validar CNPJ alfanumérico
if (validar_cnpj("A1B2C3D4000195")) {
    echo "CNPJ alfanumérico válido";
}
?>
```

### Perl

```perl
use validar_cnpj;

# Validar CNPJ numérico
if (validar_cnpj("11.222.333/0001-81")) {
    print "CNPJ válido\n";
}

# Validar CNPJ alfanumérico
if (validar_cnpj("A1B2C3D4000195")) {
    print "CNPJ alfanumérico válido\n";
}
```

### C#

```csharp
using System;

class Program
{
    static void Main()
    {
        // Validar CNPJ numérico
        if (CNPJValidator.ValidarCNPJ("11.222.333/0001-81"))
        {
            Console.WriteLine("CNPJ válido");
        }

        // Validar CNPJ alfanumérico
        if (CNPJValidator.ValidarCNPJ("A1B2C3D4000195"))
        {
            Console.WriteLine("CNPJ alfanumérico válido");
        }
    }
}
```

## 📝 Formato do CNPJ

### CNPJ Numérico (Tradicional)
- Formato: `XX.XXX.XXX/XXXX-XX`
- Exemplo: `11.222.333/0001-81`
- Total: 14 dígitos numéricos

### CNPJ Alfanumérico (Novo)
- Formato: `XX.XXX.XXX/XXXX-XX` onde os primeiros 8 caracteres podem ser letras (A-Z) ou números (0-9)
- Os últimos 6 caracteres devem ser numéricos
- Exemplo: `A1.B2C.3D4/0001-95`
- Total: 8 caracteres alfanuméricos + 6 dígitos numéricos

## 🔍 Como Funciona

A validação do CNPJ segue o algoritmo de validação de dígitos verificadores definido pela Receita Federal:

1. **Limpeza**: Remove todos os caracteres que não sejam números (0-9) ou letras maiúsculas (A-Z)
2. **Validação de Formato**: Verifica se possui 8 caracteres alfanuméricos seguidos de 6 números
3. **Cálculo dos Dígitos Verificadores**: 
   - Para caracteres alfanuméricos, utiliza o código ASCII:
     - Números 0-9 mantêm seus valores (0-9)
     - Letras A-Z são convertidas: A=17, B=18, C=19, ... Z=42
   - Aplica o algoritmo de módulo 11 com multiplicadores de 2 a 9
   - Calcula dois dígitos verificadores (12ª e 13ª posições)
4. **Validação**: Compara os dígitos calculados com os fornecidos

## ⚙️ Especificações Técnicas

- **Base Legal**: Nota Técnica conjunta COCAD/SUARA/RFB nº 49 de 14 de maio de 2024
- **Algoritmo**: Módulo 11 com pesos de 2 a 9
- **Conversão ASCII**: Caracteres numéricos e alfabéticos maiúsculos
- **Dígitos Verificadores**: Últimos 2 dígitos do CNPJ

## 🧪 Testes

Você pode testar as funções com os seguintes exemplos:

### CNPJs Válidos
- `11222333000181` (numérico)
- `11.222.333/0001-81` (formatado)
- `A1B2C3D4000195` (alfanumérico)
- `A1.B2C.3D4/0001-95` (alfanumérico formatado)

### CNPJs Inválidos
- `11222333000180` (dígito verificador incorreto)
- `12345678901234` (sequência inválida)
- `ABC1234500019X` (caractere inválido na posição numérica)

## 📄 Licença

Este projeto está licenciado sob a **BSD 3-Clause License**. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

### Resumo da Licença

- ✅ Uso comercial permitido
- ✅ Modificação permitida
- ✅ Distribuição permitida
- ✅ Uso privado permitido
- ⚠️ Sem garantias
- ⚠️ Deve manter o aviso de copyright

## 👤 Autor

**Eng. Renato Monteiro Batista**

- GitHub: [@renatomb](https://github.com/renatomb)
- URL do Projeto: [https://github.com/renatomb/validar_cnpj](https://github.com/renatomb/validar_cnpj)

## 🤝 Contribuindo

Contribuições são bem-vindas! Sinta-se à vontade para:

1. Fazer fork do projeto
2. Criar uma branch para sua feature (`git checkout -b feature/NovaFuncionalidade`)
3. Commit suas mudanças (`git commit -m 'Adiciona nova funcionalidade'`)
4. Push para a branch (`git push origin feature/NovaFuncionalidade`)
5. Abrir um Pull Request

## 📚 Referências

- [Nota Técnica COCAD/SUARA/RFB nº 49/2024](https://www.gov.br/receitafederal) - Especificação oficial do CNPJ alfanumérico
- [Receita Federal do Brasil](https://www.gov.br/receitafederal)

## 🔄 Versão

**Versão 1.0** - 11/07/2024

## ❓ FAQ

### Por que CNPJ alfanumérico?

A Receita Federal implementou CNPJs alfanuméricos para expandir a capacidade de cadastros, evitando o esgotamento dos números disponíveis com o formato numérico tradicional.

### As funções aceitam CNPJ formatado?

Sim! Todas as implementações removem automaticamente caracteres de formatação (pontos, barras, hífens) antes da validação.

### Diferença entre validação numérica e alfanumérica?

As funções validam ambos os formatos automaticamente. O algoritmo detecta e processa corretamente tanto CNPJs numéricos quanto alfanuméricos.

## 🐛 Problemas Conhecidos

Não há problemas conhecidos no momento. Se encontrar algum bug, por favor [abra uma issue](https://github.com/renatomb/validar_cnpj/issues).

---

**Nota**: Este projeto foi desenvolvido com base na documentação oficial da Receita Federal do Brasil e segue rigorosamente as especificações técnicas publicadas.
