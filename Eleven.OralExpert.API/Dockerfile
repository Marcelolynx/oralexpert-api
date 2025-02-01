FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Eleven.OralExpert.API/Eleven.OralExpert.API.csproj", "Eleven.OralExpert.API/"]
RUN dotnet restore "Eleven.OralExpert.API/Eleven.OralExpert.API.csproj"
COPY . .
WORKDIR "/src/Eleven.OralExpert.API"
RUN dotnet build "Eleven.OralExpert.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Eleven.OralExpert.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Eleven.OralExpert.API.dll"]
