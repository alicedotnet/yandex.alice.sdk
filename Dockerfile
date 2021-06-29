FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Yandex.Alice.Sdk.Demo/Yandex.Alice.Sdk.Demo.csproj", "Yandex.Alice.Sdk.Demo/"]
RUN dotnet restore "Yandex.Alice.Sdk.Demo/Yandex.Alice.Sdk.Demo.csproj"
COPY ["Yandex.Alice.Sdk.Demo.Tests/Yandex.Alice.Sdk.Demo.Tests.csproj", "Yandex.Alice.Sdk.Demo.Tests/"]
RUN dotnet restore "Yandex.Alice.Sdk.Demo.Tests/Yandex.Alice.Sdk.Demo.Tests.csproj"
COPY . .
WORKDIR "/src/Yandex.Alice.Sdk.Demo.Tests"
RUN dotnet test "Yandex.Alice.Sdk.Demo.Tests.csproj"
WORKDIR "/src/Yandex.Alice.Sdk.Demo"
RUN dotnet build "Yandex.Alice.Sdk.Demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Yandex.Alice.Sdk.Demo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Yandex.Alice.Sdk.Demo.dll"]