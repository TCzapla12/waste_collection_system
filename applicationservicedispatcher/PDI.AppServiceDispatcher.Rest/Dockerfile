#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PDI.AppServiceDispatcher.Rest/PDI.AppServiceDispatcher.Rest.csproj", "PDI.AppServiceDispatcher.Rest/"]
COPY ["PDI.AppServiceDispatcher.Logic/PDI.AppServiceDispatcher.Logic.csproj", "PDI.AppServiceDispatcher.Logic/"]
COPY ["PDI.AppServiceDispatcher.Model/PDI.AppServiceDispatcher.Model.csproj", "PDI.AppServiceDispatcher.Model/"]
COPY ["PDI.AppServiceDispatcher.Utilities/PDI.AppServiceDispatcher.Utilities.csproj", "PDI.AppServiceDispatcher.Utilities/"]
COPY ["PDI.AppServiceDispatcher.Rest.Model/PDI.AppServiceDispatcher.Rest.Model.csproj", "PDI.AppServiceDispatcher.Rest.Model/"]
COPY ["PDI.AppServiceDispatcher.Rest.Tests/PDI.AppServiceDispatcher.Rest.Tests.csproj", "PDI.AppServiceDispatcher.Rest.Tests/"]
COPY ["PDI.AppServiceDispatcher.Tests/PDI.AppServiceDispatcher.Tests.csproj", "PDI.AppServiceDispatcher.Tests/"]
RUN dotnet restore "PDI.AppServiceDispatcher.Rest/PDI.AppServiceDispatcher.Rest.csproj"
COPY . .
WORKDIR "/src/PDI.AppServiceDispatcher.Rest"
RUN dotnet build "PDI.AppServiceDispatcher.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PDI.AppServiceDispatcher.Rest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PDI.AppServiceDispatcher.Rest.dll"]