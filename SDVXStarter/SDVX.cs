﻿using System;
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
using System.Text.RegularExpressions;

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
            RefreshView();
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
            urlCombo.Items.Add("http://localhost:8083");
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
            configSet.Add("hd", networkCheck.CheckState == CheckState.Checked);
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
                MessageBox.Show("该PCBID无效", "您输入的PCBD无效。");
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
                MessageBox.Show("该PCBID无效", "您输入的PCBD无效。");
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
                MessageBox.Show("该URL无效", "您输入的URL无效。");
            }
            else
            {
                valueSet.Add("url", urlCombo.Text.ToString());
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
            ipBox.Text = "";
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
            fullScreenCheck.CheckState = CheckState.Checked;
            sslCheck.CheckState = CheckState.Unchecked;
            printerCheck.CheckState = CheckState.Unchecked;
            urlCheck.CheckState = CheckState.Unchecked;
            networkCheck.CheckState = CheckState.Unchecked;
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
            urlCombo.Items.Add("http://localhost:8083");
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
            bool CfgAtRootPath = File.Exists("cfg.xml");
            if (CfgAtRootPath)
            {
                XmlStorage configLoader = new XmlStorage();
                configLoader.LoadXml("cfg.xml");
                if (!configLoader.CheckValidity())
                {
                    MessageBox.Show("您选择的xml无效。");
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
                        Console.WriteLine(x); //For debug: see arguments
                    }
                    globalStorage = configLoader.LocalStorage;
                    PackageAndUpdate();
                }
            }
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
            else MessageBox.Show("已有重复的卡号。");
            
        }

        private void bCardVerify_Click(object sender, EventArgs e)
        {
            bool valid = globalGenerator.Verify(cardCombo.Text.ToString());
            if (valid)
            {
                MessageBox.Show("您的卡号是有效的，并已被添加到列表。","Card Verifier");
                if (!FindDuplicate(cardCombo.Items, cardCombo.Text))
                {
                    cardCombo.Items.Add(cardCombo.Text);
                }
            }
            else
            {
                MessageBox.Show("您的卡号是无效的！", "Card Verifier");               
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
                MessageBox.Show("选定的路径不包含至少一个spice tool。\n","无效路径");
            }
            else if(allExists && !pathDuplicated)
            {
                string note = Interaction.InputBox("请在下方备注这个路径：\n"+path,"备注版本号","SDVX",-1,-1);
                if (note.Equals(""))
                {
                    note = "新SDVX版本";
                }
                bool verDuplicated = globalStorage.FindKeyDuplicate(globalStorage.GetVerSet(), note);
                while (verDuplicated)
                {
                    note += "(n)";
                    verDuplicated = globalStorage.FindKeyDuplicate(globalStorage.GetVerSet(), note);
                }
                pathCombo.Items.Add(path);
                pathCombo.Text = (path);
                current.Text = note;
                globalStorage.AddVerPathMap(note, path);
            }  
            else
            {
                MessageBox.Show("该路径已被注册。");
            }
        }

        private void bBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog pathSelector = new FolderBrowserDialog();
            pathSelector.Description = "选择包含游戏资源与spice tool的路径:";
            if (pathSelector.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(pathSelector.SelectedPath))
                {
                    MessageBox.Show(this, "不能处理空路径。", "SDVXStarter");
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
                MessageBox.Show("选定的路径不包含至少一个spice tool。");
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
                MessageBox.Show("选定的路径不包含至少一个spice tool。");
            }
        }

        private void versionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pathCombo.SelectedItem.ToString().Equals("(Remove)"))
            {
                string remove = "";
                InputMediate.Show("SDVXStarter", "请输入需要删除的版本备注：",globalStorage.GetPathSet().Values,out remove);
                if (remove.Equals("Root SDVX")|| remove.Equals("Remove SDVX"))
                {
                    MessageBox.Show("命令选项不能被删除。");
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
                        MessageBox.Show("已删除版本 "+remove);
                        if (pathCombo.Text.Equals(""))
                        {
                            pathCombo.SelectedItem = "(root path)";
                        }
                    }
                    else
                    {
                        MessageBox.Show("没有该当版本。");
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
                InputMediate.Show("SDVXStarter", "虚拟卡应以E004开头共17位，街机卡请确认spice里的卡号", out intake);
                intake = intake.ToUpper();
                if (intake.Equals(""))
                {
                    cardCombo.Text = DefaultCard;
                }
                else
                {
                    while (!globalGenerator.Verify(intake) && !intake.Equals(""))
                    {
                        MessageBox.Show("该卡号无效。", "无效卡号");
                        InputMediate.Show("SDVXStarter", "虚拟卡应以E004开头共17位，街机卡请确认spice里的卡号", out intake);
                        intake = intake.ToUpper();
                    }
                    if (intake.Equals(""))
                    {
                        cardCombo.Text = "(Empty)";
                    }
                    else if (FindDuplicate(cardCombo.Items, intake))
                    {
                        MessageBox.Show("该卡号已被注册！", "无效卡号");
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
                InputMediate.Show("SDVXStarter", "虚拟卡应以E004开头共17位，街机卡请确认spice里的卡号",cardCombo.Items, out intake);
                if (intake.Equals("(Add)")||intake.Equals("(Remove)")|| intake.Equals("(Empty)")|| intake.Equals("E004000000000000"))
                {
                    MessageBox.Show("不能移除命令项目", "不能移除命令项目。");
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
                        MessageBox.Show("成功移除卡号\n"+intake);
                    }
                    else
                    {
                        MessageBox.Show("并没有注册该卡。");
                    }
                }
            }
            else cardCombo.Text = cardCombo.SelectedItem.ToString();
        }

        private void urlCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (urlCombo.SelectedItem.ToString().Equals("(Add)"))
            {
                string intake = Interaction.InputBox("从服务提供处复制URL", "要连接的URL:", "u.osu.edu", -1, -1);
                if (intake.Equals("")||intake.Equals("(Offline)"))
                {
                    urlCombo.Text = "(Offline)";
                }
                else
                {
                    if (FindDuplicate(urlCombo.Items, intake))
                    {
                        MessageBox.Show("该URL已被注册。", "无效URL");
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
                string intake = Interaction.InputBox("虚拟卡应以E004开头共17位，街机卡请确认spice里的卡号", "请输入卡号", DefaultCard, -1, -1);
                if (intake.Equals("(Add)") || intake.Equals("(Remove)"))
                {
                    MessageBox.Show("您不能移除命令行。", "无效选项");
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
                        MessageBox.Show("成功移除URL\n" + intake);
                    }
                    else
                    {
                        MessageBox.Show("没有找到该URL。");
                    }
                }
            }
            else urlCombo.Text = urlCombo.SelectedItem.ToString();
        }

        private void pcbidCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pcbidCombo.SelectedItem.ToString().Equals("(Add)"))
            {
                string intake = Interaction.InputBox("此处支持修改PCBID，其他选项请更改ea3-config.xml", "请输入PCBID","", -1, -1);
                if (intake.Equals("") || intake.Equals("(Empty)"))
                {
                    pcbidCombo.Text = "";
                }
                else
                {
                    if (FindDuplicate(pcbidCombo.Items, intake))
                    {
                        MessageBox.Show("该PCBID已被重复注册。", "无效PCBID");
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
                string intake = Interaction.InputBox("输入要移除的PCBID。", "输入您的PCBID", "", -1, -1);
                if (intake.Equals("(Add)") || intake.Equals("(Remove)"))
                {
                    MessageBox.Show("您不能移除命令行。", "无效选项");
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
                        MessageBox.Show("成功移除PCBID\n" + intake);
                    }
                    else
                    {
                        MessageBox.Show("没有找到该PCBID。");
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
            int result = (int)MessageBox.Show("该SDVX版本是64位的吗？\n注：4代不是，5代是","SDVX Starter", MessageBoxButtons.YesNoCancel);
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
                MessageBox.Show("当前路径下并没有找到可以启动的spice tools。");
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("椰叶您这么强还需要找我？\n辣您不如直接联系neskol@foxmail.com", "椰叶又在卖弱了");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int result = (int)MessageBox.Show("请确认已经保存所有本页设置。","SDVX启动器", MessageBoxButtons.YesNoCancel);
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
            MessageBox.Show("SDVX Starter ver. 1.02a CN\n顾问谨制 By Neskol Lu, 2020\n山东维系启动参数管理器\n源码： https://github.com/Neskol/SDVXStarter", "关于");
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
            xmlSelector.Title = "选择想修改的ea3-config.xml";
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
                    MessageBox.Show(this, "您选中的地址不能为空", "SDVXStarter");
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
                    MessageBox.Show("该xml文档无效。");
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
                    PackageAndUpdate();
                }
            }
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            bool selected = false;
            OpenFileDialog cardSelector = new OpenFileDialog();
            cardSelector.Title = "选择要加载的卡号文档：";
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
                    MessageBox.Show(this, "路径不能为空。", "SDVXStarter");
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
                    MessageBox.Show("您的卡号有效且已添加。", "卡号验证");
                    if (!FindDuplicate(cardCombo.Items, card))
                    {
                        cardCombo.Items.Add(card);
                    }
                    cardCombo.SelectedItem = card;
                }
                else
                {
                    MessageBox.Show("该卡号无效！", "卡号验证");
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
            string[] networking = new string[2];

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
            ///Add networking
            if (networkCheck.CheckState==CheckState.Checked)
            {
                networking[0] = ipBox.Text;
                networking[1] = subnetBox.Text;
            }
            globalStorage.IntakeValue(cardSet,pcbidSet,urlSet,viewPathSet,networking);
            XmlStorage save = new XmlStorage(globalStorage);
            save.ConstructCfgStorage();
            save.SaveXml("cfg.xml");
            MessageBox.Show("成功保存在以下路径：\n"+ Application.StartupPath + "\\cfg.xml");
        }

        private void bImport_Click(object sender, EventArgs e)
        {
            string note = "";
            InputMediate.Show(true, "SDVX启动器 - 快速加载", "粘贴您拿到的配置代码：", out note);
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
                       urlCombo.Items.Add(quickImport.Services);
                    }
                    pcbidCombo.SelectedItem = quickImport.PCBID;
                    urlCombo.SelectedItem = quickImport.Services;
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
                MessageBox.Show("您必须选择URL, PCBID和URLSlash选项来更改ea3-config,或选择框里的选项。.\n如(Empty)，(Default)，(Offline)或(Empty)");
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
                    MessageBox.Show("所选路径不包含\n" +
                        "prop\\ea3-config.xml. 请使用另存为ea3-config或EA3编辑器来保存。");
                }
                else if (propExist)
                {
                    EA3Compiler compiler = new EA3Compiler(path + "\\prop\\ea3-config.xml");
                    if (!compiler.CheckValidity())
                    {
                        MessageBox.Show(path+"中的ea3-config.xml无效。");
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
                        MessageBox.Show("成功将ea3-config保存在路径： " + path + "\\prop\\ea3-config.xml");
                    }
                }
            }
        }

        private void starterConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool selected = false;
            OpenFileDialog configSelector = new OpenFileDialog();
            configSelector.Title = "选择要加载的启动器配置：";
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
                    MessageBox.Show(this, "不能处理空路径。", "SDVXStarter");
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
                    MessageBox.Show("所选xml文档无效。");
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
                    globalStorage = configLoader.LocalStorage;
                    PackageAndUpdate();
                }
            }
        }

        public void RefreshView(List<string> newArgument)
        {
            foreach (string argument in newArgument)
            {
                //Process card selection
                if (argument.Contains("-card"))
                {
                    cardCombo.SelectedItem = argument.Split(' ')[1];
                }
                //Process URL selection
                if (argument.Contains("-url")&&!argument.Contains("-urlslash"))
                {
                    urlCombo.SelectedItem = argument.Split(' ')[1];
                }
                if (argument.Contains("-urlslash"))
                {
                    if (argument.Split(' ')[1]=="1")
                    {
                        urlCheck.CheckState = CheckState.Checked;
                    }
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
                if (argument.Contains("-p ") && !argument.Equals("-printer"))
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
            MessageBox.Show("成功重置。");
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
            xmlSelector.Title = "选择需要保存的路径：";
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
                    MessageBox.Show(this, "不能处理空路径。", "SDVXStarter");
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
                string[] networking = new string[2];
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
                if (networkCheck.CheckState == CheckState.Checked)
                {
                    networking[0] = ipBox.Text;
                    networking[1] = subnetBox.Text;
                }
                globalStorage.IntakeValue(cardSet, pcbidSet, urlSet, viewPathSet, networking);
                XmlStorage save = new XmlStorage(globalStorage);
                save.ConstructCfgStorage();
                save.SaveXml(xmlSelector.FileName);
                MessageBox.Show("成功保存在以下路径：" + xmlSelector.FileName);
            }
        }

        private void ea3configToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            bool selected = false;
            bool valueChanged = !pcbidCombo.Text.Equals("(Remove)") && !pcbidCombo.Text.Equals("(Add)") && !urlCombo.Text.Equals("(Add)") && !urlCombo.Text.Equals("Remove") && (urlCheck.CheckState == CheckState.Checked || urlCheck.CheckState == CheckState.Unchecked);
            if (!valueChanged)
            {
                MessageBox.Show("您必须选择URL, PCBID和URLSlash选项来更改ea3-config,或选择框里的选项。.\n如(Empty)，(Default)，(Offline)或(Empty)");
            }
            else
            {
                SaveFileDialog xmlSelector = new SaveFileDialog();
                xmlSelector.Title = "选择您要加载的xml：";
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
                        MessageBox.Show(this, "不能处理空路径。", "SDVXStarter");
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
                        MessageBox.Show("所选xml无效。");
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
                        MessageBox.Show("成功将ea3-config保存在" + xmlSelector.FileName);
                    }
                }
            }
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            PackageAndUpdate();
            int result = (int)MessageBox.Show("该SDVX版本是64位的吗？\n注：4代不是，5代是", "SDVX Starter", MessageBoxButtons.YesNoCancel);
            bool x64 = result == 6;
            bool x86 = result == 7;
            bool cancel = result == 2;
            if (result != 2)
            {
                string batPath="StartSDVX.bat";
                string command="";
                if (File.Exists(batPath))
                    File.Delete(batPath);
                if (result == 6)
                {
                    command += "spice64"+" ";
                }
                else if (result == 7)
                {
                    command += "spice" + " ";
                }
                command += globalStorage.ComposeArgument();
                File.WriteAllText(batPath, command, Encoding.Default);
                MessageBox.Show("成功生成" + batPath);
            }
        }

        private void ipBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void networkCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (networkCheck.Checked)
            {
                networkGroup.Visible = true;
            }
            else
            {
                networkGroup.Visible = false;
            }
        }
    }
}
