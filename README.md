# Microservice example with ASP.NET Core 3.0 #
This simple retail solution project is using Entity Framework Core (EFC), Dependency Injection (DI), Enum, Data annotation, Fluent API & JSON serialization and deserialization.

## SaaS ##

### Architecture ###
- [x] Data-driven CRUD microservice
- [ ] Domain-driven oriented microservice
- [ ] Clean Domain-driven Design microservice

### Database ###
- [x] MSSQL
- [x] InMemory

### API Overview ###
*This service has the following API:

|API|Description|Request body|Response body|
|-|:-|:-|:-|
| &#x1f499; **GET**<br> /api/Orders | Get all order items | - | Array of order items |
| &#x1f499; **GET**<br> /api/Orders/{registrationNumber} | Get an order item by registration number | - | Order item |
| &#x1F49A; **POST**<br> /api/Orders | Add a new order item | orderNumber & orderRegistrationNumber  | Order item |
| &#x1f49b; **PATCH**<br> /api/Orders/{registrationNumber}  | Update an existing order item | orderRegistrationNumber | Order item |
| &#x1f494; **DELETE** (TODO)<br> /api/Orders/{registrationNumber}  | Delete an existing order item | orderRegistrationNumber | - |

* Plural Nouns for Endpoints
* CamelCase for Attribute Names

## Environment ##
### IDE ###
*This solution have been tested and compiled with:

- [x] Visual Studio Community for Mac
- [x] Visual Studio Code

### CLI ###
*This solution has available make commands:

Install all required packages and tools.<br>
```make install```

Create SSL Certificate.<br>
```make ssl:create```

Run application.<br>
```make run```

Run application with Watcher.<br>
```make watch```

Start MSSQL in docker.<br>
```make mssql:start```

Rebuild MSSQL database.<br>
```make ef:rebuild```

Reset Visual Studio.<br>
```make ide:reset```
