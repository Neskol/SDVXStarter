using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDVXStarter
{
    public partial class UserInputCombo : Form, InputFormMethods
    {
        public UserInputCombo()
        {
            InitializeComponent();
        }

        public void SetHint(string hint)
        {
            this.hintLabel.Text = hint ;
        }

        public void SetTitle(string title)
        {
            this.Text = title;
        }

        public bool Verify()
        {
            this.inputCombo.SelectedItem = this.inputCombo.Text;
            return !this.inputCombo.Text.Equals("");
        }

        private void UserInputCombo_Load(object sender, EventArgs e)
        {

        }

        public delegate void TextEventHandler(string strText);

        public TextEventHandler TextHandler;

        private void bConfirm_Click(object sender, EventArgs e)
        {
            if (null != TextHandler)
            {
                TextHandler.Invoke(inputCombo.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public void SetElements(List<string> preElements)
        {
            this.inputCombo.Items.Clear();
            foreach (string x in preElements)
            {
                this.inputCombo.Items.Add(x);
            }
        }

        public void SetElements(ComboBox.ObjectCollection preElements)
        {
            this.inputCombo.Items.Clear();
            foreach (string x in preElements)
            {
                this.inputCombo.Items.Add(x.ToString());
            }
        }

        public void SetElements(Dictionary<string, string>.ValueCollection preElements)
        {
            this.inputCombo.Items.Clear();
            foreach (string x in preElements)
            {
                this.inputCombo.Items.Add(x.ToString());
            }
        }

        public List<string> GetElements()
        {
            List<string> result = new List<string>();
            foreach (string x in this.inputCombo.Items)
            {
                result.Add(x);
            }
            return result;
        }
    }
}
