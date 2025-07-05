## 📦 ProductService Microservice

A lightweight .NET 9 microservice for managing product data in an e-commerce system. This service is designed with clean architecture principles, containerized with Docker, and includes essential production-ready features.

---

### ✅ Features & Technologies Used

- **.NET 9 Web API** – Built using the latest .NET 9 SDK for improved performance and long-term support.
- **MongoDB** – Integrated as the NoSQL database for storing product data.
- **FluentValidation** – Used for validating DTOs with expressive and reusable validation rules.
- **AutoMapper** – Provides seamless mapping between DTOs and domain entities.
- **Custom Middleware**:
  - Global exception handling
  - Correlation ID injection for tracing
  - Request and response body logging
- **Serilog** – Structured logging with output to both console and JSON files.
- **[AUDIT] Logging** – Captures user actions (e.g., create, update, delete) with metadata for traceability.
- **Unit Testing** – Implemented using xUnit, Moq, and FluentAssertions for service-level testing.
- **GitHub Actions CI** – Automated pipeline for restoring, building, and testing the project on each push.
- **Dockerized** – Fully containerized using Docker, runs alongside MongoDB using Docker Compose.
- **Pagination Support** – Enables efficient data browsing via query string parameters.
- **In-Memory Caching (IMemoryCache)** – Caches frequently requested product data to improve performance.

---

### 🛠️ Getting Started

1. Clone the repository.
2. Build the project using `dotnet build`.
3. Run using Docker: `docker-compose up`.
4. Access the API via `http://localhost:<your_port>`.

---

### 📌 API Endpoints

| Method | Endpoint                  | Description             |
|--------|---------------------------|-------------------------|
| GET    | /api/products             | Get all products        |
| GET    | /api/products/{id}        | Get product by ID       |
| POST   | /api/products             | Create a new product    |
| PUT    | /api/products/{id}        | Update product by ID    |
| DELETE | /api/products/{id}        | Delete product by ID    |
| GET    | /api/products/paged       | Get paginated products  |

📌 Pagination supported endpoint:  
`GET /api/products/paged?pageNumber=1&pageSize=10`

---

### 🧩 Project Structure

ProductService/
│
├── ProductService.API/ # Web API entrypoint
│ ├── Controllers/
│ ├── Middlewares/
│ ├── Program.cs
│ └── appsettings.json
│
├── ProductService.Application/ # Business logic, DTOs, Validators
│ ├── DTOs/
│ ├── Interfaces/
│ ├── Services/
│ └── Validators/
│
├── ProductService.Domain/ # Domain entities
│ └── Entities/
│
├── ProductService.Infrastructure/ # MongoDB access, repositories
│ └── Repositories/
│
├── ProductService.Tests/ # Unit test project
│ └── Services/
│
├── docker-compose.yml # Docker configuration
└── README.md

---

### 🧪 How to Test

> Tests are coded using `xUnit`, `Moq` ve `FluentAssertions`.

- In order to run the tests:

```bash
dotnet test ./ProductService.Tests/ProductService.Tests.csproj

