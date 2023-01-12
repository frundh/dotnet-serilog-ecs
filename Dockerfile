FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
COPY src /src
WORKDIR /src
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0
COPY --from=build /app /app
WORKDIR /app
EXPOSE 5000
ENTRYPOINT ["dotnet", "WeatherApp.dll"]