::docker login -u tczaplic

docker images

::docker tag pdidataservicevehiclesrest:latest tczaplic/pdi:dataservicevehiclesrest

::docker rmi pdidataservicevehiclesrest:latest

docker rmi tczaplic/pdi:dataservicevehiclesrest

docker build -f PDI.DataServiceVehicles.Rest/Dockerfile.prod -t tczaplic/pdi:dataservicevehiclesrest .

docker images

docker image ls --filter label=stage=dataservicevehiclesrest_build

::docker image prune --filter label=stage=dataservicevehiclesrest_build

docker push tczaplic/pdi:dataservicevehiclesrest

::docker rmi tczaplic/pdi:dataservicevehiclesrest

::docker images

::docker logout

pause
