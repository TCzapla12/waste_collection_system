namespace PDI.SimulationModule.Model
{
    public abstract class Object
    {
        public string Id { get; private set; }

        public Object(string id)
        {
            Id = id;
        }
    }
}
