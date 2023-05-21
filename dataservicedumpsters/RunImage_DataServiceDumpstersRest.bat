::docker login -u tczaplic

docker ps -a

docker start dataservicedumpsters

docker ps 

docker images

docker pull tczaplic/pdi:dataservicedumpstersrest

docker run -d -p 8080:80 -p 44300:443 --name dataservicedumpsters tczaplic/pdi:dataservicedumpstersrest

docker inspect dataservicedumpsters

::curl -X GET "http://localhost:8080/DumpstersDatabase/GetDumpsters" -H "accept: application/json"

docker stop dataservicedumpsters

::docker rm dataservicedumpsters

pause
