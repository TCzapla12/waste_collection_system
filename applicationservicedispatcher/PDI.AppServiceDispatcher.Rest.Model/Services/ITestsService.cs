namespace PDI.AppServiceDispatcher.Rest.Model
{
  public interface ITestsService
  {
    public string RunTests( string host, int port, string dataservice );
    }
}
