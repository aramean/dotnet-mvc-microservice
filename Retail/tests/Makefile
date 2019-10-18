SHELL := /bin/bash # Use bash syntax

default:
	@dotnet test Orders.UnitTests
	@dotnet test Orders.IntegrationTests

test: default

test%unit:
	@dotnet test Orders.UnitTests

test%integration:
	@dotnet test Orders.IntegrationTests