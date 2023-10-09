kubectl apply -f processingservicesensorsrest-deployment.yaml

pause

kubectl get services

kubectl get deployments

kubectl get pods

pause

kubectl describe deployment processingservice-sensors

kubectl describe service processingservice-sensors-api

pause

curl -X GET "http://localhost:30088/Sensor/RunTests?host=localhost&port=80" -H "accept: application/json"

pause

kubectl delete service processingservice-sensors-api

kubectl delete deployment processingservice-sensors

