::docker login -u tczaplic

docker images

::docker tag pdiappservicedispatcherrest:latest tczaplic/pdi:appservicedispatcherrest

::docker rmi pdiappservicedispatcherrest:latest

docker rmi tczaplic/pdi:appservicedispatcherrest

docker build -f PDI.AppServiceDispatcher.Rest/Dockerfile_Simu.dev -t tczaplic/pdi:appservicedispatcherrest .

docker images

docker image ls --filter label=stage=appservicedispatcherrest_build

::docker image prune --filter label=stage=appservicedispatcherrest_build

docker push tczaplic/pdi:appservicedispatcherrest

::docker rmi tczaplic/pdi:appservicedispatcherrest

::docker images

::docker logout

pause

