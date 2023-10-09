namespace PDI.ProcessingServiceRoutes.Logic
{
    using PDI.ProcessingServiceRoutes.Model;

    public class FakeRoute : IRoute
    {
        public FakeRoute()
        {
        }

        public string CalculateRoute()
        {
            return Message.GetMessage(MessageEnum.success);
        }
    }
}
