# RecycleManager - Cidades ESG Inteligentes

![CI/CD Pipeline](https://github.com/SEU_USUARIO/NOME_DO_REPOSITORIO/actions/workflows/ci-cd.yml/badge.svg)
![Qodana Code Quality](https://github.com/SEU_USUARIO/NOME_DO_REPOSITORIO/actions/workflows/qodana.yml/badge.svg)

##  Sobre o Projeto
O **RecycleManager** é uma API robusta desenvolvida em .NET 8, projetada para gerenciar dados críticos de sustentabilidade e pontos de coleta. O projeto aplica o conceito de **Governança de Dados (G)** do ecossistema ESG, assegurando que o rastreamento de resíduos seja auditável e livre de falhas de integridade.

---

## Como Executar a Aplicação

### Via Docker (Recomendado)
A aplicação utiliza uma estratégia de *multi-stage build* para garantir imagens leves e seguras.
```bash
docker-compose up --build

Após o build, a documentação interativa (Swagger) estará disponível em:
 http://localhost:8080/swagger

Qualidade de Software e Governança
Este projeto utiliza uma pirâmide de testes automatizados para validar os requisitos de negócio e técnicos:

BDD (Behavior Driven Development): Cenários de usuário escritos em Gherkin (SpecFlow), garantindo que as funcionalidades atendam às necessidades dos stakeholders ambientais.

Testes de Contrato (JSON Schema): Validação rígida através do material.schema.json, assegurando que integrações externas não sofram rupturas por mudanças de schema.

Robustez de API: Validação de DTOs para garantir que apenas dados completos sejam persistidos, retornando corretamente 400 Bad Request em caso de falhas.

Para rodar a suíte de testes localmente:

Bash
dotnet test
 Pipeline CI/CD Automatizado
O ciclo de vida do software é gerido via GitHub Actions, executando as seguintes etapas a cada push na branch main:

Build & Restore: Validação da integridade do código fonte .NET 8.

Automated Testing: Execução de testes de integração, BDD e validação de contratos.

Quality Gate (Qodana): Análise estática profunda para detecção de vulnerabilidades e melhoria de performance.

Containerization: Geração de imagem Docker e preparação para deploy.

Simulated Deployment: Fluxo de entrega contínua para ambientes de Staging e Produção.

Infraestrutura e Tecnologia
Backend: .NET 8 (Web API)

Persistência: Entity Framework Core & SQL Server

Qualidade: xUnit, FluentAssertions, SpecFlow, Newtonsoft.Json.Schema

DevOps & Ops: Docker, Docker Compose, GitHub Actions, Qodana

 Desafios Superados
Integridade de Dados: Implementação de validações em nível de Controller para garantir que objetos vazios não fossem criados, corrigindo falhas de governança detectadas nos testes de integração.

Orquestração: Configuração do Docker Compose para garantir a comunicação fluida entre a API .NET e o banco de dados SQL Server.

CI/CD: Automação total do pipeline, incluindo o escaneamento de qualidade de código em tempo real.

