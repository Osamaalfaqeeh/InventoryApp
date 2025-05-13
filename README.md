# InventoryApp (.NET 9 API)

This is a backend API built using **.NET 9**, following **Clean Architecture**, **CQRS**, and **MediatR**, with **Entity Framework Core (PostgreSQL)** and **JWT-based authentication**.

---

## Features

* Clean Architecture (Domain, Application, Infrastructure, API)
* CQRS with MediatR for Commands and Queries
* FluentValidation for input validation
* EF Core with PostgreSQL
* Repository Pattern abstraction
* JWT Authentication (Static login: `admin/admin`)
* Role-based Authorization using JWT
* Swagger UI with Bearer Token support

---

## Getting Started

### 1. Clone the repo

```bash
git clone https://github.com/Osamaalfaqeeh/InventoryApp.git
cd InventoryApp
```

### 2. Update Database

Make sure PostgreSQL is installed and running.

#### Create a database manually:

Example: `InventoryDb`

### 3. Configure `appsettings.json`

In `InventoryApp.API`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=InventoryDb;Username=postgres;Password=your_password"
}
```

### 4. Run Migrations

```bash
cd InventoryApp.Infrastructure
dotnet ef database update --startup-project ../InventoryApp.API
```

### 5. Run the App

```bash
cd ../InventoryApp.API
dotnet run --project InventoryApp.API
```

Go to: `https://localhost:<port>/swagger`

---

## Authentication

### Login (POST)

```http
POST /api/auth/login
{
  "username": "admin",
  "password": "admin"
}
```

Returns:

```json
{
  "token": "<JWT_TOKEN>"
}
```

### Use Token in Swagger

* Click "Authorize" in Swagger
* Enter: `your_token`
* You can now access protected endpoints

---

## Sample Endpoint: Products

| Method | Endpoint             | Description       |
| ------ | -------------------- | ----------------- |
| GET    | `/api/products`      | Get all products  |
| GET    | `/api/products/{id}` | Get product by ID |
| POST   | `/api/products`      | Create product    |
| PUT    | `/api/products/{id}` | Update product    |
| PATCH  | `/api/products/{id}` | Partially update  |
| DELETE | `/api/products/{id}` | Delete product    |

All protected by `[Authorize]`

---

## Architecture Layers

```
InventoryApp.Domain         <- Entity definitions only
InventoryApp.Application    <- DTOs, Validators, CQRS Commands & Queries
InventoryApp.Infrastructure <- Repositories, EF DbContext, Services
InventoryApp.API            <- Controllers, Auth, Swagger, Program.cs
```

---

## Notes

* `admin/admin` is the only static login.
* Product validation is handled via FluentValidation.
* Global exception handler returns clean error responses.