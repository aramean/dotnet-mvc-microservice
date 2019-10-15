# Microservice example with ASP.NET Core 3.0
This simple project is using Entity Framework Core (EFC), Dependency Injection (DI), Enum, Data annotation, Fluent API & JSON serialization and deserialization.

## Architecture
- [x] Data-driven CRUD microservice
- [ ] Domain-driven oriented microservice
- [ ] Clean Domain-driven Design microservice

## IDE
- [x] Visual Studio
- [ ] Visual Studio Code

## API Overview ##
*This project has the following API:

|API|Description|Request body|Response body|
|-|:-|:-|:-|
| *GET* /api/Orders | Get all order items | - | Array of orders items |
| *GET* /api/Orders/{RegistrationNumber} | Get an item by registration number | - | Order item |
| *POST* /api/Orders | Create a new order item | OrderNumber & OrderRegistrationNumber  | Order item |
| *PATCH* /api/Orders{RegistrationNumber}  | Update an existing order item | OrderRegistrationNumber | Order item |
