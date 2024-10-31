# Projeto C#.NET - Fiap.Web.Challenge
## Descrição:

Este projeto é uma aplicação Web em C#.NET, projetada para arquivar dados coletados através de sensores instalados em Oceanos, para averiguar a existências de resíduos poluentes. Os testes realizados foram projetados para demonstrar as práticas de DevOps, incluindo CI/CD, containerização com Docker e orquestração. A aplicação simula um ambiente de produção real, focando em agilidade e robustez.

## Pré-requisitos:

Antes de começar, certifique-se de que você possui os seguintes pré-requisitos instalados em sua máquina:

- [Docker](https://docs.docker.com/get-docker/)
- [.NET SDK](https://dotnet.microsoft.com/download/dotnet) (versão 6.0 ou superior)
- [Git](https://git-scm.com/downloads) (opcional, mas recomendado para controle de versão)
- Acesso ao GitHub para configuração do CI/CD

## Configuração do Ambiente

1. **Clone o Repositório**:

   '''bash
   git clone https://github.com/Davi0023/FIAP.git
   cd seu_repositorio

2. **Instale as Dependências**:

Se você estiver usando pacotes NuGet, execute o seguinte comando no diretório do projeto:
   '''bash
   dotnet restore

## Containerização
Construindo a Imagem Docker
1. **Construir a Imagem**:

Execute o comando abaixo para construir a imagem Docker a partir do Dockerfile:
   '''bash
   docker build -t fiap.web.challenge:latest .

2. **Verifique se a Imagem foi Criada:

   '''bash
   docker images

## Executando a Aplicação
1. **Executar o Contêiner**:

Após construir a imagem, você pode executar o contêiner com o seguinte comando:

   '''bash
   docker run -d -p 8080:80 --nifty_johnson fiap.web.challenge:latest

O -d executa o contêiner em segundo plano.
O -p 8080:80 mapeia a porta 80 do contêiner para a porta 8080 da sua máquina.


2. **Acessar a Aplicação:**

Abra seu navegador e acesse:
   http://localhost:8080

## CI/CD com GitHub Actions

**GitHub Actions**

O workflow CI/CD foi configurado para ser acionado em push para a branch master.
As etapas incluem a construção e o push da imagem Docker.


## Contribuição
Se você deseja contribuir com este projeto, sinta-se à vontade para enviar um pull request ou abrir uma issue no repositório.

## Licença
Este projeto está licenciado sob a Licença DAVI GOMES - RM550576.