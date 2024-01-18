# CI/CD Pipeline 

Com o objetivo de manter o foco na criação de uma CI/CD Pipeline utilizando Github Actions que
é um dos entregáveis necessários para o Tech Challenge Fase 2. Foi reaproveitado o trabalho entregue no Tech Challenge Fase 1.

Caso queira verificar o projeto entregue na fase anterior, vide link abaixo.:

- [Tech Challenge 1](https://github.com/fiap-2nett/tc-fase1)

## Colaboradores

- [Ailton Alves de Araujo](https://www.linkedin.com/in/ailton-araujo-b4ba0520/) - RM350781
- [Bruno Fecchio Salgado](https://www.linkedin.com/in/bfecchio/) - RM350780
- [Cecília Gonçalves Wlinger](https://www.linkedin.com/in/cec%C3%ADlia-wlinger-6a5459100/) - RM351312
- [Cesar Julio Spaziante](https://www.linkedin.com/in/cesar-spaziante/) - RM351311
- [Paulo Felipe do Nascimento de Sousa](https://www.linkedin.com/in/paulo-felipe06/) - RM351707

## Como funciona a CI/CD Pipeline?

CI/CD Pipelines, incluso a criada neste projeto, tem como objetivo melhorar e automatizar processos envolvidos no Desenvolvimento de Software
como a integração contínua do código escrito pelos membros da equipe (CI) e a disponibilização e implantação do software em ambiente
de produção (CD).

A seguir temos mais detalhes sobre a CI/CD Pipeline deste projeto.

### Triggers (Gatilhos)

As Triggers (Gatilhos) são eventos que ocasionam a inicialização da Pipeline.

Em nosso caso foi assumido que toda vez que houver alterações na Branch (galho/ramificação) "master"
a Pipeline seria iniciada.

Vide abaixo código com comentários.:

```yaml
# Nome da Pipeline CI/CD
name: tc-fase2-pipeline

# Eventos que acionam a execução da pipeline
on:
  # Executar a pipeline quando há um push (envio) de código para a branch master
  push:
    branches:
      - master
  # Executar a pipeline quando há uma pull request (solicitação de envio)
  pull_request:
    branches:
      - master
 ```

### Variáveis de Ambiente

São valores definidos dentro do contexto de ambiente da Pipeline que podem ser reaproveitados durante sua execução.

Observe abaixo.:

```yaml
# Define variáveis de ambiente para a execução da pipeline
env:
  # Define a versão do .NET a ser utilizada
  DOTNET_VERSION: '7.0.x'
  
  # Define o diretório onde os pacotes NuGet serão armazenados
  NUGET_PACKAGES: ${{ github.workspace }}/.nuget/packages
```

### Jobs (Trabalhos)

Os Jobs são coleções de tarefas responsáveis pelas ações dentro de um Pipeline, como restaurar dependências,
testes unitários e entre outros.

A seguir temos um detalhamento de cada Job envolvido nesta Pipeline.

#### Build

Job responsável por configurar, restaurar as dependências e compilar nosso projeto .NET 7.

```yaml
# Definição do bloco "jobs", onde são definidos os jobs a serem executados na pipeline
jobs:
  # Job chamado "build"
  build:
    # Especifica o ambiente em que o job será executado (Ubuntu mais recente)
    runs-on: ubuntu-latest

    # Lista de passos (steps) que compõem o job
    steps:
      # Passo 1: Faz o checkout do código do repositório
      - name: Checkout code
        uses: actions/checkout@v2

      # Passo 2: Configurar o ambiente .NET usando a versão definida nas variáveis de ambiente
      - name: Setup .NET
        uses: actions/setup-dotnet@v3
        with:
          dotnet-version: ${{ env.DOTNET_VERSION }}

      # Passo 3: Utiliza o cache para armazenar pacotes NuGet, caso já tenham sido baixados anteriormente
      - uses: actions/cache@v3
        with:
          path: ${{ env.NUGET_PACKAGES }}
          key: ${{ runner.os }}-nuget-${{ hashFiles('**/*.csproj') }}
          restore-keys: |
            ${{ runner.os }}-nuget-

      # Passo 4: Restaura as dependências do projeto usando o comando "dotnet restore"
      - name: Restore dependencies
        run: dotnet restore TechChallenge.sln

      # Passo 5: Compila o projeto usando o comando "dotnet build"
      - name: Build
        run: dotnet build TechChallenge.sln --no-restore

```

#### Unit-test

Testes Unitários são responsável por isolar algumas partes menores de nosso sistema e as testar isoladamente para garantir que estas partes
estão se comportando corretamente.
São fornecidos dados de entrada fictícios devido à necessidade de isolamento dos Testes Unitários.

```yaml
# Definição do job chamado "unit-test"
unit-test:

  # Especifica o ambiente em que o job será executado (Ubuntu mais recente)
  runs-on: ubuntu-latest

  # Indica que este job depende da conclusão do job chamado "build"
  needs: build

    # Lista de passos (steps) que compõem o job
    steps:

    # Como cada Job funciona de maneira isolada, os passos para configurar, restaurar as dependências
    # e compilar nosso projeto devem ser replicados novamente. Os "Passos" de 1 à 5 são exatamente iguais
    # ao que vimos no Job de Build e por isso foram omitidos deste trecho de documentação. 

    # Passo 6: Executar os testes unitários usando o comando "dotnet test"
    - name: UnitTest
      run: dotnet test tests/TechChallenge.Application.UnitTests/TechChallenge.Application.UnitTests.csproj --no-build --verbosity normal
```

#### Architecture-test

Os Testes de Arquitetura são responsáveis por garantir que 
a arquitetura da solução está orientada à Domínio, portanto, aderente ao DDD.

```yaml
# Definição do job chamado "architecture-test"
architecture-test:
  # Especifica o ambiente em que o job será executado (Ubuntu mais recente)
  runs-on: ubuntu-latest

  # Indica que este job depende da conclusão do job chamado "build"
  needs: build

  # Lista de passos (steps) que compõem o job
    steps:

    # Como cada Job funciona de maneira isolada, os passos para configurar, restaurar as dependências
    # e compilar nosso projeto devem ser replicados novamente. Os "Passos" de 1 à 5 são exatamente iguais
    # ao que vimos no Job de Build e por isso foram omitidos deste trecho de documentação. 

  # Lista de passos (steps) que compõem o job
  
    # Passo 6: Executar testes de arquitetura usando o comando "dotnet test"
    - name: ArchitectureTest
      run: dotnet test tests/TechChallenge.ArchitectureTests/TechChallenge.ArchitectureTests.csproj --no-build --verbosity normal
```

#### Integration-test

Diferente dos Testes Unitários, os Testes Integrados visam garantir que diferentes partes de um sistema
interagem corretamente quando combinadas.

```yaml
# Definição do job chamado "integration-test"
integration-test:
  # Especifica o ambiente em que o job será executado (Ubuntu mais recente)
  runs-on: ubuntu-latest

  # Indica que este job depende da conclusão do job chamado "build"
  needs: build

  # Lista de passos (steps) que compõem o job
  steps:

    # Como cada Job funciona de maneira isolada, os passos para configurar, restaurar as dependências
    # e compilar nosso projeto devem ser replicados novamente. Os "Passos" de 1 à 5 são exatamente iguais
    # ao que vimos no Job de Build e por isso foram omitidos deste trecho de documentação. 

    # Passo 6: Executar testes de integração usando o comando "dotnet test"
    - name: IntegrationTest
      run: dotnet test tests/TechChallenge.Api.IntegrationTests/TechChallenge.Api.IntegrationTests.csproj --no-build --verbosity normal
```

#### *Para melhorar a performance da Pipeline os Jobs Unit-test, Architecture-test e Integration-test executam paralelamente.

#### Container-publish

Job responsável pela publicação da imagem de nosso Container no Docker Hub.

[Link para Imagem no Docker Hub](https://hub.docker.com/repository/docker/techchallengephase2/tech-challenge2-pipeline)

```yaml
# Definição do job chamado "container-publish"
container-publish:
  # Especifica o ambiente em que o job será executado (Ubuntu mais recente)
  runs-on: ubuntu-latest

  # Indica que este job depende da conclusão de outros jobs antes de ser executado
  needs: [build, unit-test, architecture-test, integration-test]

  # Lista de passos (steps) que compõem o job
  steps:
    # Passo 1: Faz o checkout do código do repositório
    - name: Checkout code
      uses: actions/checkout@v2

    # Passo 2: Realiza o login no Container Registry (Docker Hub, neste caso)
    - name: Login no Container Registry
      uses: docker/login-action@v1.6.0
      with:
        # Utiliza as credenciais armazenadas como secrets no repositório
        username: ${{ secrets.DOCKER_CONTAINER_REGISTRY_USERNAME }}
        password: ${{ secrets.DOCKER_CONTAINER_REGISTRY_PASSWORD }}

    # Passo 3: Constrói e publica a imagem do contêiner no Docker Hub
    - name: Build and Push Container Artifact on Docker Hub
      run: |
        # Constrói a imagem do contêiner usando o Dockerfile no caminho especificado
        docker build . --file src/TechChallenge.Api/Dockerfile -t techchallengephase2/tech-challenge2-pipeline:latest

        # Publicar a imagem do contêiner no Docker Hub
        docker push techchallengephase2/tech-challenge2-pipeline:latest

```


