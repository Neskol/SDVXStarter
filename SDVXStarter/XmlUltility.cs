﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SDVXStarter
{
    /// <summary>
    /// Processes the Xml Functions
    /// </summary>
    interface XmlUltility
    {
        /// <summary>
        /// Updates the storage.
        /// </summary>
        void Update();

        /// <summary>
        /// Creates and return a new XmlDocument: loadxml
        /// </summary>
        /// <param name="inputs">The input string</param>
        /// <returns></returns>
        XmlDocument CreateXml(string inputs);

        /// <summary>
        /// Loads xml file from given path.
        /// </summary>
        /// <param name="path">Path to load xml file</param>
        /// <returns></returns>
        XmlDocument LoadXml(string path);

        /// <summary>
        /// Saves xml to given path.
        /// </summary>
        /// <param name="path">Path to save xml.</param>
        void SaveXml(string path);

        /// <summary>
        /// Return the inner text inside given node
        /// </summary>
        /// <param name="name">Node to find</param>
        /// <returns>name.InnerText</returns>
        string GetValue(XmlNode name);
      
        /// <summary>
        /// Append child to node.
        /// </summary>
        /// <param name="node">node to append</param>
        /// <param name="child">child to append</param>
        void AppendChild(XmlNode node, XmlNode child);
    }
}
