kubectl apply -f applicationdispatcherblazorserver-deployment.yaml

pause

kubectl get services

kubectl get deployments

kubectl get pods

pause

kubectl describe deployment application-dispatcher

kubectl describe service application-dispatcher-api

pause

curl -X GET "http://localhost:30086/dumpsters" -H "accept: application/json"

pause

kubectl delete service application-dispatcher-api

kubectl delete deployment application-dispatcher




