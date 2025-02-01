# Eleven Boilerplate

## **Descrição do Projeto**
Este projeto foi desenvolvido como um boilerplate base para criação de APIs robustas e escaláveis utilizando .NET 8.0. Ele inclui uma arquitetura limpa e modular para facilitar a reutilização e a evolução do código ao longo do tempo. O objetivo principal é fornecer uma base sólida para novos projetos, acelerando o processo de desenvolvimento.

---

## **Arquitetura Utilizada**

O projeto segue princípios de **Clean Architecture**, com as seguintes camadas principais:

- **API**: Camada de apresentação, responsável por expor os endpoints da aplicação.
- **Services**: Contém a lógica de negócio e integrações com repositórios.
- **Infra**: Implementação de persistência e comunicação com o banco de dados.
- **Core**: Contém classes e utilitários compartilhados, como notificações e validações.
- **Domain**: Define as entidades e regras de negócio principais do domínio.

---

## **Principais Funcionalidades Implementadas**

### **Autenticação e Autorização**
- JWT Token com suporte a Bearer Authentication.
- Configuração de políticas e claims para controle de acesso.

### **Notificações**
- Padrão Notification Pattern para gerenciar notificações e validações em todo o domínio.

### **CRUD Completo**
- Implementação de CRUD genérico para entidades, com suporte a SoftDelete.
- DTOs específicos para controlar os dados expostos e recebidos.

### **Filtros, Ordenação e Paginação**
- Extensão baseada no AspNetCore.IQueryable.Extensions para aplicar filtros e ordenação dinamicamente.
- Paginação integrada com suporte genérico.

### **Log e Monitoramento**
- Serilog configurado para logs detalhados:
  - Logs de nível Warning salvos em arquivo.
  - Logs de nível Fatal enviados por e-mail.

### **Documentação da API**
- Documentação completa com Swagger UI.
- Customizações no Swagger, como temas, descrições detalhadas e organização de endpoints.

### **Outras Funcionalidades**
- Suporte a multitenancy inicial utilizando `ClinicId`.
- Integração para buscas de CEP com APIs externas (planejado).

---

## **Principais Tecnologias e Bibliotecas Utilizadas**

### **Backend**
- **.NET 8.0**: Framework principal.
- **Entity Framework Core 9.0.1**: ORM para manipulação do banco de dados.
- **FluentValidation**: Validação fluida para os DTOs.
- **Serilog**: Gerenciamento de logs.
- **AspNetCore.IQueryable.Extensions**: Extensão para filtros e ordenação dinâmicos.
- **Swashbuckle**: Geração de documentação Swagger.

### **Banco de Dados**
- PostgreSQL: Banco relacional utilizado.

---

## **Estrutura de Pastas**
```
OralExpert
│
├── Eleven.OralExpert.API          // Camada de apresentação (endpoints e controllers)
│   ├── Configurations             // Configurações (JWT, Swagger, etc.)
│   ├── DTOs                       // Data Transfer Objects
│   ├── Filters                    // Filtros e queries dinâmicas
│   ├── Middlewares                // Middlewares customizados
│   └── Utilities                  // Utilitários (como DateTimeConverter)
│
├── Eleven.OralExpert.Services     // Lógica de negócio e regras do domínio
│   ├── Interfaces                 // Contratos dos serviços
│   └── Services                   // Implementações dos serviços
│
├── Eleven.OralExpert.Infra        // Persistência e banco de dados
│   ├── Data                       // Contexto do banco (AppDbContext)
│   ├── Interfaces                 // Contratos dos repositórios
│   ├── Repository                 // Repositórios concretos
│   └── Map                        // Configurações de mapeamento (Fluent API)
│
├── Eleven.OralExpert.Core         // Classes e utilitários compartilhados
│   └── Notifications              // Implementação do Notification Pattern
│
└── Eleven.OralExpert.Domain       // Entidades e regras de negócio principais
    └── Entities                   // Entidades do domínio
```

---

## **Como Rodar o Projeto**

### **Pré-requisitos**
- .NET SDK 8.0 instalado.
- PostgreSQL configurado e rodando.

### **Configuração Inicial**
1. Clone o repositório:
   ```bash
   git clone https://github.com/seuusuario/OralExpert.git
   ```

2. Configure a string de conexão no `appsettings.json`:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=OralExpert;Username=postgres;Password=suasenha"
   }
   ```

3. Restaure os pacotes NuGet:
   ```bash
   dotnet restore
   ```

4. Crie o banco de dados e aplique as migrations:
   ```bash
   dotnet ef database update --project ./Eleven.OralExpert.Infra --startup-project ./Eleven.OralExpert.API
   ```

5. Rode o projeto:
   ```bash
   dotnet run --project ./Eleven.OralExpert.API
   ```

### **Endpoints Disponíveis**
- Swagger: `http://localhost:5000/swagger`

---

## **Próximos Passos**
- Melhorar a integração de multitenancy.
- Implementar endpoints para busca de CEP com APIs externas.
- Adicionar caching para melhorar a performance de leitura.
- Integrar testes unitários e de integração com cobertura alta.

---

## **Contribuição**
Se quiser contribuir para este projeto, abra uma issue ou envie um pull request! Feedbacks e sugestões são bem-vindos.

---

**Contato:**
- **Nome:** Marcelo Oliveira
- **Email:** contato@eleven.expert
- **Site:** [https://eleven.expert](https://eleven.expert)
