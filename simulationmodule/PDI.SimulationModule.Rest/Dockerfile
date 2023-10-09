#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PDI.SimulationModule.Rest/PDI.SimulationModule.Rest.csproj", "PDI.SimulationModule.Rest/"]
COPY ["PDI.SimulationModule.Logic/PDI.SimulationModule.Logic.csproj", "PDI.SimulationModule.Logic/"]
COPY ["PDI.SimulationModule.Model/PDI.SimulationModule.Model.csproj", "PDI.SimulationModule.Model/"]
COPY ["PDI.SimulationModule.Utilities/PDI.SimulationModule.Utilities.csproj", "PDI.SimulationModule.Utilities/"]
COPY ["PDI.SimulationModule.Rest.Model/PDI.SimulationModule.Rest.Model.csproj", "PDI.SimulationModule.Rest.Model/"]
COPY ["PDI.SimulationModule.Rest.Tests/PDI.SimulationModule.Rest.Tests.csproj", "PDI.SimulationModule.Rest.Tests/"]
COPY ["PDI.SimulationModule.Tests/PDI.SimulationModule.Tests.csproj", "PDI.SimulationModule.Tests/"]
RUN dotnet restore "PDI.SimulationModule.Rest/PDI.SimulationModule.Rest.csproj"
COPY . .
WORKDIR "/src/PDI.SimulationModule.Rest"
RUN dotnet build "PDI.SimulationModule.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PDI.SimulationModule.Rest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PDI.SimulationModule.Rest.dll"]