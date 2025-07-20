# 🔍 CpfValidatorAPI

API REST desenvolvida com **.NET 7** para validar números de CPF (Cadastro de Pessoa Física – Brasil), seguindo **princípios SOLID** e arquitetura limpa.

---

## 📦 Tecnologias

- [.NET 7](https://dotnet.microsoft.com/en-us/)
- **ASP.NET Core Web API**
- **MSTest / xUnit** – Testes automatizados
- **CORS** – Comunicação com frontend Vue
- **Swagger** – Documentação automática da API
- **Dependency Injection (DI)** nativa do .NET

---

## ⚙️ Como executar

### Pré-requisitos

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- IDE recomendada: **Visual Studio 2022** ou **VS Code**

### Executar API

```bash
# Restaura dependências
dotnet restore

# Compila a aplicação
dotnet build

# Executa a API
dotnet run --project CpfValidatorAPI

Acesse: https://localhost:7022/swagger
