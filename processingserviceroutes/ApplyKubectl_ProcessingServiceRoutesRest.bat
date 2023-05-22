kubectl apply -f processingserviceroutesrest-deployment.yaml

pause

kubectl get services

kubectl get deployments

kubectl get pods

pause

kubectl describe deployment processingservice-routes

kubectl describe service processingservice-routes-api

pause

curl -X GET "http://localhost:30085/Route/RunTests?host=localhost&port=80" -H "accept: application/json"

pause

kubectl delete service processingservice-routes-api

kubectl delete deployment processingservice-routes

