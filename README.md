# Product Inventory API

A simple ASP.NET Core Web API for managing products in an inventory system.  
It supports product creation, retrieval, update, deletion, and low-stock alerts.

---

## Features
- Add new products  
- View all products  
- Get product by ID  
- Update product details (price, stock, etc.)  
- Delete a product  
- Low-stock alert (e.g., stock < 5)

---

## Project Structure
- **Controllers/** → Contains API controllers  
- **DTOs/** → Data Transfer Objects  
- **Data/** → EF Core DbContext  
- **Models/** → Entity models  

---

## Setup Instructions
1. Clone the repository:
   ```bash
   git clone https://github.com/anjali-yadav12/ProductInventory.git
   cd ProductInventory

2. Restore dependencies:
   dotnet restore

3.Run the application:
  dotnet run

API Endpoints

1. Get all products- GET /api/products
2. Get product by ID - GET /api/products/{id}
3. Create a product- POST /api/products
4. Update a product - PUT /api/products/{id}
5. Delete a product - DELETE /api/products/{id}
6. Get low-stock products - GET /api/products/lowstock

   
