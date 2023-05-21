::docker login -u tczaplic

docker images

::docker tag pdidataservicedumpstersrest:latest tczaplic/pdi:dataservicedumpstersrest

::docker rmi pdidataservicedumpstersrest:latest

docker rmi tczaplic/pdi:dataservicedumpstersrest

docker build -f PDI.DataServiceDumpsters.Rest/Dockerfile.prod -t tczaplic/pdi:dataservicedumpstersrest .

docker images

docker image ls --filter label=stage=dataservicedumpstersrest_build

::docker image prune --filter label=stage=dataservicedumpstersrest_build

docker push tczaplic/pdi:dataservicedumpstersrest

::docker rmi tczaplic/pdi:dataservicedumpstersrest

::docker images

::docker logout

pause
