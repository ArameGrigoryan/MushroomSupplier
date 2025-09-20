# MushroomSupplier
A .NET-based web API for managing mushroom supply operations.
## Overview
The MushroomSupplier project is a web API developed using C# and ASP.NET Core. It provides endpoints to manage various aspects of a mushroom supply business, including inventory, orders, and customer interactions.
Designed for scalability and ease of integration, this API serves as a backend solution for applications in the agricultural and food supply sectors.
## Features
- Inventory Management: Track and update mushroom stock levels.
- Order Processing: Handle customer orders and manage order statuses.
- Customer Management: Maintain customer profiles and order histories.
- Authentication & Authorization: Secure endpoints with JWT-based authentication. - Data Validation: Ensure data integrity with model validation.
## Technologies Used
- C#
- ASP.NET Core
- Entity Framework Core
- SQL Server (or your preferred database) - JWT for authentication
## Installation
1. Clone the repository:
   git clone https://github.com/ArameGrigoryan/MushroomSupplier.git

2. Navigate to the project directory: cd MushroomSupplier
3. Restore dependencies: dotnet restore
4. Update the database connection string in appsettings.json: "ConnectionStrings": {
   "DefaultConnection": "Your_Connection_String_Here" }
5. Apply database migrations: dotnet ef database update
6. Run the application: dotnet run
## API Endpoints
The API provides the following endpoints:
- GET /api/products: Retrieve a list of all mushroom products. - GET /api/products/{id}: Get details of a specific product.
- POST /api/orders: Create a new customer order.
- GET /api/orders/{id}: Get details of a specific order.
- POST /api/customers: Add a new customer.
  Refer to the Swagger UI at /swagger for a comprehensive list of available endpoints and their documentation.
## Contributing
Contributions are welcome! Please fork the repository, create a new branch, and submit a pull request with a clear description of your changes.

## License
This project is licensed under the MIT License.


Arame Grigoryan