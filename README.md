# 🍽️ Food Recipes API

![Project Image](https://upload.wikimedia.org/wikipedia/en/8/8a/Mmfood.jpg)

## 📌 Overview
The **Food Recipes API** is a portfolio project that I built using **ASP.Net** and **DDD** principles. It enables users to manage recipes and ingredients through a scalable, maintainable, and modular backend system.

---

## 🚀 Features
- ✅ Domain Driven Design (DDD)
- ✅ Clean Architecture
- ✅ Rich Domain Model
- ✅ Decoupled CQRS Messaging
- ✅ Repository Pattern
- ✅ EF Core with SQLite Integration

---

## 📚 Table of Contents
- [Architecture](#architecture)
  - [Domain](doc/Domain.md)
  - [Application](doc/Application.md)
  - [Endpoints](doc/Endpoints.md)
- [Future Enhancements](#future-enhancements)

---

## 🏗️ Architecture

This API follows a layered architecture inspired by DDD and Clean Architecture to ensure separation of concerns and long-term maintainability.

### 🔹 Domain Layer
- Core business logic and entities
- Independent of other layers
- Focused on rules and invariants

### 🔹 Application Layer
- Orchestrates use cases and business workflows
- Mediates between Domain and Presentation
- Applies business rules consistently

### 🔹 Presentation Layer
- Handles HTTP requests and responses
- API controllers for user interaction
- Maps DTOs to domain models

### 🔹 Persistence Layer
- Implements data access using **EF Core**
- Uses a **local SQLite database** for lightweight storage
- Abstracted via repositories

📄 For detailed breakdowns, refer to:
- [Domain](doc/Domain.md)
- [Application](doc/Application.md)
- [Endpoints](doc/Endpoints.md)

---

## 🚧 Out-of-Scope (for now)
These features are not yet implemented but may be added in future iterations:
- ~~Authentication~~ & Authorization
- Advanced Unit Testing
- External API Integrations

---

## 🔮 Future Enhancements
- Add Domain Events for richer business logic
- Implement user ~~authentication~~ and role-based access
- Improve error handling and structured logging
- Integrate with third-party recipe or nutrition APIs
- Build a front-end client (e.g., React or Blazor)
- Expand ~~Persistence with migrations~~ and seed data

---

💡 *This project is a foundation for more advanced culinary data systems. Contributions and feedback are welcome!*
