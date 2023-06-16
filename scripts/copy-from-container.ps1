docker-compose build nuget-pack
docker create -ti --name dummy yandexalicesdk-nuget-pack bash
docker cp dummy:/build/packages ./data/
docker rm -f dummy