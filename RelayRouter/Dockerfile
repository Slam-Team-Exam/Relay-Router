ARG DOTNET_VERSION=9.0
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build
WORKDIR /src

# Copy everything
COPY . .

# Restore dependencies
ARG CONFIGURATION=Release
RUN dotnet restore RelayRouter.csproj

# Publish the project
RUN dotnet publish RelayRouter.csproj -c ${CONFIGURATION} -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION} AS runtime
WORKDIR /app

ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV ASPNETCORE_URLS="http://+:80;https://+:443"

EXPOSE 80
EXPOSE 443

COPY --from=build /app/publish .

ENTRYPOINT ["/bin/sh", "-c", "dotnet $(ls *.dll | head -n1)"]
