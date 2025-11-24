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
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "RelayRouter.dll"]
