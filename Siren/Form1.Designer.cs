namespace Siren
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLabelRightAlign = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLabelFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.labelSellFormula = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelBuy = new System.Windows.Forms.Label();
            this.labelSellMult = new System.Windows.Forms.Label();
            this.labelSell = new System.Windows.Forms.Label();
            this.numSellMult = new System.Windows.Forms.NumericUpDown();
            this.numBuy = new System.Windows.Forms.NumericUpDown();
            this.panelSellPrice = new System.Windows.Forms.Panel();
            this.labelSellPrice = new System.Windows.Forms.Label();
            this.cbLanguages = new System.Windows.Forms.ComboBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.buttonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonAbout = new System.Windows.Forms.ToolStripButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lbItems = new Siren.ListBoxEx();
            this.statusStrip.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSellMult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBuy)).BeginInit();
            this.panelSellPrice.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.LightGray;
            this.statusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelStatus,
            this.toolStripLabelRightAlign,
            this.toolStripLabelFile});
            this.statusStrip.Location = new System.Drawing.Point(0, 524);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(434, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 37;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripLabelStatus
            // 
            this.toolStripLabelStatus.BackColor = System.Drawing.Color.Transparent;
            this.toolStripLabelStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabelStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripLabelStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripLabelStatus.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.toolStripLabelStatus.Name = "toolStripLabelStatus";
            this.toolStripLabelStatus.Size = new System.Drawing.Size(39, 18);
            this.toolStripLabelStatus.Text = "Ready";
            // 
            // toolStripLabelRightAlign
            // 
            this.toolStripLabelRightAlign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabelRightAlign.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.toolStripLabelRightAlign.Name = "toolStripLabelRightAlign";
            this.toolStripLabelRightAlign.Size = new System.Drawing.Size(299, 17);
            this.toolStripLabelRightAlign.Spring = true;
            // 
            // toolStripLabelFile
            // 
            this.toolStripLabelFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabelFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripLabelFile.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.toolStripLabelFile.Name = "toolStripLabelFile";
            this.toolStripLabelFile.Size = new System.Drawing.Size(81, 18);
            this.toolStripLabelFile.Text = "No file loaded";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.lbItems);
            this.panelMain.Controls.Add(this.labelSellFormula);
            this.panelMain.Controls.Add(this.panel2);
            this.panelMain.Location = new System.Drawing.Point(-2, 25);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(441, 499);
            this.panelMain.TabIndex = 36;
            // 
            // labelSellFormula
            // 
            this.labelSellFormula.Font = new System.Drawing.Font("Arial", 8F);
            this.labelSellFormula.Location = new System.Drawing.Point(138, 480);
            this.labelSellFormula.Name = "labelSellFormula";
            this.labelSellFormula.Size = new System.Drawing.Size(295, 14);
            this.labelSellFormula.TabIndex = 40;
            this.labelSellFormula.Text = "*Sell Price = ((Buy Price / 10) / 2) * Sell Mult";
            this.labelSellFormula.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelBuy);
            this.panel2.Controls.Add(this.labelSellMult);
            this.panel2.Controls.Add(this.labelSell);
            this.panel2.Controls.Add(this.numSellMult);
            this.panel2.Controls.Add(this.numBuy);
            this.panel2.Controls.Add(this.panelSellPrice);
            this.panel2.Location = new System.Drawing.Point(135, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 155);
            this.panel2.TabIndex = 36;
            // 
            // labelBuy
            // 
            this.labelBuy.AutoSize = true;
            this.labelBuy.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBuy.Location = new System.Drawing.Point(6, 11);
            this.labelBuy.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.labelBuy.Name = "labelBuy";
            this.labelBuy.Size = new System.Drawing.Size(85, 17);
            this.labelBuy.TabIndex = 32;
            this.labelBuy.Text = "Buy Price (G)";
            // 
            // labelSellMult
            // 
            this.labelSellMult.AutoSize = true;
            this.labelSellMult.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSellMult.Location = new System.Drawing.Point(6, 38);
            this.labelSellMult.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.labelSellMult.Name = "labelSellMult";
            this.labelSellMult.Size = new System.Drawing.Size(122, 17);
            this.labelSellMult.TabIndex = 32;
            this.labelSellMult.Text = "Sell Price Multiplier";
            // 
            // labelSell
            // 
            this.labelSell.AutoSize = true;
            this.labelSell.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSell.Location = new System.Drawing.Point(6, 65);
            this.labelSell.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.labelSell.Name = "labelSell";
            this.labelSell.Size = new System.Drawing.Size(67, 17);
            this.labelSell.TabIndex = 32;
            this.labelSell.Text = "Sell Price*";
            // 
            // numSellMult
            // 
            this.numSellMult.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSellMult.Location = new System.Drawing.Point(176, 38);
            this.numSellMult.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numSellMult.Name = "numSellMult";
            this.numSellMult.Size = new System.Drawing.Size(114, 21);
            this.numSellMult.TabIndex = 37;
            this.numSellMult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSellMult.ValueChanged += new System.EventHandler(this.numSellMult_ValueChanged);
            // 
            // numBuy
            // 
            this.numBuy.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBuy.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numBuy.Location = new System.Drawing.Point(176, 11);
            this.numBuy.Maximum = new decimal(new int[] {
            655350,
            0,
            0,
            0});
            this.numBuy.Name = "numBuy";
            this.numBuy.Size = new System.Drawing.Size(114, 21);
            this.numBuy.TabIndex = 37;
            this.numBuy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.numBuy, "Use only multiple of 10s.");
            this.numBuy.ValueChanged += new System.EventHandler(this.numBuy_ValueChanged);
            // 
            // panelSellPrice
            // 
            this.panelSellPrice.BackColor = System.Drawing.SystemColors.Window;
            this.panelSellPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSellPrice.Controls.Add(this.labelSellPrice);
            this.panelSellPrice.Location = new System.Drawing.Point(176, 65);
            this.panelSellPrice.Name = "panelSellPrice";
            this.panelSellPrice.Size = new System.Drawing.Size(114, 21);
            this.panelSellPrice.TabIndex = 40;
            // 
            // labelSellPrice
            // 
            this.labelSellPrice.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSellPrice.Location = new System.Drawing.Point(3, 2);
            this.labelSellPrice.Name = "labelSellPrice";
            this.labelSellPrice.Size = new System.Drawing.Size(106, 15);
            this.labelSellPrice.TabIndex = 0;
            this.labelSellPrice.Text = "0 G";
            this.labelSellPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbLanguages
            // 
            this.cbLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguages.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbLanguages.FormattingEnabled = true;
            this.cbLanguages.Items.AddRange(new object[] {
            "English",
            "French",
            "German",
            "Italian",
            "Spanish"});
            this.cbLanguages.Location = new System.Drawing.Point(361, 1);
            this.cbLanguages.MaxDropDownItems = 5;
            this.cbLanguages.Name = "cbLanguages";
            this.cbLanguages.Size = new System.Drawing.Size(65, 21);
            this.cbLanguages.TabIndex = 35;
            this.cbLanguages.SelectedIndexChanged += new System.EventHandler(this.cbLanguages_SelectedIndexChanged);
            // 
            // toolStrip
            // 
            this.toolStrip.AllowMerge = false;
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.Color.White;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonOpen,
            this.toolStripSeparator1,
            this.buttonSave,
            this.toolStripSeparator2,
            this.buttonAbout});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.ShowItemToolTips = false;
            this.toolStrip.Size = new System.Drawing.Size(434, 25);
            this.toolStrip.TabIndex = 34;
            this.toolStrip.Text = "toolStrip1";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Image = ((System.Drawing.Image)(resources.GetObject("buttonOpen.Image")));
            this.buttonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonOpen.Margin = new System.Windows.Forms.Padding(6, 1, 0, 2);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(65, 22);
            this.buttonOpen.Text = "Open...";
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonSave
            // 
            this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
            this.buttonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(51, 22);
            this.buttonSave.Text = "Save";
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonAbout
            // 
            this.buttonAbout.Image = global::Siren.Properties.Resources.info;
            this.buttonAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAbout.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(69, 22);
            this.buttonAbout.Text = "About...";
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // lbItems
            // 
            this.lbItems.FormattingEnabled = true;
            this.lbItems.ItemHeight = 15;
            this.lbItems.Location = new System.Drawing.Point(0, -1);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(136, 499);
            this.lbItems.TabIndex = 41;
            this.lbItems.SelectedIndexChanged += new System.EventHandler(this.lbItems_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(434, 546);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.cbLanguages);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Siren.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 1200);
            this.MinimumSize = new System.Drawing.Size(450, 165);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Siren v1.0 - FFVIII price.bin editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSellMult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBuy)).EndInit();
            this.panelSellPrice.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabelStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabelRightAlign;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabelFile;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelBuy;
        private System.Windows.Forms.Label labelSell;
        private System.Windows.Forms.NumericUpDown numBuy;
        private System.Windows.Forms.ComboBox cbLanguages;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton buttonOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton buttonAbout;
        private System.Windows.Forms.Label labelSellMult;
        private System.Windows.Forms.NumericUpDown numSellMult;
        private System.Windows.Forms.Label labelSellFormula;
        private System.Windows.Forms.Panel panelSellPrice;
        private System.Windows.Forms.Label labelSellPrice;
        private System.Windows.Forms.ToolTip toolTip1;
        private ListBoxEx lbItems;
    }
}

