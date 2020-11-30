FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 7200
EXPOSE 7201

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ./AuthServer ./AuthServer
COPY ./Common ./Common
RUN dotnet restore "AuthServer/AuthServer/AuthServer.MVC.csproj"
WORKDIR "/src/."
RUN dotnet build "AuthServer/AuthServer/AuthServer.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthServer/AuthServer/AuthServer.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthServer.MVC.dll"]
