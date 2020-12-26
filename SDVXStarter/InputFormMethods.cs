using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        void GetTitle(string title);

        /// <summary>
        /// Set this.hint to given title
        /// </summary>
        /// <param name="title">hint to set</param>
        void GetHint(string hint);

        /// <summary>
        /// Verify if the user entered correct value
        /// </summary>
        /// <returns>True if valid, false elsewise</returns>
        bool Verify();
    }
}
