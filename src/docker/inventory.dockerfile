FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY ./Places ./
RUN dotnet restore 
RUN dotnet publish --no-restore -c Debug -o dist WebApi

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 7000
EXPOSE 7001
COPY --from=build-env /app/dist .
ENTRYPOINT ["dotnet", "Places.WebApi.dll"]
