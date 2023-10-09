# waste_collection_system
The system supporting the waste collection process

The main task of the system is to support the waste collection process. As part of engineering work, elements were implemented to optimize routes for garbage trucks. Routes are generated based on the analysis of the fill level measurements of the garbage cans and their location data.

The system architecture is service-oriented (SOA). It consists of microservices, which have been divided into three categories: data, processing, application and web application for facility dispatcher. Four data microservices have been defined: Dumpsters, Measurements, Vehicles, and Routes. Additionally, the Routing microservice and the Sensors microservice support the processes occurring in the system. The Dispatcher application microservice supports the Dispatcher application by performing appropriate operations and transmitting data.
