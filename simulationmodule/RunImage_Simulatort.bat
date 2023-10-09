::docker login -u tczaplic

docker ps -a

docker start simulationmodule

docker ps 

docker images

docker pull tczaplic/pdi:simulator

docker run -d -it -p 8087:80 -p 44307:443 --name simulationmodule tczaplic/pdi:simulator

docker inspect simulationmodule

:: attach simulationmodule

docker stop simulationmodule

::docker rm simulationmodule

pause

