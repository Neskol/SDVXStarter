using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDVXStarter
{
    /// <summary>
    /// Creates a multiple line input box for input.
    /// </summary>
    public partial class UserMassInput : Form, InputFormMethods
    {
        public delegate void TextEventHandler(string strText);

        public TextEventHandler TextHandler;

        public UserMassInput()
        {
            InitializeComponent();
        }

        public List<string> GetElements()
        {
            List<string> result = new List<string>();
            result.Add(this.inputBox.Text);
            return result;
        }

        public void SetElements(List<string> preElements)
        {
            foreach(string x in preElements)
            {
                this.inputBox.Text += (x + "\n");
            }
        }

        public void SetElements(ComboBox.ObjectCollection preElements)
        {
            foreach (string x in preElements)
            {
                this.inputBox.Text += (x + "\n");
            }
        }

        public void SetElements(Dictionary<string, string>.ValueCollection preElements)
        {
            foreach (string x in preElements)
            {
                this.inputBox.Text += (x + "\n");
            }
        }

        public void SetHint(string hint)
        {
            this.hintLabel.Text = hint;
        }

        public void SetTitle(string title)
        {
            this.Text = title;
        }

        public bool Verify()
        {
            return !this.inputBox.Text.Equals("");
        }

        private void bConfirm_Click(object sender, EventArgs e)
        {
            if (null != TextHandler)
            {
                TextHandler.Invoke(inputBox.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
