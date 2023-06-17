FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine as build
WORKDIR /build
COPY ./Yandex.Alice.Sdk.sln ./
COPY src/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done
COPY tests/*/*.csproj ./  
RUN for file in $(ls *.csproj); do mkdir -p tests/${file%.*}/ && mv $file tests/${file%.*}/; done
RUN dotnet restore Yandex.Alice.Sdk.sln
COPY . .
RUN dotnet build Yandex.Alice.Sdk.sln --no-restore

FROM build as unit-test
RUN dotnet test Yandex.Alice.Sdk.sln --filter "Category!=Integration" --no-restore

FROM build as test
ARG AliceSettings__SkillId
ENV AliceSettings__SkillId ${AliceSettings__SkillId}
ARG AliceSettings__DialogsOAuthToken
ENV AliceSettings__DialogsOAuthToken ${AliceSettings__DialogsOAuthToken}
ARG AliceSettings__IoTOAuthToken
ENV AliceSettings__IoTOAuthToken ${AliceSettings__IoTOAuthToken}
ARG AliceSettings__SmartHomeSkillId
ENV AliceSettings__SmartHomeSkillId ${AliceSettings__SmartHomeSkillId}
RUN dotnet test Yandex.Alice.Sdk.sln --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS demo-base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM test AS demo-publish
WORKDIR "/build/src/Yandex.Alice.Sdk.Demo"
RUN dotnet publish "Yandex.Alice.Sdk.Demo.csproj" -c Release -o /app/publish

FROM demo-base AS demo
WORKDIR /app
COPY --from=demo-publish /app/publish .
ENTRYPOINT ["dotnet", "Yandex.Alice.Sdk.Demo.dll"]

FROM test as nuget-pack
RUN dotnet build ./src/Yandex.Alice.Sdk/*.csproj -c Release --no-restore
RUN dotnet pack ./src/Yandex.Alice.Sdk/*.csproj -c Release -o ./packages/

FROM nuget-pack as nuget
ARG Nuget_Url=https://api.nuget.org/v3/index.json
ARG Nuget_Api_Key

RUN dotnet nuget push ./packages/*.nupkg --source $Nuget_Url --api-key $Nuget_Api_Key --skip-duplicate