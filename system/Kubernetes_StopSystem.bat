kubectl delete service simulationmodule-sensors-api
kubectl delete statefulset simulationmodule-sensors

kubectl delete service application-dispatcher-api
kubectl delete deployment application-dispatcher

kubectl delete service appservice-dispatcher-api
kubectl delete deployment appservice-dispatcher

kubectl delete service processservice-sensors-api
kubectl delete deployment processservice-sensors
kubectl delete service processservice-routes-api
kubectl delete deployment processservice-routes

kubectl delete service dataservice-routes-api
kubectl delete deployment dataservice-routes
kubectl delete service dataservice-vehicles-api
kubectl delete deployment dataservice-vehicles
kubectl delete service dataservice-measurements-api
kubectl delete deployment dataservice-measurements
kubectl delete service dataservice-dumpsters-api
kubectl delete deployment dataservice-dumpsters

pause

kubectl get deployments

kubectl get statefulsets

kubectl get services

kubectl get pods

pause
