::docker login -u tczaplic

docker images

::docker tag pdisimulator:latest tczaplic/pdi:simulator

::docker rmi pdisimulator:latest

docker rmi tczaplic/pdi:simulator

docker build -f PDI.SimulationModule.Rest/Dockerfile.prod -t tczaplic/pdi:simulator .

docker images

docker image ls --filter label=stage=simulator_build

::docker image prune --filter label=stage=simulator_build

docker push tczaplic/pdi:simulator

::docker rmi tczaplic/pdi:simulator

::docker images

::docker logout

pause

