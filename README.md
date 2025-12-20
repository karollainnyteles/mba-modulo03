# **Teles Educação - API RESTful**

## **1. Apresentação**

Bem-vindo ao repositório do projeto **Teles Educação**. Este projeto é uma entrega do MBA DevXpert Full Stack .NET e é referente ao módulo **Arquitetura, Modelagem e Qualidade de Software**.

Desenvolvimento da API de uma plataforma educacional com múltiplos boundede contexts (BC), aplicando DDD, TDD, CQRS e padrões arquiteturais para gestão eficiente de conteúdos educacionais, alunos e processos financeiros.


### **Autor**
- **Karollainny Teles**

## **2. Proposta do Projeto**

O projeto consiste em:

- **API RESTful:** Exposição dos recursos da plataforma de educação para integração com outras aplicações ou desenvolvimento de front-ends alternativos.
- **Autenticação e Autorização:** Autenticação via JWT.
- **Acesso a Dados:** Implementação de acesso ao banco de dados através do EF Core.

## **3. Tecnologias Utilizadas**

- **Linguagem de Programação:** C#
- **Frameworks:**
  - ASP.NET Core Web API
  - Entity Framework Core
- **Banco de Dados:** SQL Server
- **Autenticação e Autorização:**
  - ASP.NET Core Identity
  - JWT (JSON Web Token) para autenticação na API
- **Documentação da API:** Swagger

## **4. Estrutura do Projeto**

A estrutura do projeto é organizada da seguinte forma:


- src/
  - TelesEducacao.Alunos.Application/ - Camada de aplicação do bc de Alunos
  - TelesEducacao.Alunos.Data/ - Camada de acesso a dados do bc de Alunos
  - TelesEducacao.Alunos.Domain/ - Camada de domínio do bc de Alunos
  - TelesEducacao.Conteudos.Application/ - Camada de aplicação do bc de Alunos
  - TelesEducacao.Conteudos.Data/ - Camada de acesso a dados do bc de Alunos
  - TelesEducacao.Conteudos.Domain/ - Camada de domínio do bc de Alunos
  - TelesEducacao.Pagamentos.AntiCorruption/ - Camada anti corrupção do bc de pagamentos
  - TelesEducacao.Pagamentos.Business -
  - TelesEducacao.Pagamentos.Data - Camada de acesso dados do bc de pagamentos
  - TelesEducacao.Core - Interfaces e entidades bases compartilhadas entre os bcs
  - TelesEducacao.WebApp.API - Api 
- README.md - Arquivo de Documentação do Projeto
- FEEDBACK.md - Arquivo para Consolidação dos Feedbacks
- .gitignore - Arquivo de Ignoração do Git

## **5. Funcionalidades Implementadas**

- **CRUD para curso, aula:** Permite criar, editar, visualizar e excluir cursos e aulas.
- **Autenticação:** criação e autenticação de usuário.
- **API RESTful:** Exposição de endpoints para operações CRUD via API.
- **Documentação da API:** Documentação automática dos endpoints da API utilizando Swagger.

## **6. Como Executar o Projeto**

### **Pré-requisitos**

- .NET SDK 9.0
- SQL Server
- Visual Studio 2022 (ou qualquer IDE de sua preferência)
- Git

### **Passos para Execução**

1. **Clone o Repositório:**
   - `git clone https://github.com/karollainnyteles/mba-modulo03.git`
   - `cd nome-do-repositorio`

2. **Configuração do Banco de Dados:**
   - No arquivo `appsettings.json`, configure a string de conexão do SQL Server.
   - Rode o projeto para que a configuração do Seed crie o banco e popule com os dados básicos

3. **Usuários criados:**
   - **Admin:** Email: `admin@mail.com` e Senha: `Dev@123`
   - **Aluno 1:** Email: `aluno1@mail.com` e Senha: `Dev@123`
   - **Aluno 2:** Email: `aluno2@mail.com` e Senha: `Dev@123`
   - **Cliente:** Email: `cliente@mail.com` e Senha: `Dev@123`

4. **Executar a API:**
   - `cd src/TelesEducacao.WebApp.API`
   - `dotnet run`
   - Acesse a documentação da API em: `http://localhost:5035/swagger/index.html`

## **7. Instruções de Configuração**

- **JWT para API:** As chaves de configuração do JWT estão no `appsettings.json`.
- **Migrações do Banco de Dados:** As migrações são gerenciadas pelo Entity Framework Core. Não é necessário aplicar devido a configuração do Seed de dados.

## **8. Documentação da API**

A documentação da API está disponível através do Swagger. Após iniciar a API, acesse a documentação em:

- http://localhost:5035/swagger/index.html

## **9. Avaliação**

- Este projeto é parte de um curso acadêmico e não aceita contribuições externas. 
- Para feedbacks ou dúvidas utilize o recurso de Issues
- O arquivo `FEEDBACK.md` é um resumo das avaliações do instrutor e deverá ser modificado apenas por ele.
