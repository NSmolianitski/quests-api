FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/QuestsApi.Api/QuestsApi.Api.csproj", "src/QuestsApi.Api/"]
COPY ["src/QuestsApi.Application/QuestsApi.Application.csproj", "src/QuestsApi.Application/"]
COPY ["src/QuestsApi.Domain/QuestsApi.Domain.csproj", "src/QuestsApi.Domain/"]
COPY ["src/QuestsApi.Infrastructure/QuestsApi.Infrastructure.csproj", "src/QuestsApi.Infrastructure/"]
RUN dotnet restore "src/QuestsApi.Api/QuestsApi.Api.csproj"
COPY . .
WORKDIR "/src/src/QuestsApi.Api"
RUN dotnet build "QuestsApi.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "QuestsApi.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QuestsApi.Api.dll"]
