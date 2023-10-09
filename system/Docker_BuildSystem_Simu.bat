::docker login -u tczaplic

docker rmi tczaplic/pdidataservicedumpstersrest:latest
docker rmi tczaplic/pdidataservicemeasurementsrest:latest
docker rmi tczaplic/pdidataservicevehiclesrest:latest
docker rmi tczaplic/pdidataserviceroutesrest:latest
docker rmi tczaplic/pdiappservicedispatcherrest:latest
docker rmi tczaplic/pdiprocessingserviceroutesrest:latest
docker rmi tczaplic/pdiprocessingservicesensorsrest:latest
docker rmi tczaplic/pdiapplicationdispatcherblazorserver:latest
docker rmi tczaplic/pdisimulator:latest

pause

docker build -f ../dataservicedumpsters/PDI.DataServiceDumpsters.Rest/Dockerfile.prod -t tczaplic/pdidataservicedumpstersrest:latest ../dataservicedumpsters
docker build -f ../dataservicemeasurements/PDI.DataServiceMeasurements.Rest/Dockerfile.prod -t tczaplic/pdidataservicemeasurementsrest:latest ../dataservicemeasurements
docker build -f ../dataservicevehicles/PDI.DataServiceVehicles.Rest/Dockerfile.prod -t tczaplic/pdidataservicevehiclesrest:latest ../dataservicevehicles
docker build -f ../dataserviceroutes/PDI.DataServiceRoutes.Rest/Dockerfile.prod -t tczaplic/pdidataserviceroutesrest:latest ../dataserviceroutes
docker build -f ../applicationservicedispatcher/PDI.AppServiceDispatcher.Rest/Dockerfile_Simu.dev -t tczaplic/pdiappservicedispatcherrest:latest ../applicationservicedispatcher
docker build -f ../processingserviceroutes/PDI.ProcessingServiceRoutes.Rest/Dockerfile.prod -t tczaplic/pdiprocessingserviceroutesrest:latest ../processingserviceroutes
docker build -f ../processingservicesensors/PDI.ProcessingServiceSensors.Rest/Dockerfile.prod -t tczaplic/pdiprocessingservicesensorsrest:latest ../processingservicesensors
docker build -f ../applicationdispatcher/PDI.ApplicationDispatcher.BlazorServer/Dockerfile.prod -t tczaplic/pdiapplicationdispatcherblazorserver:latest ../applicationdispatcher
docker build -f ../simulationmodule/PDI.SimulationModule.Rest/Dockerfile.prod -t tczaplic/pdisimulator:latest ../simulationmodule

::pause

docker push tczaplic/pdidataservicedumpstersrest:latest
docker push tczaplic/pdidataservicemeasurementsrest:latest
docker push tczaplic/pdidataservicevehiclesrest:latest
docker push tczaplic/pdidataserviceroutesrest:latest
docker push tczaplic/pdiappservicedispatcherrest:latest
docker push tczaplic/pdiprocessingserviceroutesrest:latest
docker push tczaplic/pdiprocessingservicesensorsrest:latest
docker push tczaplic/pdiapplicationdispatcherblazorserver:latest
docker push tczaplic/pdisimulator:latest

pause