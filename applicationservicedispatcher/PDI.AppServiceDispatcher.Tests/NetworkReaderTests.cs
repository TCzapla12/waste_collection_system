namespace PDI.AppServiceDispatcher.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using System.IO;

    using System.Xml;
    using System.Xml.XPath;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    using PDI.AppServiceDispatcher.Logic;
    using PDI.AppServiceDispatcher.Model;

    [TestClass]
    public class NetworkReaderTests
    {
        private const string networkXsdFilename = "./../../../network.xsd";
        private const string networkXmlFilename = "./../../../network.xml";

        //[TestMethod]
        //public void ReadXmlDocument_DefaultXmlFileStreams_DocumentElementHas2ChildNodes()
        //{
        //    DumpstersDatabaseReader networkReader = new DumpstersDatabaseReader();

        //    using StreamReader schemaReader = File.OpenText(networkXsdFilename);

        //    using StreamReader dataReader = File.OpenText(networkXmlFilename);

        //    XmlDocument networkXmlDocument = networkReader.ReadXmlDocument(schemaReader, dataReader);

        //    int count = networkXmlDocument.DocumentElement.ChildNodes.Count;

        //    Assert.AreEqual(2, count, "The child count of the document element should be {0} and not {1}", 2, count);
        //}

        //[DataTestMethod]
        //[DataRow(networkXsdFilename, "")]
        //[DataRow("", networkXmlFilename)]
        //public void ReadXmlDocument_EmptyFilename_ThrowsArgumentException(string xsdFilename, string xmlFilename)
        //{
        //    DumpstersDatabaseReader networkReader = new DumpstersDatabaseReader();

        //    Action action = () => networkReader.ReadXmlDocument(xsdFilename, xmlFilename);

        //    Assert.ThrowsException<ArgumentException>(action, "Should throw ArgumentException on empty filenames");
        //}

        //[TestMethod]
        //public void ReadNodes_NetworkXmlFile_Returns3Nodes()
        //{
        //    DumpstersDatabaseReader networkReader = new DumpstersDatabaseReader();

        //    XmlDocument networkXmlDocument = networkReader.ReadXmlDocument(networkXsdFilename, networkXmlFilename);

        //    int count = DumpstersDatabaseReader.ReadNodes(networkXmlDocument).Count;

        //    Assert.AreEqual(3, count, "Node count should be {0} and not {1}", 3, count);
        //}

        //[TestMethod]
        //public void ReadLinks_NetworkXmlFile_Returns2Links()
        //{
        //    DumpstersDatabaseReader networkReader = new DumpstersDatabaseReader();

        //    XmlDocument networkXmlDocument = networkReader.ReadXmlDocument(networkXsdFilename, networkXmlFilename);

        //    IList<Node> nodes = this.CreateDefaultFilesNodeList();

        //    int count = DumpstersDatabaseReader.ReadLinks(networkXmlDocument, nodes).Count;

        //    Assert.AreEqual(2, count, "Link count should be {0} and not {1}", 2, count);
        //}

        //private IList<Node> CreateDefaultFilesNodeList()
        //{
        //    return new Node[] { new Node("node1", new Point(0, 0)), new Node("node2", new Point(1, 1)), new Node("node3", new Point(0, 1)) };
        //}
    }
}
