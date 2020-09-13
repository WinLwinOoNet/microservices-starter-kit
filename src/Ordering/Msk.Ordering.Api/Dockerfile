#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Ordering/Msk.Ordering.Api/Msk.Ordering.Api.csproj", "src/Ordering/Msk.Ordering.Api/"]
COPY ["src/Ordering/Msk.Ordering.Infrastructure/Msk.Ordering.Infrastructure.csproj", "src/Ordering/Msk.Ordering.Infrastructure/"]
COPY ["src/Ordering/Msk.Ordering.Core/Msk.Ordering.Core.csproj", "src/Ordering/Msk.Ordering.Core/"]
COPY ["src/Common/Msk.EventBusRabbitMQ/Msk.EventBusRabbitMQ.csproj", "src/Common/Msk.EventBusRabbitMQ/"]
COPY ["src/Ordering/Msk.Ordering.Application/Msk.Ordering.Application.csproj", "src/Ordering/Msk.Ordering.Application/"]
RUN dotnet restore "src/Ordering/Msk.Ordering.Api/Msk.Ordering.Api.csproj"
COPY . .
WORKDIR "/src/src/Ordering/Msk.Ordering.Api"
RUN dotnet build "Msk.Ordering.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Msk.Ordering.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Msk.Ordering.Api.dll"]
