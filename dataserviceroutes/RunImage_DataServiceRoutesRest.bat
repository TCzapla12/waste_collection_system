::docker login -u tczaplic

docker ps -a

docker start dataserviceroutes

docker ps 

docker images

docker pull tczaplic/pdi:dataserviceroutesrest

docker run -d -p 8083:80 -p 44303:443 --name dataserviceroutes tczaplic/pdi:dataserviceroutesrest

docker inspect dataserviceroutes

::curl -X GET "http://localhost:8083/RoutesDatabase/GetRoutes" -H "accept: application/json"

docker stop dataserviceroutes

::docker rm dataserviceroutes

pause
