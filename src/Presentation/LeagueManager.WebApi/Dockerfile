#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Presentation/LeagueManager.WebApi/LeagueManager.WebApi.csproj", "src/Presentation/LeagueManager.WebApi/"]
COPY ["src/Modules/League/LeagueManager.League.WebApi/LeagueManager.League.WebApi.csproj", "src/Modules/League/LeagueManager.League.WebApi/"]
COPY ["src/Modules/League/LeagueManager.League.Application/LeagueManager.League.Application.csproj", "src/Modules/League/LeagueManager.League.Application/"]
COPY ["src/Modules/League/LeagueManager.League.Domain/LeagueManager.League.Domain.csproj", "src/Modules/League/LeagueManager.League.Domain/"]
COPY ["src/Shared/LeagueManager.Shared.Abstractions/LeagueManager.Shared.Abstractions.csproj", "src/Shared/LeagueManager.Shared.Abstractions/"]
COPY ["src/Modules/League/LeagueManager.League.Infrastructure/LeagueManager.League.Infrastructure.csproj", "src/Modules/League/LeagueManager.League.Infrastructure/"]
RUN dotnet restore "./src/Presentation/LeagueManager.WebApi/LeagueManager.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Presentation/LeagueManager.WebApi"
RUN dotnet build "./LeagueManager.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LeagueManager.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LeagueManager.WebApi.dll"]