using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace SDVXStarter
{
    /// <summary>
    /// Construct a XMLDocument for EA3 Complier.
    /// </summary>
    public class EA3Compiler : IXmlUltility
    {
        private XmlDocument ea3Config;
        private string version;
        private string pcbid;
        private string services;
        private string urlSlash;
        XmlNode model, dest, spec, rev, ext;
        XmlNode idX;
        XmlNode servicesX;
        XmlNode urlSlashX;

       /// <summary>
       /// Construct compiler from given path.
       /// </summary>
       /// <param name="path">Path to load</param>
        public EA3Compiler(string path)
        {
            this.ea3Config = new XmlDocument();
            this.ea3Config.Load(path);
            this.model = this.ea3Config.SelectSingleNode("ea3/soft/model");
            this.dest = this.ea3Config.SelectSingleNode("ea3/soft/dest");
            this.spec = this.ea3Config.SelectSingleNode("ea3/soft/spec");
            this.rev = this.ea3Config.SelectSingleNode("ea3/soft/rev");
            this.ext = this.ea3Config.SelectSingleNode("ea3/soft/ext");
            this.idX = this.ea3Config.SelectSingleNode("ea3/id/pcbid");
            this.servicesX = this.ea3Config.SelectSingleNode("ea3/network/services");
            this.urlSlashX = this.ea3Config.SelectSingleNode("ea3/network/url_slash");
            if (CheckValidity())
            {
                UpdateStorage();
            }
        }

        /// <summary>
        /// Construct EA3Compiler either from a file or a segment of text: True to construct from text, false to constructe from file.
        /// </summary>
        /// <param name="intake">Text to process</param>
        /// <param name="isText"></param>
        public EA3Compiler(string intake, bool isText)
        {
            if (isText)
            {
                throw new NotImplementedException();
                this.ea3Config = new XmlDocument();
                StreamReader input = new StreamReader(@"<?xml version=""1.0"" encoding=""utf-8"" ?><pcbid>01203D6C56B1FE8D60A4</pcbid>
<url_slash __type=""bool"">1</url_slash><services>http://eamu.bemanicn.com</services>");
                XmlReader xmlIn = XmlReader.Create(input);
                while (xmlIn.Read())
                {
                    if (xmlIn.Name.Equals("pcbid"))
                    {
                        this.PCBID = xmlIn.Value;
                    }
                    else if (xmlIn.Name.Equals("service"))
                    {
                        this.Services = xmlIn.Value;
                    }
                    else if (xmlIn.Name.Equals("url_slash"))
                    {
                        this.UrlSlash = xmlIn.Value;
                    }
                }
                UpdateByRuntime();
                if (CheckValidity())
                {
                    UpdateStorage();
                }
            }
            else
            {
                this.ea3Config = new XmlDocument();
                this.ea3Config.Load(intake);
                this.model = this.ea3Config.SelectSingleNode("ea3/soft/model");
                this.dest = this.ea3Config.SelectSingleNode("ea3/soft/dest");
                this.spec = this.ea3Config.SelectSingleNode("ea3/soft/spec");
                this.rev = this.ea3Config.SelectSingleNode("ea3/soft/rev");
                this.ext = this.ea3Config.SelectSingleNode("ea3/soft/ext");
                this.idX = this.ea3Config.SelectSingleNode("ea3/id/pcbid");
                this.servicesX = this.ea3Config.SelectSingleNode("ea3/network/services");
                this.urlSlashX = this.ea3Config.SelectSingleNode("ea3/network/url_slash");
                if (CheckValidity())
                {
                    UpdateStorage();
                }
            }
        }

        public string GetAttribute(XmlNode name, string attrName)
        {
            throw new NotImplementedException();
        }

        public void UpdateStorage()
        {
            this.version = this.ComposeVersion();
            this.pcbid = this.idX.InnerText;
            this.services = this.servicesX.InnerText;
            this.urlSlash = this.urlSlashX.Attributes.ToString();
        }

        /// <summary>
        /// UpdateStorage ea3-config.xml by runtime variable.
        /// </summary>
        public void UpdateByRuntime()
        {
            string[] verR = DecomposeVersion(this.Version);
            this.model.InnerText = verR[0];
            this.dest.InnerText = verR[1];
            this.spec.InnerText = verR[2];
            this.rev.InnerText = verR[3];
            this.ext.InnerText = verR[4];
            this.idX.InnerText = this.PCBID;
            this.servicesX.InnerText = this.Services;
            this.urlSlashX.InnerText = this.UrlSlash;
        }

        /**
         * Accessors defined.
         * @contains
         *      this.version
         *      this.pcbid
         *      this.services
         *      this.urlSlash
         * @ensures
         *      this.attributeReturned = this.attributeValue
         */

        /// <summary>
        /// Composes version text in nodes.
        /// </summary>
        public string ComposeVersion()
        {
            string result = "";

            result = this.model.InnerText + ":"
                + this.dest.InnerText + ":"
                + this.spec.InnerText + ":"
                + this.rev.InnerText + ":"
                + this.ext.InnerText;

            return result;
        }

        /// <summary>
        /// Decomposes version text to arrays for nodes to UpdateStorage.
        /// </summary>
        /// <param name="version">
        /// Intake version text
        /// </param>
        /// <returns>
        /// An array contains version data in "model-dest-spec-rev-ext" order
        /// </returns>
        public string[] DecomposeVersion(string version)
        {
            return this.version.Split(':');
        }

        /// <summary>
        /// Contains PCBID.
        /// </summary>
        public string PCBID
        {
            get
            {
                return this.pcbid;
            }
            set
            {
                this.pcbid = value;
            }
        }

        /// <summary>
        /// Contains Version.
        /// </summary>
        public string Version
        {
            get
            {
                return this.version;
            }
            set
            {
                this.version = value;
            }
        }

        /// <summary>
        /// Contains URL.
        /// </summary>
        public string Services
        {
            get
            {
                return this.services;
            }
            set
            {
                this.services = value;
            }
        }

        /// <summary>
        /// Contains UrlSlash.
        /// </summary>
        public string UrlSlash
        {
            get
            {
                return this.urlSlash;
            }
            set
            {
                this.urlSlash = value;
            }
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

        public void AppendChild(XmlNode node, XmlNode child)
        {
            node.AppendChild(child);
        }

        public XmlDocument LoadXml(string path)
        {
            XmlDocument result = new XmlDocument();
            result.Load(path);
            return result;
        }

        public void SaveXml(string path)
        {
            this.UpdateByRuntime();
            this.ea3Config.Save(path);
        }

        public bool CheckValidity()
        {
            bool result = false;

            result = (this.ea3Config != null) && (this.idX != null) && (this.servicesX != null) && (this.urlSlashX != null);

            return result;
        }
    }
}
