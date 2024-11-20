# Use the official ASP.NET Core runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["TradeAPI/TradeAPI.csproj", "TradeAPI/"]
RUN dotnet restore "TradeAPI/TradeAPI.csproj"

# Copy the rest of the application code
COPY . .

# Build the application
WORKDIR "/src/TradeAPI"
RUN dotnet build "TradeAPI.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "TradeAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Use the base image to run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TradeAPI.dll"]