using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static SDVXStarter.Ultilities;

namespace SDVXStarter
{
    /// <summary>
    /// Load language settings by xml file
    /// </summary>
    public class LanguageStorage : IXmlUltility
    {
        private XmlDocument languageSet;

        /// <summary>
        /// Construct an deafult English version
        /// </summary>
        public LanguageStorage()
        {

        }

        public void AppendChild(XmlNode node, XmlNode child)
        {
            node.AppendChild(child);
        }

        public bool CheckValidity()
        {
            throw new NotImplementedException();
        }

        public XmlDocument CreateXml(string inputs)
        {
            XmlDocument created = new XmlDocument();
            created.LoadXml(inputs);
            return created;
        }

        public string GetAttribute(XmlNode name, string attrName)
        {
            return ((XmlElement)name).GetAttribute(attrName);
        }

        public string GetValue(XmlNode name)
        {
            return name.InnerText;
        }

        public XmlDocument LoadXml(string path)
        {
            XmlDocument loaded = new XmlDocument();
            loaded.Load(path);
            return loaded;
        }

        public void SaveXml(string path)
        {
            this.languageSet.Save(path);
        }

        public void UpdateStorage()
        {
            throw new NotImplementedException();
        }
    }
}
