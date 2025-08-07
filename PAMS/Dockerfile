# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore separately for layer caching
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and publish
COPY . . 
RUN dotnet publish -c Release -o /app/publish

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Replace ISB.dll with your actual output DLL if it's different
ENTRYPOINT ["dotnet", "PAMS.dll"]
