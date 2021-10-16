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

```powershell
docker ps
docker stop mongo
docker volume ls
docker volume rm mongodbdata
docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=Pass#word1 mongo
```

```powershell
dotnet user-secrets init
dotnet user-secrets set MongoDbSettings:Password Pass#word1
```

```powershell
docker build -t catalog:v1 .
docker network create net5tutorial
docker network ls
docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=Pass#word1 --network=net5tutorial mongo
docker images
docker run -it --rm -p 8080:80 -e MongoDbSettings:Host=mongo -e MongoDbSettings:Password=Pass#word1 --network net5tutorial catalog:v1
```

```powershell
docker login
docker tag catalog:v1 DOCKER_ID/catalog:v1
docker push DOCKER_ID/catalog:v1
docker rmi catalog:v1
docker rmi DOCKER_ID/catalog:v1
docker logout
docker run -it --rm -p 8080:80 -e MongoDbSettings:Host=mongo -e MongoDbSettings:Password=Pass#word1 --network net5tutorial DOCKER_ID/catalog:v1
```

```powershell
kubectl config current-context
kubectl create secret generic catalog-secrets --from-literal=mongodb-password='Pass#word1'
kubectl apply -f .\catalog.yaml
kubectl get deployments
kubectl get pods
kubectl logs catalog-deployment-65b4f4d4cb-cw7vx
kubectl apply -f .\mongodb.yaml
kubectl get statefulsets
```

```powershell
kubectl get pods -w
kubectl delete pod catalog-deployment-65b4f4d4cb-cw7vx
kubectl delete pod mongodb-statefulset-0
kubectl scale deployments/catalog-deployment --replicas=3
```

```powershell
docker build -t DOCKER_ID/catalog:v2 .
docker login
docker push DOCKER_ID/catalog:v2
kubectl apply -f .\catalog.yaml
kubectl logs catalog-deployment-6c7967cd4f-82ckx -f
kubectl logs catalog-deployment-6c7967cd4f-hnml7 -f
kubectl logs catalog-deployment-6c7967cd4f-wd899 -f
```

```powershell
docker build -t DOCKER_ID/catalog:v3 .
dotnet new xunit -n Catalog.UnitTests
dotnet add reference ..\Catalog.Api\Catalog.Api.csproj
```
