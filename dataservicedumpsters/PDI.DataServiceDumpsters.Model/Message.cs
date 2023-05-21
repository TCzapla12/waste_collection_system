namespace PDI.DataServiceDumpsters.Model
{
    public enum MessageEnum
    {
        success,
        warning,
        notAvailable,
        notExist,
        sameState
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
                case MessageEnum.warning:
                    {
                        return "Warning";
                    }
                case MessageEnum.notAvailable:
                    {
                        return "Modification not available";
                    }
                case MessageEnum.notExist:
                    {
                        return "Object not exist";
                    }
                case MessageEnum.sameState:
                    {
                        return "Same state";
                    }
                default:
                    {
                        return "Not implemented";
                    }
            }
        }
    }

    
}
