FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 7300
EXPOSE 7301

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ./Places ./Places
COPY ./Common ./Common
RUN dotnet restore "Places/WebApi/Places.WebApi/Places.WebApi.csproj"
WORKDIR "/src/."
RUN dotnet build "Places/WebApi/Places.WebApi/Places.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Places/WebApi/Places.WebApi/Places.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Places.WebApi.dll"]
