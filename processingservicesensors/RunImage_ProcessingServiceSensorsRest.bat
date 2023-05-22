::docker login -u tczaplic

docker ps -a

docker start processingservicesensors

docker ps 

docker images

docker pull tczaplic/pdi:processingservicesensorsrest

docker run -d -p 8088:80 -p 44308:443 --name processingservicesensors tczaplic/pdi:processingservicesensorsrest

docker inspect processingservicesensors

::curl -X GET "http://localhost:8088/Sensor/RunTests?host=localhost&port=80" -H "accept: application/json"

docker stop processingservicesensors

::docker rm processingservicesensors

pause

