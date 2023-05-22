::docker login -u tczaplic

docker ps -a

docker start processingserviceroutes

docker ps 

docker images

docker pull tczaplic/pdi:processingserviceroutesrest

docker run -d -p 8085:80 -p 44305:443 --name processingserviceroutes tczaplic/pdi:processingserviceroutesrest

docker inspect processingserviceroutes

::curl -X GET "http://localhost:8085/Route/RunTests?host=localhost&port=80" -H "accept: application/json"

docker stop processingserviceroutes

::docker rm processingserviceroutes

pause

