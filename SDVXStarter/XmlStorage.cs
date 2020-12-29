using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SDVXStarter
{
    class XmlStorage : IXmlUltility
    {
        private string path;
        private IStorage localStorage;
        private XmlDocument configStorage;

        /// <summary>
        /// Saves storage into Xml file.
        /// </summary>
        /// <param name="globalStorage">storage that contains all values.</param>
        /// <param name="saving">place to save </param>
        public XmlStorage(IStorage globalStorage, string saving)
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
        public XmlStorage(IStorage globalStorage)
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
                XmlAttribute ver = configStorage.CreateAttribute("Version");
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
                XmlElement pair = configStorage.CreateElement("Pair");
                pair.InnerText = x.Value.ToString();
                XmlAttribute set = configStorage.CreateAttribute("Set");
                set.Value = x.Key;
                pair.Attributes.Append(set);
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
            return (localStorage != null)&&localStorage.CheckValidity()&&(configStorage.SelectSingleNode("SDVXStarter")!=null);
        }

        public XmlDocument CreateXml(string inputs)
        {
            XmlDocument result = new XmlDocument();
            result.LoadXml(inputs);
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
            this.configStorage = result;
            UpdateStorage();
            return result;
        }

        public void SaveXml(string path)
        {
            configStorage.Save(path);
        }

        public void UpdateStorage()
        {
            if (this.CheckValidity())
            {
                Dictionary<string, string> verPathSet = new Dictionary<string, string>();
                Dictionary<string, bool> configSet = new Dictionary<string, bool>();
                List<string> argumentSet = new List<string>();
                List<string> cardSet = new List<string>();
                List<string> pcbidSet = new List<string>();
                List<string> urlSet = new List<string>();
                List<string> pathSet = new List<string>();

                XmlNodeList verPathNodes = configStorage.SelectSingleNode("SDVXStarter/VerPath").ChildNodes;
                XmlNodeList configNodes = configStorage.SelectSingleNode("SDVXStarter/UserConfigSet").ChildNodes;
                XmlNodeList cardNodes = configStorage.SelectSingleNode("SDVXStarter/CardSet").ChildNodes;
                XmlNodeList pcbidNodes = configStorage.SelectSingleNode("SDVXStarter/PCBIDSet").ChildNodes;
                XmlNodeList urlNodes = configStorage.SelectSingleNode("SDVXStarter/URLSet").ChildNodes;
                XmlNodeList argumentNodes = configStorage.SelectSingleNode("SDVXStarter/DefaultSetting").ChildNodes;

                // Updates verPathSet
                foreach (XmlNode pair in verPathNodes)
                {
                    if (pair.Attributes != null && !pair.InnerText.Equals("") && !localStorage.FindKeyDuplicate(verPathSet, ((XmlElement)pair).GetAttribute("Version")))
                    {
                        verPathSet.Add(((XmlElement)pair).GetAttribute("Version"), pair.InnerText);
                    }
                }
                // Updates configSet
                foreach (XmlNode pair in configNodes)
                {
                    if (pair.Attributes != null && !pair.InnerText.Equals("") && !localStorage.FindKeyDuplicate(configSet, ((XmlElement)pair).GetAttribute("Set")))
                    {
                        bool set = pair.InnerText.Equals("true");
                        configSet.Add(((XmlElement)pair).GetAttribute("Set"), set);
                    }
                }
                // Updates argument
                foreach (XmlNode argument in argumentNodes)
                {
                    if (!argument.InnerText.Equals(""))
                    {
                        argumentSet.Add(argument.InnerText);
                    }
                }
                // Updates PCBID
                foreach (XmlNode pcbid in pcbidNodes)
                {
                    if (!pcbid.InnerText.Equals(""))
                    {
                        pcbidSet.Add(pcbid.InnerText);
                    }
                }
                // Updates URL
                foreach (XmlNode url in urlNodes)
                {
                    if (!url.InnerText.Equals(""))
                    {
                        urlSet.Add(url.InnerText);
                    }
                }
                // Updates card
                foreach (XmlNode card in cardNodes)
                {
                    if (!card.InnerText.Equals(""))
                    {
                        cardSet.Add(card.InnerText);
                    }
                }
                IStorage importedStorage = new Storage1L();
                // Updates importedStorage's verPathSet
                foreach (KeyValuePair<string, string> x in verPathSet)
                {
                    importedStorage.AddVerPathMap(x.Key, x.Value);
                }
                // Updates importedStorage's configSet
                foreach (KeyValuePair<string, bool> x in configSet)
                {
                    importedStorage.AddConfigSetMap(x.Key, x.Value);
                }
                // Updates importedStorage's lists.
                foreach (string path in verPathSet.Values)
                {
                    pathSet.Add(path);
                }
                //Updates importedStorage's argument
                importedStorage.UpdateArgument(argumentSet);
                importedStorage.IntakeValue(cardSet, pcbidSet, urlSet, pathSet);
                this.localStorage = importedStorage;
            }
        }

        /// <summary>
        /// Get and set localStorage
        /// </summary>
        public IStorage LocalStorage
        {
            get
            {
                return this.localStorage;
            }
            set
            {
                this.localStorage = value;
            }
        }

        public string GetAttribute(XmlNode name, string attrName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get and set this.configStorage
        /// </summary>
        public XmlDocument ConfigStorage
        {
            get
            {
                return this.configStorage;
            }
            set
            {
                this.configStorage = value;
            }
        }

        /// <summary>
        /// Get and set this.path
        /// </summary>
        public string Path
        {
            get
            {
                return this.path;
            }
            set
            {
                this.path = value;
            }
        }
    }
}
