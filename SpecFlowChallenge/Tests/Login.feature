#Feature: Feature1
#
#A short summary of the feature
#
#@tag1
#Scenario: [scenario name]
#	Given [context]
#	When [action]
#	Then [outcome]
Feature: Login

  # Cenário positivo: verifica se o login com credenciais válidas é bem-sucedido
  Scenario: Login bem-sucedido com credenciais corretas
     Dado que o usuário tem as credenciais válidas
     Quando o usuário faz uma requisição de login
     Então o sistema responde com status code 200
     E o corpo da resposta contém um token de autenticação válido

  # Cenário negativo: verifica se o login com credenciais inválidas falha corretamente
  Scenario: Login falha com credenciais incorretas
     Dado que o usuário tem credenciais inválidas
     Quando o usuário faz uma requisição de login
     Então o sistema responde com status code 401
     E o corpo da resposta contém uma mensagem de erro
