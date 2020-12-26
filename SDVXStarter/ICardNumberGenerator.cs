using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDVXStarter
{
    /// <summary>
    /// Interface for ICardNumberGenerator.
    /// </summary>
    interface ICardNumberGenerator
    {
        ///<summary>
        ///Returns a valid card number.
        ///</summary>
        ///<returns>a 16-char card number that valid for e-amuse informat of "E004XXXXXXXXXXXX"</returns>
        string Generate();

        /// <summary>
        /// Verify if given card number is valid.
        /// </summary>
        /// <returns>True if the card number matches, false elsewise</returns>
        bool Verify(string cardNumber);
    }
}
