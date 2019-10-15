# Microservice example with ASP.NET Core 3.0
This simple retail solution project is using Entity Framework Core (EFC), Dependency Injection (DI), Enum, Data annotation, Fluent API & JSON serialization and deserialization.

## Architecture
- [x] Data-driven CRUD microservice
- [ ] Domain-driven oriented microservice
- [ ] Clean Domain-driven Design microservice

## Environment
### IDE
*This project have been tested and compiled with:

- [x] Visual Studio Community for Mac
- [ ] Visual Studio Code

## API Overview ##
*This project has the following API:

|API|Description|Request body|Response body|
|-|:-|:-|:-|
| &#x1f499; **GET**<br> /api/Orders | Get all order items | - | Array of orders items |
| &#x1f499; **GET**<br> /api/Orders/{RegistrationNumber} | Get an order item by registration number | - | Order item |
| &#x1F49A; **POST**<br> /api/Orders | Add a new order item | OrderNumber & OrderRegistrationNumber  | Order item |
| &#x1f49b; **PATCH**<br> /api/Orders/{RegistrationNumber}  | Update an existing order item | OrderRegistrationNumber | Order item |

* Plural Nouns for Endpoints
* CamelCase for Attribute Names
