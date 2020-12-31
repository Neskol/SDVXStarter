using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDVXStarter
{
    /// <summary>
    /// Invokes user input interface.
    /// </summary>
    public static class InputMediate
    {
        /// <summary>
        /// Invokes user input form which has specified title and hint.
        /// </summary>
        /// <param name="title">Title to set</param>
        /// <param name="hint">Hint to set</param>
        /// <param name="preloadItems">Items to load</param>
        /// <param name="strText">Output text</param>
        /// <returns></returns>
        public static DialogResult Show(string title, string hint, List<string> preloadItems, out string strText)
        {
            string strTemp = string.Empty;

            UserInputCombo inputDialog = new UserInputCombo();
            inputDialog.SetTitle(title);
            inputDialog.SetHint(hint);
            inputDialog.SetElements(preloadItems);
            inputDialog.TextHandler = (str) => { strTemp = str; };

            DialogResult result = inputDialog.ShowDialog();
            strText = strTemp;

            return result;
        }

        /// <summary>
        /// Invokes user input form which has specified title and hint.
        /// </summary>
        /// <param name="title">Title to set</param>
        /// <param name="hint">Hint to set</param>
        /// <param name="preloadItems">Items to load</param>
        /// <param name="strText">Output text</param>
        /// <returns></returns>
        public static DialogResult Show(string title, string hint, ComboBox.ObjectCollection preloadItems, out string strText)
        {
            string strTemp = string.Empty;

            UserInputCombo inputDialog = new UserInputCombo();
            inputDialog.SetTitle(title);
            inputDialog.SetHint(hint);
            inputDialog.SetElements(preloadItems);
            inputDialog.TextHandler = (str) => { strTemp = str; };

            DialogResult result = inputDialog.ShowDialog();
            strText = strTemp;

            return result;
        }

        /// <summary>
        /// Invokes user input form which has specified title and hint.
        /// </summary>
        /// <param name="title">Title to set</param>
        /// <param name="hint">Hint to set</param>
        /// <param name="preloadItems">Items to load</param>
        /// <param name="strText">Output text</param>
        /// <returns></returns>
        public static DialogResult Show(string title, string hint, Dictionary<string, string>.ValueCollection preloadItems, out string strText)
        {
            string strTemp = string.Empty;

            UserInputCombo inputDialog = new UserInputCombo();
            inputDialog.SetTitle(title);
            inputDialog.SetHint(hint);
            inputDialog.SetElements(preloadItems);
            inputDialog.TextHandler = (str) => { strTemp = str; };

            DialogResult result = inputDialog.ShowDialog();
            strText = strTemp;

            return result;
        }

        /// <summary>
        /// Invokes user input form which has specified title and hint.
        /// </summary>
        /// <param name="title">Title to show</param>
        /// <param name="hint">Hint to show</param>
        /// <param name="strText">Output string</param>
        /// <returns></returns>
        public static DialogResult Show(string title, string hint, out string strText)
        {
            string strTemp = string.Empty;

            UserInputCombo inputDialog = new UserInputCombo();
            inputDialog.SetTitle(title);
            inputDialog.SetHint(hint);
            inputDialog.TextHandler = (str) => { strTemp = str; };

            DialogResult result = inputDialog.ShowDialog();
            strText = strTemp;

            return result;
        }

        /// <summary>
        /// Invokes user input form which has specified title and hint.
        /// </summary>
        /// <param name="isMass">Indicates if is creating a mass input</param>
        /// <param name="title">Title to show</param>
        /// <param name="hint">Hint to show</param>
        /// <param name="strText">Output string</param>
        /// <returns></returns>
        public static DialogResult Show(bool isMass, string title, string hint, out string strText)
        {
            if (isMass)
            {
                string strTemp = string.Empty;

                UserMassInput inputDialog = new UserMassInput();
                inputDialog.SetTitle(title);
                inputDialog.SetHint(hint);
                inputDialog.TextHandler = (str) => { strTemp = str; };

                DialogResult result = inputDialog.ShowDialog();
                strText = strTemp;

                return result;
            }
            else
            {
                string strTemp = string.Empty;

                UserInputCombo inputDialog = new UserInputCombo();
                inputDialog.SetTitle(title);
                inputDialog.SetHint(hint);
                inputDialog.TextHandler = (str) => { strTemp = str; };

                DialogResult result = inputDialog.ShowDialog();
                strText = strTemp;

                return result;
            }
            
        }
    }
}
