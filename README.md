# Food Recipes API

![Project Image](https://upload.wikimedia.org/wikipedia/en/8/8a/Mmfood.jpg)

## Scope
The Food Recipes API showcases my skills in C# and ASP.NET using Domain Driven Design (DDD) and Clean Architecture principles. It allows users to manage recipes and ingredients, demonstrating a robust and scalable solution for handling culinary data.

## Table of Contents
- [Features](#features)
- [Architecture](#architecture)
  - [Domain](Domain.md)
  - [Application](Application.md)
  - [Endpoints](Endpoints.md)
- [Future Enhancements](#future-enhancements)

## Features
- Domain Driven Design (DDD)
- Clean Architecture
- Rich Domain Model
- Decoupled CQRS Messaging

## Architecture
This project follows Domain Driven Design (DDD) and Clean Architecture principles to ensure a well-structured and maintainable codebase.

### Layers
- **Domain**: Contains the core business logic and entities. This layer is independent of other layers and focuses on the business rules and logic.
- **Application**: Handles the application logic and use cases. It acts as a mediator between the domain and presentation layers, ensuring that business rules are applied correctly.
- **Presentation**: Manages the user interface and API endpoints. This layer is responsible for handling HTTP requests, processing user input, and returning appropriate responses.
- **Persistence**: Deals with data storage and retrieval. This layer abstracts the data access logic and ensures that the domain remains independent of the data storage technology.

For more detailed information, please refer to the following files:
- [Domain](Domain.md)
- [Application](Application.md)
- [Endpoints](Endpoints.md)

## Future Enhancements
- Add Domain Events
- Implement user authentication and authorization.
- Add more detailed error handling and logging.
- Integrate with external APIs for additional data sources.
- Develop a front-end application to interact with the API.
- Expand the Persistence layer with actual data access.

