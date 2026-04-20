# Projeto - RecycleManager (Cidades ESG Inteligentes)

# Descrição

API desenvolvida em .NET com foco em gerenciamento de dados relacionados a sustentabilidade (ESG), utilizando boas práticas de DevOps.

---

#Como executar com Docker

### Pré-requisitos

* Docker instalado

### Passos

```bash
docker-compose up --build
```

A aplicação estará disponível em:
(http://localhost:8080/swagger)
---

# Pipeline CI/CD

Foi utilizado o GitHub Actions para automação do ciclo de vida da aplicação.

### Etapas do pipeline:

* Build da aplicação (.NET)
* Execução de testes automatizados
* Build da imagem Docker
* Deploy simulado em ambiente de staging
* Deploy simulado em ambiente de produção

O pipeline é acionado automaticamente a cada push na branch main.

---

# Containerização

A aplicação foi containerizada utilizando Docker com estratégia de **multi-stage build**, permitindo:

* Redução do tamanho da imagem final
* Separação entre build e execução
* Maior eficiência e segurança

Também foi utilizado Docker Compose para orquestrar:

* API (.NET)
* Banco de dados SQL Server

---

# Prints do funcionamento

<img width="1340" height="596" alt="image" src="https://github.com/user-attachments/assets/2824dae8-76ba-49fc-a897-31eb7513fe23" />

* Pipeline rodando no GitHub Actions
* API funcionando no navegador/Postman
* Containers rodando (docker ps)

---

# Tecnologias utilizadas

* .NET 8
* SQL Server
* Docker
* Docker Compose
* GitHub Actions

---

# Desafios encontrados

* Configuração do pipeline CI/CD
* Erro de Dockerfile não encontrado no pipeline
* Integração entre aplicação e banco via Docker

---

# Checklist

[x] Projeto compactado em .ZIP com estrutura organizada
[x] Dockerfile funcional
[x] docker-compose.yml
[x] Pipeline com etapas de build, teste e deploy
[x] README.md com instruções e prints
[x] Documentação técnica com evidências
[x] Deploy realizado (simulado)
