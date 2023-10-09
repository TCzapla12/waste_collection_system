#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PDI.DataServiceVehicles.Rest/PDI.DataServiceVehicles.Rest.csproj", "PDI.DataServiceVehicles.Rest/"]
COPY ["PDI.DataServiceVehicles.Logic/PDI.DataServiceVehicles.Logic.csproj", "PDI.DataServiceVehicles.Logic/"]
COPY ["PDI.DataServiceVehicles.Model/PDI.DataServiceVehicles.Model.csproj", "PDI.DataServiceVehicles.Model/"]
COPY ["PDI.DataServiceVehicles.Rest.Model/PDI.DataServiceVehicles.Rest.Model.csproj", "PDI.DataServiceVehicles.Rest.Model/"]
COPY ["PDI.DataServiceVehicles.Rest.Tests/PDI.DataServiceVehicles.Rest.Tests.csproj", "PDI.DataServiceVehicles.Rest.Tests/"]
COPY ["PDI.DataServiceVehicles.Tests/PDI.DataServiceVehicles.Tests.csproj", "PDI.DataServiceVehicles.Tests/"]
RUN dotnet restore "PDI.DataServiceVehicles.Rest/PDI.DataServiceVehicles.Rest.csproj"
COPY . .
WORKDIR "/src/PDI.DataServiceVehicles.Rest"
RUN dotnet build "PDI.DataServiceVehicles.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PDI.DataServiceVehicles.Rest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY PDI.DataServiceVehicles.Rest/vehicles.json .
ENTRYPOINT ["dotnet", "PDI.DataServiceVehicles.Rest.dll"]