SHELL := /bin/bash # Use bash syntax

default:
	docker-compose build

up: default
	docker-compose up -d

install:
	@dotnet tool install -g dotnet-ef && echo "[Success]" || echo "[Failure]"
	@dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 3.0.0 && echo "[Success]" || echo "[Failure]"
	@dotnet add package Microsoft.EntityFrameworkCore.Design && echo "[Success]" || echo "[Failure]"
	@dotnet add package Microsoft.DotNet.Watcher.Tools && echo "[Success]" || echo "[Failure]"
	@dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 3.0.0 && echo "[Success]" || echo "[Failure]"

run:
	@dotnet run

rebuild: ef%rebuild watch

watch:
	@dotnet watch run

ef%rebuild:
	rm -fr Migrations/*
#	docker exec -it gunnebo-postgresql dropdb --if-exists -h localhost -U root -w  gunnebo
	dotnet ef database drop -f -v
	dotnet ef migrations -v add InitialCreate --context OrderContext
	dotnet ef database update -v

ssl%create:
	dotnet dev-certs https --clean
	dotnet dev-certs https --trust

mssql%start:
	docker-compose run gunnebo-db
