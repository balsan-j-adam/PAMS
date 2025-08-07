# Use the official .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set working directory inside the container
WORKDIR /app

# Copy everything and restore dependencies
COPY . . 
RUN dotnet restore

# Build the application
RUN dotnet publish -c Release -o out

# Use the smaller ASP.NET Core runtime image for the final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

# Copy the published build from the previous stage
COPY --from=build /app/out .

# Set the entry point for the container
ENTRYPOINT ["dotnet", "PAMS.dll"]
