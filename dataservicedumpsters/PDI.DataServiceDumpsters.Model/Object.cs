namespace PDI.DataServiceDumpsters.Model
{
  public abstract class Object
  {
    public string Id { get; private set; }

    public Object( string id )
    {
      this.Id = id;
    }
  }
}
