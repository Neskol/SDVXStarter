namespace SDVXStarter
{
    partial class SDVX
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SDVX));
            this.versionBox = new System.Windows.Forms.GroupBox();
            this.bStarter64 = new System.Windows.Forms.Button();
            this.versionCombo = new System.Windows.Forms.ComboBox();
            this.bStarter = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.configBox = new System.Windows.Forms.GroupBox();
            this.bSpiceConfig = new System.Windows.Forms.Button();
            this.optionBox = new System.Windows.Forms.GroupBox();
            this.pcbidCombo = new System.Windows.Forms.ComboBox();
            this.bImport = new System.Windows.Forms.Button();
            this.hdCheck = new System.Windows.Forms.CheckBox();
            this.urlCheck = new System.Windows.Forms.CheckBox();
            this.sslCheck = new System.Windows.Forms.CheckBox();
            this.printerCheck = new System.Windows.Forms.CheckBox();
            this.fullScreenCheck = new System.Windows.Forms.CheckBox();
            this.pcbLabel = new System.Windows.Forms.Label();
            this.urlCombo = new System.Windows.Forms.ComboBox();
            this.networkLabel = new System.Windows.Forms.Label();
            this.cardBox = new System.Windows.Forms.GroupBox();
            this.bGenerate = new System.Windows.Forms.Button();
            this.bLoad = new System.Windows.Forms.Button();
            this.bCardVerify = new System.Windows.Forms.Button();
            this.cardCombo = new System.Windows.Forms.ComboBox();
            this.locationBox = new System.Windows.Forms.GroupBox();
            this.bBrowse = new System.Windows.Forms.Button();
            this.pathLabel = new System.Windows.Forms.Label();
            this.bPathVerify = new System.Windows.Forms.Button();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.curentBox = new System.Windows.Forms.GroupBox();
            this.current = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.starterConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ea3configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.starterConfigToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ea3configToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionBox.SuspendLayout();
            this.configBox.SuspendLayout();
            this.optionBox.SuspendLayout();
            this.cardBox.SuspendLayout();
            this.locationBox.SuspendLayout();
            this.curentBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // versionBox
            // 
            this.versionBox.Controls.Add(this.bStarter64);
            this.versionBox.Controls.Add(this.versionCombo);
            this.versionBox.Controls.Add(this.bStarter);
            this.versionBox.Controls.Add(this.versionLabel);
            this.versionBox.Location = new System.Drawing.Point(9, 83);
            this.versionBox.Margin = new System.Windows.Forms.Padding(2);
            this.versionBox.Name = "versionBox";
            this.versionBox.Padding = new System.Windows.Forms.Padding(2);
            this.versionBox.Size = new System.Drawing.Size(218, 134);
            this.versionBox.TabIndex = 0;
            this.versionBox.TabStop = false;
            this.versionBox.Text = "Version Select";
            // 
            // bStarter64
            // 
            this.bStarter64.Location = new System.Drawing.Point(117, 62);
            this.bStarter64.Margin = new System.Windows.Forms.Padding(2);
            this.bStarter64.Name = "bStarter64";
            this.bStarter64.Size = new System.Drawing.Size(86, 58);
            this.bStarter64.TabIndex = 4;
            this.bStarter64.Text = "Run spice64";
            this.bStarter64.UseVisualStyleBackColor = true;
            this.bStarter64.Click += new System.EventHandler(this.bStarter64_Click);
            // 
            // versionCombo
            // 
            this.versionCombo.FormattingEnabled = true;
            this.versionCombo.Location = new System.Drawing.Point(20, 38);
            this.versionCombo.Margin = new System.Windows.Forms.Padding(2);
            this.versionCombo.Name = "versionCombo";
            this.versionCombo.Size = new System.Drawing.Size(183, 20);
            this.versionCombo.TabIndex = 3;
            this.versionCombo.Text = "(root path)";
            this.versionCombo.SelectedIndexChanged += new System.EventHandler(this.versionCombo_SelectedIndexChanged);
            // 
            // bStarter
            // 
            this.bStarter.Location = new System.Drawing.Point(20, 62);
            this.bStarter.Margin = new System.Windows.Forms.Padding(2);
            this.bStarter.Name = "bStarter";
            this.bStarter.Size = new System.Drawing.Size(86, 58);
            this.bStarter.TabIndex = 2;
            this.bStarter.Text = "Run spice";
            this.bStarter.UseVisualStyleBackColor = true;
            this.bStarter.Click += new System.EventHandler(this.bStarter_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(18, 17);
            this.versionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(173, 12);
            this.versionLabel.TabIndex = 1;
            this.versionLabel.Text = "Select a version to startup.";
            // 
            // configBox
            // 
            this.configBox.Controls.Add(this.bSpiceConfig);
            this.configBox.Controls.Add(this.optionBox);
            this.configBox.Controls.Add(this.cardBox);
            this.configBox.Location = new System.Drawing.Point(248, 32);
            this.configBox.Margin = new System.Windows.Forms.Padding(2);
            this.configBox.Name = "configBox";
            this.configBox.Padding = new System.Windows.Forms.Padding(2);
            this.configBox.Size = new System.Drawing.Size(375, 335);
            this.configBox.TabIndex = 1;
            this.configBox.TabStop = false;
            this.configBox.Text = "Quick Config";
            // 
            // bSpiceConfig
            // 
            this.bSpiceConfig.Location = new System.Drawing.Point(278, 260);
            this.bSpiceConfig.Margin = new System.Windows.Forms.Padding(2);
            this.bSpiceConfig.Name = "bSpiceConfig";
            this.bSpiceConfig.Size = new System.Drawing.Size(71, 60);
            this.bSpiceConfig.TabIndex = 7;
            this.bSpiceConfig.Text = " spice   Config";
            this.bSpiceConfig.UseVisualStyleBackColor = true;
            this.bSpiceConfig.Click += new System.EventHandler(this.bSpiceConfig_Click);
            // 
            // optionBox
            // 
            this.optionBox.Controls.Add(this.pcbidCombo);
            this.optionBox.Controls.Add(this.bImport);
            this.optionBox.Controls.Add(this.hdCheck);
            this.optionBox.Controls.Add(this.urlCheck);
            this.optionBox.Controls.Add(this.sslCheck);
            this.optionBox.Controls.Add(this.printerCheck);
            this.optionBox.Controls.Add(this.fullScreenCheck);
            this.optionBox.Controls.Add(this.pcbLabel);
            this.optionBox.Controls.Add(this.urlCombo);
            this.optionBox.Controls.Add(this.networkLabel);
            this.optionBox.Location = new System.Drawing.Point(14, 109);
            this.optionBox.Margin = new System.Windows.Forms.Padding(2);
            this.optionBox.Name = "optionBox";
            this.optionBox.Padding = new System.Windows.Forms.Padding(2);
            this.optionBox.Size = new System.Drawing.Size(356, 222);
            this.optionBox.TabIndex = 2;
            this.optionBox.TabStop = false;
            this.optionBox.Text = "Start up selection";
            // 
            // pcbidCombo
            // 
            this.pcbidCombo.FormattingEnabled = true;
            this.pcbidCombo.Location = new System.Drawing.Point(84, 47);
            this.pcbidCombo.Margin = new System.Windows.Forms.Padding(2);
            this.pcbidCombo.Name = "pcbidCombo";
            this.pcbidCombo.Size = new System.Drawing.Size(176, 20);
            this.pcbidCombo.TabIndex = 12;
            this.pcbidCombo.Text = "(Default)";
            this.pcbidCombo.SelectedIndexChanged += new System.EventHandler(this.pcbidCombo_SelectedIndexChanged);
            // 
            // bImport
            // 
            this.bImport.Location = new System.Drawing.Point(274, 22);
            this.bImport.Margin = new System.Windows.Forms.Padding(2);
            this.bImport.Name = "bImport";
            this.bImport.Size = new System.Drawing.Size(62, 43);
            this.bImport.TabIndex = 11;
            this.bImport.Text = "Quick Import";
            this.bImport.UseVisualStyleBackColor = true;
            // 
            // hdCheck
            // 
            this.hdCheck.AutoSize = true;
            this.hdCheck.Location = new System.Drawing.Point(264, 105);
            this.hdCheck.Margin = new System.Windows.Forms.Padding(2);
            this.hdCheck.Name = "hdCheck";
            this.hdCheck.Size = new System.Drawing.Size(84, 16);
            this.hdCheck.TabIndex = 10;
            this.hdCheck.Text = "Force 720p";
            this.hdCheck.UseVisualStyleBackColor = true;
            // 
            // urlCheck
            // 
            this.urlCheck.AutoSize = true;
            this.urlCheck.Location = new System.Drawing.Point(130, 105);
            this.urlCheck.Margin = new System.Windows.Forms.Padding(2);
            this.urlCheck.Name = "urlCheck";
            this.urlCheck.Size = new System.Drawing.Size(120, 16);
            this.urlCheck.TabIndex = 8;
            this.urlCheck.Text = "Enable URL Slash";
            this.urlCheck.UseVisualStyleBackColor = true;
            // 
            // sslCheck
            // 
            this.sslCheck.AutoSize = true;
            this.sslCheck.Location = new System.Drawing.Point(130, 77);
            this.sslCheck.Margin = new System.Windows.Forms.Padding(2);
            this.sslCheck.Name = "sslCheck";
            this.sslCheck.Size = new System.Drawing.Size(132, 16);
            this.sslCheck.TabIndex = 6;
            this.sslCheck.Text = "Use SSL connection";
            this.sslCheck.UseVisualStyleBackColor = true;
            // 
            // printerCheck
            // 
            this.printerCheck.AutoSize = true;
            this.printerCheck.Location = new System.Drawing.Point(12, 105);
            this.printerCheck.Margin = new System.Windows.Forms.Padding(2);
            this.printerCheck.Name = "printerCheck";
            this.printerCheck.Size = new System.Drawing.Size(108, 16);
            this.printerCheck.TabIndex = 5;
            this.printerCheck.Text = "Enable printer";
            this.printerCheck.UseVisualStyleBackColor = true;
            // 
            // fullScreenCheck
            // 
            this.fullScreenCheck.AutoSize = true;
            this.fullScreenCheck.Location = new System.Drawing.Point(13, 77);
            this.fullScreenCheck.Margin = new System.Windows.Forms.Padding(2);
            this.fullScreenCheck.Name = "fullScreenCheck";
            this.fullScreenCheck.Size = new System.Drawing.Size(90, 16);
            this.fullScreenCheck.TabIndex = 4;
            this.fullScreenCheck.Text = "Full screen";
            this.fullScreenCheck.UseVisualStyleBackColor = true;
            // 
            // pcbLabel
            // 
            this.pcbLabel.AutoSize = true;
            this.pcbLabel.Location = new System.Drawing.Point(8, 50);
            this.pcbLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pcbLabel.Name = "pcbLabel";
            this.pcbLabel.Size = new System.Drawing.Size(41, 12);
            this.pcbLabel.TabIndex = 2;
            this.pcbLabel.Text = "PCBID:";
            // 
            // urlCombo
            // 
            this.urlCombo.FormattingEnabled = true;
            this.urlCombo.Location = new System.Drawing.Point(84, 22);
            this.urlCombo.Margin = new System.Windows.Forms.Padding(2);
            this.urlCombo.Name = "urlCombo";
            this.urlCombo.Size = new System.Drawing.Size(176, 20);
            this.urlCombo.TabIndex = 1;
            this.urlCombo.Text = "(Offline)";
            this.urlCombo.SelectedIndexChanged += new System.EventHandler(this.urlCombo_SelectedIndexChanged);
            // 
            // networkLabel
            // 
            this.networkLabel.AutoSize = true;
            this.networkLabel.Location = new System.Drawing.Point(8, 25);
            this.networkLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.networkLabel.Name = "networkLabel";
            this.networkLabel.Size = new System.Drawing.Size(71, 12);
            this.networkLabel.TabIndex = 0;
            this.networkLabel.Text = "Connect to:";
            // 
            // cardBox
            // 
            this.cardBox.Controls.Add(this.bGenerate);
            this.cardBox.Controls.Add(this.bLoad);
            this.cardBox.Controls.Add(this.bCardVerify);
            this.cardBox.Controls.Add(this.cardCombo);
            this.cardBox.Location = new System.Drawing.Point(14, 19);
            this.cardBox.Margin = new System.Windows.Forms.Padding(2);
            this.cardBox.Name = "cardBox";
            this.cardBox.Padding = new System.Windows.Forms.Padding(2);
            this.cardBox.Size = new System.Drawing.Size(356, 85);
            this.cardBox.TabIndex = 1;
            this.cardBox.TabStop = false;
            this.cardBox.Text = "Card number";
            // 
            // bGenerate
            // 
            this.bGenerate.Location = new System.Drawing.Point(274, 18);
            this.bGenerate.Margin = new System.Windows.Forms.Padding(2);
            this.bGenerate.Name = "bGenerate";
            this.bGenerate.Size = new System.Drawing.Size(62, 43);
            this.bGenerate.TabIndex = 3;
            this.bGenerate.Text = "Generate";
            this.bGenerate.UseVisualStyleBackColor = true;
            this.bGenerate.Click += new System.EventHandler(this.bGenerate_Click);
            // 
            // bLoad
            // 
            this.bLoad.Location = new System.Drawing.Point(206, 19);
            this.bLoad.Margin = new System.Windows.Forms.Padding(2);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(62, 43);
            this.bLoad.TabIndex = 2;
            this.bLoad.Text = "Load";
            this.bLoad.UseVisualStyleBackColor = true;
            // 
            // bCardVerify
            // 
            this.bCardVerify.Location = new System.Drawing.Point(136, 19);
            this.bCardVerify.Margin = new System.Windows.Forms.Padding(2);
            this.bCardVerify.Name = "bCardVerify";
            this.bCardVerify.Size = new System.Drawing.Size(62, 43);
            this.bCardVerify.TabIndex = 1;
            this.bCardVerify.Text = "Verify";
            this.bCardVerify.UseVisualStyleBackColor = true;
            this.bCardVerify.Click += new System.EventHandler(this.bCardVerify_Click);
            // 
            // cardCombo
            // 
            this.cardCombo.FormattingEnabled = true;
            this.cardCombo.Location = new System.Drawing.Point(12, 32);
            this.cardCombo.Margin = new System.Windows.Forms.Padding(2);
            this.cardCombo.Name = "cardCombo";
            this.cardCombo.Size = new System.Drawing.Size(120, 20);
            this.cardCombo.TabIndex = 0;
            this.cardCombo.Text = "(Empty)";
            this.cardCombo.SelectedIndexChanged += new System.EventHandler(this.cardCombo_SelectedIndexChanged);
            // 
            // locationBox
            // 
            this.locationBox.Controls.Add(this.bBrowse);
            this.locationBox.Controls.Add(this.pathLabel);
            this.locationBox.Controls.Add(this.bPathVerify);
            this.locationBox.Controls.Add(this.pathBox);
            this.locationBox.Location = new System.Drawing.Point(9, 222);
            this.locationBox.Margin = new System.Windows.Forms.Padding(2);
            this.locationBox.Name = "locationBox";
            this.locationBox.Padding = new System.Windows.Forms.Padding(2);
            this.locationBox.Size = new System.Drawing.Size(218, 145);
            this.locationBox.TabIndex = 2;
            this.locationBox.TabStop = false;
            this.locationBox.Text = "Game path selector";
            // 
            // bBrowse
            // 
            this.bBrowse.Location = new System.Drawing.Point(166, 42);
            this.bBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.bBrowse.Name = "bBrowse";
            this.bBrowse.Size = new System.Drawing.Size(37, 20);
            this.bBrowse.TabIndex = 3;
            this.bBrowse.Text = "...";
            this.bBrowse.UseVisualStyleBackColor = true;
            this.bBrowse.Click += new System.EventHandler(this.bBrowse_Click);
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(19, 17);
            this.pathLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(113, 12);
            this.pathLabel.TabIndex = 2;
            this.pathLabel.Text = "Default game path:";
            // 
            // bPathVerify
            // 
            this.bPathVerify.Location = new System.Drawing.Point(20, 85);
            this.bPathVerify.Margin = new System.Windows.Forms.Padding(2);
            this.bPathVerify.Name = "bPathVerify";
            this.bPathVerify.Size = new System.Drawing.Size(182, 45);
            this.bPathVerify.TabIndex = 1;
            this.bPathVerify.Text = "Verify";
            this.bPathVerify.UseVisualStyleBackColor = true;
            this.bPathVerify.Click += new System.EventHandler(this.bPathVerify_Click);
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(20, 42);
            this.pathBox.Margin = new System.Windows.Forms.Padding(2);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(137, 21);
            this.pathBox.TabIndex = 0;
            this.pathBox.Text = "(root path)";
            // 
            // curentBox
            // 
            this.curentBox.Controls.Add(this.current);
            this.curentBox.Location = new System.Drawing.Point(9, 32);
            this.curentBox.Margin = new System.Windows.Forms.Padding(2);
            this.curentBox.Name = "curentBox";
            this.curentBox.Padding = new System.Windows.Forms.Padding(2);
            this.curentBox.Size = new System.Drawing.Size(218, 46);
            this.curentBox.TabIndex = 3;
            this.curentBox.TabStop = false;
            this.curentBox.Text = "Current Version";
            // 
            // current
            // 
            this.current.AutoSize = true;
            this.current.Location = new System.Drawing.Point(19, 19);
            this.current.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.current.Name = "current";
            this.current.Size = new System.Drawing.Size(59, 12);
            this.current.TabIndex = 0;
            this.current.Text = "Root SDVX";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(633, 25);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.newToolStripMenuItem.Text = "&New Config";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.starterConfigToolStripMenuItem,
            this.ea3configToolStripMenuItem});
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // starterConfigToolStripMenuItem
            // 
            this.starterConfigToolStripMenuItem.Name = "starterConfigToolStripMenuItem";
            this.starterConfigToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.starterConfigToolStripMenuItem.Text = "Starter Config";
            // 
            // ea3configToolStripMenuItem
            // 
            this.ea3configToolStripMenuItem.Name = "ea3configToolStripMenuItem";
            this.ea3configToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.ea3configToolStripMenuItem.Text = "ea3-config";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(192, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.starterConfigToolStripMenuItem1,
            this.ea3configToolStripMenuItem1});
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // starterConfigToolStripMenuItem1
            // 
            this.starterConfigToolStripMenuItem1.Name = "starterConfigToolStripMenuItem1";
            this.starterConfigToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.starterConfigToolStripMenuItem1.Text = "Starter Config";
            // 
            // ea3configToolStripMenuItem1
            // 
            this.ea3configToolStripMenuItem1.Name = "ea3configToolStripMenuItem1";
            this.ea3configToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.ea3configToolStripMenuItem1.Text = "ea3-config";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(192, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.searchToolStripMenuItem.Text = "&Get Help";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(177, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // SDVX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 374);
            this.Controls.Add(this.curentBox);
            this.Controls.Add(this.locationBox);
            this.Controls.Add(this.configBox);
            this.Controls.Add(this.versionBox);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SDVX";
            this.Text = "SDVX Starter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.versionBox.ResumeLayout(false);
            this.versionBox.PerformLayout();
            this.configBox.ResumeLayout(false);
            this.optionBox.ResumeLayout(false);
            this.optionBox.PerformLayout();
            this.cardBox.ResumeLayout(false);
            this.locationBox.ResumeLayout(false);
            this.locationBox.PerformLayout();
            this.curentBox.ResumeLayout(false);
            this.curentBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox versionBox;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Button bStarter;
        private System.Windows.Forms.GroupBox configBox;
        private System.Windows.Forms.GroupBox optionBox;
        private System.Windows.Forms.ComboBox urlCombo;
        private System.Windows.Forms.Label networkLabel;
        private System.Windows.Forms.GroupBox cardBox;
        private System.Windows.Forms.GroupBox locationBox;
        private System.Windows.Forms.Button bPathVerify;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Label pcbLabel;
        private System.Windows.Forms.CheckBox fullScreenCheck;
        private System.Windows.Forms.CheckBox sslCheck;
        private System.Windows.Forms.CheckBox printerCheck;
        private System.Windows.Forms.Button bCardVerify;
        private System.Windows.Forms.ComboBox cardCombo;
        private System.Windows.Forms.Button bSpiceConfig;
        private System.Windows.Forms.Button bLoad;
        private System.Windows.Forms.Button bGenerate;
        private System.Windows.Forms.CheckBox urlCheck;
        private System.Windows.Forms.CheckBox hdCheck;
        private System.Windows.Forms.ComboBox versionCombo;
        private System.Windows.Forms.Button bImport;
        private System.Windows.Forms.Button bBrowse;
        private System.Windows.Forms.GroupBox curentBox;
        private System.Windows.Forms.Label current;
        private System.Windows.Forms.Button bStarter64;
        private System.Windows.Forms.ComboBox pcbidCombo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem starterConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ea3configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem starterConfigToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ea3configToolStripMenuItem1;
    }
}

