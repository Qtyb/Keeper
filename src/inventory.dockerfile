FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 7000
EXPOSE 7001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ./Inventory ./Inventory
COPY ./Common ./Common
RUN dotnet restore "Inventory/WebApi/Inventory.WebApi.csproj"
WORKDIR "/src/."
RUN dotnet build "Inventory/WebApi/Inventory.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Inventory/WebApi/Inventory.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Inventory.WebApi.dll"]
