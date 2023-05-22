namespace PDI.ProcessingServiceRoutes.Model
{
    public enum MessageEnum
    {
        success,
        rangeError,
        dumpstersError,
        measurementsError,
        error
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
                case MessageEnum.rangeError:
                    {
                        return "Out of range";
                    }
                case MessageEnum.dumpstersError:
                    {
                        return "DumpstersClient error: ";
                    }
                case MessageEnum.measurementsError:
                    {
                        return "MeasurementsClient error: ";
                    }
                case MessageEnum.error:
                    {
                        return "ProcessingServiceRoutes error: ";
                    }
                default:
                    {
                        return "Not implemented";
                    }
            }
        }
    }
}
