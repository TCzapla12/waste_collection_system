namespace PDI.ApplicationDispatcher.Model
{
    public enum MessageEnum
    {
        success,
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
                case MessageEnum.error:
                    {
                        return "Error";
                    }
                default:
                    {
                        return "Not implemented";
                    }
            }
        }
    }
}
