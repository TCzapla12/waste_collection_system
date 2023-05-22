namespace PDI.ApplicationDispatcher.Model
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  using PDI.ApplicationDispatcher.Utilities;

  public partial class Model : PropertyContainerBase, IModel
  {
    public Model( IEventDispatcher dispatcher ) : base( dispatcher )
    {
    }
  }
}
