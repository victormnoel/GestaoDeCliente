# GestaoDeCliente

Este projeto é uma aplicação parcial de um sistema desenvolvido para gestão de Clientes, com o objetivo é cadastrar novos clientes e visualizar clientes já cadastrados.

## Funcionalidades

- Cadastro de novos clientes
- Listagem de clientes cadastrados

## Tecnologias Utilizadas

**Backend**
- .NET Web API Rest(C#)
- MediatR (implementação do padrão Mediator em conjunto com CQRS)
- NHibernate (ORM para persistência de dados)


**Banco de Dados**
- SQLite

**Documentação e Testes de API**
- Postman (documentação e testes dos endpoints)
  
**Testes**
- xUnit (testes unitários)
- FakeItEasy (mock)
- Bogus / AutoFixture (carga de teste)

**Gerenciamento**
- NuGet (dependências)
- Git / GitHub (controle de versão)

## Padrões e Boas Práticas

- **Arquitetura Limpa:** Separação clara entre camadas de domínio, aplicação, infraestrutura e apresentação.
- **DDD (Domain-Driven Design):** Organização do código baseada em domínios de negócio.
- **CQRS (Command Query Responsibility Segregation):** Separação entre operações de escrita (commands) e leitura (queries), garantindo maior clareza, escalabilidade e manutenibilidade.
- **Repository Pattern:** Abstração do acesso a dados.
- **Injeção de Dependência:** Facilita o desacoplamento entre componentes.
- **Validação de Dados:** Garantia de integridade dos dados inseridos pelo usuário.
- **Testes Unitários:** Cobertura das principais funcionalidades para garantir a qualidade do código.
- **Mediator Pattern com MediatR:** Implementação de mediadores para orquestrar comandos e consultas no padrão CQRS, reduzindo acoplamento entre camadas.
- **API REST:** Padrão de comunicação entre cliente e servidor, utilizando endpoints claros e semânticos.
