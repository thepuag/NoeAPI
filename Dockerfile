FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia todos los archivos .csproj primero
COPY ["Noe.API/Noe.API.csproj", "Noe.API/"]
COPY ["Noe.BLL/Noe.BLL.csproj", "Noe.BLL/"]
COPY ["Noe.DAL/Noe.DAL.csproj", "Noe.DAL/"]
COPY ["Noe.Models/Noe.Models.csproj", "Noe.Models/"]

# Restaura las dependencias
RUN dotnet restore "Noe.API/Noe.API.csproj"

# Copia todo el código fuente
COPY . .

# Compila y publica
WORKDIR "/src/Noe.API"
RUN dotnet publish "Noe.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:5000
ENTRYPOINT ["dotnet", "Noe.API.dll"]