# Dotnet & Elastic Common Schema (ECS)
Dotnet application with Serilog using Elastic Common Schema (ECS)

## Quickstart
```
docker-compose -f elk/docker-compose.yml -f docker-compose.yml up --build
```

### Application
```
http://localhost:5000/swagger
```

### Kibana
```
# user: elastic
# pass: changeme

http://localhost:5601
```