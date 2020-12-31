using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDVXStarter
{
    /// <summary>
    /// Defines methods used in Input form
    /// </summary>
    interface InputFormMethods
    {
        /// <summary>
        /// Set this.title to given title
        /// </summary>
        /// <param name="title">title to set</param>
        void SetTitle(string title);

        /// <summary>
        /// Set this.hint to given title
        /// </summary>
        /// <param name="title">hint to set</param>
        void SetHint(string hint);

        /// <summary>
        /// Verify if the user entered correct value
        /// </summary>
        /// <returns>True if valid, false elsewise</returns>
        bool Verify();

        /// <summary>
        /// Load items for selecting
        /// </summary>
        /// <param name="preElements">Items to load</param>
        void SetElements(List<string> preElements);

        /// <summary>
        /// Load items for selecting
        /// </summary>
        /// <param name="preElements">Items to load</param>
        void SetElements(ComboBox.ObjectCollection preElements);

        /// <summary>
        /// Load items for selecting
        /// </summary>
        /// <param name="preElements">Items to load</param>
        void SetElements(Dictionary<string, string>.ValueCollection preElements);

            /// <summary>
            /// Return all items in window
            /// </summary>
            /// <returns>All elements in window</returns>
            List<string> GetElements();
    }
}
