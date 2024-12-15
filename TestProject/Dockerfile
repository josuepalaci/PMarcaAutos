FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
USER app
WORKDIR /app

# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TestProject/TestProject.csproj", "TestProject/"]
COPY ["Api/Api.csproj", "Api/"]
COPY ["Infraestructura/Infraestructura.csproj", "Infraestructura/"]
RUN dotnet restore "./TestProject/TestProject.csproj"
COPY . .
WORKDIR "/src/TestProject"
RUN dotnet build "./TestProject.csproj" -c $BUILD_CONFIGURATION -o /app/build

RUN ls -la /app/build
ENTRYPOINT ["dotnet", "test", "/src/TestProject/TestProject.csproj", "--logger", "console;verbosity=minimal"]

