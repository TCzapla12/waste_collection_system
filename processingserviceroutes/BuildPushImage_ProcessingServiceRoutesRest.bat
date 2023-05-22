::docker login -u tczaplic

docker images

::docker tag pdiprocessingserviceroutesrest:latest tczaplic/pdi:processingserviceroutesrest

::docker rmi pdiprocessingserviceroutesrest:latest

docker rmi tczaplic/pdi:processingserviceroutesrest

docker build -f PDI.ProcessingServiceRoutes.Rest/Dockerfile.prod -t tczaplic/pdi:processingserviceroutesrest .

docker images

docker image ls --filter label=stage=processingserviceroutesrest_build

::docker image prune --filter label=stage=processingserviceroutesrest_build

docker push tczaplic/pdi:processingserviceroutesrest

::docker rmi tczaplic/pdi:processingserviceroutesrest

::docker images

::docker logout

pause

