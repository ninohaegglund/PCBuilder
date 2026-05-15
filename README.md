# PCBuilder

PCBuilder is an ASP.NET Core solution for running a small PC-building workflow. It includes an MVC web frontend plus service APIs for component browsing, authentication, customer orders, inventory, wallets, and assembled computers.

## Features

- User registration, login, cookie sessions, and JWT-backed API authentication.
- Component catalog with seeded PC parts such as CPUs, GPUs, memory kits, motherboards, cases, power supplies, storage, peripherals, and accessories.
- Shop and inventory flow where users can buy components and spend from a wallet balance.
- Customer order workflow for accepting, rejecting, building, completing, and reviewing PC builds.
- Builder service for storing assembled computers and builder inventory items.
- Swagger UI for the API projects in development.

## Solution Structure

| Project | Purpose |
| --- | --- |
| `PCBuilder.Web` | ASP.NET Core MVC frontend for account, shop, inventory, computer builder, orders, reviews, and workshop pages. |
| `PCBuilder.Service.ComponentsAPI` | Component catalog API and seed data. |
| `PCBuilder.Service.BuilderServiceAPI` | API for built computers and builder inventory. |
| `PCBuilder.Services.CustomerAPI` | API for customers, orders, generated reviews, and order status changes. |
| `PCBuilder.Services.IdentityAPI` | API for registration, login, roles, JWT tokens, and current-user data. |
| `PCBuilder.Services.InventoryAPI` | API for user wallets and purchased inventory items. |
| `Contracts` | Shared response DTOs used by services. |

## Tech Stack

- .NET 10
- ASP.NET Core MVC and Web API
- Entity Framework Core with SQL Server LocalDB
- AutoMapper
- JWT bearer authentication and cookie authentication
- Swagger / Swashbuckle
- Bootstrap, jQuery, and Razor views

## Prerequisites

- .NET 10 SDK
- SQL Server LocalDB, or another SQL Server instance with updated connection strings
- Visual Studio or a terminal capable of running multiple .NET projects
- Trusted local HTTPS development certificate:

```powershell
dotnet dev-certs https --trust
```

## Configuration

The projects are configured for local development by default. Most services use this database:

```text
Server=(localdb)\MSSQLLocalDB;Database=PCbuilderDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True
```

Service URLs are configured in each project's `appsettings.json`. The default HTTPS ports are:

| Service | HTTPS URL |
| --- | --- |
| Web frontend | `https://localhost:7121` |
| Components API | `https://localhost:7255` |
| Builder Service API | `https://localhost:7219` |
| Customer API | `https://localhost:7290` |
| Identity API | `https://localhost:7011` |
| Inventory API | `https://localhost:7185` |

Development JWT settings are stored in `appsettings.json`. Move real secrets to user secrets, environment variables, or a secret manager before using this outside local development.

## Database Setup

The Components API and Identity API apply their migrations automatically on startup. The other service projects include migrations but may need to be updated manually when starting from an empty LocalDB database:

```powershell
dotnet ef database update --project PCBuilder.Service.BuilderServiceAPI --context BuildDataContext
dotnet ef database update --project PCBuilder.Services.CustomerAPI --context CustomerDbContext
dotnet ef database update --project PCBuilder.Services.InventoryAPI --context InventoryDbContext
```

The seeders create starter component data, customer/order data, roles, and a development admin account.

## Running Locally

Restore and build the solution:

```powershell
dotnet restore
dotnet build PCBuilder.sln
```

Start each project in a separate terminal:

```powershell
dotnet run --project PCBuilder.Service.ComponentsAPI --launch-profile https
dotnet run --project PCBuilder.Service.BuilderServiceAPI --launch-profile https
dotnet run --project PCBuilder.Services.IdentityAPI --launch-profile https
dotnet run --project PCBuilder.Services.CustomerAPI --launch-profile https
dotnet run --project PCBuilder.Services.InventoryAPI --launch-profile https
dotnet run --project PCBuilder.Web --launch-profile https
```

Then open the web app:

```text
https://localhost:7121
```

The solution also includes a Visual Studio multiple-startup profile named `multiple startup`, which starts the web app and all service projects together.

## API Documentation

When running in the Development environment, each API exposes Swagger UI at `/swagger`:

- `https://localhost:7255/swagger` - Components API
- `https://localhost:7219/swagger` - Builder Service API
- `https://localhost:7011/swagger` - Identity API
- `https://localhost:7290/swagger` - Customer API
- `https://localhost:7185/swagger` - Inventory API

## Common Workflow

1. Register or log in through the web frontend.
2. Browse and buy parts in the shop.
3. Review purchased parts in the inventory.
4. Accept a customer order.
5. Build a computer from available parts.
6. Complete the order and review the generated customer feedback.

## Development Notes

- The app uses a shared LocalDB database name across the services for local development.
- The web app stores the API token in session and signs users in with cookie authentication.
- A wallet is created automatically for a user the first time wallet data is requested.
- No dedicated automated test project is currently included in the solution.
