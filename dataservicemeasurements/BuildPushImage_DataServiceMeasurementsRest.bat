::docker login -u tczaplic

docker images

::docker tag pdidataservicemeasurementsrest:latest tczaplic/pdi:dataservicemeasurementsrest

::docker rmi pdidataservicemeasurementsrest:latest

docker rmi tczaplic/pdi:dataservicemeasurementsrest

docker build -f PDI.DataServiceMeasurements.Rest/Dockerfile.prod -t tczaplic/pdi:dataservicemeasurementsrest .

docker images

docker image ls --filter label=stage=dataservicemeasurementsrest_build

::docker image prune --filter label=stage=dataservicemeasurementsrest_build

docker push tczaplic/pdi:dataservicemeasurementsrest

::docker rmi tczaplic/pdi:dataservicemeasurementsrest

::docker images

::docker logout

pause
