using SDVXStatrter;
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
using static SDVXStarter.Ultilities;

namespace SDVXStarter
{
    /// <summary>
    /// Openup EA3 modifier form
    /// </summary>
    public partial class EA3Modifier : Form, SDVXView
    {
        private string path;
        private IStorage storage;
        public EA3Modifier()
        {
            InitializeComponent();
            path = Application.StartupPath;
            this.storage = new Storage1L();
        }

        public EA3Modifier(string path ,IStorage globalStorage)
        {
            InitializeComponent();
            this.path = path;
            this.storage = globalStorage;
        }

        public bool FindDuplicate(ComboBox.ObjectCollection array, string name)
        {
            return FindDuplicates(array, name);
        }

        public string GetDiskName(string path)
        {
            return Ultilities.GetDiskName(path);
        }

        public void PackageAndUpdate()
        {

        }

        public void RefreshStorage()
        {
            this.storage = new Storage1L();
        }

        public void RefreshView()
        {
            this.versionCombo.Items.Clear();
            this.versionCombo.Items.Add("KFC:J:A:A:2020011500");
            this.pcbidCombo.Items.Clear();
            this.pcbidCombo.Items.Add("01020304050607080900");
            this.urlCombo.Items.Clear();
            this.slashButton0.Checked = true;
            this.slashButton1.Checked = false;
        }

        void SDVXView.RefreshView(XmlStorage newStorage)
        {
            this.storage = newStorage.LocalStorage;
        }

        public void RefreshView(List<string> newArgument)
        {
            
        }

        public void RestoreCommands()
        {
            
        }

        void SDVXView.UpdateView(IStorage externalStroage)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool selected = false;
            OpenFileDialog xmlSelector = new OpenFileDialog();
            xmlSelector.Title = "Select the ea3-config.xml you'd like to load:";
            xmlSelector.Filter = "ea3-config.xml|*.xml";
            if (!path.Equals("(root path)") && !path.Equals("(Remove)") && !path.Equals(""))
            {
                xmlSelector.InitialDirectory = path;
            }
            else
            {
                xmlSelector.InitialDirectory = Application.StartupPath;
            }
            if (xmlSelector.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(xmlSelector.FileName))
                {
                    MessageBox.Show(this, "Cannot process null path.", "SDVXStarter");
                }
                else
                {
                    RefreshView();
                    selected = true;
                    this.pathContentLabel.Text = xmlSelector.FileName;
                    this.verContentLabel.Text = this.storage.GetVersion(FindFatherPathContainSpice(xmlSelector.FileName,false));
                }
            }
            if (selected)
            {
                EA3Compiler compiler = new EA3Compiler(xmlSelector.FileName);
                if (!compiler.CheckValidity())
                {
                    MessageBox.Show("The xml file you selected is invalid.");
                }
                else
                {
                    SafeAdd(this.versionCombo.Items,compiler.Version);
                    this.versionCombo.Text = compiler.Version;
                    SafeAdd(this.pcbidCombo.Items, compiler.PCBID);
                    this.pcbidCombo.Text = compiler.PCBID;
                    SafeAdd(this.urlCombo.Items, compiler.Services);
                    this.urlCombo.Text = compiler.Services;
                    if (compiler.UrlSlash.Equals("1"))
                    {
                        slashButton0.Checked = false;
                        slashButton1.Checked = true;
                    }
                    else
                    {
                        slashButton0.Checked = true;
                        slashButton1.Checked = false;
                    }
                }
            }
        }

        private void quickLoadButton_Click(object sender, EventArgs e)
        {
            string output = "";
            InputMediate.Show(true, "SDVXStarter - Quick Load", "Paste the fast config text here to fill settings:", out output);
            EA3Compiler loaded = new EA3Compiler(output, true);
            if (!loaded.CheckValidity())
            {
                MessageBox.Show("The xml file you selected is invalid.");
            }
            else
            {
                SafeAdd(this.pcbidCombo.Items, loaded.PCBID);
                this.pcbidCombo.Text = loaded.PCBID;
                SafeAdd(this.urlCombo.Items,loaded.Services);
                this.urlCombo.Text = loaded.Services;
                if (loaded.UrlSlash.Equals("1"))
                {
                    slashButton0.Checked = false;
                    slashButton1.Checked = true;
                }
                else
                {
                    slashButton0.Checked = true;
                    slashButton1.Checked = false;
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int result = (int)MessageBox.Show("Please confirm you have saved any changes in this page.", "SDVX Starter", MessageBoxButtons.YesNoCancel);
            bool saved = result == 6;
            if (saved)
            {
                RefreshView();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = pathContentLabel.Text;
            bool propExist;
            if (pathContentLabel.Text.Equals("") || pathContentLabel.Text.Equals("(root path)") || pathContentLabel.Text.Equals("(Remove)"))
            {
                path = "\\prop\\ea3-config.xml";
            }
            propExist = File.Exists(path);
            if (!propExist)
            {
                MessageBox.Show("The path you selected does not contain prop\\ea3-config.xml. \nPlease use save as function to save.");
            }
            else if (propExist)
            {
                EA3Compiler compiler = new EA3Compiler(path);
                if (!compiler.CheckValidity())
                {
                    MessageBox.Show("The ea3-config.xml in " + path + " is not valid.");
                }
                else
                {
                    string preProcessPCBID = pcbidCombo.Text;
                    string preProcessURL = urlCombo.Text;
                    if (preProcessPCBID.Equals("(Default)"))
                    {
                        preProcessPCBID = "01020304050607080900";
                    }
                    else if (preProcessPCBID.Equals("(Empty)"))
                    {
                        preProcessPCBID = "";
                    }
                    if (preProcessURL.Equals("(Empty)") || preProcessURL.Equals("(Offline)"))
                    {
                        preProcessURL = "";
                    }
                    compiler.PCBID = preProcessPCBID;
                    compiler.Services = preProcessURL;
                    if (slashButton1.Checked)
                    {
                        compiler.UrlSlash = "1";
                    }
                    else
                    {
                        compiler.UrlSlash = "0";
                    }
                    compiler.UpdateByRuntime();
                    compiler.SaveXml(path);
                    MessageBox.Show("Successfully saved ea3-config.xml at path " + path);
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool selected = false;
            SaveFileDialog xmlSelector = new SaveFileDialog();
            xmlSelector.Title = "Select the ea3-config.xml you'd like to save:";
            xmlSelector.FileName = "ea3-config.xml";
            xmlSelector.Filter = "ea3-config.xml|*.xml";
            if (!pathContentLabel.Text.Equals("(root path)") && !pathContentLabel.Text.Equals("(Remove)") && !pathContentLabel.Text.Equals(""))
            {
                xmlSelector.InitialDirectory = FindFatherPathContainSpice(pathContentLabel.Text,false);
            }
            else
            {
                xmlSelector.InitialDirectory = Application.StartupPath;
            }
            if (xmlSelector.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(xmlSelector.FileName))
                {
                    MessageBox.Show(this, "Cannot process null path.", "SDVXStarter");
                }
                else
                {
                    selected = true;
                }
            }
            if (selected)
            {
                EA3Compiler compiler = new EA3Compiler(xmlSelector.FileName);
                if (!compiler.CheckValidity())
                {
                    MessageBox.Show("The xml file you selected is invalid.");
                }
                else
                {
                    string preProcessPCBID = pcbidCombo.Text;
                    string preProcessURL = urlCombo.Text;
                    if (preProcessPCBID.Equals("(Default)"))
                    {
                        preProcessPCBID = "01020304050607080900";
                    }
                    else if (preProcessPCBID.Equals("(Empty)"))
                    {
                        preProcessPCBID = "";
                    }
                    if (preProcessURL.Equals("(Empty)") || preProcessURL.Equals("(Offline)"))
                    {
                        preProcessURL = "";
                    }
                    compiler.PCBID = preProcessPCBID;
                    compiler.Services = preProcessURL;
                    if (slashButton1.Checked)
                    {
                        compiler.UrlSlash = "1";
                    }
                    else
                    {
                        compiler.UrlSlash = "0";
                    }
                    compiler.UpdateByRuntime();
                    compiler.SaveXml(xmlSelector.FileName);
                    MessageBox.Show("Successfully saved ea3-config.xml at path " + xmlSelector.FileName);
                }
            }
        }
    }
}
