
FROM mcr.microsoft.com/dotnet/sdk:latest AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /src

COPY . . 

RUN dotnet restore

COPY . .
 
WORKDIR /src/FlowR.Sample
RUN dotnet build -c release --no-restore

FROM build AS publish
RUN dotnet publish -c release --no-build -o /app

EXPOSE 80/tcp
EXPOSE 443/tcp

FROM mcr.microsoft.com/dotnet/aspnet:latest
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FlowR.Sample.dll"]