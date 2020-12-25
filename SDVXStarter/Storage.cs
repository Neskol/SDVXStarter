﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDVXStarter
{
    /// <summary>
    /// Interface of Memory / Storage
    /// </summary>
    interface Storage
    {
        /// <summary>
        /// Updates cardSet, pcbidSet, urlSet and viewPathSet
        /// </summary>
        /// <param name="cardSet">card set in view</param>
        /// <param name="pcbidSet">pcbid set in view</param>
        /// <param name="urlSet">url set in view</param>
        /// <param name="viewPathSet">path set in view</param>
         void IntakeViewValue(List<string> cardSet, List<string> pcbidSet, List<string> urlSet, List<string> viewPathSet);

        /// <summary>
        /// Return this.CardSet
        /// </summary>
         List<string> GetCardSet();

        /// <summary>
        /// Return this.UrlSet
        /// </summary>
         List<string> GetUrlSet();

        /// <summary>
        /// Return this.pcbidSet
        /// </summary>
         List<string> GetPCBIDSet();

        /// <summary>
        /// Return this.viewPathSet
        /// </summary>
         List<string> GetViewPathSet();

        /// <summary>
        /// Set storage to its initial value.
        /// </summary>
        void Clear();

        /// <summary>
        /// Saves the storage value to Xml File.
        /// </summary>
        void Save();

        /// <summary>
        /// Saves the storage to given path.
        /// </summary>
        /// <param name="path">path to save the configuration</param>
        void Save(string path);

        /// <summary>
        /// Replaces the storage with given XML in path.
        /// </summary>
        /// <param name="path">path to load the configuration.</param>
        void ReplaceWith(string path);

        /// <summary>
        /// Return the version set for operation.
        /// </summary>
        /// <returns>
        /// this.versionSet.
        /// </returns>
        Dictionary<string, string> GetVerSet();

        /// <summary>
        /// Return the path set for operation.
        /// </summary>
        /// <returns>this.pathSet</returns>
        Dictionary<string, string> GetPathSet();

        /// <summary>
        /// Add map to versionSet and pathSet.
        /// </summary>
        /// <param name="note">version user noted</param>
        /// <param name="path">path this game located</param>
        void AddVerPathMap(string note, string path);

        /// <summary>
        /// Removes the version in map specified.
        /// </summary>
        /// <param name="note">note to find</param>
        /// <returns>True if removed, false otherwise.</returns>
        bool RemoveVerPathMap(string note);

        /// <summary>
        /// Add config for arguments.
        /// </summary>
        /// <param name="item">Item to add</param>
        /// <param name="set">Status to add</param>
        /// <param name="value">Specific value to add</param>
        void AddConfigMap(string item, bool set, string value);

        /// <summary>
        /// Get version of given path.
        /// </summary>
        /// <param name="path">
        /// path to find</param>
        /// <returns>
        /// this.version</returns>
        string GetVersion(string path);


        /// <summary>
        /// Get path of given version.
        /// </summary>
        /// <param name="version">
        /// version to find</param>
        /// <returns>
        /// this.path</returns>
        string GetPath(string version);

        /// <summary>
        /// Return the setting of given name
        /// </summary>
        /// <param name="name">The item name</param>
        /// <returns>The setting of given item</returns>
        bool GetCfgSet(string name);

        /// <summary>
        /// Returns the setting value of given item
        /// </summary>
        /// <param name="name">The item name</param>
        /// <returns>The setting value of given name</returns>
        string GetCfgValue(string name);

        /// <summary>
        /// Return composited argument to run.
        /// </summary>
        /// <returns>
        /// each in this.argument
        /// </returns>
        string GetArgument();

        /// <summary>
        /// Return Argument List for saving
        /// </summary>
        /// <returns>Argument List</returns>
        List<string> ReturnArgument();

        /// <summary>
        /// Updates argument to match user choises in pannel.
        /// </summary>
        /// <changes>this.argument</changes>
        void UpdateArgument();

        /// <summary>
        /// Updates all settings to match user choises in pannel.
        /// </summary>
        /// <param name="configSet">User checks</param>
        /// <param name="valueSet">User inputs</param>
        void Update(Dictionary<string, bool>configSet, Dictionary<string, string>valueSet);

        /// <summary>
        /// Returns value matched with given key
        /// </summary>
        /// <param name="mapName">Map that to find</param>
        /// <param name="key">Key to specify</param>
        /// <returns>Value matched with given key</returns>
        string GetValue(Dictionary<string,string> mapName, string key);

        /// <summary>
        /// Return requiring dictionary.
        /// </summary>
        /// <param name="name">Name to find</param>
        /// <returns>Dictionary that matches</returns>
        Dictionary<string, string> GetMap(string name);

        /// <summary>
        /// Return this.configSet.
        /// </summary>
        /// <returns>Return this.configSet</returns>
        Dictionary<string, bool> GetCfgMap();

        /// <summary>
        /// Find if given set already has value as key.
        /// </summary>
        /// <param name="set">Set specified</param>
        /// <param name="key">Key to verify</param>
        /// <returns></returns>
        bool FindKeyDuplicate(Dictionary<string, string> set, string key);
    }
}
