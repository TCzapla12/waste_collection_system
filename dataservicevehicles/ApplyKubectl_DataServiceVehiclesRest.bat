kubectl apply -f dataservicevehiclesrest-deployment.yaml

pause

kubectl get services

kubectl get deployments

kubectl get pods

pause

kubectl describe deployment dataservice-vehicles

kubectl describe service dataservice-vehicles-api

pause

curl -X GET "http://localhost:30082/VehiclesDatabase/GetVehicles" -H "accept: application/json"

pause

kubectl delete service dataservice-vehicles-api

kubectl delete deployment dataservice-vehicles




