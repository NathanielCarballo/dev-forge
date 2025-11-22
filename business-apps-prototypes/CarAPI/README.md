# CarAPI — ASP.NET Core Web API (.NET 7 + EF Core, SQL Server)
**CarAPI** is a production-style Web API demonstrating clean controller design, Entity Framework Core with SQL Server, Swagger, and DTO-driven contracts. It exposes endpoints for **Cars** and **Users** with relational mapping (User ↔ Cars).
---

## Tech Stack

- **Runtime:** .NET 7
- **Frameworks:** ASP.NET Core Web API, Entity Framework Core (SQL Server)
- **Data:** SQL Server (LocalDB/SQL Express/full instance)
- **Tooling:** dotnet CLI, Swagger/OpenAPI, JSON, Git/GitHub
- **Concepts:** Controllers, DTOs, validation, migrations, DI, layered design
---

## Features

- CRUD endpoints for **Cars** and **Users**
- **EF Core** DbContext + migrations, SQL Server persistence
- **Swagger UI** for interactive docs
- One-to-many relation: **User** has many **Cars**
- Clean separation across Controllers, Models, Data (DbContext), and Migrations
---

## Getting Started

### Prerequisites
- .NET 7 SDK
- SQL Server (LocalDB or SQL Express is fine)
- (Optional) EF tooling:
```bash
dotnet tool install --global dotnet-ef
```
### 1) Restore & Build
```bash
dotnet restore
dotnet build
```
### 2) Configure Connection String
Edit `appsettings.json` (or `appsettings.Development.json`) and set `ConnectionStrings:DefaultConnection` to your SQL Server instance.

### 3) Create/Update Database
```bash
dotnet ef database update
```
### 4) Run
```bash
dotnet run
```
Swagger UI is available at:
- https://localhost:7252/swagger
- http://localhost:5182/swagger

---

## API Reference

### Cars
- **HTTPGET** `api/Car`
- **HTTPGET** `/api/Car/{id}`
- **HTTPPOST** `api/Car`
- **HTTPPUT** `/api/Car/{id}`
- **HTTPDELETE** `/api/Car/{id}`

**Examples**
```bash
curl https://localhost:7252/api/car
curl https://localhost:7252/api/car/{id}
```
```bash
curl -X POST https://localhost:7252/api/car \
  -H "Content-Type: application/json" \
  -d '{
    "make": "Ford",
    "model": "F-150",
    "color": "Red",
    "year": 1987,
    "price": 12000.0
  }'
```
```bash
curl -X PUT https://localhost:7252/api/car/{id} \
  -H "Content-Type: application/json" \
  -d '{
    "make": "Ford",
    "model": "F-150 XLT",
    "color": "Blue",
    "year": 1988,
    "price": 13500.0
  }'
```
```bash
curl -X DELETE https://localhost:7252/api/car/{id}
```

### Users
- **HTTPGET** `api/User`
- **HTTPGET** `/api/User/id`
- **HTTPPOST** `api/User`
- **HTTPPUT** `/api/User/id`
- **HTTPDELETE** `/api/User/id`
```bash
curl https://localhost:7252/api/user
curl https://localhost:7252/api/user/id
```
```bash
curl -X POST https://localhost:7252/api/user \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Nate",
    "email": "nate@example.com",
    "password": "S3cret!",
    "dateOfBirth": "1990-01-01"
  }'
```

> Note: Replace `{id}` with a concrete GUID returned by POST.

---

## Data Model

**DbSets**
- Users
- Cars

**Car** (properties inferred from source)
```csharp
public Guid Id { get; set; }
public string? Make { get; set; }
public string? Model { get; set; }
public string? Color { get; set; }
public int? Year { get; set; }
public float? Price { get; set; }
public Guid? UserId { get; set; }
public User? User { get; set; }
```
**User** (properties inferred from source)
```csharp
public Guid Id { get; set; }
public string? Name { get; set; }
public string? Email { get; set; }
public string? Password { get; set; }
public DateTime? DateOfBirth { get; set; }
public List<Car>? Cars { get; set; }
```

---

## Project Structure
```
CarAPI/
├─ Controllers/
│  ├─ CarController.cs
│  └─ UserController.cs
├─ Data/
│  └─ AppDbContext.cs
├─ Migrations/
├─ Models/
│  ├─ Car.cs
│  └─ User.cs
├─ Properties/
│  └─ launchSettings.json
├─ appsettings.json
├─ Program.cs
└─ CarApi.csproj
```

---

## Roadmap

- [ ] Validation attributes + ModelState checks
- [ ] DTO mapping (e.g., AutoMapper)
- [ ] Filtering/pagination/sorting (`GET /api/car?make=Ford&page=1&pageSize=20`)
- [ ] Unit & integration tests (xUnit + WebApplicationFactory)
- [ ] JWT auth + roles
- [ ] Dockerfile + Azure SQL deployment
