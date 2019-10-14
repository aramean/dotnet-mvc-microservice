FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY Gunnebo/Gunnebo.csproj Gunnebo/
RUN dotnet restore "Gunnebo/Gunnebo.csproj"
COPY . .
WORKDIR "/src/Gunnebo"
RUN dotnet build "Gunnebo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gunnebo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT dotnet watch run --no-restore
#ENTRYPOINT ["dotnet", "watch", "run", "Gunnebo.dll"