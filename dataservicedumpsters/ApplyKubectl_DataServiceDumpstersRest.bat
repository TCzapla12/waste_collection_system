kubectl apply -f dataservicedumpstersrest-deployment.yaml

pause

kubectl get services

kubectl get deployments

kubectl get pods

pause

kubectl describe deployment dataservice-dumpsters

kubectl describe service dataservice-dumpsters-api

pause

curl -X GET "http://localhost:30080/DumpstersDatabase/GetDumpsters" -H "accept: application/json"

pause

kubectl delete service dataservice-dumpsters-api

kubectl delete deployment dataservice-dumpsters




