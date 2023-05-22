::docker login -u tczaplic

docker ps -a

docker start appservicedispatcher

docker ps 

docker images

docker pull tczaplic/pdi:appservicedispatcherrest

docker run -d -p 8084:80 -p 44304:443 --name appservicedispatcher tczaplic/pdi:appservicedispatcherrest

docker inspect appservicedispatcher

::curl -X GET "http://localhost:8084/Dispatcher/GetDumpsters" -H "accept: application/json"

docker stop appservicedispatcher

::docker rm appservicedispatcher

pause

