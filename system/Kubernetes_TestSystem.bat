curl -X GET "http://localhost:30084/Dispatcher/GetDumpsters" -H "accept: application/json"
curl -X GET "http://localhost:30084/Dispatcher/GetMeasurements" -H "accept: application/json"
curl -X GET "http://localhost:30084/Dispatcher/GetVehicles" -H "accept: application/json"
curl -X GET "http://localhost:30084/Dispatcher/GetRoutes" -H "accept: application/json"

pause

curl -X GET "http://localhost:30084/Dispatcher/RunTests?host=localhost&port=80&dataService=dumpsters" -H "accept: application/json"
curl -X GET "http://localhost:30084/Dispatcher/RunTests?host=appservice-dispatcher-api&port=80&dataService=dumpsters" -H "accept: application/json"
curl -X GET "http://localhost:30084/Dispatcher/RunTests?host=localhost&port=80&dataService=measurements" -H "accept: application/json"
curl -X GET "http://localhost:30084/Dispatcher/RunTests?host=appservice-dispatcher-api&port=80&dataService=measurements" -H "accept: application/json"
curl -X GET "http://localhost:30084/Dispatcher/RunTests?host=localhost&port=80&dataService=vehicles" -H "accept: application/json"
curl -X GET "http://localhost:30084/Dispatcher/RunTests?host=appservice-dispatcher-api&port=80&dataService=vehicles" -H "accept: application/json"
curl -X GET "http://localhost:30084/Dispatcher/RunTests?host=localhost&port=80&dataService=routes" -H "accept: application/json"
curl -X GET "http://localhost:30084/Dispatcher/RunTests?host=appservice-dispatcher-api&port=80&dataService=routes" -H "accept: application/json"
curl -X GET "http://localhost:30084/Dispatcher/RunTests?host=localhost&port=80&dataService=processing" -H "accept: application/json"
curl -X GET "http://localhost:30084/Dispatcher/RunTests?host=appservice-dispatcher-api&port=80&dataService=processing" -H "accept: application/json"

pause

curl -X GET "http://localhost:30086/dumpsters"

pause

curl -X GET "http://localhost:30088/Sensor/RunTests?host=localhost&port=80" -H "accept: application/json"
curl -X GET "http://localhost:30088/Sensor/RunTests?host=processservice-sensors-api&port=80" -H "accept: application/json"

pause

curl -X GET "http://localhost:30085/Route/RunTests?host=localhost&port=80" -H "accept: application/json"
curl -X GET "http://localhost:30085/Route/RunTests?host=processservice-routes-api&port=80" -H "accept: application/json"

pause