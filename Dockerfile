# ===== Etapa 1: Build =====
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copiamos solo los .csproj primero (para aprovechar el cache de Docker)
COPY Electrobombas.Api/Electrobombas.Api.csproj Electrobombas.Api/
COPY Electrobombas.Application/Electrobombas.Application.csproj Electrobombas.Application/
COPY Electrobombas.Core/Electrobombas.Core.csproj Electrobombas.Core/
COPY Electrobombas.Domain/Electrobombas.Domain.csproj Electrobombas.Domain/
COPY Electrobombas.Infraestructure/Electrobombas.Infraestructure.csproj Electrobombas.Infraestructure/

RUN dotnet restore Electrobombas.Api/Electrobombas.Api.csproj

# Ahora copiamos todo el código fuente
COPY . .

# Compilamos y publicamos en modo Release
WORKDIR /src/Electrobombas.Api
RUN dotnet publish -c Release -o /app/publish

# ===== Etapa 2: Runtime =====
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# El puerto que escuchará la app dentro del contenedor
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "Electrobombas.Api.dll"]