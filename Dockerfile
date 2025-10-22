# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia csproj e restaura dependências
COPY src/Agende.Api/*.csproj ./src/Agende.Api/
RUN dotnet restore src/Agende.Api/Agende.Api.csproj

# Copia todo o código e compila
COPY . .
RUN dotnet publish src/Agende.Api/Agende.Api.csproj -c Release -o /out

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia os artefatos do build
COPY --from=build /out ./

# Define variáveis de ambiente
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# Expõe a porta da API
EXPOSE 8080

# Comando de execução
ENTRYPOINT ["dotnet", "Agende.Api.dll"]
