FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only the necessary project files
COPY ["../../src/MyProject.Api/MyProject.Api.csproj", "src/MyProject.Api/"]
COPY ["../../src/MyProject.Application/MyProject.Application.csproj", "src/MyProject.Application/"]
COPY ["../../src/MyProject.Domain/MyProject.Domain.csproj", "src/MyProject.Domain/"]
COPY ["../../src/MyProject.Infrastructure/MyProject.Infrastructure.csproj", "src/MyProject.Infrastructure/"]

# Restore only the API project (which will restore its dependencies)
RUN dotnet restore "src/MyProject.Api/MyProject.Api.csproj"

# Copy the entire source code
COPY ../../src .

WORKDIR "/src/MyProject.Api"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyProject.Api.dll"]
