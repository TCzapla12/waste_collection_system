kubectl apply -f appservicedispatcherrest-deployment.yaml

pause

kubectl get services

kubectl get deployments

kubectl get pods

pause

kubectl describe deployment appservice-dispatcher

kubectl describe service appservice-dispatcher-api

pause

curl -X GET "http://localhost:30084/Dispatcher/GetDumpsters" -H "accept: application/json"

pause

kubectl delete service appservice-dispatcher-api

kubectl delete deployment appservice-dispatcher

