#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PDI.DataServiceMeasurements.Rest/PDI.DataServiceMeasurements.Rest.csproj", "PDI.DataServiceMeasurements.Rest/"]
COPY ["PDI.DataServiceMeasurements.Logic/PDI.DataServiceMeasurements.Logic.csproj", "PDI.DataServiceMeasurements.Logic/"]
COPY ["PDI.DataServiceMeasurements.Model/PDI.DataServiceMeasurements.Model.csproj", "PDI.DataServiceMeasurements.Model/"]
COPY ["PDI.DataServiceMeasurements.Rest.Model/PDI.DataServiceMeasurements.Rest.Model.csproj", "PDI.DataServiceMeasurements.Rest.Model/"]
COPY ["PDI.DataServiceMeasurements.Rest.Tests/PDI.DataServiceMeasurements.Rest.Tests.csproj", "PDI.DataServiceMeasurements.Rest.Tests/"]
COPY ["PDI.DataServiceMeasurements.Tests/PDI.DataServiceMeasurements.Tests.csproj", "PDI.DataServiceMeasurements.Tests/"]
RUN dotnet restore "PDI.DataServiceMeasurements.Rest/PDI.DataServiceMeasurements.Rest.csproj"
COPY . .
WORKDIR "/src/PDI.DataServiceMeasurements.Rest"
RUN dotnet build "PDI.DataServiceMeasurements.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PDI.DataServiceMeasurements.Rest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY PDI.DataServiceMeasurements.Rest/measurements.json .
ENTRYPOINT ["dotnet", "PDI.DataServiceMeasurements.Rest.dll"]