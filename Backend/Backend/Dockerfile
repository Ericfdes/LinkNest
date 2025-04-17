#  Base runtime image: only contains .NET runtime (no SDK)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Set working directory
WORKDIR /app

# Expose ports
EXPOSE 3000    
EXPOSE 3001    

# 2 Build image: has .NET SDK to compile the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Development

WORKDIR /src

# Copy project file first (to cache restore layer)
COPY ["Backend.csproj", "./"]
RUN dotnet restore "Backend.csproj"

# Copy rest of the app
COPY . .

# Build the app
RUN dotnet build "Backend.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 3️⃣ Publish image: optimized release version
FROM build AS publish
ARG BUILD_CONFIGURATION=Development
RUN dotnet publish "Backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# 4️⃣ Final runtime image: smaller image with only published output
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Entry point
ENTRYPOINT ["dotnet", "Backend.dll"]
