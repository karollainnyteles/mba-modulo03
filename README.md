# **Teles Educação - API RESTful**

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=flat-square&logo=dotnet)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=flat-square&logo=microsoft-sql-server&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=flat-square&logo=swagger&logoColor=black)

## **1. Apresentação**
Bem-vindo ao repositório do projeto **Teles Educação**. Esta API é o resultado prático do MBA DevXpert Full Stack .NET, focada no módulo de **Arquitetura, Modelagem e Qualidade de Software**.

O projeto consiste no desenvolvimento de uma plataforma educacional robusta, aplicando padrões de design de software modernos para gerir eficientemente conteúdos, alunos e processos financeiros.

---

## **2. Pilares Técnicos**
Para garantir uma aplicação escalável e de fácil manutenção, foram aplicados os seguintes conceitos:

* **DDD (Domain-Driven Design):** Modelagem orientada ao negócio com separação clara de domínios.
* **Bounded Contexts:** Cada contexto possui autonomia total e isolamento de responsabilidades.
* **CQRS:** Segregação de responsabilidades de leitura e escrita.
* **TDD (Test Driven Development):** Desenvolvimento orientado a testes para garantir a qualidade do código.
* **ACL (Anti-Corruption Layer):** Implementada no contexto de pagamentos para proteger o domínio interno de integrações externas.

---

## **3. Tecnologias Utilizadas**
| Categoria | Tecnologia |
| :--- | :--- |
| **Linguagem** | C# 13 / .NET 9 |
| **Framework Web** | ASP.NET Core Web API |
| **ORM** | Entity Framework Core |
| **Banco de Dados** | SQL Server |
| **Segurança** | ASP.NET Core Identity & JWT (JSON Web Token) |
| **Documentação** | Swagger (OpenAPI) |

---

## **4. Estrutura do Projeto (Bounded Contexts)**
A solução foi desenhada seguindo a premissa de **Contextos Delimitados**. Cada BC possui as camadas necessárias para implementar as soluções de cada problema específico de negócio, funcionando de forma independente:



* **TelesEducacao.Core:** Interfaces, entidades base e notificações compartilhadas (*Shared Kernel*).
* **TelesEducacao.Alunos:** Gestão completa do ciclo de vida do aluno.
    * Possui suas próprias camadas de `Domain`, `Application` e `Data`.
* **TelesEducacao.Conteudos:** Gestão pedagógica (Cursos e Aulas).
    * Possui suas próprias camadas de `Domain`, `Application` e `Data`.
* **TelesEducacao.Pagamentos:** Processamento financeiro.
    * `Business` e `Data`: Regras de negócio e persistência de transações.
    * `AntiCorruption`: Camada de tradução para gateways de pagamentos.
* **TelesEducacao.WebApp.API:** Ponto de entrada da aplicação e configuração da Injeção de Dependência.

---

## **5. Funcionalidades Implementadas**
* **Gestão de Cursos e Aulas:** CRUD completo para administração de conteúdo.
* **Autenticação e Autorização:** Registro de usuários e controle de acesso via Roles.
* **API RESTful:** Endpoints padronizados para integração com Front-ends ou Apps.
* **Documentação Interativa:** Interface Swagger para exploração em tempo real.

---

## **6. Como Executar o Projeto**

### **Pré-requisitos**
* .NET SDK 9.0
* SQL Server
* IDE de sua preferência (Visual Studio 2022, Rider ou VS Code)

### **Passos para Execução**

1.  **Clone o Repositório:**
    ```bash
    git clone https://github.com/karollainnyteles/mba-modulo03.git
    cd mba-modulo03
    ```

2.  **Configuração do Banco de Dados:**
    * No arquivo `appsettings.json` (em `src/TelesEducacao.WebApp.API`), configure sua string de conexão.
    * O projeto possui configuração de **Seed**. Ao rodar, o banco será criado e populado automaticamente.

3.  **Usuários de Teste (Seed):**
    | Perfil | Email | Senha |
    | :--- | :--- | :--- |
    | Admin | `admin@mail.com` | `Dev@123` |
    | Aluno | `aluno1@mail.com` | `Dev@123` |
    | Aluno | `aluno2@mail.com` | `Dev@123` |

5.  **Executar a API:**
    ```bash
    dotnet run --project src/TelesEducacao.WebApp.API
    ```
    Acesse a documentação em: `http://localhost:5035/swagger/index.html`

---

## **7. Documentação da API**
A documentação completa dos endpoints, modelos de entrada e saída pode ser acessada via Swagger após o início da aplicação no endereço local indicado acima.

---

## **8. Avaliação e Contribuições**
* Este é um projeto acadêmico; contribuições externas não são aceitas no momento.
* Para dúvidas, utilize a aba de **Issues**.
* O arquivo `FEEDBACK.md` é reservado exclusivamente para as avaliações do instrutor.

---
**Desenvolvido por [Karollainny Teles](https://github.com/karollainnyteles).**
