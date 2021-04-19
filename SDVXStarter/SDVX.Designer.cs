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
            this.versionGroup = new System.Windows.Forms.GroupBox();
            this.bStarter64 = new System.Windows.Forms.Button();
            this.pathCombo = new System.Windows.Forms.ComboBox();
            this.bStarter = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.configGroup = new System.Windows.Forms.GroupBox();
            this.hdCheck = new System.Windows.Forms.CheckBox();
            this.optionBox = new System.Windows.Forms.GroupBox();
            this.apiCheck = new System.Windows.Forms.CheckBox();
            this.pcbidCombo = new System.Windows.Forms.ComboBox();
            this.bImport = new System.Windows.Forms.Button();
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
            this.bSpiceConfig = new System.Windows.Forms.Button();
            this.pathGroup = new System.Windows.Forms.GroupBox();
            this.bBrowse = new System.Windows.Forms.Button();
            this.pathLabel = new System.Windows.Forms.Label();
            this.bPathVerify = new System.Windows.Forms.Button();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.curentGroup = new System.Windows.Forms.GroupBox();
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
            this.starterConfigToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ea3configToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreDefaultCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出选项为batBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apiGroup = new System.Windows.Forms.GroupBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.portBox = new System.Windows.Forms.TextBox();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.versionGroup.SuspendLayout();
            this.configGroup.SuspendLayout();
            this.optionBox.SuspendLayout();
            this.cardBox.SuspendLayout();
            this.pathGroup.SuspendLayout();
            this.curentGroup.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.apiGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // versionGroup
            // 
            this.versionGroup.Controls.Add(this.bStarter64);
            this.versionGroup.Controls.Add(this.pathCombo);
            this.versionGroup.Controls.Add(this.bStarter);
            this.versionGroup.Controls.Add(this.versionLabel);
            this.versionGroup.Location = new System.Drawing.Point(12, 104);
            this.versionGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.versionGroup.Name = "versionGroup";
            this.versionGroup.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.versionGroup.Size = new System.Drawing.Size(291, 168);
            this.versionGroup.TabIndex = 0;
            this.versionGroup.TabStop = false;
            this.versionGroup.Text = "版本选择";
            // 
            // bStarter64
            // 
            this.bStarter64.Location = new System.Drawing.Point(156, 78);
            this.bStarter64.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bStarter64.Name = "bStarter64";
            this.bStarter64.Size = new System.Drawing.Size(115, 72);
            this.bStarter64.TabIndex = 4;
            this.bStarter64.Text = "启动spice64 (64位)";
            this.bStarter64.UseVisualStyleBackColor = true;
            this.bStarter64.Click += new System.EventHandler(this.bStarter64_Click);
            // 
            // pathCombo
            // 
            this.pathCombo.AllowDrop = true;
            this.pathCombo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pathCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pathCombo.FormattingEnabled = true;
            this.pathCombo.Location = new System.Drawing.Point(27, 48);
            this.pathCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pathCombo.Name = "pathCombo";
            this.pathCombo.Size = new System.Drawing.Size(243, 23);
            this.pathCombo.TabIndex = 3;
            this.pathCombo.SelectedIndexChanged += new System.EventHandler(this.versionCombo_SelectedIndexChanged);
            // 
            // bStarter
            // 
            this.bStarter.Location = new System.Drawing.Point(27, 78);
            this.bStarter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bStarter.Name = "bStarter";
            this.bStarter.Size = new System.Drawing.Size(115, 72);
            this.bStarter.TabIndex = 2;
            this.bStarter.Text = "启动spice (32位)";
            this.bStarter.UseVisualStyleBackColor = true;
            this.bStarter.Click += new System.EventHandler(this.bStarter_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(24, 21);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(187, 15);
            this.versionLabel.TabIndex = 1;
            this.versionLabel.Text = "从下拉菜单选择一个版本：";
            // 
            // configGroup
            // 
            this.configGroup.Controls.Add(this.optionBox);
            this.configGroup.Controls.Add(this.cardBox);
            this.configGroup.Location = new System.Drawing.Point(331, 40);
            this.configGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.configGroup.Name = "configGroup";
            this.configGroup.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.configGroup.Size = new System.Drawing.Size(500, 389);
            this.configGroup.TabIndex = 1;
            this.configGroup.TabStop = false;
            this.configGroup.Text = "快速配置";
            // 
            // hdCheck
            // 
            this.hdCheck.AutoSize = true;
            this.hdCheck.Location = new System.Drawing.Point(320, 131);
            this.hdCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hdCheck.Name = "hdCheck";
            this.hdCheck.Size = new System.Drawing.Size(91, 19);
            this.hdCheck.TabIndex = 10;
            this.hdCheck.Text = "强制720p";
            this.hdCheck.UseVisualStyleBackColor = true;
            // 
            // optionBox
            // 
            this.optionBox.Controls.Add(this.apiCheck);
            this.optionBox.Controls.Add(this.pcbidCombo);
            this.optionBox.Controls.Add(this.hdCheck);
            this.optionBox.Controls.Add(this.bImport);
            this.optionBox.Controls.Add(this.urlCheck);
            this.optionBox.Controls.Add(this.sslCheck);
            this.optionBox.Controls.Add(this.printerCheck);
            this.optionBox.Controls.Add(this.fullScreenCheck);
            this.optionBox.Controls.Add(this.pcbLabel);
            this.optionBox.Controls.Add(this.urlCombo);
            this.optionBox.Controls.Add(this.networkLabel);
            this.optionBox.Location = new System.Drawing.Point(19, 136);
            this.optionBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.optionBox.Name = "optionBox";
            this.optionBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.optionBox.Size = new System.Drawing.Size(475, 160);
            this.optionBox.TabIndex = 2;
            this.optionBox.TabStop = false;
            this.optionBox.Text = "启动选项";
            // 
            // apiCheck
            // 
            this.apiCheck.AutoSize = true;
            this.apiCheck.Location = new System.Drawing.Point(320, 96);
            this.apiCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.apiCheck.Name = "apiCheck";
            this.apiCheck.Size = new System.Drawing.Size(119, 19);
            this.apiCheck.TabIndex = 14;
            this.apiCheck.Text = "使用助手程序";
            this.apiCheck.UseVisualStyleBackColor = true;
            this.apiCheck.CheckedChanged += new System.EventHandler(this.apiBox_CheckedChanged);
            // 
            // pcbidCombo
            // 
            this.pcbidCombo.FormattingEnabled = true;
            this.pcbidCombo.Location = new System.Drawing.Point(112, 59);
            this.pcbidCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pcbidCombo.Name = "pcbidCombo";
            this.pcbidCombo.Size = new System.Drawing.Size(233, 23);
            this.pcbidCombo.TabIndex = 12;
            this.pcbidCombo.Text = "(Default)";
            this.pcbidCombo.SelectedIndexChanged += new System.EventHandler(this.pcbidCombo_SelectedIndexChanged);
            // 
            // bImport
            // 
            this.bImport.Location = new System.Drawing.Point(365, 28);
            this.bImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bImport.Name = "bImport";
            this.bImport.Size = new System.Drawing.Size(83, 54);
            this.bImport.TabIndex = 11;
            this.bImport.Text = "从ea3导入";
            this.bImport.UseVisualStyleBackColor = true;
            this.bImport.Click += new System.EventHandler(this.bImport_Click);
            // 
            // urlCheck
            // 
            this.urlCheck.AutoSize = true;
            this.urlCheck.Location = new System.Drawing.Point(173, 131);
            this.urlCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.urlCheck.Name = "urlCheck";
            this.urlCheck.Size = new System.Drawing.Size(131, 19);
            this.urlCheck.TabIndex = 8;
            this.urlCheck.Text = "启用URL Slash";
            this.urlCheck.UseVisualStyleBackColor = true;
            // 
            // sslCheck
            // 
            this.sslCheck.AutoSize = true;
            this.sslCheck.Location = new System.Drawing.Point(173, 96);
            this.sslCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sslCheck.Name = "sslCheck";
            this.sslCheck.Size = new System.Drawing.Size(113, 19);
            this.sslCheck.TabIndex = 6;
            this.sslCheck.Text = "禁用SSL连接";
            this.sslCheck.UseVisualStyleBackColor = true;
            // 
            // printerCheck
            // 
            this.printerCheck.AutoSize = true;
            this.printerCheck.Location = new System.Drawing.Point(16, 131);
            this.printerCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.printerCheck.Name = "printerCheck";
            this.printerCheck.Size = new System.Drawing.Size(104, 19);
            this.printerCheck.TabIndex = 5;
            this.printerCheck.Text = "启用印卡机";
            this.printerCheck.UseVisualStyleBackColor = true;
            // 
            // fullScreenCheck
            // 
            this.fullScreenCheck.AutoSize = true;
            this.fullScreenCheck.Location = new System.Drawing.Point(17, 96);
            this.fullScreenCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fullScreenCheck.Name = "fullScreenCheck";
            this.fullScreenCheck.Size = new System.Drawing.Size(59, 19);
            this.fullScreenCheck.TabIndex = 4;
            this.fullScreenCheck.Text = "全屏";
            this.fullScreenCheck.UseVisualStyleBackColor = true;
            // 
            // pcbLabel
            // 
            this.pcbLabel.AutoSize = true;
            this.pcbLabel.Location = new System.Drawing.Point(11, 62);
            this.pcbLabel.Name = "pcbLabel";
            this.pcbLabel.Size = new System.Drawing.Size(55, 15);
            this.pcbLabel.TabIndex = 2;
            this.pcbLabel.Text = "PCBID:";
            // 
            // urlCombo
            // 
            this.urlCombo.FormattingEnabled = true;
            this.urlCombo.Location = new System.Drawing.Point(112, 28);
            this.urlCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.urlCombo.Name = "urlCombo";
            this.urlCombo.Size = new System.Drawing.Size(233, 23);
            this.urlCombo.TabIndex = 1;
            this.urlCombo.Text = "(Offline)";
            this.urlCombo.SelectedIndexChanged += new System.EventHandler(this.urlCombo_SelectedIndexChanged);
            // 
            // networkLabel
            // 
            this.networkLabel.AutoSize = true;
            this.networkLabel.Location = new System.Drawing.Point(11, 31);
            this.networkLabel.Name = "networkLabel";
            this.networkLabel.Size = new System.Drawing.Size(52, 15);
            this.networkLabel.TabIndex = 0;
            this.networkLabel.Text = "连接至";
            // 
            // cardBox
            // 
            this.cardBox.Controls.Add(this.bGenerate);
            this.cardBox.Controls.Add(this.bLoad);
            this.cardBox.Controls.Add(this.bCardVerify);
            this.cardBox.Controls.Add(this.cardCombo);
            this.cardBox.Location = new System.Drawing.Point(19, 24);
            this.cardBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cardBox.Name = "cardBox";
            this.cardBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cardBox.Size = new System.Drawing.Size(475, 106);
            this.cardBox.TabIndex = 1;
            this.cardBox.TabStop = false;
            this.cardBox.Text = "卡号";
            // 
            // bGenerate
            // 
            this.bGenerate.Location = new System.Drawing.Point(365, 22);
            this.bGenerate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bGenerate.Name = "bGenerate";
            this.bGenerate.Size = new System.Drawing.Size(83, 54);
            this.bGenerate.TabIndex = 3;
            this.bGenerate.Text = "生成并添加";
            this.bGenerate.UseVisualStyleBackColor = true;
            this.bGenerate.Click += new System.EventHandler(this.bGenerate_Click);
            // 
            // bLoad
            // 
            this.bLoad.Location = new System.Drawing.Point(275, 24);
            this.bLoad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(83, 54);
            this.bLoad.TabIndex = 2;
            this.bLoad.Text = "从txt加载";
            this.bLoad.UseVisualStyleBackColor = true;
            this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
            // 
            // bCardVerify
            // 
            this.bCardVerify.Location = new System.Drawing.Point(181, 24);
            this.bCardVerify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bCardVerify.Name = "bCardVerify";
            this.bCardVerify.Size = new System.Drawing.Size(83, 54);
            this.bCardVerify.TabIndex = 1;
            this.bCardVerify.Text = "验证并添加";
            this.bCardVerify.UseVisualStyleBackColor = true;
            this.bCardVerify.Click += new System.EventHandler(this.bCardVerify_Click);
            // 
            // cardCombo
            // 
            this.cardCombo.FormattingEnabled = true;
            this.cardCombo.Location = new System.Drawing.Point(16, 40);
            this.cardCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cardCombo.Name = "cardCombo";
            this.cardCombo.Size = new System.Drawing.Size(159, 23);
            this.cardCombo.TabIndex = 0;
            this.cardCombo.Text = "(Empty)";
            this.cardCombo.SelectedIndexChanged += new System.EventHandler(this.cardCombo_SelectedIndexChanged);
            // 
            // bSpiceConfig
            // 
            this.bSpiceConfig.Location = new System.Drawing.Point(735, 440);
            this.bSpiceConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bSpiceConfig.Name = "bSpiceConfig";
            this.bSpiceConfig.Size = new System.Drawing.Size(95, 90);
            this.bSpiceConfig.TabIndex = 7;
            this.bSpiceConfig.Text = "打开spicecfg配置程序";
            this.bSpiceConfig.UseVisualStyleBackColor = true;
            this.bSpiceConfig.Click += new System.EventHandler(this.bSpiceConfig_Click);
            // 
            // pathGroup
            // 
            this.pathGroup.Controls.Add(this.bBrowse);
            this.pathGroup.Controls.Add(this.pathLabel);
            this.pathGroup.Controls.Add(this.bPathVerify);
            this.pathGroup.Controls.Add(this.pathBox);
            this.pathGroup.Location = new System.Drawing.Point(15, 276);
            this.pathGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pathGroup.Name = "pathGroup";
            this.pathGroup.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pathGroup.Size = new System.Drawing.Size(291, 181);
            this.pathGroup.TabIndex = 2;
            this.pathGroup.TabStop = false;
            this.pathGroup.Text = "路径/版本添加器";
            // 
            // bBrowse
            // 
            this.bBrowse.Location = new System.Drawing.Point(221, 52);
            this.bBrowse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bBrowse.Name = "bBrowse";
            this.bBrowse.Size = new System.Drawing.Size(49, 25);
            this.bBrowse.TabIndex = 3;
            this.bBrowse.Text = "...";
            this.bBrowse.UseVisualStyleBackColor = true;
            this.bBrowse.Click += new System.EventHandler(this.bBrowse_Click);
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(25, 21);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(172, 15);
            this.pathLabel.TabIndex = 2;
            this.pathLabel.Text = "程序将会验证下列路径：";
            // 
            // bPathVerify
            // 
            this.bPathVerify.Location = new System.Drawing.Point(27, 106);
            this.bPathVerify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bPathVerify.Name = "bPathVerify";
            this.bPathVerify.Size = new System.Drawing.Size(243, 56);
            this.bPathVerify.TabIndex = 1;
            this.bPathVerify.Text = "验证";
            this.bPathVerify.UseVisualStyleBackColor = true;
            this.bPathVerify.Click += new System.EventHandler(this.bPathVerify_Click);
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(27, 52);
            this.pathBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(181, 25);
            this.pathBox.TabIndex = 0;
            this.pathBox.Text = "(root path)";
            // 
            // curentGroup
            // 
            this.curentGroup.Controls.Add(this.current);
            this.curentGroup.Location = new System.Drawing.Point(12, 40);
            this.curentGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.curentGroup.Name = "curentGroup";
            this.curentGroup.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.curentGroup.Size = new System.Drawing.Size(291, 58);
            this.curentGroup.TabIndex = 3;
            this.curentGroup.TabStop = false;
            this.curentGroup.Text = "当前选中版本";
            // 
            // current
            // 
            this.current.AutoSize = true;
            this.current.Location = new System.Drawing.Point(25, 24);
            this.current.Name = "current";
            this.current.Size = new System.Drawing.Size(79, 15);
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(844, 28);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.fileToolStripMenuItem.Text = "文件(&F)";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.newToolStripMenuItem.Text = "新配置(N)";
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
            this.openToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.openToolStripMenuItem.Text = "打开(&O)";
            // 
            // starterConfigToolStripMenuItem
            // 
            this.starterConfigToolStripMenuItem.Name = "starterConfigToolStripMenuItem";
            this.starterConfigToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.starterConfigToolStripMenuItem.Text = "启动器配置";
            this.starterConfigToolStripMenuItem.Click += new System.EventHandler(this.starterConfigToolStripMenuItem_Click);
            // 
            // ea3configToolStripMenuItem
            // 
            this.ea3configToolStripMenuItem.Name = "ea3configToolStripMenuItem";
            this.ea3configToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.ea3configToolStripMenuItem.Text = "ea3-config";
            this.ea3configToolStripMenuItem.Click += new System.EventHandler(this.ea3configToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(214, 6);
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
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.saveToolStripMenuItem.Text = "保存(&S)";
            // 
            // starterConfigToolStripMenuItem1
            // 
            this.starterConfigToolStripMenuItem1.Name = "starterConfigToolStripMenuItem1";
            this.starterConfigToolStripMenuItem1.Size = new System.Drawing.Size(170, 26);
            this.starterConfigToolStripMenuItem1.Text = "启动器配置";
            this.starterConfigToolStripMenuItem1.Click += new System.EventHandler(this.starterConfigToolStripMenuItem1_Click);
            // 
            // ea3configToolStripMenuItem1
            // 
            this.ea3configToolStripMenuItem1.Name = "ea3configToolStripMenuItem1";
            this.ea3configToolStripMenuItem1.Size = new System.Drawing.Size(170, 26);
            this.ea3configToolStripMenuItem1.Text = "ea3-config";
            this.ea3configToolStripMenuItem1.Click += new System.EventHandler(this.ea3configToolStripMenuItem1_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.starterConfigToolStripMenuItem2,
            this.ea3configToolStripMenuItem2});
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.saveAsToolStripMenuItem.Text = "另存为(&A)";
            // 
            // starterConfigToolStripMenuItem2
            // 
            this.starterConfigToolStripMenuItem2.Name = "starterConfigToolStripMenuItem2";
            this.starterConfigToolStripMenuItem2.Size = new System.Drawing.Size(170, 26);
            this.starterConfigToolStripMenuItem2.Text = "启动器配置";
            this.starterConfigToolStripMenuItem2.Click += new System.EventHandler(this.starterConfigToolStripMenuItem2_Click);
            // 
            // ea3configToolStripMenuItem2
            // 
            this.ea3configToolStripMenuItem2.Name = "ea3configToolStripMenuItem2";
            this.ea3configToolStripMenuItem2.Size = new System.Drawing.Size(170, 26);
            this.ea3configToolStripMenuItem2.Text = "ea3-config";
            this.ea3configToolStripMenuItem2.Click += new System.EventHandler(this.ea3configToolStripMenuItem2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(214, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(214, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.exitToolStripMenuItem.Text = "退出(&X)";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.restoreDefaultCommandToolStripMenuItem,
            this.导出选项为batBToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.toolsToolStripMenuItem.Text = "工具(&T)";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.customizeToolStripMenuItem.Text = "ea3-config修改器(&E)";
            this.customizeToolStripMenuItem.Click += new System.EventHandler(this.customizeToolStripMenuItem_Click);
            // 
            // restoreDefaultCommandToolStripMenuItem
            // 
            this.restoreDefaultCommandToolStripMenuItem.Name = "restoreDefaultCommandToolStripMenuItem";
            this.restoreDefaultCommandToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.restoreDefaultCommandToolStripMenuItem.Text = "重置选项命令(&R)";
            this.restoreDefaultCommandToolStripMenuItem.Click += new System.EventHandler(this.restoreDefaultCommandToolStripMenuItem_Click);
            // 
            // 导出选项为batBToolStripMenuItem
            // 
            this.导出选项为batBToolStripMenuItem.Name = "导出选项为batBToolStripMenuItem";
            this.导出选项为batBToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.导出选项为batBToolStripMenuItem.Text = "导出选项为bat (&B)";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.helpToolStripMenuItem.Text = "帮助(H)";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.searchToolStripMenuItem.Text = "求助(G)";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(140, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.aboutToolStripMenuItem.Text = "关于(A)";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // apiGroup
            // 
            this.apiGroup.Controls.Add(this.passwordLabel);
            this.apiGroup.Controls.Add(this.portLabel);
            this.apiGroup.Controls.Add(this.passwordBox);
            this.apiGroup.Controls.Add(this.portBox);
            this.apiGroup.Location = new System.Drawing.Point(331, 435);
            this.apiGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.apiGroup.Name = "apiGroup";
            this.apiGroup.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.apiGroup.Size = new System.Drawing.Size(384, 95);
            this.apiGroup.TabIndex = 8;
            this.apiGroup.TabStop = false;
            this.apiGroup.Text = "Spice助手程序设定";
            this.apiGroup.Visible = false;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(136, 26);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(82, 15);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "连接密码：";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(13, 25);
            this.portLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(82, 15);
            this.portLabel.TabIndex = 2;
            this.portLabel.Text = "使用端口：";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(133, 46);
            this.passwordBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(229, 25);
            this.passwordBox.TabIndex = 1;
            this.passwordBox.Text = "0000";
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(12, 48);
            this.portBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(109, 25);
            this.portBox.TabIndex = 0;
            this.portBox.Text = "8080";
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(12, 466);
            this.GenerateButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(293, 62);
            this.GenerateButton.TabIndex = 9;
            this.GenerateButton.Text = "将本页面配置导出为批处理文件";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // SDVX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 545);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.apiGroup);
            this.Controls.Add(this.bSpiceConfig);
            this.Controls.Add(this.curentGroup);
            this.Controls.Add(this.pathGroup);
            this.Controls.Add(this.configGroup);
            this.Controls.Add(this.versionGroup);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SDVX";
            this.Text = "SDVX 启动器 By 顾问 Neskol";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.versionGroup.ResumeLayout(false);
            this.versionGroup.PerformLayout();
            this.configGroup.ResumeLayout(false);
            this.optionBox.ResumeLayout(false);
            this.optionBox.PerformLayout();
            this.cardBox.ResumeLayout(false);
            this.pathGroup.ResumeLayout(false);
            this.pathGroup.PerformLayout();
            this.curentGroup.ResumeLayout(false);
            this.curentGroup.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.apiGroup.ResumeLayout(false);
            this.apiGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox versionGroup;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Button bStarter;
        private System.Windows.Forms.GroupBox configGroup;
        private System.Windows.Forms.GroupBox optionBox;
        private System.Windows.Forms.ComboBox urlCombo;
        private System.Windows.Forms.Label networkLabel;
        private System.Windows.Forms.GroupBox cardBox;
        private System.Windows.Forms.GroupBox pathGroup;
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
        private System.Windows.Forms.ComboBox pathCombo;
        private System.Windows.Forms.Button bImport;
        private System.Windows.Forms.Button bBrowse;
        private System.Windows.Forms.GroupBox curentGroup;
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
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem starterConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ea3configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem starterConfigToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ea3configToolStripMenuItem1;
        private System.Windows.Forms.CheckBox apiCheck;
        private System.Windows.Forms.GroupBox apiGroup;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.ToolStripMenuItem restoreDefaultCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem starterConfigToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ea3configToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 导出选项为batBToolStripMenuItem;
        private System.Windows.Forms.Button GenerateButton;
    }
}

