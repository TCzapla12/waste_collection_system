::docker login -u tczaplic

docker images

::docker tag pdiprocessingservicesensorsrest:latest tczaplic/pdi:processingservicesensorsrest

::docker rmi pdiprocessingservicesensorsrest:latest

docker rmi tczaplic/pdi:processingservicesensorsrest

docker build -f PDI.ProcessingServiceSensors.Rest/Dockerfile.prod -t tczaplic/pdi:processingservicesensorsrest .

docker images

docker image ls --filter label=stage=processingservicesensorsrest_build

::docker image prune --filter label=stage=processingservicesensorsrest_build

docker push tczaplic/pdi:processingservicesensorsrest

::docker rmi tczaplic/pdi:processingservicesensorsrest

::docker images

::docker logout

pause

