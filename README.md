# Sistema de Banco de Dados de Doação de Sangue

Este projeto é o desenvolvimento de um **Sistema de Banco de Dados de Doação de Sangue**.

O sistema permite o 
  **cadastro de doadores**, 
  **cadastros de doações**, 
  **gestão de usuários**,
  **relatório de doações** com a integração da API **ViaCep** para a obtenção do endereço com base no **CEP** do doador.

## Tecnologias Utilizadas Até Agora 💻

O sistema foi desenvolvido utilizando as seguintes tecnologias:

- ✅ **ASP.NET Core API**: Framework para construção da API.
- ✅ **Entity Framework Core**: ORM utilizado para manipulação do banco de dados.
- ✅ **Fluent Validation**: Biblioteca para validação de dados de entrada.
- ✅ **Padrão Repository**: Implementação do padrão Repository para desacoplamento da lógica de acesso a dados.
- ✅ **SQL Server**: Banco de dados relacional utilizado.
- ✅ **Arquitetura Limpa**: Estrutura do projeto seguindo os princípios da Arquitetura Limpa (Clean Architecture).
- ✅ **Integração da API ViaCep**: Integração com a API ViaCep para busca de endereços via CEP.
- ✅ **CQRS com MediatR**: Implementação do padrão CQRS (Command Query Responsibility Segregation) com MediatR para manipulação de comandos e consultas.
- ✅ **Unit Of Work**: Padrão utilizado para garantir que todas as alterações no banco de dados sejam feitas de forma atômica.
- ✅ **Autenticação e Autorização com JWT (Web Token)**: Implementação de segurança utilizando JSON Web Tokens para autenticação e autorização.
- ✅ **Swagger para Documentação de API**: Utilização do Swagger para gerar e fornecer documentação interativa da API.
- ✅ **Testes Unitários**: Desenvolvimento de testes unitários para garantir a qualidade e confiabilidade do código.
- ✅ **Middleware para Tratamento de Exceções**: Implementação de middleware para tratamento global de exceções.
- ✅ **Hosted Service**: Implementação de serviços hospedados para tarefas em segundo plano.
- ✅ **Fail Fast Validation com MediatR**: Validação de dados em tempo de execução utilizando o padrão "Fail Fast" com MediatR.

## Como Executar

1. Clone este repositório para sua máquina local:

    ```bash
    git clone https://github.com/Fabio-AmorimSilva/Projeto-2-Sistema-de-banco-de-dados-de-doa-o-de-sangue.git
    ```

2. Abra o projeto na sua IDE preferida (como Visual Studio ou Visual Studio Code).

3. Restaure as dependências do projeto:

    ```bash
    dotnet restore
    ```

4. Configure sua string de conexão no arquivo `appsettings.json` para o banco de dados SQL Server.

5. Execute o projeto:

    ```bash
    dotnet run
    ```

6. O sistema estará disponível em [http://localhost:5000](http://localhost:5000/v1/scalar) ou outra porta configurada.
