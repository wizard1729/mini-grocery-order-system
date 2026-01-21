🛒 Mini Grocery Order System

ASP.NET Core Web API | Clean Architecture Demo Project

📌 Overview

The Mini Grocery Order System is a backend REST API built using ASP.NET Core Web API.
It demonstrates clean backend design principles such as layered architecture, separation of concerns, transaction handling, and RESTful API design.

This project was developed as a demo task to showcase backend engineering fundamentals.

🎯 Problem Statement

1. Display available grocery products

2. Allow users to place orders

3. Prevent orders if sufficient stock is not available

4. Ensure stock updates and order creation happen atomically

✅ Solution Highlights

1. Clean separation between Controller, Service, and Repository

2. Business logic isolated in the Service layer

3. Order placement handled inside a single database transaction

4. Lightweight In-Memory Database for easy setup

5. Fully testable via Swagger UI

🧱 Architecture

The application follows a layered architecture:

Controller Layer
       ↓
Service Layer (Business Logic + Transactions)
       ↓
Repository Layer (Data Access)
       ↓
EF Core In-Memory Database

Why this architecture?

1. Improves maintainability

2. Easier to test

3. Scales well for larger systems

4. Matches real-world backend standards

🛠️ Tech Stack

| Technology              | Usage                           |
|-------------------------|----------------------------------|
| ASP.NET Core Web API    | Backend framework                |
| Entity Framework Core   | ORM                              |
| EF Core InMemory        | Database                         |
| Swagger (Swashbuckle)   | API documentation & testing      |
| C#                      | Programming language             |

📂 Project Structure

MiniGroceryOrderSystem/
├── Controllers/
│   ├── ProductsController.cs
│   └── OrdersController.cs
│
├── Services/
│   ├── IOrderService.cs
│   └── OrderService.cs
│
├── Repositories/
│   ├── IProductRepository.cs
│   ├── ProductRepository.cs
│   ├── IOrderRepository.cs
│   └── OrderRepository.cs
│
├── Models/
│   ├── Product.cs
│   └── Order.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Program.cs
└── README.md

▶️ How to Run the Project

Prerequisites
.NET SDK 8.0+

Steps
dotnet restore
dotnet build
dotnet run

Open Swagger UI:
http://localhost:5034/swagger

📌 API Endpoints
🔹 GET /products

Returns all available grocery products.

Response
[
  { "id": 1, "name": "Apple", "price": 100, "stock": 10 },
  { "id": 2, "name": "Banana", "price": 40, "stock": 20 },
  { "id": 3, "name": "Milk", "price": 60, "stock": 15 }
]

🔹 POST /orders

Places an order for a product.

Parameters

| Name       | Type |
|------------|------|
| productId  | int  |
| quantity   | int  |

Success Response
Order placed successfully

Failure Response
Insufficient stock

🔐 Business Rules

● Orders are processed inside a database transaction

● Stock is reduced only if the order succeeds

● Invalid or insufficient stock orders are rejected

● Controller layer contains no business logic

🧠 Design Decisions

● Service Layer
Centralizes business rules and transactional logic.

● Repository Pattern
Abstracts data access and improves testability.

● In-Memory Database
Keeps the demo lightweight and setup-free.

● Swagger
Enables quick validation and demonstration of APIs.

🚀 Possible Enhancements

● Replace In-Memory DB with SQL Server / PostgreSQL

● Add authentication & authorization

● Add unit tests

📎 Notes

This project is designed for demonstration and evaluation purposes.
It focuses on correctness, clarity, and clean backend design rather than UI or persistence.

👨‍💻 Author

Built as a backend demo project to demonstrate clean architecture, transactional integrity, and REST API best practices.