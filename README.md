# Microservice example with ASP.NET Core 3.0 #
This simple retail solution project is using Entity Framework Core (EFC), Dependency Injection (DI), Enum, Data annotation, Fluent API & JSON serialization and deserialization.

## Application ##

### Paradigm ###
- [x] Data-driven CRUD microservice

### Software architecture ###
- [ ] Domain-driven oriented microservice
- [ ] Clean Domain-driven Design microservice

### Design principle ###
- [x] SOLID

### Database ###
- [x] MSSQL
- [x] InMemory

### Database ORM ###
- [x] Entity Framework
- [ ] Dapper
- [ ] NHibernate

### Testing ###
- [x] Integration
- [ ] Unit

### API Overview ###
*This service has swagger support.


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
