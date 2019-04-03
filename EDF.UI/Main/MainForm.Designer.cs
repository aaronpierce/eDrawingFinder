namespace EDF.UI
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Panel CheckBoxPanel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BMCheckBox = new System.Windows.Forms.CheckBox();
            this.OPCheckBox = new System.Windows.Forms.CheckBox();
            this.PrintButton = new System.Windows.Forms.Button();
            this.MainDataGridView = new System.Windows.Forms.DataGridView();
            this.DataGridContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CopyDataGridContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.PartNumberDataGridContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.DrawingFilenameDataGridContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.FilePathDataGridContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenWithDataGridContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.EDrawingsDataGridContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.FileExplorerDataGridContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintDataGridContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SendToBatchDataGridContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterTextBox = new System.Windows.Forms.TextBox();
            this.StartsWithFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.OpenButton = new System.Windows.Forms.Button();
            this.MainToolStripMenu = new System.Windows.Forms.MenuStrip();
            this.FileMainToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMainToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintMainToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsMainToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.BatchPrintMainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsMainToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PrinterSelectMainToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PrinterSelectionComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.EDrawingsDefaultMainToolStipMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.UpdateDBMainToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ExpandButton = new System.Windows.Forms.Button();
            this.PreviewPanel = new System.Windows.Forms.Panel();
            this.PreviewRevisionTextBox = new System.Windows.Forms.TextBox();
            this.RevisionLabel = new System.Windows.Forms.Label();
            this.PreviewLastModifiedTextBox = new System.Windows.Forms.TextBox();
            this.PreviewLastModifiedLabel = new System.Windows.Forms.Label();
            this.PreviewNameTextBox = new System.Windows.Forms.TextBox();
            this.PreviewNameLabel = new System.Windows.Forms.Label();
            this.FilterButton = new System.Windows.Forms.Button();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.AlignmentToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.VersionMainStatusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            CheckBoxPanel = new System.Windows.Forms.Panel();
            CheckBoxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGridView)).BeginInit();
            this.DataGridContextMenuStrip.SuspendLayout();
            this.MainToolStripMenu.SuspendLayout();
            this.PreviewPanel.SuspendLayout();
            this.MainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckBoxPanel
            // 
            CheckBoxPanel.BackColor = System.Drawing.Color.LightGray;
            CheckBoxPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            CheckBoxPanel.Controls.Add(this.BMCheckBox);
            CheckBoxPanel.Controls.Add(this.OPCheckBox);
            CheckBoxPanel.Location = new System.Drawing.Point(465, 30);
            CheckBoxPanel.Name = "CheckBoxPanel";
            CheckBoxPanel.Size = new System.Drawing.Size(131, 26);
            CheckBoxPanel.TabIndex = 22;
            // 
            // BMCheckBox
            // 
            this.BMCheckBox.AutoSize = true;
            this.BMCheckBox.Checked = true;
            this.BMCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BMCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BMCheckBox.Location = new System.Drawing.Point(18, 3);
            this.BMCheckBox.Name = "BMCheckBox";
            this.BMCheckBox.Size = new System.Drawing.Size(48, 18);
            this.BMCheckBox.TabIndex = 21;
            this.BMCheckBox.Text = "BM";
            this.BMCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BMCheckBox.UseVisualStyleBackColor = true;
            this.BMCheckBox.CheckedChanged += new System.EventHandler(this.BMCheckBox_CheckedChanged);
            // 
            // OPCheckBox
            // 
            this.OPCheckBox.AutoSize = true;
            this.OPCheckBox.Checked = true;
            this.OPCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OPCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OPCheckBox.Location = new System.Drawing.Point(72, 3);
            this.OPCheckBox.Name = "OPCheckBox";
            this.OPCheckBox.Size = new System.Drawing.Size(47, 18);
            this.OPCheckBox.TabIndex = 20;
            this.OPCheckBox.Text = "OP";
            this.OPCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OPCheckBox.UseVisualStyleBackColor = true;
            this.OPCheckBox.CheckedChanged += new System.EventHandler(this.OPCheckBox_CheckedChanged);
            // 
            // PrintButton
            // 
            this.PrintButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.PrintButton.Location = new System.Drawing.Point(602, 30);
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.MainDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.MainDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MainDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.MainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainDataGridView.ContextMenuStrip = this.DataGridContextMenuStrip;
            this.MainDataGridView.Location = new System.Drawing.Point(7, 62);
            this.MainDataGridView.Name = "MainDataGridView";
            this.MainDataGridView.ReadOnly = true;
            this.MainDataGridView.RowHeadersVisible = false;
            this.MainDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MainDataGridView.Size = new System.Drawing.Size(815, 474);
            this.MainDataGridView.TabIndex = 4;
            this.MainDataGridView.SelectionChanged += new System.EventHandler(this.MainDataGridView_SelectionChanged);
            this.MainDataGridView.DoubleClick += new System.EventHandler(this.OpenButton_Click);
            // 
            // DataGridContextMenuStrip
            // 
            this.DataGridContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyDataGridContextMenuStrip,
            this.OpenWithDataGridContextMenuStrip,
            this.PrintDataGridContextMenuStrip,
            this.toolStripSeparator3,
            this.SendToBatchDataGridContextMenuStrip});
            this.DataGridContextMenuStrip.Name = "DataGridContextMenuStrip";
            this.DataGridContextMenuStrip.Size = new System.Drawing.Size(202, 98);
            // 
            // CopyDataGridContextMenuStrip
            // 
            this.CopyDataGridContextMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PartNumberDataGridContextMenuStrip,
            this.DrawingFilenameDataGridContextMenuStrip,
            this.FilePathDataGridContextMenuStrip});
            this.CopyDataGridContextMenuStrip.Name = "CopyDataGridContextMenuStrip";
            this.CopyDataGridContextMenuStrip.Size = new System.Drawing.Size(201, 22);
            this.CopyDataGridContextMenuStrip.Text = "Copy";
            // 
            // PartNumberDataGridContextMenuStrip
            // 
            this.PartNumberDataGridContextMenuStrip.Name = "PartNumberDataGridContextMenuStrip";
            this.PartNumberDataGridContextMenuStrip.Size = new System.Drawing.Size(169, 22);
            this.PartNumberDataGridContextMenuStrip.Text = "Part Number";
            this.PartNumberDataGridContextMenuStrip.Click += new System.EventHandler(this.PartNumberDataGridContextMenuStrip_Click);
            // 
            // DrawingFilenameDataGridContextMenuStrip
            // 
            this.DrawingFilenameDataGridContextMenuStrip.Name = "DrawingFilenameDataGridContextMenuStrip";
            this.DrawingFilenameDataGridContextMenuStrip.Size = new System.Drawing.Size(169, 22);
            this.DrawingFilenameDataGridContextMenuStrip.Text = "Drawing Filename";
            this.DrawingFilenameDataGridContextMenuStrip.Click += new System.EventHandler(this.DrawingFilenameDataGridContextMenuStrip_Click);
            // 
            // FilePathDataGridContextMenuStrip
            // 
            this.FilePathDataGridContextMenuStrip.Name = "FilePathDataGridContextMenuStrip";
            this.FilePathDataGridContextMenuStrip.Size = new System.Drawing.Size(169, 22);
            this.FilePathDataGridContextMenuStrip.Text = "File Path";
            this.FilePathDataGridContextMenuStrip.Click += new System.EventHandler(this.FilePathDataGridContextMenuStrip_Click);
            // 
            // OpenWithDataGridContextMenuStrip
            // 
            this.OpenWithDataGridContextMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EDrawingsDataGridContextMenuStrip,
            this.FileExplorerDataGridContextMenuStrip});
            this.OpenWithDataGridContextMenuStrip.Name = "OpenWithDataGridContextMenuStrip";
            this.OpenWithDataGridContextMenuStrip.Size = new System.Drawing.Size(201, 22);
            this.OpenWithDataGridContextMenuStrip.Text = "Open With";
            // 
            // EDrawingsDataGridContextMenuStrip
            // 
            this.EDrawingsDataGridContextMenuStrip.Name = "EDrawingsDataGridContextMenuStrip";
            this.EDrawingsDataGridContextMenuStrip.Size = new System.Drawing.Size(137, 22);
            this.EDrawingsDataGridContextMenuStrip.Text = "eDrawings";
            this.EDrawingsDataGridContextMenuStrip.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // FileExplorerDataGridContextMenuStrip
            // 
            this.FileExplorerDataGridContextMenuStrip.Name = "FileExplorerDataGridContextMenuStrip";
            this.FileExplorerDataGridContextMenuStrip.Size = new System.Drawing.Size(137, 22);
            this.FileExplorerDataGridContextMenuStrip.Text = "File Explorer";
            this.FileExplorerDataGridContextMenuStrip.Click += new System.EventHandler(this.FileExplorerDataGridContextMenuStrip_Click);
            // 
            // PrintDataGridContextMenuStrip
            // 
            this.PrintDataGridContextMenuStrip.Name = "PrintDataGridContextMenuStrip";
            this.PrintDataGridContextMenuStrip.Size = new System.Drawing.Size(201, 22);
            this.PrintDataGridContextMenuStrip.Text = "Print";
            this.PrintDataGridContextMenuStrip.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(198, 6);
            // 
            // SendToBatchDataGridContextMenuStrip
            // 
            this.SendToBatchDataGridContextMenuStrip.Enabled = false;
            this.SendToBatchDataGridContextMenuStrip.Name = "SendToBatchDataGridContextMenuStrip";
            this.SendToBatchDataGridContextMenuStrip.Size = new System.Drawing.Size(201, 22);
            this.SendToBatchDataGridContextMenuStrip.Text = "Send To Batch Selection";
            this.SendToBatchDataGridContextMenuStrip.Click += new System.EventHandler(this.SendToBatchDataGridContextMenuStrip_Click);
            // 
            // FilterTextBox
            // 
            this.FilterTextBox.Location = new System.Drawing.Point(97, 34);
            this.FilterTextBox.Name = "FilterTextBox";
            this.FilterTextBox.Size = new System.Drawing.Size(231, 20);
            this.FilterTextBox.TabIndex = 7;
            // 
            // StartsWithFilterCheckBox
            // 
            this.StartsWithFilterCheckBox.AutoSize = true;
            this.StartsWithFilterCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.StartsWithFilterCheckBox.Location = new System.Drawing.Point(334, 35);
            this.StartsWithFilterCheckBox.Name = "StartsWithFilterCheckBox";
            this.StartsWithFilterCheckBox.Size = new System.Drawing.Size(84, 18);
            this.StartsWithFilterCheckBox.TabIndex = 8;
            this.StartsWithFilterCheckBox.Text = "Starts Wtih";
            this.StartsWithFilterCheckBox.UseVisualStyleBackColor = true;
            this.StartsWithFilterCheckBox.CheckedChanged += new System.EventHandler(this.StartsWithFilterCheckBox_CheckedChanged);
            // 
            // OpenButton
            // 
            this.OpenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.OpenButton.Location = new System.Drawing.Point(692, 30);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(84, 25);
            this.OpenButton.TabIndex = 9;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
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
            this.ExitMainToolStripMenuItem});
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
            // ExitMainToolStripMenuItem
            // 
            this.ExitMainToolStripMenuItem.Name = "ExitMainToolStripMenuItem";
            this.ExitMainToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.ExitMainToolStripMenuItem.Text = "E&xit";
            this.ExitMainToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // ToolsMainToolStripMenu
            // 
            this.ToolsMainToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BatchPrintMainToolStripMenuItem});
            this.ToolsMainToolStripMenu.Name = "ToolsMainToolStripMenu";
            this.ToolsMainToolStripMenu.Size = new System.Drawing.Size(48, 20);
            this.ToolsMainToolStripMenu.Text = "Tools";
            // 
            // BatchPrintMainToolStripMenuItem
            // 
            this.BatchPrintMainToolStripMenuItem.Name = "BatchPrintMainToolStripMenuItem";
            this.BatchPrintMainToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.BatchPrintMainToolStripMenuItem.Text = "Batch Print";
            this.BatchPrintMainToolStripMenuItem.Click += new System.EventHandler(this.BatchPrintMainToolStripMenuItem_Click);
            // 
            // SettingsMainToolStripMenu
            // 
            this.SettingsMainToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrinterSelectMainToolStripMenu,
            this.EDrawingsDefaultMainToolStipMenu,
            this.toolStripSeparator1,
            this.UpdateDBMainToolStripMenu});
            this.SettingsMainToolStripMenu.Name = "SettingsMainToolStripMenu";
            this.SettingsMainToolStripMenu.ShortcutKeyDisplayString = "";
            this.SettingsMainToolStripMenu.Size = new System.Drawing.Size(61, 20);
            this.SettingsMainToolStripMenu.Text = "Settings";
            // 
            // PrinterSelectMainToolStripMenu
            // 
            this.PrinterSelectMainToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrinterSelectionComboBox});
            this.PrinterSelectMainToolStripMenu.Name = "PrinterSelectMainToolStripMenu";
            this.PrinterSelectMainToolStripMenu.Size = new System.Drawing.Size(189, 22);
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
            // EDrawingsDefaultMainToolStipMenu
            // 
            this.EDrawingsDefaultMainToolStipMenu.Checked = true;
            this.EDrawingsDefaultMainToolStipMenu.CheckOnClick = true;
            this.EDrawingsDefaultMainToolStipMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EDrawingsDefaultMainToolStipMenu.Name = "EDrawingsDefaultMainToolStipMenu";
            this.EDrawingsDefaultMainToolStipMenu.Size = new System.Drawing.Size(189, 22);
            this.EDrawingsDefaultMainToolStipMenu.Text = "Open With eDrawings";
            this.EDrawingsDefaultMainToolStipMenu.Click += new System.EventHandler(this.EDrawingsDefaultMainToolStipMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(186, 6);
            // 
            // UpdateDBMainToolStripMenu
            // 
            this.UpdateDBMainToolStripMenu.Name = "UpdateDBMainToolStripMenu";
            this.UpdateDBMainToolStripMenu.Size = new System.Drawing.Size(189, 22);
            this.UpdateDBMainToolStripMenu.Text = "Update Database";
            this.UpdateDBMainToolStripMenu.Click += new System.EventHandler(this.UpdateDBMainToolStripMenu_Click);
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
            // PreviewPanel
            // 
            this.PreviewPanel.Controls.Add(this.PreviewRevisionTextBox);
            this.PreviewPanel.Controls.Add(this.RevisionLabel);
            this.PreviewPanel.Controls.Add(this.PreviewLastModifiedTextBox);
            this.PreviewPanel.Controls.Add(this.PreviewLastModifiedLabel);
            this.PreviewPanel.Controls.Add(this.PreviewNameTextBox);
            this.PreviewPanel.Controls.Add(this.PreviewNameLabel);
            this.PreviewPanel.Location = new System.Drawing.Point(830, 78);
            this.PreviewPanel.Name = "PreviewPanel";
            this.PreviewPanel.Size = new System.Drawing.Size(352, 433);
            this.PreviewPanel.TabIndex = 15;
            // 
            // PreviewRevisionTextBox
            // 
            this.PreviewRevisionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PreviewRevisionTextBox.Enabled = false;
            this.PreviewRevisionTextBox.Location = new System.Drawing.Point(105, 361);
            this.PreviewRevisionTextBox.Name = "PreviewRevisionTextBox";
            this.PreviewRevisionTextBox.Size = new System.Drawing.Size(213, 20);
            this.PreviewRevisionTextBox.TabIndex = 5;
            // 
            // RevisionLabel
            // 
            this.RevisionLabel.AutoSize = true;
            this.RevisionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RevisionLabel.Location = new System.Drawing.Point(6, 366);
            this.RevisionLabel.Name = "RevisionLabel";
            this.RevisionLabel.Size = new System.Drawing.Size(57, 15);
            this.RevisionLabel.TabIndex = 4;
            this.RevisionLabel.Text = "Revision:";
            // 
            // PreviewLastModifiedTextBox
            // 
            this.PreviewLastModifiedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PreviewLastModifiedTextBox.Enabled = false;
            this.PreviewLastModifiedTextBox.Location = new System.Drawing.Point(105, 387);
            this.PreviewLastModifiedTextBox.Name = "PreviewLastModifiedTextBox";
            this.PreviewLastModifiedTextBox.Size = new System.Drawing.Size(213, 20);
            this.PreviewLastModifiedTextBox.TabIndex = 3;
            // 
            // PreviewLastModifiedLabel
            // 
            this.PreviewLastModifiedLabel.AutoSize = true;
            this.PreviewLastModifiedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviewLastModifiedLabel.Location = new System.Drawing.Point(6, 392);
            this.PreviewLastModifiedLabel.Name = "PreviewLastModifiedLabel";
            this.PreviewLastModifiedLabel.Size = new System.Drawing.Size(84, 15);
            this.PreviewLastModifiedLabel.TabIndex = 2;
            this.PreviewLastModifiedLabel.Text = "Last Modified:";
            // 
            // PreviewNameTextBox
            // 
            this.PreviewNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PreviewNameTextBox.Enabled = false;
            this.PreviewNameTextBox.Location = new System.Drawing.Point(105, 335);
            this.PreviewNameTextBox.Name = "PreviewNameTextBox";
            this.PreviewNameTextBox.Size = new System.Drawing.Size(213, 20);
            this.PreviewNameTextBox.TabIndex = 1;
            // 
            // PreviewNameLabel
            // 
            this.PreviewNameLabel.AutoSize = true;
            this.PreviewNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.PreviewNameLabel.Location = new System.Drawing.Point(6, 340);
            this.PreviewNameLabel.Name = "PreviewNameLabel";
            this.PreviewNameLabel.Size = new System.Drawing.Size(93, 15);
            this.PreviewNameLabel.TabIndex = 0;
            this.PreviewNameLabel.Text = "Drawing Name:";
            // 
            // FilterButton
            // 
            this.FilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FilterButton.Location = new System.Drawing.Point(7, 32);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(84, 25);
            this.FilterButton.TabIndex = 16;
            this.FilterButton.Text = "Filter";
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusStripStatusLabel,
            this.AlignmentToolStripStatusLabel,
            this.VersionMainStatusStrip});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 541);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainStatusStrip.Size = new System.Drawing.Size(1194, 22);
            this.MainStatusStrip.TabIndex = 18;
            // 
            // StatusStripStatusLabel
            // 
            this.StatusStripStatusLabel.Name = "StatusStripStatusLabel";
            this.StatusStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // AlignmentToolStripStatusLabel
            // 
            this.AlignmentToolStripStatusLabel.Name = "AlignmentToolStripStatusLabel";
            this.AlignmentToolStripStatusLabel.Size = new System.Drawing.Size(1017, 17);
            this.AlignmentToolStripStatusLabel.Spring = true;
            // 
            // VersionMainStatusStrip
            // 
            this.VersionMainStatusStrip.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionMainStatusStrip.Name = "VersionMainStatusStrip";
            this.VersionMainStatusStrip.Size = new System.Drawing.Size(162, 17);
            this.VersionMainStatusStrip.Text = "eDrawing Finder, Version x.x.x";
            this.VersionMainStatusStrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AcceptButton = this.FilterButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1194, 563);
            this.Controls.Add(this.StartsWithFilterCheckBox);
            this.Controls.Add(CheckBoxPanel);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.FilterButton);
            this.Controls.Add(this.PreviewPanel);
            this.Controls.Add(this.ExpandButton);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.FilterTextBox);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            CheckBoxPanel.ResumeLayout(false);
            CheckBoxPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGridView)).EndInit();
            this.DataGridContextMenuStrip.ResumeLayout(false);
            this.MainToolStripMenu.ResumeLayout(false);
            this.MainToolStripMenu.PerformLayout();
            this.PreviewPanel.ResumeLayout(false);
            this.PreviewPanel.PerformLayout();
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.DataGridView MainDataGridView;
        private System.Windows.Forms.TextBox FilterTextBox;
        private System.Windows.Forms.CheckBox StartsWithFilterCheckBox;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.ToolStripMenuItem FileMainToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenMainToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem PrintMainToolStripMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ExitMainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsMainToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem SettingsMainToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem PrinterSelectMainToolStripMenu;
        private System.Windows.Forms.ToolStripComboBox PrinterSelectionComboBox;
        private System.Windows.Forms.Button ExpandButton;
        private System.Windows.Forms.ToolStripMenuItem BatchPrintMainToolStripMenuItem;
        private System.Windows.Forms.Panel PreviewPanel;
        private System.Windows.Forms.TextBox PreviewNameTextBox;
        private System.Windows.Forms.Label PreviewNameLabel;
        private System.Windows.Forms.TextBox PreviewLastModifiedTextBox;
        private System.Windows.Forms.Label PreviewLastModifiedLabel;
        private System.Windows.Forms.TextBox PreviewRevisionTextBox;
        private System.Windows.Forms.Label RevisionLabel;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.ContextMenuStrip DataGridContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem CopyDataGridContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem PartNumberDataGridContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem DrawingFilenameDataGridContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FilePathDataGridContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem SendToBatchDataGridContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem OpenWithDataGridContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem EDrawingsDataGridContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileExplorerDataGridContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem PrintDataGridContextMenuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel VersionMainStatusStrip;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.CheckBox OPCheckBox;
        private System.Windows.Forms.CheckBox BMCheckBox;
        private System.Windows.Forms.MenuStrip MainToolStripMenu;
        private System.Windows.Forms.ToolStripStatusLabel StatusStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel AlignmentToolStripStatusLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem UpdateDBMainToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem EDrawingsDefaultMainToolStipMenu;
    }
}

