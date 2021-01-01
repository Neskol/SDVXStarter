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
using SDVXStarter;

namespace SDVXStarter
{
    public partial class SDVX : Form, SDVXStatrter.SDVXView
    {
        private IStorage globalStorage;
        private ICardNumberGenerator globalGenerator;
        private const string DefaultCard = "E004000000000000";

        public SDVX()
        {
            InitializeComponent();
            globalStorage = new Storage1L();
            globalGenerator = new CardNumberGenerator1L();
        }

        public void RestoreCommands()
        {
            // Processes pathCombo
            List<string> previous = new List<string>();
            foreach (string x in pathCombo.Items)
            {
                previous.Add(x);
            }
            pathCombo.Items.Clear();
            pathCombo.Items.Add("(Remove)");
            pathCombo.Items.Add("(root path)");
            foreach (string x in previous)
            {
                if (!pathCombo.Items.Contains(x))
                {
                    pathCombo.Items.Add(x);
                }
            }
            // Processes cardCombo
            previous = new List<string>();
            foreach (string x in cardCombo.Items)
            {
                previous.Add(x);
            }
            cardCombo.Items.Clear();
            cardCombo.Items.Add("(Empty)");
            cardCombo.Items.Add("(Remove)");
            cardCombo.Items.Add("(Add)");
            cardCombo.Items.Add(DefaultCard);
            foreach (string x in previous)
            {
                if (!cardCombo.Items.Contains(x))
                {
                    cardCombo.Items.Add(x);
                }
            }
            // Processes urlCombo
            previous = new List<string>();
            foreach (string x in urlCombo.Items)
            {
                previous.Add(x);
            }
            urlCombo.Items.Clear();
            urlCombo.Items.Add("(Offline)");
            urlCombo.Items.Add("(Add)");
            urlCombo.Items.Add("(Remove)");
            urlCombo.Items.Add("http://xrpc.arcana.nu/core/");
            urlCombo.Items.Add("http://eamu.bemanicn.com/");
            foreach (string x in previous)
            {
                if (!urlCombo.Items.Contains(x))
                {
                    urlCombo.Items.Add(x);
                }
            }
            // Process pcbidCombo
            previous = new List<string>();
            foreach (string x in pcbidCombo.Items)
            {
                previous.Add(x);
            }
            pcbidCombo.Items.Clear();
            pcbidCombo.Items.Add("(Empty)");
            pcbidCombo.Items.Add("(Default)");
            pcbidCombo.Items.Add("(Add)");
            pcbidCombo.Items.Add("(Remove)");
            foreach (string x in previous)
            {
                if (!pcbidCombo.Items.Contains(x))
                {
                    pcbidCombo.Items.Add(x);
                }
            }
        }

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
            configSet.Add("api", apiCheck.CheckState == CheckState.Checked);
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
                valueSet.Add("pcbid", pcbidCombo.Text.ToString());
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
                valueSet.Add("card", cardCombo.Text.ToString());
            }
            // Checks url
            if (urlCombo.Text.Equals("") || urlCombo.Text.Equals("(Empty)"))
            {
                valueSet.Add("url", "");
            }
            else if (urlCombo.Text.Equals("(Add)") || urlCombo.Text.Equals("(Remove)"))
            {
                MessageBox.Show("Invalid url.", "Seems like you entered ommands");
            }
            else
            {
                valueSet.Add("url", urlCombo.SelectedItem.ToString());
            }
            // Checks api
            if (apiCheck.Checked)
            {
                valueSet.Add("apiPort", portBox.Text);
                valueSet.Add("apiPassword",passwordBox.Text);
            }
            globalStorage.Update(configSet, valueSet);
        }

        public bool FindDuplicate(ComboBox.ObjectCollection array, string name)
        {
            bool result = false;

            foreach (string x in array)
            {
                result = result || x.Equals(name);
            }

            return result;
        }

        public string GetDiskName(string path)
        {
            string[] disk = path.Split('\\');
            return disk[0];
        }

        public void RefreshView()
        {
            pathCombo.SelectedItem = "(root path)";
            pathCombo.Text = ("(root path)");
            current.Text = "Root SDVX";
            pathBox.Text = "(root path)";
            cardCombo.SelectedItem = "(Empty)";
            cardCombo.Text = "(Empty)";
            urlCombo.SelectedItem = "(Offline)";
            urlCombo.Text = "(Offline)";
            pcbidCombo.SelectedItem = "(Default)";
            pcbidCombo.Text = "(Default)";
            fullScreenCheck.CheckState = CheckState.Unchecked;
            sslCheck.CheckState = CheckState.Unchecked;
            printerCheck.CheckState = CheckState.Unchecked;
            urlCheck.CheckState = CheckState.Unchecked;
            hdCheck.CheckState = CheckState.Unchecked;
        }

        void SDVXStatrter.SDVXView.RefreshView(XmlStorage newStorage)
        {

        }

        void SDVXStatrter.SDVXView.UpdateView(IStorage storage)
        {

        }

        public void RefreshStorage()
        {
            pathCombo.Items.Clear();
            urlCombo.Items.Clear();
            cardCombo.Items.Clear();
            pcbidCombo.Items.Clear();
            globalStorage.Clear();
            globalStorage.AddVerPathMap("Root SDVX","(root path)");

            current.Text = "Root SDVX";
            pathCombo.Items.Add("(Remove)");
            pathCombo.Items.Add("(root path)");
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshStorage();
            RefreshView();
            PackageAndUpdate();
            Console.WriteLine("Hello World!");
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
                bool verDuplicated = globalStorage.FindKeyDuplicate(globalStorage.GetVerSet(), note);
                if (verDuplicated)
                {
                    note += "(n)";
                }
                pathCombo.Items.Add(path);
                pathCombo.Text = (path);
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
            if (pathSelector.ShowDialog() == DialogResult.OK)
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
            if (pathCombo.Text.Equals(""))
            {
                pathCombo.SelectedItem = "(root path)";
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
                spice.StandardInput.WriteLine(".\\spice.exe " + globalStorage.ComposeArgument());          
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
                spice.StandardInput.WriteLine(".\\spice.exe " + globalStorage.ComposeArgument());
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
            if (pathCombo.Text.Equals(""))
            {
                pathCombo.SelectedItem = "(root path)";
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
                spice.StandardInput.WriteLine(".\\spice64.exe " + globalStorage.ComposeArgument());
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
                spice.StandardInput.WriteLine(".\\spice64.exe " + globalStorage.ComposeArgument());
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
            if (pathCombo.SelectedItem.ToString().Equals("(Remove)"))
            {
                string remove = "";
                InputMediate.Show("SDVXStarter", "Insert the version NOTE you'd like to remove.",globalStorage.GetPathSet().Values,out remove);
                if (remove.Equals("Root SDVX")|| remove.Equals("Remove SDVX"))
                {
                    MessageBox.Show("No you cannot remove the command item.");
                }
                else if (!remove.Equals(""))
                {
                    bool found = globalStorage.RemoveVerPathMap(remove);
                    if (found)
                    {
                        pathCombo.Items.Clear();
                        foreach (string x in globalStorage.GetVerSet().Values)
                        {
                            if (!x.Equals(""))
                            {
                                pathCombo.Items.Add(x);
                            }
                        }
                        MessageBox.Show("Suceesfuly removed version "+remove);
                        if (pathCombo.Text.Equals(""))
                        {
                            pathCombo.SelectedItem = "(root path)";
                        }
                    }
                    else
                    {
                        MessageBox.Show("No such version identified.");
                    }
                }
            }
            else if (pathCombo.SelectedItem.ToString().Equals("(root path)"))
            {
                current.Text = "Root SDVX";
            }
            else 
            {
                current.Text = globalStorage.GetVersion(pathCombo.SelectedItem.ToString());
            }
            
        }

        private void cardCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cardCombo.SelectedItem.ToString().Equals("(Add)"))
            {
                string intake = "";
                InputMediate.Show("SDVXStarter","It shall start with E004, contains only 0-9 and A-F and 16 characters in total",out intake);
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
                        InputMediate.Show("SDVXStarter", "It shall start with E004, contains only 0-9 and A-F and 16 characters in total", out intake);
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
                string intake = "";
                InputMediate.Show("SDVXStarter", "It shall start with E004, contains only 0-9 and A-F and 16 characters in total",cardCombo.Items, out intake);
                if (intake.Equals("(Add)")||intake.Equals("(Remove)")|| intake.Equals("(Empty)")|| intake.Equals("E004000000000000"))
                {
                    MessageBox.Show("You cannot move default items.","How do you do if you removes the commands?");
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
            if (pathCombo.Text.Equals(""))
            {
                pathCombo.SelectedItem = "(root path)";
            }
            string path = globalStorage.GetPath(current.Text);
            bool spiceCfgExist = File.Exists(path + "spicecfg.exe");
            int result = (int)MessageBox.Show("Is this version in 64-bit?","SDVX Starter", MessageBoxButtons.YesNoCancel);
            bool x64 = result == 6;
            bool x86 = result == 7;
            bool cancel = result == 2;

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
            else if (!cancel)
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
                RefreshStorage();
                RefreshView();
                PackageAndUpdate();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SDVX Starter ver 0.9a\nBy Neskol Lu, 2020\nManages details to play.\nSee https://github.com/Neskol/SDVXStarter for source codes", "About");
        }

        private void apiBox_CheckedChanged(object sender, EventArgs e)
        {
            if (apiCheck.Checked)
            {
                apiGroup.Visible = true;
            }
            else
            {
                apiGroup.Visible = false;
            }
        }

        private void ea3configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool selected = false;
            OpenFileDialog xmlSelector = new OpenFileDialog();
            xmlSelector.Title = "Select the ea3-config.xml you'd like to load:";
            xmlSelector.Filter = "ea3-config.xml|*.xml";
            if (!pathCombo.Text.Equals("(root path)")&& !pathCombo.Text.Equals("(Remove)")&& !pathCombo.Text.Equals(""))
            {
                xmlSelector.InitialDirectory = pathCombo.Text;
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
                }else
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
                    if (!FindDuplicate(pcbidCombo.Items, compiler.PCBID))
                    {
                        pcbidCombo.Items.Add(compiler.PCBID);
                    }
                    pcbidCombo.SelectedItem = (compiler.PCBID);
                    if (!FindDuplicate(urlCombo.Items, compiler.Services))
                    {
                        urlCombo.Items.Add(compiler.Services);
                    }
                    urlCombo.SelectedItem = (compiler.Services);
                    sslCheck.CheckState = CheckState.Unchecked;
                    urlCheck.CheckState = CheckState.Checked;
                    PackageAndUpdate();
                }
            }
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            bool selected = false;
            OpenFileDialog cardSelector = new OpenFileDialog();
            cardSelector.Title = "Select the card number you'd like to load:";
            cardSelector.Filter = "Text File |*.txt";
            if (!pathCombo.Text.Equals("(root path)") && !pathCombo.Text.Equals("(Remove)") && !pathCombo.Text.Equals(""))
            {
                cardSelector.InitialDirectory = pathCombo.Text;
            }
            else
            {
                cardSelector.InitialDirectory = Application.StartupPath;
            }
            if (cardSelector.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(cardSelector.FileName))
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
                StreamReader cardStream = new StreamReader(cardSelector.FileName);
                string card = cardStream.ReadLine();
                bool valid = globalGenerator.Verify(card);
                if (valid)
                {
                    MessageBox.Show("Your card is valid and added to list.", "Card Verifier");
                    if (!FindDuplicate(cardCombo.Items, card))
                    {
                        cardCombo.Items.Add(card);
                    }
                    cardCombo.SelectedItem = card;
                }
                else
                {
                    MessageBox.Show("Your card is invalid!", "Card Verifier");
                }
            }
            PackageAndUpdate();
        }

        private void starterConfigToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PackageAndUpdate();
            List<string> viewPathSet = new List<string>();
            List<string> cardSet = new List<string>();
            List<string> urlSet = new List<string>();
            List<string> pcbidSet = new List<string>();
            /// Add element to view path set
            foreach (string x in pathCombo.Items)
            {
                viewPathSet.Add(x);
            }
            /// Add element to card set
            foreach (string x in cardCombo.Items)
            {
                cardSet.Add(x);
            }
            /// Add element to url set
            foreach (string x in urlCombo.Items)
            {
                urlSet.Add(x);
            }
            /// Add element to view path set
            foreach (string x in pcbidCombo.Items)
            {
                pcbidSet.Add(x);
            }
            globalStorage.IntakeValue(cardSet,pcbidSet,urlSet,viewPathSet);
            XmlStorage save = new XmlStorage(globalStorage);
            save.ConstructCfgStorage();
            save.SaveXml("cfg.xml");
            MessageBox.Show("Successfully saved at: "+ Application.StartupPath + "\\cfg.xml");
        }

        private void bImport_Click(object sender, EventArgs e)
        {
            string note = Interaction.InputBox("Paste config text from your account.", "BEMANICN Config fast import", "", -1, -1);
            if (!note.Equals(""))
            {
                EA3Compiler quickImport = new EA3Compiler(note, true);
                bool isValid = quickImport.CheckValidity();
                if (isValid)
                {
                    /// Set PCBID
                    if (!FindDuplicate(pcbidCombo.Items, quickImport.PCBID))
                    {
                        pcbidCombo.Items.Add(quickImport.PCBID);
                    }
                    pcbidCombo.SelectedItem = quickImport.PCBID;
                    /// Set URL
                    if (!FindDuplicate(urlCombo.Items, quickImport.Services))
                    {
                        pcbidCombo.Items.Add(quickImport.Services);
                    }
                    pcbidCombo.SelectedItem = quickImport.Services;
                    /// Set UrlSlash
                    sslCheck.CheckState = CheckState.Unchecked;
                    if (quickImport.UrlSlash.Equals("1"))
                    {
                        urlCheck.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        urlCheck.CheckState = CheckState.Unchecked;
                    }
                }
            
        }
        }

        private void ea3configToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool valueChanged = !pcbidCombo.Text.Equals("(Remove)") && !pcbidCombo.Text.Equals("(Add)") && !urlCombo.Text.Equals("(Add)") && !urlCombo.Text.Equals("Remove") && (urlCheck.CheckState == CheckState.Checked || urlCheck.CheckState == CheckState.Unchecked);
            if (!valueChanged)
            {
                MessageBox.Show("You must select URL, PCBID and URLSlash section to modify ea3-config, or selected items contains comands.\ne.g. (Remove) but not (Default), (Offline) or (Empty)");
            }
            else
            {
                string path = pathCombo.Text;
                bool propExist;
                if (pathCombo.Text.Equals("")|| pathCombo.Text.Equals("(root path)")|| pathCombo.Text.Equals("(Remove)"))
                {
                    path = "";
                }
                propExist = File.Exists(path + "\\prop\\ea3-config.xml");
                if (!propExist)
                {
                    MessageBox.Show("The path you selected in path combo does not contain\n" +
                        "prop\\ea3-config.xml. Please use save as function or EA3 modifier ultility to save.");
                }
                else if (propExist)
                {
                    EA3Compiler compiler = new EA3Compiler(path + "\\prop\\ea3-config.xml");
                    if (!compiler.CheckValidity())
                    {
                        MessageBox.Show("The ea3-config.xml in "+path+" is not valid.");
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
                        if (urlCheck.CheckState == CheckState.Checked)
                        {
                            compiler.UrlSlash = "1";
                        }
                        else
                        {
                            compiler.UrlSlash = "0";
                        }
                        compiler.UpdateByRuntime();
                        compiler.SaveXml(path + "\\prop\\ea3-config.xml");
                        MessageBox.Show("Successfully saved ea3-config.xml at path " + path + "\\prop\\ea3-config.xml");
                    }
                }
            }
        }

        private void starterConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool selected = false;
            OpenFileDialog configSelector = new OpenFileDialog();
            configSelector.Title = "Select the Starter Config you'd like to load:";
            configSelector.Filter = "Starter Config |*.xml";
            if (!pathCombo.Text.Equals("(root path)") && !pathCombo.Text.Equals("(Remove)") && !pathCombo.Text.Equals(""))
            {
                configSelector.InitialDirectory = pathCombo.Text;
            }
            else
            {
                configSelector.InitialDirectory = Application.StartupPath;
            }
            if (configSelector.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(configSelector.FileName))
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
                XmlStorage configLoader = new XmlStorage();
                configLoader.LoadXml(configSelector.FileName);
                if (!configLoader.CheckValidity())
                {
                    MessageBox.Show("The xml file you selected is invalid.");
                }
                else
                {
                    // Adds items to PCBID combo
                    pcbidCombo.Items.Clear();
                    foreach (string x in configLoader.LocalStorage.GetPCBIDSet())
                    {
                        pcbidCombo.Items.Add(x);
                    }
                    // Adds items to Path Combo
                    pathCombo.Items.Clear();
                    foreach (string x in configLoader.LocalStorage.GetVerSet().Values)
                    {
                        pathCombo.Items.Add(x);
                    }
                    // Adds items to card combo
                    cardCombo.Items.Clear();
                    foreach (string x in configLoader.LocalStorage.GetCardSet())
                    {
                        cardCombo.Items.Add(x);
                    }
                    // Adds items to URL combo
                    urlCombo.Items.Clear();
                    foreach (string x in configLoader.LocalStorage.GetUrlSet())
                    {
                        urlCombo.Items.Add(x);
                    }
                    RefreshView(configLoader.LocalStorage.ReturnArgument());
                    foreach (string x in configLoader.LocalStorage.ReturnArgument())
                    {
                        Console.WriteLine(x);
                    }
                    globalStorage = configLoader.LocalStorage;
                    PackageAndUpdate();
                }
            }
        }

        public void RefreshView(List<string> newArgument)
        {
            foreach (string argument in newArgument)
            {
                // Processes 720p option
                if (argument.Equals("-sdvx"))
                {
                    hdCheck.CheckState = CheckState.Unchecked;
                }
                else if (argument.Equals("-sdvx720p"))
                {
                    hdCheck.CheckState = CheckState.Checked;
                }
                //Process card selection
                if (argument.Contains("-card"))
                {
                    cardCombo.SelectedItem = argument.Split(' ')[1];
                }
                //Process URL selection
                if (argument.Contains("-url")&&!argument.Contains("-urlslash"))
                {
                    urlCombo.SelectedItem = argument.Split(' ')[1];
                    urlCheck.CheckState = CheckState.Checked;
                }
                //Process SSL option
                if (argument.Equals("-ssldisable"))
                {
                    sslCheck.CheckState = CheckState.Checked;
                }
                //Process printer option
                if (argument.Equals("-printer"))
                {
                    printerCheck.CheckState = CheckState.Checked;
                }
                //Process PCBID option
                if (argument.Contains("-p"))
                {
                    pcbidCombo.SelectedItem = argument.Split(' ')[1];
                }
                //Process full screen option
                if (argument.Equals("-w"))
                {
                    fullScreenCheck.CheckState = CheckState.Unchecked;
                }
                //Process spice comanion option
                if (argument.Contains("-api")&&!argument.Contains("-apipass"))
                {
                    apiCheck.CheckState = CheckState.Checked;
                    portBox.Text = argument.Split(' ')[1];
                }
                else if (argument.Contains("-apipass"))
                {
                    apiCheck.CheckState = CheckState.Checked;
                    passwordBox.Text = argument.Split(' ')[1];
                }
            }
        }

        private void restoreDefaultCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoreCommands();
            MessageBox.Show("Successfully Restored.");
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EA3Modifier ea3 = new EA3Modifier(pathCombo.Text, globalStorage);
            ea3.ShowDialog();
        }

        private void starterConfigToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            bool selected = false;
            SaveFileDialog xmlSelector = new SaveFileDialog();
            xmlSelector.Title = "Select the path you'd like to save:";
            xmlSelector.FileName = "cfg.xml";
            xmlSelector.Filter = "Starter Config |*.xml";
            if (!pathCombo.Text.Equals("(root path)") && !pathCombo.Text.Equals("(Remove)") && !pathCombo.Text.Equals(""))
            {
                xmlSelector.InitialDirectory = pathCombo.Text;
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
                PackageAndUpdate();
                List<string> viewPathSet = new List<string>();
                List<string> cardSet = new List<string>();
                List<string> urlSet = new List<string>();
                List<string> pcbidSet = new List<string>();
                /// Add element to view path set
                foreach (string x in pathCombo.Items)
                {
                    viewPathSet.Add(x);
                }
                /// Add element to card set
                foreach (string x in cardCombo.Items)
                {
                    cardSet.Add(x);
                }
                /// Add element to url set
                foreach (string x in urlCombo.Items)
                {
                    urlSet.Add(x);
                }
                /// Add element to view path set
                foreach (string x in pcbidCombo.Items)
                {
                    pcbidSet.Add(x);
                }
                globalStorage.IntakeValue(cardSet, pcbidSet, urlSet, viewPathSet);
                XmlStorage save = new XmlStorage(globalStorage);
                save.ConstructCfgStorage();
                save.SaveXml(xmlSelector.FileName);
                MessageBox.Show("Successfully saved at: " + xmlSelector.FileName);
            }
        }

        private void ea3configToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            bool selected = false;
            bool valueChanged = !pcbidCombo.Text.Equals("(Remove)") && !pcbidCombo.Text.Equals("(Add)") && !urlCombo.Text.Equals("(Add)") && !urlCombo.Text.Equals("Remove") && (urlCheck.CheckState == CheckState.Checked || urlCheck.CheckState == CheckState.Unchecked);
            if (!valueChanged)
            {
                MessageBox.Show("You must select URL, PCBID and URLSlash section to modify ea3-config, or selected items contains comands.\ne.g. (Remove) but not (Default), (Offline) or (Empty)");
            }
            else
            {
                SaveFileDialog xmlSelector = new SaveFileDialog();
                xmlSelector.Title = "Select the ea3-config.xml you'd like to load:";
                xmlSelector.Filter = "ea3-config.xml|*.xml";
                if (!pathCombo.Text.Equals("(root path)") && !pathCombo.Text.Equals("(Remove)") && !pathCombo.Text.Equals(""))
                {
                    xmlSelector.InitialDirectory = pathCombo.Text;
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
                        if (urlCheck.CheckState == CheckState.Checked)
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
}
