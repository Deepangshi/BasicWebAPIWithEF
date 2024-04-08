# Basic Web API with EF

## Project Overview

The project is a simple web application for managing employee data. It uses ASP.NET Web API to create a server that handles web requests, Entity Framework to interact with a SQL Server database, and JWT for secure user authentication. Users can add, view, update, and delete employee records through this application, ensuring that data is managed efficiently and securely.

## Project Structure

- /Context/APIDbContext: The Context links application models to the database, enabling data operations like CRUD.
- /Controller: Controllers handle incoming HTTP requests and send responses, balance application flow.
- /Interfaces: Interfaces define contracts for services, outlining methods without implementing them.
- /Models: Models represent the data structure, match database entities or custom data shapes for the API.
- /Request Models : Request Models are added for specific operations, shaping data for requests or responses.
- /Services: Services encapsulate business logic, performing specific tasks like user authentication or data management.

## Technologies Used

- ASP.NET Core 7
- Entity Framework (EF) Core
- SQL Server
