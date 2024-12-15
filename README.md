# Prueba Marcas Autos

1.  se debe generar un archivo .env con las siguientes variables

```code

POSTGRES_PASSWORD=
POSTGRES_USER=
POSTGRES_DB=
DB_CONNECTION_STRING=Host=;Port=;Database=;Username=;Password=

# la siguiente variable indica si la aplicacion esta en modo desarrollo  o Production
# en modo desarrollo realiza las migraciones pendientes a la base de datos y en modo production no realiza migraciones
ASPNETCORE_ENVIRONMENT=Development

DOTNET_GENERATE_ASPNET_CERTIFICATE=false
ASPNETCORE_HTTP_PORTS=8080
ASPNETCORE_URLS=http://+:8080

```

2. ejecutar el comando

```bash
docker compose up -d
```

- Nota: para visualizar las pruegas pueden hacerlo desde el log del contenedor o quitando del flag '-d'
