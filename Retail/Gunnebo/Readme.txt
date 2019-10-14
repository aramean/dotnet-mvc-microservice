===================================
Gunnebo Retail Solution Recruitment
===================================

This project was created by Josef Gabrielsson. =).
I choose the fastest and simplest way without layers.
Not the best quality solution, security is medium, No uml use cases, No unit or integration tests are included, docker not fully functional with api.

But it works!

Please check the awesome CLI-commands at the bottom of this file.

-----------------------------------------------------------------

API v0.1
========

* Plural Nouns for Endpoints
* CamelCase for Attribute Names
_______________________________________________________________________________________________________

GET     | /api/orders                                              | Get all orders
GET     | /api/orders/[RegistrationNumber]                         | Get order by Registration number
POST    | /api/orders                                              | Submit new "pickup order" 
            ->Body->{OrderNumber|OrderRegistrationNumber}
PATCH   | /api/orders/[RegistrationNumber]                         | Update "pickup order" to "arrived"
            ->Body->{OrderRegistrationNumber}
_______________________________________________________________________________________________________


Software architectural pattern
==============================
[YES] Model View Controller Microservice
[NO] Domain Driven Design Microservice
[NO] Clean Domain Driven Design Microservice

Domain Entity pattern
=====================
[NO] Bounded Contexts


Database
========
[YES] MSSQL
[NO] InMemory
[NO] CosmosDB
[NO] Postgres

Testing
=======

*** Unit Testing ***
[NO] Sociable unit testing
[NO] Solitary unit testing

*** Integration testing ***
[NO] End-to-end testing


Install packages & tools
========================
dotnet tool install -g dotnet-ef
#dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 3.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.DotNet.Watcher.Tools


Create SSL certificate
======================
dotnet dev-certs https --clean
dotnet dev-certs https --trust


Entity Framework
================
*** Create migration for the first time ***
dotnet ef migrations add InitialCreate -v --context OrderContext

*** Update database ***
dotnet ef database update -v
dotnet ef database update -v --context OrderContext

*** Scaffold database (reverse engineer) ***
dotnet ef dbcontext scaffold "Host=gunnebo-dbhost;Database=Gunnebo;Username=root;Password=root;Port=15432" Npgsql.EntityFrameworkCore.PostgreSQL


CLI-Commands
============
make install
make ef:rebuild
make mssql:start
make ssl:create
make run
make watch
