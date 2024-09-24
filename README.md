# TodoListApp

## Overview

TodoListApp is a simple task management app built using ASP.NET Core with Razor Pages for a challenge. The project is structured to follow best practices in software design and architecture, ensuring maintainability, scalability and testability.

## Project Structure

The solution is divided into several projects, each with a specific responsibility:

- **TodoListApp**: This project contains the Razor views and the main application logic.
- **TodoListApp.Business**: This layer contains the business logic and services. It includes interfaces to facilitate dependency injection.
- **TodoListApp.Data**: This project handles database communication, including the context, repositories, and unit of work. Interfaces are used to support dependency injection.
- **TodoListApp.Models**: This project contains the data models representing the application's entities.
- **TodoListApp.Test**: This layer includes unit tests using Moq and NUnit to ensure the reliability of the business logic.

## Design Decisions and Architectural Choices

### 1. **Separation of Concerns**
   - The application is divided into distinct layers, each responsible for a specific aspect of the application. This separation improves maintainability and scalability.

### 2. **Dependency Injection**
   - Interfaces are used extensively to decouple the implementation from the interface, allowing for easier testing and flexibility in changing implementations.

### 3. **Repository Pattern**
   - The repository pattern is used to abstract the data access layer, providing a clean API for data operations and promoting a testable and maintainable codebase.

### 4. **Unit of Work Pattern**
   - The unit of work pattern is implemented to manage transactions and ensure that a series of operations are completed successfully before committing to the database.

### 5. **Model-View-Controller (MVC) Pattern**
   - The MVC pattern is used to separate the application's concerns, with models representing the data, views handling the UI, and controllers managing the application logic and user input.

### 6. **Test-Driven Development (TDD)**
   - The project includes a comprehensive suite of unit tests to ensure the correctness of the business logic. Moq is used for mocking dependencies, and NUnit is used as the testing framework.

## Setup Instructions

### Prerequisites

- .NET 8 SDK
- Docker

### Running the Application

1. **Clone the Repository**
   ```bash
   git clone https://github.com/rafaeldsouza/todolist.git
   cd TodoListApp

2. **Build and Run the Docker Containers**
The project includes a docker-compose.yml file that sets up the application and a SQL Server instance.
   ```bash
   docker-compose up --build

3. **Access the Application**
Once the containers are up and running, you can access the application at `http://localhost:8080`

	***Database Configuration***					
    The SQL Server container is configured with the necessary database setup. Ensure that the connection string in appsettings.json matches the configuration in the docker-compose.yml file.
    
    ***Running Tests***
    To run the unit tests, use the following command:
    ```bash
     dotnet test
### Conclusion
This project demonstrates a clean and maintainable architecture using ASP.NET Core, following best practices in software design. The use of Docker ensures a consistent development and deployment environment, making it easy to set up and run the application.