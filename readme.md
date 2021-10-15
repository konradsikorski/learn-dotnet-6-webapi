# Based on this tutorial: https://www.youtube.com/watch?v=ZXdFisA_hOY&t=7348s

1. DateTimeOffset vs DateTime
2. Using visual studio Code for development
3. .net 6.0
4. .net 6.0 > webapi template without startup.cs file
5. .net 6.0 > using records
6. Great introduction to Mongo DB
7. Secrets in built in .net Secret Managment
8. Nuget AspNetCore.HealthChecks https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks
9. /health/ready and /health/live concepts
10. check HelthCheckUI

## What to check

1. HelthCheckUI https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks
2. DateTimeOffset
3. HealthChecks for Azure Service Bus, Azure Storage, Azure Key Vault, Azure IoT Hub

## Terminal Commands

```text
docker ps
docker stop mongo
docker volume ls
docker volume rm mongodbdata
docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=Pass#word1 mongo
dotnet user-secrets init
dotnet user-secrets set MongoDbSettings:Password Pass#word1
```