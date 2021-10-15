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
11. Move app to docker
12. push docker to public

## What to check

* [ ] HelthCheckUI https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks
* [x] DateTimeOffset
* [ ] HealthChecks for Azure Service Bus, Azure Storage, Azure Key Vault, Azure IoT Hub

## Terminal Commands

```text
docker ps
docker stop mongo
docker volume ls
docker volume rm mongodbdata
docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=Pass#word1 mongo
```

```text
dotnet user-secrets init
dotnet user-secrets set MongoDbSettings:Password Pass#word1
```

```text
docker build -t catalog:v1 .
docker network create net5tutorial
docker network ls
docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=Pass#word1 --network=net5tutorial mongo
docker images
docker run -it --rm -p 8080:80 -e MongoDbSettings:Host=mongo -e MongoDbSettings:Password=Pass#word1 --network net5tutorial catalog:v1
```

```text
docker login
docker tag catalog:v1 DOCKER_ID/catalog:v1
docker push DOCKER_ID/catalog:v1
docker rmi catalog:v1
docker rmi DOCKER_ID/catalog:v1
docker logout
docker run -it --rm -p 8080:80 -e MongoDbSettings:Host=mongo -e MongoDbSettings:Password=Pass#word1 --network net5tutorial DOCKER_ID/catalog:v1
```
