using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualBasic;

namespace SDVXStarter
{
    public partial class SDVX : Form
    {
        private Storage globalStorage;
        private CardNumberGenerator globalGenerator;
        private const string DefaultCard = "E004000000000000";

        public SDVX()
        {
            InitializeComponent();
            globalStorage = new Storage1L();
            globalGenerator = new CardNumberGenerator1L();
        }

        /// <summary>
        /// Packages all settings and Update sets for argument
        /// </summary>
        public void PackageAndUpdate()
        {
            pcbidCombo.SelectedItem = pcbidCombo.Text;
            cardCombo.SelectedItem = cardCombo.Text;
            urlCombo.SelectedItem = urlCombo.Text;
            Dictionary<string, bool> configSet = new Dictionary<string, bool>();
            Dictionary<string, string> valueSet = new Dictionary<string, string>();
            configSet.Add("window", fullScreenCheck.CheckState == CheckState.Checked);
            configSet.Add("ssl", sslCheck.CheckState == CheckState.Checked);
            configSet.Add("printer", printerCheck.CheckState == CheckState.Checked);
            configSet.Add("urlSlash", urlCheck.CheckState == CheckState.Checked);
            configSet.Add("hd", hdCheck.CheckState == CheckState.Checked);
            // Checks PCBID
            if (pcbidCombo.Text.Equals("(Default)"))
            {
                valueSet.Add("pcbid", "01020304050607080910");
            }
            else if (pcbidCombo.Text.Equals("") || pcbidCombo.Text.Equals("(Empty)"))
            {
                valueSet.Add("pcbid", "");
            }
            else if (pcbidCombo.Text.Equals("(Add)") || pcbidCombo.Text.Equals("(Remove)"))
            {
                MessageBox.Show("Invalid PCBID.", "Seems like you entered with errors");
            }
            else
            {
                valueSet.Add("pcbid", pcbidCombo.SelectedItem.ToString());
            }
            // Checks card
            if (cardCombo.Text.Equals("") || cardCombo.Text.Equals("(Empty)"))
            {
                valueSet.Add("card", "");
            }
            else if (cardCombo.Text.Equals("(Add)") || cardCombo.Text.Equals("(Remove)"))
            {
                MessageBox.Show("Invalid card.", "Seems like you entered with errors");
            }
            else
            {
                valueSet.Add("card", cardCombo.SelectedItem.ToString());
            }
            // Checks url
            if (cardCombo.Text.Equals("") || cardCombo.Text.Equals("(Empty)"))
            {
                valueSet.Add("url", "");
            }
            else if (cardCombo.Text.Equals("(Add)") || cardCombo.Text.Equals("(Remove)"))
            {
                MessageBox.Show("Invalid url.", "Seems like you entered ommands");
            }
            else
            {
                valueSet.Add("url", urlCombo.SelectedItem.ToString());
            }
            globalStorage.Update(configSet, valueSet);
        }

        /// <summary>
        /// Find if added string is already in given array.
        /// </summary>
        /// <param name="array">List to find</param>
        /// <param name="name">Item to find</param>
        /// <returns></returns>
        public bool FindDuplicate(ComboBox.ObjectCollection array, string name)
        {
            bool result = false;

            foreach (string x in array)
            {
                result = result || x.Equals(name);
            }

            return result;
        }

        /// <summary>
        /// Returns the Disk Name of given path.
        /// </summary>
        /// <param name="path">Path to find</param>
        /// <returns>path.DiskName</returns>
        public string GetDiskName(string path)
        {
            string[] disk = path.Split('\\');
            return disk[0];
        }

        public void RefreshView()
        {

        }

        private void RefreshStorage()
        {
            versionCombo.Items.Clear();
            urlCombo.Items.Clear();
            cardCombo.Items.Clear();
            pcbidCombo.Items.Clear();


            current.Text = "Root SDVX";
            versionCombo.Items.Add("(Remove)");
            versionCombo.Items.Add("(root path)");
            urlCombo.Items.Add("(Offline)");
            urlCombo.Items.Add("(Add)");
            urlCombo.Items.Add("(Remove)");
            urlCombo.Items.Add("http://xrpc.arcana.nu/core/");
            urlCombo.Items.Add("http://eamu.bemanicn.com/");
            cardCombo.Items.Add("(Empty)");
            cardCombo.Items.Add("(Add)");
            cardCombo.Items.Add("(Remove)");
            cardCombo.Items.Add(DefaultCard);
            pcbidCombo.Items.Add("(Empty)");
            pcbidCombo.Items.Add("(Default)");
            pcbidCombo.Items.Add("(Add)");
            pcbidCombo.Items.Add("(Remove)");
            PackageAndUpdate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void bGenerate_Click(object sender, EventArgs e)
        {
            bool duplicated = false;
            string newCard = globalGenerator.Generate();
            foreach (string x in cardCombo.Items)
            {
                duplicated = duplicated || newCard.Equals(x);
            }
            if (!duplicated)
            {
                cardCombo.Items.Add(newCard);
                cardCombo.Text = newCard;
            }
            else MessageBox.Show("This card is duplicated.");
            
        }

        private void bCardVerify_Click(object sender, EventArgs e)
        {
            bool valid = globalGenerator.Verify(cardCombo.Text.ToString());
            if (valid)
            {
                MessageBox.Show("Your card is valid and added to list.","Card Verifier");
                if (!FindDuplicate(cardCombo.Items, cardCombo.Text))
                {
                    cardCombo.Items.Add(cardCombo.Text);
                }
            }
            else
            {
                MessageBox.Show("Your card is invalid!", "Card Verifier");               
            }
        }

        private void bPathVerify_Click(object sender, EventArgs e)
        {
            string path = pathBox.Text;
            bool pathDuplicated = globalStorage.FindKeyDuplicate(globalStorage.GetPathSet(), path);
            bool allExists;
            bool spiceExist = File.Exists(path + "spice.exe");
            bool spice64Exist = File.Exists(path + "spice64.exe");
            bool spiceCfgExist = File.Exists(path + "spicecfg.exe");
            allExists = (spiceExist || spice64Exist) && spiceCfgExist;
            if (!allExists&&!pathDuplicated)
            {
                MessageBox.Show("Given path does not contain all spice tools to run.\n","Invalid Path");
            }
            else if(allExists && !pathDuplicated)
            {
                string note = Interaction.InputBox("Note your path here.","Which version is it?","SDVX",-1,-1);
                if (note.Equals(""))
                {
                    note = "New SDVX Instance";
                }
                foreach (string x in globalStorage.GetVerSet().Values)
                {
                    if (x.Equals(note))
                        note += "(n)";
                }
                versionCombo.Items.Add(path);
                versionCombo.Text = (path);
                current.Text = note;
                globalStorage.AddVerPathMap(note, path);
            }  
            else
            {
                MessageBox.Show("Given path was already in list.");
            }
        }

        private void bBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog pathSelector = new FolderBrowserDialog();
            pathSelector.Description = "Select the folder with Game assets and spice tools:";
            if (pathSelector.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(pathSelector.SelectedPath))
                {
                    MessageBox.Show(this, "Cannot process null path.", "SDVXStarter");
                    return;
                }
            }
            pathBox.Text = pathSelector.SelectedPath+"\\";
        }

        private void bStarter_Click(object sender, EventArgs e)
        {
            if (versionCombo.Text.Equals(""))
            {
                versionCombo.SelectedItem = "(root path)";
            }
            string path = globalStorage.GetPath(current.Text);
            this.PackageAndUpdate();
            bool allPass = false;
            bool spiceExist = File.Exists(path+"spice.exe");
            bool spice64Exist = File.Exists(path+"spice64.exe");
            bool spiceCfgExist = File.Exists(path+"spicecfg.exe");          
            allPass = (spiceExist || spice64Exist) && spiceCfgExist;
            
            if (!current.Text.Equals("Root SDVX"))
            {
                Process spice = new Process();
                spice.StartInfo.FileName = "cmd";
                spice.StartInfo.UseShellExecute = false;
                spice.StartInfo.RedirectStandardInput = true;
                spice.StartInfo.RedirectStandardError = true;
                spice.StartInfo.CreateNoWindow = false;
                spice.Start();
                globalStorage.GetVerSet().TryGetValue(current.Text, out path);
                spice.StandardInput.WriteLine(GetDiskName(path));
                spice.StandardInput.WriteLine("cd " + "\"" + path + "\"");
                spice.StandardInput.WriteLine(".\\spice.exe " + globalStorage.GetArgument());          
                spice.StandardInput.WriteLine("exit");
                spice.Close();
            }         
            else if (spiceExist)
            {
                Process spice = new Process();
                spice.StartInfo.FileName = "cmd";
                spice.StartInfo.UseShellExecute = false;
                spice.StartInfo.RedirectStandardInput = true;
                spice.StartInfo.RedirectStandardError = true;
                spice.StartInfo.CreateNoWindow = false;
                spice.Start();
                spice.StandardInput.WriteLine(".\\spice.exe " + globalStorage.GetArgument());
                spice.StandardInput.WriteLine("exit");
                spice.Close();
            }
            else
            {
                MessageBox.Show("The root path does not contain spice tools.");
            }
        }

        private void bStarter64_Click(object sender, EventArgs e)
        {
            if (versionCombo.Text.Equals(""))
            {
                versionCombo.SelectedItem = "(root path)";
            }
            string path = globalStorage.GetPath(current.Text);
            this.PackageAndUpdate();
            bool allPass = false;
            bool spiceExist = File.Exists(path + "spice.exe");
            bool spice64Exist = File.Exists(path + "spice64.exe");
            bool spiceCfgExist = File.Exists(path + "spicecfg.exe");
            allPass = (spiceExist || spice64Exist) && spiceCfgExist;

            if (!current.Text.Equals("Root SDVX"))
            {
                Process spice = new Process();
                spice.StartInfo.FileName = "cmd";
                spice.StartInfo.UseShellExecute = false;
                spice.StartInfo.RedirectStandardInput = true;
                spice.StartInfo.RedirectStandardError = true;
                spice.StartInfo.CreateNoWindow = false;
                spice.Start();
                globalStorage.GetVerSet().TryGetValue(current.Text, out path);
                spice.StandardInput.WriteLine(GetDiskName(path));
                spice.StandardInput.WriteLine("cd " + "\"" + path + "\"");
                spice.StandardInput.WriteLine(".\\spice64.exe " + globalStorage.GetArgument());
                spice.StandardInput.WriteLine("exit");
                spice.Close();
            }
            else if (spiceExist)
            {
                Process spice = new Process();
                spice.StartInfo.FileName = "cmd";
                spice.StartInfo.UseShellExecute = false;
                spice.StartInfo.RedirectStandardInput = true;
                spice.StartInfo.RedirectStandardError = true;
                spice.StartInfo.CreateNoWindow = false;
                spice.Start();
                spice.StandardInput.WriteLine(".\\spice64.exe " + globalStorage.GetArgument());
                spice.StandardInput.WriteLine("exit");
                spice.Close();
            }
            else
            {
                MessageBox.Show("The root path does not contain spice tools.");
            }
        }

        private void versionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (versionCombo.SelectedItem.ToString().Equals("(Remove)"))
            {
                string remove = Interaction.InputBox("Insert the version NOTE you'd like to remove.", "Which version is it?", "SDVX", -1, -1);
                if (remove.Equals("Root SDVX"))
                {
                    MessageBox.Show("No you cannot remove the root path.");
                }
                else
                {
                    bool found = globalStorage.RemoveVerPathMap(remove);
                    if (found)
                    {
                        versionCombo.Items.Clear();
                        versionCombo.Items.Add("(Remove)");
                        foreach (string x in globalStorage.GetVerSet().Values)
                        {
                            versionCombo.Items.Add(x);
                        }
                        MessageBox.Show("Suceesfuly removed version "+remove);
                        if (versionCombo.Text.Equals(""))
                        {
                            versionCombo.SelectedItem = "(root path)";
                        }
                    }
                    else
                    {
                        MessageBox.Show("No such version identified.");
                    }
                }
            }
            else 
            {
                current.Text = globalStorage.GetVersion(versionCombo.SelectedItem.ToString());
            }
            
        }

        private void cardCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cardCombo.SelectedItem.ToString().Equals("(Add)"))
            {
                string intake = Interaction.InputBox("It shall start with E004, contains only 0-9 and A-F and 16 characters in total", "Input your card number.", DefaultCard, -1, -1);
                intake = intake.ToUpper();
                if (intake.Equals(""))
                {
                    cardCombo.Text = DefaultCard;
                }
                else
                {
                    while (!globalGenerator.Verify(intake) && !intake.Equals(""))
                    {
                        MessageBox.Show("The card number is not valid.", "Invalid card");
                        intake = Interaction.InputBox("It shall start with E004, contains only 0-9 and A-F and 16 characters in total", "Input your card number.", DefaultCard, -1, -1);
                        intake = intake.ToUpper();
                    }
                    if (intake.Equals(""))
                    {
                        cardCombo.Text = "(Empty)";
                    }
                    else if (FindDuplicate(cardCombo.Items, intake))
                    {
                        MessageBox.Show("This card is already registered!", "Invalid card");
                        cardCombo.Text = DefaultCard;
                    }
                    else
                    {
                        cardCombo.Items.Add(intake);
                        cardCombo.Text = intake;
                    }
                }
            }
            else if(cardCombo.Text.Equals("(Remove)"))
            {
                string intake = Interaction.InputBox("It shall start with E004, contains only 0-9 and A-F and 16 characters in total",  "Input your card number.", DefaultCard, -1, -1);
                if (intake.Equals("(Add)")||intake.Equals("(Remove)"))
                {
                    MessageBox.Show("This shall throw an exception... But not today!","How do you do if you removes the commands?");
                }
                else
                {
                    bool remove = false;
                    foreach (string x in cardCombo.Items)
                    {
                        if (x.Equals(intake))
                        {
                            remove = true;
                        }
                    }
                    if (remove)
                    {
                        cardCombo.Items.Remove(intake);
                        MessageBox.Show("Successfully removed card number:\n"+intake);
                    }
                    else
                    {
                        MessageBox.Show("No such card found!");
                    }
                }
            }
            else cardCombo.Text = cardCombo.SelectedItem.ToString();
        }

        private void urlCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (urlCombo.SelectedItem.ToString().Equals("(Add)"))
            {
                string intake = Interaction.InputBox("Copy from your server URL.", "Input your URL.", "u.osu.edu", -1, -1);
                if (intake.Equals("")||intake.Equals("(Offline)"))
                {
                    urlCombo.Text = "(Offline)";
                }
                else
                {
                    if (FindDuplicate(urlCombo.Items, intake))
                    {
                        MessageBox.Show("This URL is already registered!", "Invalid URL");
                        urlCombo.Text = "(Offline)";
                    }
                    else
                    {
                        urlCombo.Items.Add(intake);
                        urlCombo.Text = intake;
                    }
                }
            }
            else if (urlCombo.Text.Equals("(Remove)"))
            {
                string intake = Interaction.InputBox("It shall start with E004, contains only 0-9 and A-F and 16 characters in total", "Input your card number.", DefaultCard, -1, -1);
                if (intake.Equals("(Add)") || intake.Equals("(Remove)"))
                {
                    MessageBox.Show("This shall throw an exception... But not today!", "How do you do if you removes the commands?");
                }
                else
                {
                    bool remove = false;
                    foreach (string x in cardCombo.Items)
                    {
                        if (x.Equals(intake))
                        {
                            remove = true;
                        }
                    }
                    if (remove)
                    {
                        cardCombo.Items.Remove(intake);
                        MessageBox.Show("Successfully removed url:\n" + intake);
                    }
                    else
                    {
                        MessageBox.Show("No such url found!");
                    }
                }
            }
            else urlCombo.Text = urlCombo.SelectedItem.ToString();
        }

        private void pcbidCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pcbidCombo.SelectedItem.ToString().Equals("(Add)"))
            {
                string intake = Interaction.InputBox("So far only PCBID is supported. Please directly modify xml files for further modifications.", "Input your PCBID","", -1, -1);
                if (intake.Equals("") || intake.Equals("(Empty)"))
                {
                    pcbidCombo.Text = "";
                }
                else
                {
                    if (FindDuplicate(pcbidCombo.Items, intake))
                    {
                        MessageBox.Show("This PCBID is already registered!", "Invalid PCBID");
                        pcbidCombo.Text = "(Empty)";
                    }
                    else
                    {
                        pcbidCombo.Items.Add(intake);
                        pcbidCombo.Text = intake;
                    }
                }
            }
            else if (pcbidCombo.Text.Equals("(Remove)"))
            {
                string intake = Interaction.InputBox("Input the PCBID record you'd like to delete.", "Input your PCBID", "", -1, -1);
                if (intake.Equals("(Add)") || intake.Equals("(Remove)"))
                {
                    MessageBox.Show("This shall throw an exception... But not today!", "How do you do if you removes the commands?");
                }
                else
                {
                    bool remove = false;
                    foreach (string x in pcbidCombo.Items)
                    {
                        if (x.Equals(intake))
                        {
                            remove = true;
                        }
                    }
                    if (remove)
                    {
                        pcbidCombo.Items.Remove(intake);
                        MessageBox.Show("Successfully removed PCBID:\n" + intake);
                    }
                    else
                    {
                        MessageBox.Show("No such PCBID found!");
                    }
                }
            }
            else pcbidCombo.Text = pcbidCombo.SelectedItem.ToString();
        }

        private void bSpiceConfig_Click(object sender, EventArgs e)
        {
            if (versionCombo.Text.Equals(""))
            {
                versionCombo.SelectedItem = "(root path)";
            }
            string path = globalStorage.GetPath(current.Text);
            bool spiceCfgExist = File.Exists(path + "spicecfg.exe");
            int result = (int)MessageBox.Show("Is this version in 64-bit?","SDVX Starter", MessageBoxButtons.YesNoCancel);
            bool x64 = result == 6;
            bool x86 = result == 7;

            if (!current.Text.Equals("Root SDVX"))
            {
                Process spice = new Process();
                spice.StartInfo.FileName = "cmd";
                spice.StartInfo.UseShellExecute = false;
                spice.StartInfo.RedirectStandardInput = true;
                spice.StartInfo.RedirectStandardError = true;
                spice.StartInfo.CreateNoWindow = false;
                spice.Start();
                globalStorage.GetVerSet().TryGetValue(current.Text, out path);
                spice.StandardInput.WriteLine(GetDiskName(path));
                spice.StandardInput.WriteLine("cd " + "\"" + path + "\"");
                if (x64)
                {
                    spice.StandardInput.WriteLine(".\\spice64.exe " + "-cfg");
                }
                else if (x86)
                {
                    spice.StandardInput.WriteLine(".\\spice.exe " + "-cfg");
                }         
                spice.StandardInput.WriteLine("exit");
                spice.Close();
            }
            else if (spiceCfgExist)
            {
                Process spice = new Process();
                spice.StartInfo.FileName = "cmd";
                spice.StartInfo.UseShellExecute = false;
                spice.StartInfo.RedirectStandardInput = true;
                spice.StartInfo.RedirectStandardError = true;
                spice.StartInfo.CreateNoWindow = false;
                spice.Start();
                if (x64)
                {
                    spice.StandardInput.WriteLine(".\\spice64.exe " + "-cfg");
                }
                else if (x86)
                {
                    spice.StandardInput.WriteLine(".\\spice.exe " + "-cfg");
                }
                spice.StandardInput.WriteLine("exit");
                spice.Close();
            }
            else
            {
                MessageBox.Show("The root path does not contain spice tools.");
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int result = (int)MessageBox.Show("Please confirm you have saved any changes in this page.","SDVX Starter", MessageBoxButtons.YesNoCancel);
            bool saved = result == 6;
            if (saved)
            {

            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SDVX Starter ver 0.1a\nBy Neskol Lu, 2020\nManages details to play.", "About");
        }
    }
}
