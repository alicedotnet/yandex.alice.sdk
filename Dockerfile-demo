FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
ARG AliceSettings__SkillId
ENV AliceSettings__SkillId ${AliceSettings__SkillId}
ARG AliceSettings__DialogsOAuthToken
ENV AliceSettings__DialogsOAuthToken ${AliceSettings__DialogsOAuthToken}
WORKDIR /build
COPY ./Yandex.Alice.Sdk.sln ./
COPY ./docker-compose.dcproj ./
COPY src/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done
COPY tests/*/*.csproj ./  
RUN for file in $(ls *.csproj); do mkdir -p tests/${file%.*}/ && mv $file tests/${file%.*}/; done
RUN dotnet restore Yandex.Alice.Sdk.sln
COPY . .
RUN dotnet test Yandex.Alice.Sdk.sln

FROM build AS publish
WORKDIR "/build/src/Yandex.Alice.Sdk.Demo"
RUN dotnet publish "Yandex.Alice.Sdk.Demo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Yandex.Alice.Sdk.Demo.dll"]