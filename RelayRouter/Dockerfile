# Multi-stage Dockerfile for a .NET 9 ASP.NET Core app
# Builds with the SDK image, runs with the smaller ASP.NET runtime image.

ARG DOTNET_VERSION=9.0
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build
WORKDIR /src

# Copy everything (works for arbitrary repo layout)
COPY . .

# Restore and publish (use build arg to control configuration)
ARG CONFIGURATION=Release
RUN dotnet restore
RUN dotnet publish -c ${CONFIGURATION} -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION} AS runtime
WORKDIR /app

# Container settings
ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV ASPNETCORE_URLS="http://+:80;https://+:443"

EXPOSE 80
EXPOSE 443

# Copy published output from build stage
COPY --from=build /app/publish .

# Run the first DLL found in the publish folder (works without hardcoding the assembly name)
ENTRYPOINT ["/bin/sh", "-c", "dotnet $(ls *.dll | head -n1)"]
