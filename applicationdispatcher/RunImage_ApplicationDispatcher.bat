::docker login -u tczaplic

docker ps -a

docker start applicationdispatcher

docker ps 

docker images

docker pull tczaplic/pdi:applicationdispatcherblazorserver

docker run -d -p 8086:80 -p 44306:443 --name applicationdispatcher tczaplic/pdi:applicationdispatcherblazorserver

docker inspect applicationdispatcher

::curl -X GET "http://localhost:8086/dumpsters"

::pause

docker stop applicationdispatcher

::docker rm applicationdispatcher

pause
