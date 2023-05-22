#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PDI.ApplicationDispatcher.BlazorServer/PDI.ApplicationDispatcher.BlazorServer.csproj", "PDI.ApplicationDispatcher.BlazorServer/"]
COPY ["PDI.ApplicationDispatcher.Controller/PDI.ApplicationDispatcher.Controller.csproj", "PDI.ApplicationDispatcher.Controller/"]
COPY ["PDI.ApplicationDispatcher.Model/PDI.ApplicationDispatcher.Model.csproj", "PDI.ApplicationDispatcher.Model/"]
COPY ["PDI.ApplicationDispatcher.Utilities/PDI.ApplicationDispatcher.Utilities.csproj", "PDI.ApplicationDispatcher.Utilities/"]
COPY ["PDI.ApplicationDispatcher.Tests/PDI.ApplicationDispatcher.Tests.csproj", "PDI.ApplicationDispatcher.Tests/"]
RUN dotnet restore "PDI.ApplicationDispatcher.BlazorServer/PDI.ApplicationDispatcher.BlazorServer.csproj"
COPY . .
WORKDIR "/src/PDI.ApplicationDispatcher.BlazorServer"
RUN dotnet build "PDI.ApplicationDispatcher.BlazorServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PDI.ApplicationDispatcher.BlazorServer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PDI.ApplicationDispatcher.BlazorServer.dll"]