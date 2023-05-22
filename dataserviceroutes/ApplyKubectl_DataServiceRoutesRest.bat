kubectl apply -f dataserviceroutesrest-deployment.yaml

pause

kubectl get services

kubectl get deployments

kubectl get pods

pause

kubectl describe deployment dataservice-routes

kubectl describe service dataservice-routes-api

pause

curl -X GET "http://localhost:30083/RoutesDatabase/GetRoutes" -H "accept: application/json"

pause

kubectl delete service dataservice-routes-api

kubectl delete deployment dataservice-routes



