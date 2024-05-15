FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# ENV ASPNETCORE_URLS=http://+:7286

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["SEMS-API-V2/SEMS-API-V2.csproj", "SEMS-API-V2/"]
RUN dotnet restore "SEMS-API-V2/SEMS-API-V2.csproj"
COPY . .
WORKDIR "/src/SEMS-API-V2"
RUN dotnet build "SEMS-API-V2.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "SEMS-API-V2.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY SEMS-API-V2/SEMS.db .
ENTRYPOINT ["dotnet", "SEMS-API-V2.dll"]
