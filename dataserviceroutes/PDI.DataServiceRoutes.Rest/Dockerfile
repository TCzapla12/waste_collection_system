#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PDI.DataServiceRoutes.Rest/PDI.DataServiceRoutes.Rest.csproj", "PDI.DataServiceRoutes.Rest/"]
COPY ["PDI.DataServiceRoutes.Logic/PDI.DataServiceRoutes.Logic.csproj", "PDI.DataServiceRoutes.Logic/"]
COPY ["PDI.DataServiceRoutes.Model/PDI.DataServiceRoutes.Model.csproj", "PDI.DataServiceRoutes.Model/"]
COPY ["PDI.DataServiceRoutes.Rest.Model/PDI.DataServiceRoutes.Rest.Model.csproj", "PDI.DataServiceRoutes.Rest.Model/"]
COPY ["PDI.DataServiceRoutes.Rest.Tests/PDI.DataServiceRoutes.Rest.Tests.csproj", "PDI.DataServiceRoutes.Rest.Tests/"]
COPY ["PDI.DataServiceRoutes.Tests/PDI.DataServiceRoutes.Tests.csproj", "PDI.DataServiceRoutes.Tests/"]
RUN dotnet restore "PDI.DataServiceRoutes.Rest/PDI.DataServiceRoutes.Rest.csproj"
COPY . .
WORKDIR "/src/PDI.DataServiceRoutes.Rest"
RUN dotnet build "PDI.DataServiceRoutes.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PDI.DataServiceRoutes.Rest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY PDI.DataServiceRoutes.Rest/routes.json .
ENTRYPOINT ["dotnet", "PDI.DataServiceRoutes.Rest.dll"]