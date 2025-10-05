
---

## Design Pattern

- **CQRS**: Separates read (queries) and write (commands) operations for better scalability and maintainability.
- **MediatR**: Handles the dispatching of commands and queries to their respective handlers, promoting loose coupling.
- **Entity Framework Core**: Used for data persistence and migrations.

---

## Key Features

- Create and retrieve products via API endpoints.
- Clean separation of domain, data, and API layers.
- Automatic database migration on startup.
- Easily extendable for more features (update, delete, etc.).

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (or update connection string for another provider)

### Setup

1. **Clone the repository**
    ```sh
    git clone <your-repo-url>
    cd <your-repo-folder>
    ```

2. **Update the connection string**  
   Edit `appsettings.json` in `CQRS.API`:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Your-Database-Connection-String-Here"
    }
    ```

3. **Apply migrations and run the API**
    ```sh
    dotnet build
    dotnet run --project CQRS.API
    ```

4. **API Endpoints**
    - `GET /api/products` - List all products
    - `POST /api/products` - Create a new product

---

## Packages Used

- MediatR
- MediatR.Extensions.Microsoft.DependencyInjection
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer (or your DB provider)
- Swashbuckle.AspNetCore (Swagger for API documentation)

---

## Extending

- Add more commands/queries for update/delete operations.
- Implement validation and error handling.
- Add authentication/authorization as needed.

---

## License

MIT