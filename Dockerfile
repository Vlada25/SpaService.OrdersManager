#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OrdersManager.API/OrdersManager.API.csproj", "OrdersManager.API/"]
COPY ["OrdersManager.Interfaces/OrdersManager.Interfaces.csproj", "OrdersManager.Interfaces/"]
COPY ["OrdersManager.Domain/OrdersManager.Domain.csproj", "OrdersManager.Domain/"]
COPY ["OrdersManager.DTO/OrdersManager.DTO.csproj", "OrdersManager.DTO/"]
COPY ["OrdersManager.Database/OrdersManager.Database.csproj", "OrdersManager.Database/"]
COPY ["OrdersManager.Messaging/OrdersManager.Messaging.csproj", "OrdersManager.Messaging/"]
RUN dotnet restore "OrdersManager.API/OrdersManager.API.csproj"
COPY . .
WORKDIR "/src/OrdersManager.API"
RUN dotnet build "OrdersManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrdersManager.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrdersManager.API.dll"]