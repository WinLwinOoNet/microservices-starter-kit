#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/ApiGateway/Msk.ApiGateway/Msk.ApiGateway.csproj", "src/ApiGateway/Msk.ApiGateway/"]
RUN dotnet restore "src/ApiGateway/Msk.ApiGateway/Msk.ApiGateway.csproj"
COPY . .
WORKDIR "/src/src/ApiGateway/Msk.ApiGateway"
RUN dotnet build "Msk.ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Msk.ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Msk.ApiGateway.dll"]
