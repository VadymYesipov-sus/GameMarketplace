# Stage 1: Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Restore
COPY ["MVCProject.csproj", "MVCProject/"]
RUN dotnet restore "MVCProject/MVCProject.csproj"

# Build
COPY . ./MVCProject
WORKDIR /app/MVCProject
RUN dotnet build "MVCProject.csproj" -c Release -o /app/build

# Stage 2: Publish stage
FROM build AS publish
RUN dotnet publish "MVCProject.csproj" -c Release -o /app/publish

# Stage 3: Run stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MVCProject.dll"]