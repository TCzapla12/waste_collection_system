::docker login -u tczaplic

docker ps -a

docker start dataservicemeasurements

docker ps 

docker images

docker pull tczaplic/pdi:dataservicemeasurementsrest

docker run -d -p 8081:80 -p 44301:443 --name dataservicemeasurements tczaplic/pdi:dataservicemeasurementsrest

docker inspect dataservicemeasurements

::curl -X GET "http://localhost:8081/MeasurementsDatabase/GetMeasurements" -H "accept: application/json"

docker stop dataservicemeasurements

::docker rm dataservicemeasurements

pause
