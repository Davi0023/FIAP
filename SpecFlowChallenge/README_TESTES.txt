# SpecFlow Challenge - Testes Automatizados com BDD

Este projeto contém testes automatizados de API para um sistema de autenticação, utilizando BDD com SpecFlow, escrita de cenários em Gherkin e validação de contrato com JSON Schema.

## Índice
- Requisitos
- Configuração do Ambiente
- Estrutura dos Cenários de Teste
- Execução dos Testes
- Evidência dos Testes

---

## Requisitos

Para executar este projeto, os seguintes itens são necessários:

- **Visual Studio 2022** (Português - BR)
- **.NET 6 ou superior**
- **SpecFlow** (Extensão para Visual Studio)
- **Pacotes NuGet**
  - SpecFlow
  - SpecFlow.NUnit
  - Newtonsoft.Json
  - Newtonsoft.Json.Schema
  - RestSharp (107.0 ou superior)
  - FluentAssertions

## Configuração do Ambiente

1. **Clone o projeto** para o seu diretório local:
   
2. **Abra o projeto no Visual Studio**.

3. **Instale os pacotes necessários**:
   - No Visual Studio, vá até o `Gerenciador de Pacotes NuGet` e instale os pacotes mencionados na seção Requisitos.

4. **Configuração de dependências**:
   - Para garantir que todas as dependências estão corretamente instaladas, você pode atualizar o `RestSharp` para a versão 107.0 ou superior para resolver problemas de compatibilidade com `Method`.

## Estrutura dos Cenários de Teste

Abaixo estão os cenários de teste criados em Gherkin para validar o sistema de autenticação da aplicação.

### Cenário 1: Login com credenciais válidas
```gherkin
Dado que o usuário tem as credenciais válidas
Quando o usuário faz uma requisição de login
Então o sistema responde com status code 200
E o corpo da resposta contém um token de autenticação válido

Este cenário valida que, ao fornecer credenciais corretas, o sistema retorna um status code 200 e um token de autenticação válido.


### Cenário 2: Login com credenciais inválidas
Dado que o usuário tem credenciais inválidas
Quando o usuário faz uma requisição de login
Então o sistema responde com status code 401
E o corpo da resposta contém uma mensagem de erro

Este cenário simula uma tentativa de login com credenciais incorretas, verificando se o sistema retorna um status code 401 e uma mensagem de erro informando o problema.

### Cenário 3: Tentativa de login com campos ausentes
Dado que o usuário não fornece credenciais
Quando o usuário faz uma requisição de login
Então o sistema responde com status code 400
E o corpo da resposta contém uma mensagem de erro indicando falta de dados

Este cenário simula uma tentativa de login com dados incompletos ou ausentes e espera uma resposta 400 com uma mensagem de erro indicando a ausência de dados necessários.