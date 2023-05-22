namespace PDI.ApplicationDispatcher.Tests
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using Microsoft.VisualStudio.TestTools.UnitTesting;

  using PDI.ApplicationDispatcher.Controller;
  using PDI.ApplicationDispatcher.Model;
  using PDI.ApplicationDispatcher.Utilities;

  [TestClass]
  public class ModelTests
  {
    [TestMethod]
    public void LoadNodeList_ReadsFromNodeArray_ThereIsOneMatchingNode( )
    {
      IModel model = new Model( new EmptyEventDispatcher( ) );

      string searchText = "node2";

      model.SearchText = searchText;

      //model.LoadNodeList( );

      int expectedCount = 1;

      int actualCount = model.RoutesList.Count;

      Assert.AreEqual( expectedCount, actualCount, "Node count should be {0} and not {1}", expectedCount, actualCount );
    }
  }
}
