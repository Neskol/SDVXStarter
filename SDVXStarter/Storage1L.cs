using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDVXStarter
{
    /// <summary>
    /// Implementation of Memory / IStorage.
    /// </summary>
    public class Storage1L : IStorage
    {
        private Dictionary<string, string> versionSet;
        private Dictionary<string, string> pathSet;
        private Dictionary<string, string> valueSet;
        private Dictionary<string, bool> configSet;
        private List<string> cardSet;
        private List<string> pcbidSet;
        private List<string> urlSet;
        private List<string> viewPathSet;
        private List<string> argument;

        /// <summary>
        /// Initializes Storage1L();
        /// </summary>
        public Storage1L()
        {
            versionSet = new Dictionary<string, string>();
            pathSet = new Dictionary<string, string>();
            configSet = new Dictionary<string, bool>();
            valueSet = new Dictionary<string, string>();
            cardSet = new List<string>();
            pcbidSet = new List<string>();
            urlSet = new List<string>();
            viewPathSet = new List<string>();
            argument = new List<string>();
            this.AddVerPathMap("Root SDVX", "(root path)");
        }

        public void IntakeValue(List<string> cardSet, List<string> pcbidSet, List<string> urlSet, List<string> viewPathSet)
        {
            this.cardSet = cardSet;
            this.pcbidSet = pcbidSet;
            this.urlSet = urlSet;
            this.viewPathSet = viewPathSet;
        }

        /// <summary>
        /// Return this.CardSet
        /// </summary>
        public List<string> GetCardSet()
        {
                return this.cardSet;
        }

        /// <summary>
        /// Return this.UrlSet
        /// </summary>
        public List<string> GetUrlSet()
        {
                return this.urlSet;
        }

        /// <summary>
        /// Return this.pcbidSet
        /// </summary>
        public List<string> GetPCBIDSet()
        {
                return this.pcbidSet;
        }

        /// <summary>
        /// Return this.viewPathSet
        /// </summary>
        public List<string> GetViewPathSet()
        {
                return this.viewPathSet;
        }

        public void ReplaceWith(string path)
        {

        }

        public Dictionary<string, string> GetVerSet()
        {      
            return this.versionSet;
        }

        public Dictionary<string, string> GetPathSet()
        {
            return this.pathSet;
        }

        public void AddVerPathMap(string note, string path)
        {
            if (!FindKeyDuplicate(versionSet,note))
            {
                this.versionSet.Add(note, path);
                if (note.Equals("Root SDVX")||path.Equals(""))
                {
                    this.pathSet.Add("(root path)",note);
                }
                else
                {
                    this.pathSet.Add(path, note);
                }
            }           
        }

        public bool RemoveVerPathMap(string note)
        {
            bool found = this.GetVerSet().TryGetValue(note, out string path);
            if (found)
            {
                this.versionSet.Remove(note);
                this.pathSet.Remove(path);
            }
            return found;
        }

        public void AddConfigSetMap(string item, bool set)
        {
            this.configSet.Add(item, set);
        }

        public void AddConfigValueMap(string item, string value)
        {
            this.valueSet.Add(item, value);
        }

        public string GetVersion(string path)
        {
            string version = "";
            this.pathSet.TryGetValue(path, out version);
            return version;
        }

        public string GetPath(string version)
        {
            string path = "";
            this.versionSet.TryGetValue(version, out path);
            if (path.Equals("(root path)")||version.Equals(""))
            {
                path = "";
            }
            return path;
        }

        public string GetArgument()
        {
            string result = "";

            foreach (string x in this.argument)
            {
                result = result + x + " ";
            }

            return result;
        }

        public void UpdateArgument()
        {
            this.argument.Clear();
            // Updates 720p setting
            if (this.GetCfgSet("hd"))
            {
                this.argument.Add("-sdvx720p");
            }           
            else
            { 
                this.argument.Add("-sdvx");
            }
            // Updates full screen setting
            if (!this.GetCfgSet("window"))
            {
                this.argument.Add("-w");
            }
            // Updates printer setting
            if (this.GetCfgSet("printer"))
            {
                this.argument.Add("-printer");
            }
            // Updates urlSlash setting
            if (this.GetCfgSet("urlSlash"))
            {
                this.argument.Add("-urlslash 1");
            }
            // Updates ssl setting
            if (!this.GetCfgSet("ssl"))
            {
                this.argument.Add("-ssldisable");
            }
            // Updates card setting
            if (!this.GetCfgValue("card").Equals(""))
            {
                this.argument.Add("-card0 "+this.GetCfgValue("card"));
            }
            // Updates url setting
            if (!this.GetCfgValue("url").Equals("")&&!this.GetCfgValue("url").Equals("(Offline)"))
            {
                this.argument.Add("-url " + this.GetCfgValue("url"));
            }
            else
            {
                this.argument.Add("-ea");
            }
            // Updates pcbid setting
            if (!this.GetCfgValue("pcbid").Equals(""))
            {
                this.argument.Add("-p " + this.GetCfgValue("pcbid"));
            }
            // Updates spice companion setting
            if (this.GetCfgSet("api"))
            {
                if (!this.GetCfgValue("apiPort").Equals("")&&!this.GetCfgValue("apiPassword").Equals(""))
                {
                    this.argument.Add("-api "+ this.GetCfgValue("apiPort"));
                    this.argument.Add("-apipass " + this.GetCfgValue("apiPassword"));
                }
            }
        }

        public void Update(Dictionary<string, bool> configSet, Dictionary<string, string> valueSet)
        {
            this.configSet = configSet;
            this.valueSet = valueSet;
            UpdateArgument();
        }

        public string GetValue(Dictionary<string, string> mapName, string key)
        {
            string result = "";

            if (!mapName.TryGetValue(key, out result))
            {
                throw new NullReferenceException();
            }
            else
            {
                return result;
            }
        }

        public bool GetCfgSet(string name)
        {
            bool result = false;
            bool found = false;
            found = this.configSet.TryGetValue(name, out result);

            if (!found)
            {
                throw new NullReferenceException();
            }
            else
            {
                return result;
            }
        }

        public string GetCfgValue(string name)
        {
            bool found;
            found = this.valueSet.TryGetValue(name, out string result);

            if (!found)
            {
                throw new NullReferenceException();
            }
            else
            {
                return result;
            }
        }

        public Dictionary<string, string> GetMap(string name)
        {
            Dictionary<string, string> result;
            if (name.Equals("versionSet")||name.Equals("version"))
            {
                result = this.versionSet;
            }
            else if (name.Equals("pathSet") || name.Equals("path"))
            {
                result = this.pathSet;
            }
            else if(name.Equals("valueSet") || name.Equals("value"))
            {
                result = this.valueSet;
            }
            else
            {
                throw new NullReferenceException();
            }
            return result;
        }

        public Dictionary<string, bool> GetCfgMap()
        {
            return this.configSet;
        }

        public bool FindKeyDuplicate(Dictionary<string, string> set, string key)
        {
            bool result = false;

            foreach (KeyValuePair<string,string> x in set)
            {
                if (x.Key.Equals(key) || x.Key.Equals(key + "\\") || x.Key.Equals(key + "/")) // Incase URL has a slash at the end
                {
                    result = true;
                }
            }

            return result;
        }

        public bool FindKeyDuplicate(Dictionary<string, bool> set, string key)
        {
            bool result = false;

            foreach (KeyValuePair<string, bool> x in set)
            {
                if (x.Key.Equals(key)||x.Key.Equals(key+"\\") || x.Key.Equals(key + "/"))
                {
                    result = true;
                }
            }

            return result;
        }

        public void Clear()
        {
            this.versionSet.Clear();
            this.pathSet.Clear();
            this.versionSet.Add("Root SDVX","(root path)");
            this.pathSet.Add("(root path)","Root SDVX");
            this.configSet.Clear();
            this.valueSet.Clear();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Save(string path)
        {
            throw new NotImplementedException();
        }

        public List<string> ReturnArgument()
        {
            return this.argument;
        }

        /// <summary>
        /// Get and set this.configSet
        /// </summary>
        public Dictionary<string,bool> ConfigSet
        {
            get
            {
                return this.configSet;
            }
            set
            {
                this.configSet = value;
            }
        }

        public bool CheckValidity()
        {
            return (this.pathSet != null)&& (this.versionSet != null) && (this.valueSet != null) && (this.configSet != null)  ;
        }
    }
}
