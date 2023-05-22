#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PDI.ProcessingServiceRoutes.Rest/PDI.ProcessingServiceRoutes.Rest.csproj", "PDI.ProcessingServiceRoutes.Rest/"]
COPY ["PDI.ProcessingServiceRoutes.Logic/PDI.ProcessingServiceRoutes.Logic.csproj", "PDI.ProcessingServiceRoutes.Logic/"]
COPY ["PDI.ProcessingServiceRoutes.Model/PDI.ProcessingServiceRoutes.Model.csproj", "PDI.ProcessingServiceRoutes.Model/"]
COPY ["PDI.ProcessingServiceRoutes.Utilities/PDI.ProcessingServiceRoutes.Utilities.csproj", "PDI.ProcessingServiceRoutes.Utilities/"]
COPY ["PDI.ProcessingServiceRoutes.Rest.Model/PDI.ProcessingServiceRoutes.Rest.Model.csproj", "PDI.ProcessingServiceRoutes.Rest.Model/"]
COPY ["PDI.ProcessingServiceRoutes.Rest.Tests/PDI.ProcessingServiceRoutes.Rest.Tests.csproj", "PDI.ProcessingServiceRoutes.Rest.Tests/"]
COPY ["PDI.ProcessingServiceRoutes.Tests/PDI.ProcessingServiceRoutes.Tests.csproj", "PDI.ProcessingServiceRoutes.Tests/"]
RUN dotnet restore "PDI.ProcessingServiceRoutes.Rest/PDI.ProcessingServiceRoutes.Rest.csproj"
COPY . .
WORKDIR "/src/PDI.ProcessingServiceRoutes.Rest"
RUN dotnet build "PDI.ProcessingServiceRoutes.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PDI.ProcessingServiceRoutes.Rest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PDI.ProcessingServiceRoutes.Rest.dll"]