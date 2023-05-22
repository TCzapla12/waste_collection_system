kubectl apply -f simulator-statefulset.yaml

pause

kubectl get services

kubectl get statefulsets

kubectl get pods

pause

kubectl describe statefulset simulationmodule-sensors

pause

::kubectl attach simulationmodule-sensors-0 -it

pause

kubectl delete statefulsets simulationmodule-sensors

