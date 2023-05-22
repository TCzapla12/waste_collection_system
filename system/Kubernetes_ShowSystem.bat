kubectl get services

kubectl get deployments

kubectl get statefulsets

kubectl get pods

pause

kubectl describe service simulationmodule-sensors-api
kubectl describe service application-dispatcher-api
kubectl describe service appservice-dispatcher-api
kubectl describe service processservice-sensors-api
kubectl describe service processservice-routes-api
kubectl describe service dataservice-routes-api
kubectl describe service dataservice-vehicles-api
kubectl describe service dataservice-measurements-api
kubectl describe service dataservice-dumpsters-api

pause

kubectl describe deployment application-dispatcher
kubectl describe deployment appservice-dispatcher
kubectl describe deployment processservice-sensors
kubectl describe deployment processservice-routes
kubectl describe deployment dataservice-routes
kubectl describe deployment dataservice-vehicles
kubectl describe deployment dataservice-measurements
kubectl describe deployment dataservice-dumpsters

pause

kubectl describe statefulset simulationmodule-sensors

pause
