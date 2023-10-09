namespace PDI.DataServiceMeasurements.Model
{
    public enum MessageEnum
    {
        success,
        notExist,
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
                case MessageEnum.notExist:
                    {
                        return "Object not exist";
                    }
                default:
                    {
                        return "Not implemented";
                    }
            }
        }
    }


}
