::docker login -u tczaplic

docker images

::docker tag pdidataserviceroutesrest:latest tczaplic/pdi:dataserviceroutesrest

::docker rmi pdidataserviceroutesrest:latest

docker rmi tczaplic/pdi:dataserviceroutesrest

docker build -f PDI.DataServiceRoutes.Rest/Dockerfile.prod -t tczaplic/pdi:dataserviceroutesrest .

docker images

docker image ls --filter label=stage=dataserviceroutesrest_build

::docker image prune --filter label=stage=dataserviceroutesrest_build

docker push tczaplic/pdi:dataserviceroutesrest

::docker rmi tczaplic/pdi:dataserviceroutesrest

::docker images

::docker logout

pause