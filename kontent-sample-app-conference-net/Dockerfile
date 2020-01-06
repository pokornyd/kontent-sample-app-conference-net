FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY kontent-sample-app-conference-net.csproj .
RUN dotnet restore kontent-sample-app-conference-net.csproj
COPY . .
WORKDIR /src
RUN dotnet build kontent-sample-app-conference-net.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish kontent-sample-app-conference-net.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "kontent-sample-app-conference-net.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet kontent-sample-app-conference-net.dll
