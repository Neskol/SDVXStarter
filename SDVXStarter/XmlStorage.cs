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
            configStorage.Load(saving);
        }

        /// <summary>
        /// Construct an xml storage of global storage
        /// </summary>
        /// <param name="globalStorage">Global storage to construct</param>
        public XmlStorage(Storage globalStorage)
        {
            path = "cfg.xml";
            localStorage = globalStorage;
            configStorage = new XmlDocument();
        }

        /// <summary>
        /// Construct an xml to load other 
        /// </summary>
        public XmlStorage()
        {
            path = "cfg.xml";
            localStorage = new Storage1L();
            configStorage = new XmlDocument();
        }

        /// <summary>
        /// Updates configStorage 
        /// </summary>
        public void ConstructCfgStorage()
        {
            XmlDeclaration xmlDecl = configStorage.CreateXmlDeclaration("1.0", "utf-8", null);
            configStorage.AppendChild(xmlDecl);
            XmlElement root = configStorage.CreateElement("SDVXStarter");
            configStorage.AppendChild(root);
            XmlElement verPathSet = configStorage.CreateElement("VerPath");
            /// Add elements in verPathSet
            root.AppendChild(verPathSet);
            foreach(string x in localStorage.GetVerSet().Values)
            {
                XmlElement pair = configStorage.CreateElement("Pair");
                pair.InnerText = x;
                XmlAttribute ver = configStorage.CreateAttribute("version");
                ver.Value = localStorage.GetVersion(x);
                pair.Attributes.Append(ver);
                verPathSet.AppendChild(pair);
            }
            XmlElement cardSet = configStorage.CreateElement("CardSet");
            root.AppendChild(cardSet);
            /// Add elements in cardSet
            foreach (string x in localStorage.GetCardSet())
            {
                XmlElement card = configStorage.CreateElement("Card");
                card.InnerText = x;
                cardSet.AppendChild(card);
            }
            XmlElement pcbidSet = configStorage.CreateElement("PCBIDSet");
            root.AppendChild(pcbidSet);
            /// Add elements in pcbidSet
            foreach (string x in localStorage.GetPCBIDSet())
            {
                XmlElement id = configStorage.CreateElement("PCBID");
                id.InnerText = x;
                pcbidSet.AppendChild(id);
            }
            XmlElement urlSet = configStorage.CreateElement("URLSet");
            root.AppendChild(urlSet);
            /// Add elements in urlSet
            foreach (string x in localStorage.GetUrlSet())
            {
                XmlElement url = configStorage.CreateElement("URL");
                url.InnerText = x;
                urlSet.AppendChild(url);
            }
            XmlElement cfgSet = configStorage.CreateElement("UserConfigSet");
            root.AppendChild(cfgSet);
            /// Add elements in configSet
            foreach (KeyValuePair<string,bool> x in localStorage.GetCfgMap())
            {
                XmlElement pair = configStorage.CreateElement(x.Key);
                pair.InnerText = x.Value.ToString();
                cfgSet.AppendChild(pair);
            }
            XmlElement lastSet = configStorage.CreateElement("DefaultSetting");
            root.AppendChild(lastSet);
            /// Add elements in lastSet
            foreach (string x in localStorage.ReturnArgument())
            {
                XmlElement argument = configStorage.CreateElement("Argument");
                argument.InnerText = x;
                lastSet.AppendChild(argument);
            }
        }

        public void AppendChild(XmlNode node, XmlNode child)
        {
            node.AppendChild(child);
        }

        public bool CheckValidity()
        {
            return true;
        }

        public XmlDocument CreateXml(string inputs)
        {
            XmlDocument result = new XmlDocument();
            result.LoadXml(path);
            return result;
        }

        public string GetValue(XmlNode name)
        {
            return name.InnerText;
        }

        public XmlDocument LoadXml(string path)
        {
            XmlDocument result = new XmlDocument();
            result.Load(path);
            return result;
        }

        public void SaveXml(string path)
        {
            configStorage.Save(path);
        }

        public void Update()
        {

        }
    }
}
