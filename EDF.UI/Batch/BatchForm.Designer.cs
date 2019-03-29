namespace EDF.UI
{
    partial class BatchForm
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
            System.Windows.Forms.Panel BatchCheckBoxPanel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchForm));
            this.BatchBMCheckBox = new System.Windows.Forms.CheckBox();
            this.BatchOPCheckBox = new System.Windows.Forms.CheckBox();
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.CurrentFileLabel = new System.Windows.Forms.Label();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.BatchPrintStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.BatchPrintStatusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.BatchPrintButton = new System.Windows.Forms.Button();
            this.BatchFileTextBox = new System.Windows.Forms.TextBox();
            this.BatchConfirmButton = new System.Windows.Forms.Button();
            this.BatchDataGridView = new System.Windows.Forms.DataGridView();
            this.BatchPrintContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SearchBatchPrintContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.CopyBatchPrintContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.PartNumberBatchDataGridContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.DrawingFilenameBatchDataGridContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.FilePathBatchDataGridContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenWithDataGridContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.EDrawingsBatchDataGridContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.FileExplorerBatchDataGridContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.RemoveDrawingDataContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            BatchCheckBoxPanel = new System.Windows.Forms.Panel();
            BatchCheckBoxPanel.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BatchDataGridView)).BeginInit();
            this.BatchPrintContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // BatchCheckBoxPanel
            // 
            BatchCheckBoxPanel.BackColor = System.Drawing.Color.LightGray;
            BatchCheckBoxPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            BatchCheckBoxPanel.Controls.Add(this.BatchBMCheckBox);
            BatchCheckBoxPanel.Controls.Add(this.BatchOPCheckBox);
            BatchCheckBoxPanel.Location = new System.Drawing.Point(335, 12);
            BatchCheckBoxPanel.Name = "BatchCheckBoxPanel";
            BatchCheckBoxPanel.Size = new System.Drawing.Size(131, 26);
            BatchCheckBoxPanel.TabIndex = 23;
            // 
            // BatchBMCheckBox
            // 
            this.BatchBMCheckBox.AutoSize = true;
            this.BatchBMCheckBox.Checked = true;
            this.BatchBMCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BatchBMCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BatchBMCheckBox.Location = new System.Drawing.Point(18, 3);
            this.BatchBMCheckBox.Name = "BatchBMCheckBox";
            this.BatchBMCheckBox.Size = new System.Drawing.Size(48, 18);
            this.BatchBMCheckBox.TabIndex = 21;
            this.BatchBMCheckBox.Text = "BM";
            this.BatchBMCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BatchBMCheckBox.UseVisualStyleBackColor = true;
            // 
            // BatchOPCheckBox
            // 
            this.BatchOPCheckBox.AutoSize = true;
            this.BatchOPCheckBox.Checked = true;
            this.BatchOPCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BatchOPCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BatchOPCheckBox.Location = new System.Drawing.Point(72, 3);
            this.BatchOPCheckBox.Name = "BatchOPCheckBox";
            this.BatchOPCheckBox.Size = new System.Drawing.Size(47, 18);
            this.BatchOPCheckBox.TabIndex = 20;
            this.BatchOPCheckBox.Text = "OP";
            this.BatchOPCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BatchOPCheckBox.UseVisualStyleBackColor = true;
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.Location = new System.Drawing.Point(12, 12);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(75, 25);
            this.SelectFileButton.TabIndex = 0;
            this.SelectFileButton.Text = "Select File";
            this.SelectFileButton.UseVisualStyleBackColor = true;
            this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
            // 
            // CurrentFileLabel
            // 
            this.CurrentFileLabel.AutoSize = true;
            this.CurrentFileLabel.Location = new System.Drawing.Point(103, 18);
            this.CurrentFileLabel.Name = "CurrentFileLabel";
            this.CurrentFileLabel.Size = new System.Drawing.Size(0, 13);
            this.CurrentFileLabel.TabIndex = 2;
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BatchPrintStatusLabel,
            this.BatchPrintStatusProgressBar});
            this.StatusStrip.Location = new System.Drawing.Point(0, 572);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(684, 22);
            this.StatusStrip.TabIndex = 4;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // BatchPrintStatusLabel
            // 
            this.BatchPrintStatusLabel.Name = "BatchPrintStatusLabel";
            this.BatchPrintStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.BatchPrintStatusLabel.Text = "Ready.";
            // 
            // BatchPrintStatusProgressBar
            // 
            this.BatchPrintStatusProgressBar.Name = "BatchPrintStatusProgressBar";
            this.BatchPrintStatusProgressBar.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.BatchPrintStatusProgressBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BatchPrintStatusProgressBar.Size = new System.Drawing.Size(100, 16);
            this.BatchPrintStatusProgressBar.Visible = false;
            // 
            // BatchPrintButton
            // 
            this.BatchPrintButton.Enabled = false;
            this.BatchPrintButton.Location = new System.Drawing.Point(575, 12);
            this.BatchPrintButton.Name = "BatchPrintButton";
            this.BatchPrintButton.Size = new System.Drawing.Size(97, 25);
            this.BatchPrintButton.TabIndex = 5;
            this.BatchPrintButton.Text = "Print Drawings";
            this.BatchPrintButton.UseVisualStyleBackColor = true;
            this.BatchPrintButton.Click += new System.EventHandler(this.BatchPrintButton_Click);
            // 
            // BatchFileTextBox
            // 
            this.BatchFileTextBox.Location = new System.Drawing.Point(93, 15);
            this.BatchFileTextBox.Name = "BatchFileTextBox";
            this.BatchFileTextBox.ReadOnly = true;
            this.BatchFileTextBox.Size = new System.Drawing.Size(236, 20);
            this.BatchFileTextBox.TabIndex = 6;
            // 
            // BatchConfirmButton
            // 
            this.BatchConfirmButton.Enabled = false;
            this.BatchConfirmButton.Location = new System.Drawing.Point(472, 12);
            this.BatchConfirmButton.Name = "BatchConfirmButton";
            this.BatchConfirmButton.Size = new System.Drawing.Size(97, 25);
            this.BatchConfirmButton.TabIndex = 7;
            this.BatchConfirmButton.Text = "Confirm";
            this.BatchConfirmButton.UseVisualStyleBackColor = true;
            this.BatchConfirmButton.Click += new System.EventHandler(this.BatchConfirmButton_Click);
            // 
            // BatchDataGridView
            // 
            this.BatchDataGridView.AllowUserToAddRows = false;
            this.BatchDataGridView.AllowUserToDeleteRows = false;
            this.BatchDataGridView.AllowUserToResizeColumns = false;
            this.BatchDataGridView.AllowUserToResizeRows = false;
            this.BatchDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BatchDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BatchDataGridView.ContextMenuStrip = this.BatchPrintContextMenuStrip;
            this.BatchDataGridView.Location = new System.Drawing.Point(12, 43);
            this.BatchDataGridView.MultiSelect = false;
            this.BatchDataGridView.Name = "BatchDataGridView";
            this.BatchDataGridView.ReadOnly = true;
            this.BatchDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.BatchDataGridView.Size = new System.Drawing.Size(660, 521);
            this.BatchDataGridView.TabIndex = 1;
            this.BatchDataGridView.RowContextMenuStripNeeded += new System.Windows.Forms.DataGridViewRowContextMenuStripNeededEventHandler(this.BatchDataGridView_RowContextMenuStripNeeded);
            this.BatchDataGridView.SelectionChanged += new System.EventHandler(this.BatchDataGridView_SelectionChanged);
            // 
            // BatchPrintContextMenuStrip
            // 
            this.BatchPrintContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SearchBatchPrintContextMenuStrip,
            this.toolStripSeparator3,
            this.CopyBatchPrintContextMenuStrip,
            this.OpenWithDataGridContextMenuStrip,
            this.toolStripSeparator1,
            this.RemoveDrawingDataContextMenuStrip});
            this.BatchPrintContextMenuStrip.Name = "DataGridContextMenuStrip";
            this.BatchPrintContextMenuStrip.Size = new System.Drawing.Size(165, 104);
            // 
            // SearchBatchPrintContextMenuStrip
            // 
            this.SearchBatchPrintContextMenuStrip.Name = "SearchBatchPrintContextMenuStrip";
            this.SearchBatchPrintContextMenuStrip.Size = new System.Drawing.Size(164, 22);
            this.SearchBatchPrintContextMenuStrip.Text = "Search";
            this.SearchBatchPrintContextMenuStrip.Click += new System.EventHandler(this.SearchBatchPrintContextMenuStrip_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(161, 6);
            // 
            // CopyBatchPrintContextMenuStrip
            // 
            this.CopyBatchPrintContextMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PartNumberBatchDataGridContextMenuStrip,
            this.DrawingFilenameBatchDataGridContextMenuStrip,
            this.FilePathBatchDataGridContextMenuStrip});
            this.CopyBatchPrintContextMenuStrip.Name = "CopyBatchPrintContextMenuStrip";
            this.CopyBatchPrintContextMenuStrip.Size = new System.Drawing.Size(164, 22);
            this.CopyBatchPrintContextMenuStrip.Text = "Copy";
            // 
            // PartNumberBatchDataGridContextMenuStrip
            // 
            this.PartNumberBatchDataGridContextMenuStrip.Name = "PartNumberBatchDataGridContextMenuStrip";
            this.PartNumberBatchDataGridContextMenuStrip.Size = new System.Drawing.Size(169, 22);
            this.PartNumberBatchDataGridContextMenuStrip.Text = "Part Number";
            this.PartNumberBatchDataGridContextMenuStrip.Click += new System.EventHandler(this.PartNumberBatchDataGridContextMenuStrip_Click);
            // 
            // DrawingFilenameBatchDataGridContextMenuStrip
            // 
            this.DrawingFilenameBatchDataGridContextMenuStrip.Name = "DrawingFilenameBatchDataGridContextMenuStrip";
            this.DrawingFilenameBatchDataGridContextMenuStrip.Size = new System.Drawing.Size(169, 22);
            this.DrawingFilenameBatchDataGridContextMenuStrip.Text = "Drawing Filename";
            this.DrawingFilenameBatchDataGridContextMenuStrip.Click += new System.EventHandler(this.DrawingFilenameDataGridContextMenuStrip_Click);
            // 
            // FilePathBatchDataGridContextMenuStrip
            // 
            this.FilePathBatchDataGridContextMenuStrip.Name = "FilePathBatchDataGridContextMenuStrip";
            this.FilePathBatchDataGridContextMenuStrip.Size = new System.Drawing.Size(169, 22);
            this.FilePathBatchDataGridContextMenuStrip.Text = "File Path";
            this.FilePathBatchDataGridContextMenuStrip.Click += new System.EventHandler(this.FilePathBatchDataGridContextMenuStrip_Click);
            // 
            // OpenWithDataGridContextMenuStrip
            // 
            this.OpenWithDataGridContextMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EDrawingsBatchDataGridContextMenuStrip,
            this.FileExplorerBatchDataGridContextMenuStrip});
            this.OpenWithDataGridContextMenuStrip.Name = "OpenWithDataGridContextMenuStrip";
            this.OpenWithDataGridContextMenuStrip.Size = new System.Drawing.Size(164, 22);
            this.OpenWithDataGridContextMenuStrip.Text = "Open With";
            // 
            // EDrawingsBatchDataGridContextMenuStrip
            // 
            this.EDrawingsBatchDataGridContextMenuStrip.Name = "EDrawingsBatchDataGridContextMenuStrip";
            this.EDrawingsBatchDataGridContextMenuStrip.Size = new System.Drawing.Size(137, 22);
            this.EDrawingsBatchDataGridContextMenuStrip.Text = "eDrawings";
            this.EDrawingsBatchDataGridContextMenuStrip.Click += new System.EventHandler(this.EDrawingsBatchDataGridContextMenuStrip_Click);
            // 
            // FileExplorerBatchDataGridContextMenuStrip
            // 
            this.FileExplorerBatchDataGridContextMenuStrip.Name = "FileExplorerBatchDataGridContextMenuStrip";
            this.FileExplorerBatchDataGridContextMenuStrip.Size = new System.Drawing.Size(137, 22);
            this.FileExplorerBatchDataGridContextMenuStrip.Text = "File Explorer";
            this.FileExplorerBatchDataGridContextMenuStrip.Click += new System.EventHandler(this.FileExplorerBatchDataGridContextMenuStrip_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // RemoveDrawingDataContextMenuStrip
            // 
            this.RemoveDrawingDataContextMenuStrip.Name = "RemoveDrawingDataContextMenuStrip";
            this.RemoveDrawingDataContextMenuStrip.Size = new System.Drawing.Size(164, 22);
            this.RemoveDrawingDataContextMenuStrip.Text = "Remove Drawing";
            this.RemoveDrawingDataContextMenuStrip.Click += new System.EventHandler(this.RemoveDrawingDataContextMenuStrip_Click);
            // 
            // BatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 594);
            this.Controls.Add(BatchCheckBoxPanel);
            this.Controls.Add(this.BatchConfirmButton);
            this.Controls.Add(this.BatchFileTextBox);
            this.Controls.Add(this.BatchPrintButton);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.CurrentFileLabel);
            this.Controls.Add(this.BatchDataGridView);
            this.Controls.Add(this.SelectFileButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 632);
            this.MinimumSize = new System.Drawing.Size(700, 632);
            this.Name = "BatchForm";
            this.Text = "eDrawing Finder - Batch Print";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BatchForm_FormClosing);
            this.Load += new System.EventHandler(this.BatchForm_Load);
            BatchCheckBoxPanel.ResumeLayout(false);
            BatchCheckBoxPanel.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BatchDataGridView)).EndInit();
            this.BatchPrintContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectFileButton;
        private System.Windows.Forms.Label CurrentFileLabel;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel BatchPrintStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar BatchPrintStatusProgressBar;
        private System.Windows.Forms.Button BatchPrintButton;
        private System.Windows.Forms.TextBox BatchFileTextBox;
        private System.Windows.Forms.Button BatchConfirmButton;
        private System.Windows.Forms.DataGridView BatchDataGridView;
        private System.Windows.Forms.CheckBox BatchBMCheckBox;
        private System.Windows.Forms.CheckBox BatchOPCheckBox;
        private System.Windows.Forms.ContextMenuStrip BatchPrintContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem CopyBatchPrintContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem PartNumberBatchDataGridContextMenuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem SearchBatchPrintContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem DrawingFilenameBatchDataGridContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem OpenWithDataGridContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem EDrawingsBatchDataGridContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileExplorerBatchDataGridContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FilePathBatchDataGridContextMenuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem RemoveDrawingDataContextMenuStrip;
    }
}