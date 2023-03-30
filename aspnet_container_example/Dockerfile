#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["aspnet_container_example/aspnet_container_example.csproj", "aspnet_container_example/"]
RUN dotnet restore "aspnet_container_example/aspnet_container_example.csproj"
COPY . .
WORKDIR "/src/aspnet_container_example"
RUN dotnet build "aspnet_container_example.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "aspnet_container_example.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "aspnet_container_example.dll"]
