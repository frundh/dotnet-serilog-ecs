# Dotnet & Elastic Common Schema (ECS)
Dotnet application with Serilog using Elastic Common Schema (ECS)

## Index Template
https://github.com/elastic/ecs/tree/main/generated/elasticsearch

## Quickstart

```
docker-compose up
```

### Application
```
http://localhost:5000/swagger
```

### Kibana
```
http://localhost:5601
```

## Complete ELK Stack
```
# Kibana
# user: elastic
# pass: changeme

docker-compose -f elk/docker-compose.yml -f docker-compose.elk.yml up --build
```