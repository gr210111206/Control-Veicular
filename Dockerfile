# Etapa de construcción (Build)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar el archivo de proyecto y restaurar las dependencias
COPY ["ControlVeicular.API/ControlVeicular.API.csproj", "ControlVeicular.API/"]
RUN dotnet restore "ControlVeicular.API/ControlVeicular.API.csproj"

# Copiar todo el código fuente y compilar
COPY . .
WORKDIR "/src/ControlVeicular.API"
RUN dotnet publish "ControlVeicular.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa de ejecución (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Exponer el puerto que usará Render (por defecto es 80 u 8080 en Docker)
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "ControlVeicular.API.dll"]
