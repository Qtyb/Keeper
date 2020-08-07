# Keeper
Application stores users project and assigns them to locations
This is my bachelor project. 

## Services
| Service       | Port          |
| ------------- |:-------------:|
| Inventory     | 7000,7001     |
| ApiGateway    | 7100,7101     |
| Db            | 1433          |
| RabbitMq      | 5672          |
| RabbitMqGui   | 15672         |

## Dependencies
 - [.Net Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)
 - [Docker](https://docs.docker.com/docker-for-windows/install/)

## How to run
Steps (1-3 only the first time):
 1. To create mssql and rabbitmq servers run inside `docker` directory:
    ```
    docker-compose up
    ```
 2. [Create database](#Database-migrations)
 3. [Seed database](#Database-seeds)
 4. Run Keeper (DEV)
    - Using Powershell script: go inside `scripts` and run `.\dev_run.ps1`
    - Using Visual Studio: open `Keeper.sln` and run:
        - `ApiGateway.WebApi`
        - `Inventory.WebApi`
    - Using dotnetCLI: head to `src` directory and run `dotnet run`
        - Inside `ApiGateway\ApiGateway.WebApi`
        - Inside `Inventory\WebApi`


*Proper script based on docker is in development.*


## Docker configuration

## Database
### Database migrations
Clean database need migrations applied.
To do so you need first to install tools:
```
dotnet tool install --global dotnet-ef
```
After this operation you may need to restart system.

Database connection string is in every service in appsettings.json file.
You might need to change it to connect to database.
You can apply migrations for one service going to service solution directory and typing
```
dotnet ef database update
```

### Database seeds
Seeds are located in `sql\<service_name>` folder.
To apply them run `seed.ps1` per each service.

## RabbitMq
Each microservice will have his own queue, which it will listen on.
All microservices will use the same direct exchange to send messages.

### Messages
