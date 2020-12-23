using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDVXStarter
{
    /// <summary>
    /// Implementation of Memory / Storage.
    /// </summary>
    public class Storage1L : Storage
    {
        private Dictionary<string, string> versionSet;
        private Dictionary<string, string> pathSet;
        private Dictionary<string, string> valueSet;
        private Dictionary<string, bool> configSet;
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
            argument = new List<string>();
            this.AddVerPathMap("Root SDVX", "(root path)");
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
            this.versionSet.Add(note, path);
            this.pathSet.Add(path, note);
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

        public void AddConfigMap(string item, bool set, string value)
        {
            this.configSet.Add(item, set);
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
            if (path.Equals("(root path)")||path.Equals(""))
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
            if (this.GetCfgSet("hd"))
            {
                this.argument.Add("-sdvx720p");
            }           
            else
            { this.argument.Add("-sdvx");
        }
            if (!this.GetCfgSet("window"))
            {
                this.argument.Add("-w");
            }
            if (this.GetCfgSet("printer"))
            {
                this.argument.Add("-printer");
            }
            if (this.GetCfgSet("urlSlash"))
            {
                this.argument.Add("-urlslash 1");
            }
            if (!this.GetCfgSet("ssl"))
            {
                this.argument.Add("-ssldisable");
            }
            if (!this.GetCfgValue("card").Equals(""))
            {
                this.argument.Add("-card0 "+this.GetCfgValue("card"));
            }
            if (!this.GetCfgValue("url").Equals("")&&!this.GetCfgValue("url").Equals("(Offline)"))
            {
                this.argument.Add("-url " + this.GetCfgValue("url"));
            }
            else
            {
                this.argument.Add("-ea");
            }
            if (!this.GetCfgValue("pcbid").Equals(""))
            {
                this.argument.Add("-p " + this.GetCfgValue("pcbid"));
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
                if (x.Key.Equals(key))
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
            this.versionSet.Add("Root SDVX","");
            this.pathSet.Add("","Root SDVX");
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
    }
}
