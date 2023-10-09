namespace PDI.ApplicationDispatcher.Controller
{
  using PDI.ApplicationDispatcher.Model;
  using PDI.ApplicationDispatcher.Utilities;

  public partial class Controller : PropertyContainerBase, IController
  {
    public IModel Model { get; private set; }

    public Controller( IEventDispatcher dispatcher, IModel model ) : base( dispatcher )
    {
      this.Model = model;

      //this.SearchNodesCommand = new ControllerCommand( this.SearchNodes );

      this.ShowListCommand = new ControllerCommand( this.ShowList );

      this.ShowMapCommand = new ControllerCommand( this.ShowMap );
    }
  }
}
