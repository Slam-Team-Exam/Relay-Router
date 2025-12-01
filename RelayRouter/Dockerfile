# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["RelayRouter.csproj", "."]
RUN dotnet restore "RelayRouter.csproj"

COPY . .
RUN dotnet publish "RelayRouter.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Tell ASP.NET which port to listen on
ENV ASPNETCORE_URLS=http://0.0.0.0:5002

COPY --from=build /app/publish .

EXPOSE 5002

ENTRYPOINT ["dotnet", "RelayRouter.dll"]
