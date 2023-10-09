namespace PDI.AppServiceDispatcher.Model
{
    public enum MessageEnum
    {
        success,
        error,
        dumpstersError,
        vehiclesError,
        routesError
    }
    public static class Message
    {
        public static string GetMessage(MessageEnum message)
        {
            switch (message)
            {
                case MessageEnum.success:
                    {
                        return "Success";
                    }
                case MessageEnum.error:
                    {
                        return "AppServiceDispatcher error: ";
                    }
                case MessageEnum.dumpstersError:
                    {
                        return "DumpstersClient error: ";
                    }
                case MessageEnum.vehiclesError:
                    {
                        return "VehiclesClient error: ";
                    }
                case MessageEnum.routesError:
                    {
                        return "RoutesClient error: ";
                    }
                default:
                    {
                        return "Not implemented";
                    }
            }
        }
    }
}
