::docker login -u tczaplic

docker ps -a

docker start dataservicevehicles

docker ps 

docker images

docker pull tczaplic/pdi:dataservicevehiclesrest

docker run -d -p 8082:80 -p 44302:443 --name dataservicevehicles tczaplic/pdi:dataservicevehiclesrest

docker inspect dataservicevehicles

::curl -X GET "http://localhost:8082/VehiclesDatabase/GetVehicles" -H "accept: application/json"

docker stop dataservicevehicles

::docker rm dataservicevehicles

pause

