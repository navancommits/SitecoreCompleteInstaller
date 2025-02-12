namespace SCIA
{
    partial class SolrInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolrInstaller));
            this.txtSolrVersion = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnInstall = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lnkJavaDownloadUrl = new System.Windows.Forms.LinkLabel();
            this.txtJavaDownloadUrl = new System.Windows.Forms.TextBox();
            this.txtSolrPrefix = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSolrDomain = new System.Windows.Forms.TextBox();
            this.txtSolrUrl = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSolrPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSolrService = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSolrRoot = new System.Windows.Forms.TextBox();
            this.toolTipSolrInstaller = new System.Windows.Forms.ToolTip(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtSolrSrc = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSolrVersion
            // 
            this.txtSolrVersion.Location = new System.Drawing.Point(209, 19);
            this.txtSolrVersion.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtSolrVersion.MaxLength = 7;
            this.txtSolrVersion.Name = "txtSolrVersion";
            this.txtSolrVersion.Size = new System.Drawing.Size(827, 31);
            this.txtSolrVersion.TabIndex = 71;
            this.txtSolrVersion.Text = "8.4.0";
            this.toolTipSolrInstaller.SetToolTip(this.txtSolrVersion, "Enter Valid Solr Versions based on https://archive.apache.org/dist/lucene/solr/");
            this.txtSolrVersion.TextChanged += new System.EventHandler(this.txtSolrVersion_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(29, 21);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(158, 154);
            this.panel1.TabIndex = 70;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.label25.Location = new System.Drawing.Point(202, 21);
            this.label25.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(950, 154);
            this.label25.TabIndex = 69;
            this.label25.Text = "Solr Installer";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 25);
            this.label1.TabIndex = 63;
            this.label1.Text = "Solr Version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 25);
            this.label2.TabIndex = 64;
            this.label2.Text = "Solr Root:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(552, 25);
            this.label3.TabIndex = 75;
            this.label3.Text = "Provide Solr info to download and install automatically....";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblStatus.Location = new System.Drawing.Point(30, 798);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1122, 38);
            this.lblStatus.TabIndex = 74;
            this.lblStatus.Text = "Happy Sitecoring!";
            // 
            // btnInstall
            // 
            this.btnInstall.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnInstall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInstall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInstall.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnInstall.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInstall.Location = new System.Drawing.Point(972, 737);
            this.btnInstall.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(180, 48);
            this.btnInstall.TabIndex = 73;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = false;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(30, 247);
            this.panel2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1122, 458);
            this.panel2.TabIndex = 76;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel3.Controls.Add(this.linkLabel1);
            this.panel3.Controls.Add(this.txtSolrSrc);
            this.panel3.Controls.Add(this.txtSolrVersion);
            this.panel3.Controls.Add(this.lnkJavaDownloadUrl);
            this.panel3.Controls.Add(this.txtJavaDownloadUrl);
            this.panel3.Controls.Add(this.txtSolrPrefix);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtSolrDomain);
            this.panel3.Controls.Add(this.txtSolrUrl);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtSolrPort);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtSolrService);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtSolrRoot);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(9, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1053, 395);
            this.panel3.TabIndex = 0;
            // 
            // lnkJavaDownloadUrl
            // 
            this.lnkJavaDownloadUrl.AutoSize = true;
            this.lnkJavaDownloadUrl.Location = new System.Drawing.Point(15, 294);
            this.lnkJavaDownloadUrl.Name = "lnkJavaDownloadUrl";
            this.lnkJavaDownloadUrl.Size = new System.Drawing.Size(186, 25);
            this.lnkJavaDownloadUrl.TabIndex = 85;
            this.lnkJavaDownloadUrl.TabStop = true;
            this.lnkJavaDownloadUrl.Text = "JavaDownloadUrl:";
            this.lnkJavaDownloadUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkJavaDownloadUrl_LinkClicked);
            // 
            // txtJavaDownloadUrl
            // 
            this.txtJavaDownloadUrl.Location = new System.Drawing.Point(209, 291);
            this.txtJavaDownloadUrl.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtJavaDownloadUrl.MaxLength = 1000;
            this.txtJavaDownloadUrl.Name = "txtJavaDownloadUrl";
            this.txtJavaDownloadUrl.Size = new System.Drawing.Size(827, 31);
            this.txtJavaDownloadUrl.TabIndex = 84;
            this.txtJavaDownloadUrl.Text = "https://github.com/AdoptOpenJDK/openjdk8-binaries/releases/download/jdk8u242-b08/" +
    "OpenJDK8U-jre_x64_windows_hotspot_8u242b08.zip";
            // 
            // txtSolrPrefix
            // 
            this.txtSolrPrefix.Location = new System.Drawing.Point(209, 96);
            this.txtSolrPrefix.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtSolrPrefix.MaxLength = 100;
            this.txtSolrPrefix.Name = "txtSolrPrefix";
            this.txtSolrPrefix.Size = new System.Drawing.Size(827, 31);
            this.txtSolrPrefix.TabIndex = 82;
            this.txtSolrPrefix.TextChanged += new System.EventHandler(this.txtSolrPrefix_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 25);
            this.label8.TabIndex = 81;
            this.label8.Text = "Solr Prefix:";
            // 
            // txtSolrDomain
            // 
            this.txtSolrDomain.Enabled = false;
            this.txtSolrDomain.Location = new System.Drawing.Point(209, 58);
            this.txtSolrDomain.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtSolrDomain.MaxLength = 100;
            this.txtSolrDomain.Name = "txtSolrDomain";
            this.txtSolrDomain.Size = new System.Drawing.Size(827, 31);
            this.txtSolrDomain.TabIndex = 80;
            this.txtSolrDomain.Text = "localhost";
            // 
            // txtSolrUrl
            // 
            this.txtSolrUrl.Enabled = false;
            this.txtSolrUrl.Location = new System.Drawing.Point(209, 252);
            this.txtSolrUrl.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtSolrUrl.MaxLength = 100;
            this.txtSolrUrl.Name = "txtSolrUrl";
            this.txtSolrUrl.Size = new System.Drawing.Size(827, 31);
            this.txtSolrUrl.TabIndex = 78;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 25);
            this.label7.TabIndex = 79;
            this.label7.Text = "Solr Domain:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 25);
            this.label6.TabIndex = 77;
            this.label6.Text = "Solr Url:";
            // 
            // txtSolrPort
            // 
            this.txtSolrPort.Location = new System.Drawing.Point(209, 213);
            this.txtSolrPort.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtSolrPort.MaxLength = 100;
            this.txtSolrPort.Name = "txtSolrPort";
            this.txtSolrPort.Size = new System.Drawing.Size(827, 31);
            this.txtSolrPort.TabIndex = 76;
            this.txtSolrPort.Text = "8983";
            this.txtSolrPort.TextChanged += new System.EventHandler(this.txtSolrPort_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 25);
            this.label5.TabIndex = 75;
            this.label5.Text = "Solr Port:";
            // 
            // txtSolrService
            // 
            this.txtSolrService.Location = new System.Drawing.Point(209, 174);
            this.txtSolrService.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtSolrService.MaxLength = 100;
            this.txtSolrService.Name = "txtSolrService";
            this.txtSolrService.Size = new System.Drawing.Size(827, 31);
            this.txtSolrService.TabIndex = 74;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 25);
            this.label4.TabIndex = 73;
            this.label4.Text = "Solr Service:";
            // 
            // txtSolrRoot
            // 
            this.txtSolrRoot.Location = new System.Drawing.Point(209, 135);
            this.txtSolrRoot.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtSolrRoot.MaxLength = 100;
            this.txtSolrRoot.Name = "txtSolrRoot";
            this.txtSolrRoot.Size = new System.Drawing.Size(827, 31);
            this.txtSolrRoot.TabIndex = 72;
            this.txtSolrRoot.Text = "c:\\solr";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(15, 333);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(151, 25);
            this.linkLabel1.TabIndex = 87;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "SolrSourceUrl:";
            // 
            // txtSolrSrc
            // 
            this.txtSolrSrc.Location = new System.Drawing.Point(209, 330);
            this.txtSolrSrc.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtSolrSrc.MaxLength = 1000;
            this.txtSolrSrc.Name = "txtSolrSrc";
            this.txtSolrSrc.Size = new System.Drawing.Size(827, 31);
            this.txtSolrSrc.TabIndex = 86;
            this.txtSolrSrc.Text = "http://archive.apache.org/dist/lucene/solr";
            // 
            // SolrInstaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 845);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SolrInstaller";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SCIA - Solr Installer";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSolrVersion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtSolrUrl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSolrPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSolrService;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSolrRoot;
        private System.Windows.Forms.TextBox txtSolrPrefix;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSolrDomain;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtJavaDownloadUrl;
        private System.Windows.Forms.LinkLabel lnkJavaDownloadUrl;
        private System.Windows.Forms.ToolTip toolTipSolrInstaller;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox txtSolrSrc;
    }
}