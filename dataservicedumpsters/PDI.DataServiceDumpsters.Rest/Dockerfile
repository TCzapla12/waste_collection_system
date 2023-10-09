#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PDI.DataServiceDumpsters.Rest/PDI.DataServiceDumpsters.Rest.csproj", "PDI.DataServiceDumpsters.Rest/"]
COPY ["PDI.DataServiceDumpsters.Logic/PDI.DataServiceDumpsters.Logic.csproj", "PDI.DataServiceDumpsters.Logic/"]
COPY ["PDI.DataServiceDumpsters.Model/PDI.DataServiceDumpsters.Model.csproj", "PDI.DataServiceDumpsters.Model/"]
COPY ["PDI.DataServiceDumpsters.Rest.Model/PDI.DataServiceDumpsters.Rest.Model.csproj", "PDI.DataServiceDumpsters.Rest.Model/"]
COPY ["PDI.DataServiceDumpsters.Rest.Tests/PDI.DataServiceDumpsters.Rest.Tests.csproj", "PDI.DataServiceDumpsters.Rest.Tests/"]
COPY ["PDI.DataServiceDumpsters.Tests/PDI.DataServiceDumpsters.Tests.csproj", "PDI.DataServiceDumpsters.Tests/"]
RUN dotnet restore "PDI.DataServiceDumpsters.Rest/PDI.DataServiceDumpsters.Rest.csproj"
COPY . .
WORKDIR "/src/PDI.DataServiceDumpsters.Rest"
RUN dotnet build "PDI.DataServiceDumpsters.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PDI.DataServiceDumpsters.Rest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY PDI.DataServiceDumpsters.Rest/dumpsters.json .
ENTRYPOINT ["dotnet", "PDI.DataServiceDumpsters.Rest.dll"]