::docker login -u tczaplic

docker rmi tczaplic/pdi:dataservicedumpstersrest
docker rmi tczaplic/pdi:dataservicemeasurementsrest
docker rmi tczaplic/pdi:dataservicevehiclesrest
docker rmi tczaplic/pdi:dataserviceroutesrest
docker rmi tczaplic/pdi:appservicedispatcherrest
docker rmi tczaplic/pdi:processingserviceroutesrest
docker rmi tczaplic/pdi:processingservicesensorsrest
docker rmi tczaplic/pdi:applicationdispatcherblazorserver

pause

docker build -f ../dataservicedumpsters/PDI.DataServiceDumpsters.Rest/Dockerfile.prod -t tczaplic/pdi:dataservicedumpstersrest ../dataservicedumpsters
docker build -f ../dataservicemeasurements/PDI.DataServiceMeasurements.Rest/Dockerfile.prod -t tczaplic/pdi:dataservicemeasurementsrest ../dataservicemeasurements
docker build -f ../dataservicevehicles/PDI.DataServiceVehicles.Rest/Dockerfile.prod -t tczaplic/pdi:dataservicevehiclesrest ../dataservicevehicles
docker build -f ../dataserviceroutes/PDI.DataServiceRoutes.Rest/Dockerfile.prod -t tczaplic/pdi:dataserviceroutesrest ../dataserviceroutes
docker build -f ../applicationservicedispatcher/PDI.AppServiceDispatcher.Rest/Dockerfile.prod -t tczaplic/pdi:appservicedispatcherrest ../applicationservicedispatcher
docker build -f ../processingserviceroutes/PDI.ProcessingServiceRoutes.Rest/Dockerfile.prod -t tczaplic/pdi:processingserviceroutesrest ../processingserviceroutes
docker build -f ../processingservicesensors/PDI.ProcessingServiceSensors.Rest/Dockerfile.prod -t tczaplic/pdi:processingservicesensorsrest ../processingservicesensors
docker build -f ../applicationdispatcher/PDI.ApplicationDispatcher.BlazorServer/Dockerfile.prod -t tczaplic/pdi:applicationdispatcherblazorserver ../applicationdispatcher

::pause

docker push tczaplic/pdi:dataservicedumpstersrest
docker push tczaplic/pdi:dataservicemeasurementsrest
docker push tczaplic/pdi:dataservicevehiclesrest
docker push tczaplic/pdi:dataserviceroutesrest
docker push tczaplic/pdi:appservicedispatcherrest
docker push tczaplic/pdi:processingserviceroutesrest
docker push tczaplic/pdi:processingservicesensorsrest
docker push tczaplic/pdi:applicationdispatcherblazorserver

pause