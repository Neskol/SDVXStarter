using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace SDVXStarter
{
    /// <summary>
    /// Construct a XMLDocument for EA3 Complier.
    /// </summary>
    public class EA3Compiler : XmlUltility
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

        /**
         * Constructor.
         * 
         * <param name="path">
         * The path for ea3-config.xml
         * </param>
         * <require>
         * ea3-config.xml exists and all elements exist
         * </require>
         */
        public EA3Compiler(string path)
        {
            this.ea3Config = new XmlDocument();
            this.ea3Config.Load(path);
            this.model = this.ea3Config.SelectSingleNode("ea3/soft/model");
            this.dest = this.ea3Config.SelectSingleNode("ea3/soft/dest");
            this.spec = this.ea3Config.SelectSingleNode("ea3/soft/spec");
            this.rev = this.ea3Config.SelectSingleNode("ea3/soft/rev");
            this.ext = this.ea3Config.SelectSingleNode("ea3/soft/ext");
            this.version = this.ComposeVersion();

            this.idX = this.ea3Config.SelectSingleNode("ea3/id/pcbid");
            this.pcbid = this.idX.InnerText;

            this.servicesX = this.ea3Config.SelectSingleNode("ea3/network/services");
            this.services = this.servicesX.InnerText;

            this.urlSlashX = this.ea3Config.SelectSingleNode("ea3/network/url_slash");
            this.urlSlash = this.urlSlashX.Attributes.ToString();
        }

        /// <summary>
        /// Update ea3-config.xml by runtime variable.
        /// </summary>
        public void Update()
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
        /// Decomposes version text to arrays for nodes to Update.
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
        private string PCBID
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
        private string Version
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
        private string Services
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
        private string UrlSlash
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
            throw new NotImplementedException();
        }

        public string GetValue(XmlNode name)
        {
            throw new NotImplementedException();
        }

        public void AppendChild(XmlNode node, XmlNode child)
        {
            throw new NotImplementedException();
        }
    }
}
