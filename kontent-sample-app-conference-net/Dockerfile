FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY kontent-sample-app-conference-net/kontent-sample-app-conference-net.csproj kontent-sample-app-conference-net/
RUN dotnet restore kontent-sample-app-conference-net/kontent-sample-app-conference-net.csproj
COPY . .
WORKDIR /src/kontent-sample-app-conference-net
RUN dotnet build kontent-sample-app-conference-net.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish kontent-sample-app-conference-net.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "kontent-sample-app-conference-net.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet kontent-sample-app-conference-net.dll
