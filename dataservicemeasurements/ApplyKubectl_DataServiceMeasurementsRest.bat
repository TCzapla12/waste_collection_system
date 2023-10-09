kubectl apply -f dataservicemeasurementsrest-deployment.yaml

pause

kubectl get services

kubectl get deployments

kubectl get pods

pause

kubectl describe deployment dataservice-measurements

kubectl describe service dataservice-measurements-api

pause

curl -X GET "http://localhost:30081/MeasurementsDatabase/GetMeasurements" -H "accept: application/json"

pause

kubectl delete service dataservice-measurements-api

kubectl delete deployment dataservice-measurements