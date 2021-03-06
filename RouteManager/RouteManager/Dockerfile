FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["RouteManager/RouteManager.csproj", "RouteManager/"]
COPY ["ApplicationCore/ApplicationCore.csproj", "ApplicationCore/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "RouteManager/RouteManager.csproj"
COPY . .
WORKDIR "/src/RouteManager"
RUN dotnet build "RouteManager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RouteManager.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RouteManager.dll"]