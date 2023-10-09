namespace PDI.ApplicationDispatcher.Controller
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using PDI.ApplicationDispatcher.Model;
  using PDI.ApplicationDispatcher.Utilities;

  public static class ControllerFactory
  {
    private static IController controller;

    public static IController GetController( IEventDispatcher dispatch )
    {
      if( controller == null )
      {
        IModel newModel = new Model( dispatch ) as IModel;

        IController newController = new Controller( dispatch, newModel );

        controller = newController;
      }
      return controller;
    }
  }
}
