namespace PDI.ApplicationDispatcher.Model
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    public static class DispatcherClientFactory
    {
        public static IDispatcher GetDispatcherClient()
        {
#if DEBUG
            /* 
            const string serviceHost = "localhost";
            const int servicePort = 8083;

            return new NetworkClient( serviceHost, servicePort );
            */
            //return new FakeDispatcherClient( );

            const string serviceHost = "localhost";
            const int servicePort = 8084;

            return new DispatcherClient(serviceHost, servicePort);


#else
            /* 
            const string serviceHost = "localhost";
            const int servicePort = 44328;

            const string serviceHost = "appservice-dispatcher-api";
            const int servicePort = 80;

            return new NetworkClient( serviceHost, servicePort );
            */
            //return new FakeDispatcherClient( );
            const string serviceHost = "appservice-dispatcher-api";
            const int servicePort = 80;

            return new DispatcherClient(serviceHost, servicePort);

#endif
        }
    }
}
