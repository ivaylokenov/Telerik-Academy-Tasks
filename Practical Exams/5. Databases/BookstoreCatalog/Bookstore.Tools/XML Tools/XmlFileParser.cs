namespace Bookstore.Tools.XMLTools
{
    using System;
    using System.Xml;

    public class XMLFileParser
    {
        protected XmlDocument Document { get; private set; }

        public XMLFileParser()
        {
            this.Document = new XmlDocument();
        }
    }
}
