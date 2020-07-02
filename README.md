# Things keeper
Application stores users project and assigns them to locations
This is my bachelor project. 

## Services
| Service       | Port          |
| ------------- |:-------------:|
| Db            | 1433          |
| RabbitMq      | 5672          |
| RabbitMqGui   | 15672         |

## How to run

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

## RabbitMq
Each microservice will have his own queue, which it will listen on.
All microservices will use the same direct exchange to send messages.

### Messages
