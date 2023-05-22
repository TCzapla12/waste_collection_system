::docker login -u tczaplic

docker images

::docker tag pdiapplicationdispatcherblazorserver:latest tczaplic/pdi:applicationdispatcherblazorserver

::docker rmi pdiapplicationdispatcherblazorserver:latest

docker rmi tczaplic/pdi:applicationdispatcherblazorserver

docker build -f PDI.ApplicationDispatcher.BlazorServer/Dockerfile.prod -t tczaplic/pdi:applicationdispatcherblazorserver .

docker images

docker image ls --filter label=stage=applicationdispatcherblazorserver_build

::docker image prune --filter label=stage=applicationdispatcherblazorserver_build --force

docker push tczaplic/pdi:applicationdispatcherblazorserver

::docker rmi tczaplic/pdi:applicationdispatcherblazorserver

::docker images

::docker logout

pause
