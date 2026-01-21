# 🛒 Mini Grocery Order System

ASP.NET Core Web API | Demo Backend Project

---

## 📌 Overview

Mini Grocery Order System is a backend REST API built using **ASP.NET Core Web API**.  
It demonstrates clean backend architecture, business logic handling, and safe order processing.

This project was developed as a **demo task** to showcase backend engineering fundamentals.

---

## 🎯 Problem Statement

1. Display available grocery products
2. Allow users to place orders
3. Prevent orders if sufficient stock is not available
4. Ensure stock updates and order creation happen safely

---

## 🧩 Task 1 – Product Listing

### ✔ Features
- Fetch all available products
- Each product contains:
  - `Id`
  - `Name`
  - `Price`
  - `Stock`

### 🔗 API Endpoint

GET /products

## 🧩 Task 2 – Safe Order Placement (Concurrency Handling)

### ✔ Objective
Ensure that **multiple users cannot place orders exceeding available stock**.

### ✔ Solution Approach
- Stock is checked before placing an order
- Order is rejected if stock is insufficient
- Stock is updated only after successful validation
- Order creation and stock update occur together

### 🔗 API Endpoint

POST /orders


### 🔢 Parameters
| Name | Type | Description |
|----|----|----|
| productId | int | Product ID |
| quantity | int | Quantity to order |

### ✔ Success Response

Order placed successfully
### ❌ Failure Response

Insufficient stock
---

## 🏗 Architecture Used

Controller → Service → Repository → Database

- **Controllers**: Handle HTTP requests
- **Services**: Business logic & validation
- **Repositories**: Data access layer
- **EF Core InMemory DB**: Used for demo/testing

---

## 🛠 Tech Stack

- ASP.NET Core Web API
- Entity Framework Core (InMemory)
- Swagger UI
- C#

---

## 🚀 How to Run

```bash
dotnet restore
dotnet run

Open Swagger:
http://localhost:<port>/swagger
.

🧪 Testing
● All APIs can be tested directly using Swagger UI.

📌 Notes
● Designed for clarity and correctness
● Easily extendable to SQL Server / PostgreSQL
● Follows clean code & separation of concerns

👨‍💻 Author
Anurag Lal
Full Stack Developer | Software Engineer