using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDVXStarter;

namespace SDVXStatrter
{
    /// <summary>
    /// Interface of SDVXView Element;
    /// </summary>
    interface SDVXView
    {
        /// <summary>
        /// Packages all settings and UpdateStorage sets for argument
        /// </summary>
        void PackageAndUpdate();

        /// <summary>
        /// Find if added string is already in given array.
        /// </summary>
        /// <param name="array">List to find</param>
        /// <param name="name">Item to find</param>
        /// <returns></returns>
        bool FindDuplicate(ComboBox.ObjectCollection array, string name);

        /// <summary>
        /// Returns the Disk Name of given path.
        /// </summary>
        /// <param name="path">Path to find</param>
        /// <returns>path.DiskName</returns>
        string GetDiskName(string path);

        /// <summary>
        /// Resets the user interface to initial looking.
        /// </summary>
        void RefreshView();

        /// <summary>
        /// Resets the user interface to given storage's value.
        /// </summary>
        /// <param name="newStorage">Storage to read</param>
        void RefreshView(XmlStorage newStorage);

        /// <summary>
        /// Resets the storage to its initial value.
        /// </summary>
        void RefreshStorage();

        /// <summary>
        /// Updates the view to match the storage
        /// </summary>
        void UpdateView(Storage stroage);
    }
}
