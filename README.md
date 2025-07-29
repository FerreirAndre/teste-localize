# CnpjControl

Sistema para autenticação de usuários e cadastro de empresas por CNPJ, utilizando a API pública da ReceitaWS.

## 🧱 Tecnologias

- **Backend:** ASP.NET Core (Clean Architecture)
- **Frontend:** React + PicoCSS
- **Banco de Dados:** SQL Server (rodando em container Docker)

## 🚀 Executando o projeto

### Pré-requisitos

- [.NET 9](https://dotnet.microsoft.com/)
- [Node.js](https://nodejs.org/)
- [Docker](https://www.docker.com/)

### Banco de Dados (SQL Server)

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=localize36" \
  -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-lts
```

- **Usuário:** `sa`
- **Senha:** `localize36`
- **Porta:** `1433`

### Backend (.NET)

```bash
Migration - dotnet ef migrations add InitialMigration --project CnpjControl.Persistence --startup-project CnpjControl.Api
DatabaseUpdate - dotnet ef database update --project CnpjControl.Persistence --startup-project CnpjControl.Api
cd CnpjControl.Api
dotnet ef database update
dotnet run
```

Certifique-se de que a `ConnectionString` no `appsettings.json` aponte corretamente para o SQL Server:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=CnpjControlDb;User Id=sa;Password=localize36;TrustServerCertificate=True;"
}
```

### Frontend (React)

```bash
cd frontend
npm install
npm run dev
```

## 🔐 Funcionalidades

- Login e registro de usuário com autenticação JWT
- Cadastro de empresas por CNPJ, usando integração com a ReceitaWS
- Validação de CNPJ no frontend
- Listagem e detalhamento das empresas cadastradas por usuário

## 📁 Estrutura do Backend (Clean Architecture)

```
CnpjControl.Domain       --> Entidades e interfaces puras
CnpjControl.Application  --> Casos de uso e DTOs
CnpjControl.Persistence  --> Implementações de repositórios e EF Core
CnpjControl.Identity     --> Camada de Identidade (Autorização, JWT)
CnpjControl.Api          --> Camada de apresentação (Web API)
```

## 📦 Endpoints principais

- `POST /api/Auth/register` - Registro de novo usuário
- `POST /api/Auth/login` - Autenticação e retorno do token JWT
- `GET /api/company` - Listagem de empresas do usuário autenticado
- `POST /api/company` - Cadastro de nova empresa via CNPJ (body: string JSON)

## 📝 Observações

- A ReceitaWS pode limitar chamadas se muitos CNPJs forem consultados em sequência.
- Certifique-se de usar o token JWT no header `Authorization` para as rotas protegidas.

---

Feito por André.
