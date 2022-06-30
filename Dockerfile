FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "Adapter/Adapter.csproj"
RUN dotnet build "Adapter/Adapter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Adapter/Adapter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Adapter.dll"]