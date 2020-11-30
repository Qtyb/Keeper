FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 7100
EXPOSE 7101

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ./ApiGateway ./ApiGateway
RUN dotnet restore "ApiGateway/ApiGateway.WebApi/ApiGateway.WebApi.csproj"
WORKDIR "/src/."
RUN dotnet build "ApiGateway/ApiGateway.WebApi/ApiGateway.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiGateway/ApiGateway.WebApi/ApiGateway.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiGateway.WebApi.dll"]
