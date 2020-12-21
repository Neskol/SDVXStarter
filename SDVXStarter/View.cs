using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDVXStatrter
{
    /// <summary>
    /// Interface of View Element;
    /// </summary>
    interface View
    {
        /// <summary>
        /// Acts when Form1 is loaded.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        void Form1_Load(object sender, EventArgs e);

        /// <summary>
        /// Perform card number generation.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        void bGenerate_Click(object sender, EventArgs e);

        /// <summary>
        /// Perform card number verification.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        void bCardVerify_Click(object sender, EventArgs e);

        /// <summary>
        /// Perform SDVX path verification.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        void bPathVerify_Click(object sender, EventArgs e);

        /// <summary>
        /// Perform directory browse operation.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        void bBrowse_Click(object sender, EventArgs e);

        /// <summary>
        /// Start spice.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        void bStarter_Click(object sender, EventArgs e);

        /// <summary>
        /// Start spice64.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        void bStarter64_Click(object sender, EventArgs e);

        /// <summary>
        /// Perform version selection.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        void versionCombo_SelectedIndexChanged(object sender, EventArgs e);

        /// <summary>
        /// Perform card selection.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        void cardCombo_SelectedIndexChanged(object sender, EventArgs e);

        /// <summary>
        /// Perform URL selection.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        void urlCombo_SelectedIndexChanged(object sender, EventArgs e);

        /// <summary>
        /// Perform PCBID selection.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        void pcbidCombo_SelectedIndexChanged(object sender, EventArgs e);

        /// <summary>
        /// Packages all settings and Update sets for argument
        /// </summary>
        void packageAndUpdate();

        /// <summary>
        /// Find if added string is already in given array.
        /// </summary>
        /// <param name="array">List to find</param>
        /// <param name="name">Item to find</param>
        /// <returns></returns>
        bool FindDuplicate(ComboBox.ObjectCollection array, string name);
    }
}
