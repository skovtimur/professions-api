FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Development
WORKDIR /src
COPY ["Professions.Api/Professions.Api.csproj", "Professions.Api/"]
COPY ["Professions.Application/Professions.Application.csproj", "Professions.Application/"]
COPY ["Professions.Domain/Professions.Domain.csproj", "Professions.Domain/"]
COPY ["Professions.Infrastructure/Professions.Infrastructure.csproj", "Professions.Infrastructure/"]
RUN dotnet restore "Professions.Api/Professions.Api.csproj"
COPY . .
WORKDIR "/src/Professions.Api"
RUN dotnet build "Professions.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Development
RUN dotnet publish "Professions.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Professions.Api.dll"]
