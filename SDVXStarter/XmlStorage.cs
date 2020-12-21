using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SDVXStarter
{
    class XmlStorage : XmlUltility
    {
        private string path;
        private Storage localStorage;
        private XmlDocument configStorage;

        /// <summary>
        /// Saves storage into Xml file.
        /// </summary>
        /// <param name="globalStorage">storage that contains all values.</param>
        /// <param name="saving">place to save </param>
        public XmlStorage(Storage globalStorage, string saving)
        {
            path = saving;
            localStorage = globalStorage;
            configStorage = new XmlDocument();
        }

        public void AppendChild(XmlNode node, XmlNode child)
        {
            throw new NotImplementedException();
        }

        public XmlDocument CreateXml(string inputs)
        {
            throw new NotImplementedException();
        }

        public string GetValue(XmlNode name)
        {
            throw new NotImplementedException();
        }

        public XmlDocument LoadXml(string path)
        {
            throw new NotImplementedException();
        }

        public void SaveXml(string path)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
