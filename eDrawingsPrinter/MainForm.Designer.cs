using System;

namespace eDrawingFinder
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PrintButton = new System.Windows.Forms.Button();
            this.MainDataGridView = new System.Windows.Forms.DataGridView();
            this.FilterSearchButton = new System.Windows.Forms.Button();
            this.FilterTextBox = new System.Windows.Forms.TextBox();
            this.StartsWithFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.OpenButton = new System.Windows.Forms.Button();
            this.OPRadioButton = new System.Windows.Forms.RadioButton();
            this.BMRadioButton = new System.Windows.Forms.RadioButton();
            this.MainToolStripMenu = new System.Windows.Forms.MenuStrip();
            this.FileMainToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMainToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintMainToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsMainToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsMainToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PrinterSelectMainToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PrinterSelectionComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.PreviewFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ExpandButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGridView)).BeginInit();
            this.MainToolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrintButton
            // 
            this.PrintButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.PrintButton.Location = new System.Drawing.Point(604, 31);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(84, 25);
            this.PrintButton.TabIndex = 0;
            this.PrintButton.Text = "Print";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // MainDataGridView
            // 
            this.MainDataGridView.AllowUserToAddRows = false;
            this.MainDataGridView.AllowUserToDeleteRows = false;
            this.MainDataGridView.AllowUserToResizeColumns = false;
            this.MainDataGridView.AllowUserToResizeRows = false;
            this.MainDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MainDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.MainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainDataGridView.Location = new System.Drawing.Point(7, 62);
            this.MainDataGridView.Name = "MainDataGridView";
            this.MainDataGridView.ReadOnly = true;
            this.MainDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MainDataGridView.Size = new System.Drawing.Size(815, 474);
            this.MainDataGridView.TabIndex = 4;
            this.MainDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainDataGridView_CellClick);
            this.MainDataGridView.DoubleClick += new System.EventHandler(this.OpenButton_Click);
            // 
            // FilterSearchButton
            // 
            this.FilterSearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FilterSearchButton.Location = new System.Drawing.Point(12, 32);
            this.FilterSearchButton.Name = "FilterSearchButton";
            this.FilterSearchButton.Size = new System.Drawing.Size(93, 25);
            this.FilterSearchButton.TabIndex = 6;
            this.FilterSearchButton.Text = "Search";
            this.FilterSearchButton.UseVisualStyleBackColor = true;
            this.FilterSearchButton.Click += new System.EventHandler(this.FilterSearchButton_Click);
            // 
            // FilterTextBox
            // 
            this.FilterTextBox.Location = new System.Drawing.Point(129, 36);
            this.FilterTextBox.Name = "FilterTextBox";
            this.FilterTextBox.Size = new System.Drawing.Size(254, 20);
            this.FilterTextBox.TabIndex = 7;
            // 
            // StartsWithFilterCheckBox
            // 
            this.StartsWithFilterCheckBox.AutoSize = true;
            this.StartsWithFilterCheckBox.Location = new System.Drawing.Point(389, 38);
            this.StartsWithFilterCheckBox.Name = "StartsWithFilterCheckBox";
            this.StartsWithFilterCheckBox.Size = new System.Drawing.Size(78, 17);
            this.StartsWithFilterCheckBox.TabIndex = 8;
            this.StartsWithFilterCheckBox.Text = "Starts Wtih";
            this.StartsWithFilterCheckBox.UseVisualStyleBackColor = true;
            this.StartsWithFilterCheckBox.CheckedChanged += new System.EventHandler(this.StartsWithFilterCheckBox_CheckedChanged);
            // 
            // OpenButton
            // 
            this.OpenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.OpenButton.Location = new System.Drawing.Point(694, 31);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(84, 25);
            this.OpenButton.TabIndex = 9;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // OPRadioButton
            // 
            this.OPRadioButton.AutoSize = true;
            this.OPRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.OPRadioButton.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.OPRadioButton.Checked = true;
            this.OPRadioButton.Location = new System.Drawing.Point(490, 37);
            this.OPRadioButton.Name = "OPRadioButton";
            this.OPRadioButton.Size = new System.Drawing.Size(40, 17);
            this.OPRadioButton.TabIndex = 10;
            this.OPRadioButton.TabStop = true;
            this.OPRadioButton.Text = "OP";
            this.OPRadioButton.UseVisualStyleBackColor = false;
            this.OPRadioButton.CheckedChanged += new System.EventHandler(this.OPRadioButton_CheckedChanged);
            // 
            // BMRadioButton
            // 
            this.BMRadioButton.AutoSize = true;
            this.BMRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.BMRadioButton.Location = new System.Drawing.Point(536, 37);
            this.BMRadioButton.Name = "BMRadioButton";
            this.BMRadioButton.Size = new System.Drawing.Size(41, 17);
            this.BMRadioButton.TabIndex = 11;
            this.BMRadioButton.Text = "BM";
            this.BMRadioButton.UseVisualStyleBackColor = false;
            this.BMRadioButton.CheckedChanged += new System.EventHandler(this.BMRadioButton_CheckedChanged);
            // 
            // MainToolStripMenu
            // 
            this.MainToolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMainToolStripMenu,
            this.ToolsMainToolStripMenu,
            this.SettingsMainToolStripMenu});
            this.MainToolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.MainToolStripMenu.Name = "MainToolStripMenu";
            this.MainToolStripMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainToolStripMenu.ShowItemToolTips = true;
            this.MainToolStripMenu.Size = new System.Drawing.Size(1194, 24);
            this.MainToolStripMenu.TabIndex = 12;
            // 
            // FileMainToolStripMenu
            // 
            this.FileMainToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenMainToolStripMenu,
            this.PrintMainToolStripMenu,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem1});
            this.FileMainToolStripMenu.Name = "FileMainToolStripMenu";
            this.FileMainToolStripMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMainToolStripMenu.Text = "File";
            // 
            // OpenMainToolStripMenu
            // 
            this.OpenMainToolStripMenu.Image = ((System.Drawing.Image)(resources.GetObject("OpenMainToolStripMenu.Image")));
            this.OpenMainToolStripMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenMainToolStripMenu.Name = "OpenMainToolStripMenu";
            this.OpenMainToolStripMenu.ShortcutKeyDisplayString = "";
            this.OpenMainToolStripMenu.Size = new System.Drawing.Size(140, 22);
            this.OpenMainToolStripMenu.Text = "Open";
            this.OpenMainToolStripMenu.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // PrintMainToolStripMenu
            // 
            this.PrintMainToolStripMenu.Image = ((System.Drawing.Image)(resources.GetObject("PrintMainToolStripMenu.Image")));
            this.PrintMainToolStripMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PrintMainToolStripMenu.Name = "PrintMainToolStripMenu";
            this.PrintMainToolStripMenu.ShortcutKeyDisplayString = "";
            this.PrintMainToolStripMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.PrintMainToolStripMenu.Size = new System.Drawing.Size(140, 22);
            this.PrintMainToolStripMenu.Text = "Print";
            this.PrintMainToolStripMenu.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(137, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.exitToolStripMenuItem1.Text = "E&xit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // ToolsMainToolStripMenu
            // 
            this.ToolsMainToolStripMenu.Name = "ToolsMainToolStripMenu";
            this.ToolsMainToolStripMenu.Size = new System.Drawing.Size(48, 20);
            this.ToolsMainToolStripMenu.Text = "Tools";
            // 
            // SettingsMainToolStripMenu
            // 
            this.SettingsMainToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrinterSelectMainToolStripMenu});
            this.SettingsMainToolStripMenu.Name = "SettingsMainToolStripMenu";
            this.SettingsMainToolStripMenu.ShortcutKeyDisplayString = "";
            this.SettingsMainToolStripMenu.Size = new System.Drawing.Size(61, 20);
            this.SettingsMainToolStripMenu.Text = "Settings";
            this.SettingsMainToolStripMenu.Click += new System.EventHandler(this.SettingsMainToolStripMenu_Click);
            // 
            // PrinterSelectMainToolStripMenu
            // 
            this.PrinterSelectMainToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrinterSelectionComboBox});
            this.PrinterSelectMainToolStripMenu.Name = "PrinterSelectMainToolStripMenu";
            this.PrinterSelectMainToolStripMenu.Size = new System.Drawing.Size(143, 22);
            this.PrinterSelectMainToolStripMenu.Text = "Printer Select";
            // 
            // PrinterSelectionComboBox
            // 
            this.PrinterSelectionComboBox.DropDownWidth = 250;
            this.PrinterSelectionComboBox.MaxDropDownItems = 15;
            this.PrinterSelectionComboBox.Name = "PrinterSelectionComboBox";
            this.PrinterSelectionComboBox.Size = new System.Drawing.Size(250, 23);
            this.PrinterSelectionComboBox.Sorted = true;
            this.PrinterSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.PrinterSelectionComboBox_SelectedIndexChanged);
            // 
            // PreviewFlowLayoutPanel
            // 
            this.PreviewFlowLayoutPanel.Location = new System.Drawing.Point(835, 230);
            this.PreviewFlowLayoutPanel.Name = "PreviewFlowLayoutPanel";
            this.PreviewFlowLayoutPanel.Size = new System.Drawing.Size(352, 307);
            this.PreviewFlowLayoutPanel.TabIndex = 13;
            // 
            // ExpandButton
            // 
            this.ExpandButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ExpandButton.Image = ((System.Drawing.Image)(resources.GetObject("ExpandButton.Image")));
            this.ExpandButton.Location = new System.Drawing.Point(797, 30);
            this.ExpandButton.Name = "ExpandButton";
            this.ExpandButton.Size = new System.Drawing.Size(25, 25);
            this.ExpandButton.TabIndex = 14;
            this.ExpandButton.UseVisualStyleBackColor = true;
            this.ExpandButton.Click += new System.EventHandler(this.ExpandButton_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.FilterSearchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1194, 548);
            this.Controls.Add(this.ExpandButton);
            this.Controls.Add(this.PreviewFlowLayoutPanel);
            this.Controls.Add(this.BMRadioButton);
            this.Controls.Add(this.OPRadioButton);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.StartsWithFilterCheckBox);
            this.Controls.Add(this.FilterTextBox);
            this.Controls.Add(this.FilterSearchButton);
            this.Controls.Add(this.MainDataGridView);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.MainToolStripMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainToolStripMenu;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "eDrawing Finder";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGridView)).EndInit();
            this.MainToolStripMenu.ResumeLayout(false);
            this.MainToolStripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.DataGridView MainDataGridView;
        private System.Windows.Forms.Button FilterSearchButton;
        private System.Windows.Forms.TextBox FilterTextBox;
        private System.Windows.Forms.CheckBox StartsWithFilterCheckBox;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.RadioButton OPRadioButton;
        private System.Windows.Forms.RadioButton BMRadioButton;
        private System.Windows.Forms.MenuStrip MainToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem FileMainToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenMainToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem PrintMainToolStripMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ToolsMainToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem SettingsMainToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem PrinterSelectMainToolStripMenu;
        private System.Windows.Forms.ToolStripComboBox PrinterSelectionComboBox;
        private System.Windows.Forms.FlowLayoutPanel PreviewFlowLayoutPanel;
        private System.Windows.Forms.Button ExpandButton;
    }
}

