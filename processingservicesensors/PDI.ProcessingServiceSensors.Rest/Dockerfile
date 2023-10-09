#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PDI.ProcessingServiceSensors.Rest/PDI.ProcessingServiceSensors.Rest.csproj", "PDI.ProcessingServiceSensors.Rest/"]
COPY ["PDI.ProcessingServiceSensors.Logic/PDI.ProcessingServiceSensors.Logic.csproj", "PDI.ProcessingServiceSensors.Logic/"]
COPY ["PDI.ProcessingServiceSensors.Model/PDI.ProcessingServiceSensors.Model.csproj", "PDI.ProcessingServiceSensors.Model/"]
COPY ["PDI.ProcessingServiceSensors.Utilities/PDI.ProcessingServiceSensors.Utilities.csproj", "PDI.ProcessingServiceSensors.Utilities/"]
COPY ["PDI.ProcessingServiceSensors.Rest.Model/PDI.ProcessingServiceSensors.Rest.Model.csproj", "PDI.ProcessingServiceSensors.Rest.Model/"]
COPY ["PDI.ProcessingServiceSensors.Rest.Tests/PDI.ProcessingServiceSensors.Rest.Tests.csproj", "PDI.ProcessingServiceSensors.Rest.Tests/"]
COPY ["PDI.ProcessingServiceSensors.Tests/PDI.ProcessingServiceSensors.Tests.csproj", "PDI.ProcessingServiceSensors.Tests/"]
RUN dotnet restore "PDI.ProcessingServiceSensors.Rest/PDI.ProcessingServiceSensors.Rest.csproj"
COPY . .
WORKDIR "/src/PDI.ProcessingServiceSensors.Rest"
RUN dotnet build "PDI.ProcessingServiceSensors.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PDI.ProcessingServiceSensors.Rest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PDI.ProcessingServiceSensors.Rest.dll"]