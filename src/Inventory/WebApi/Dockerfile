FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 6000
EXPOSE 6001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Inventory.csproj", ""]
RUN dotnet restore "./Inventory.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Inventory.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Inventory.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Inventory.dll"]
