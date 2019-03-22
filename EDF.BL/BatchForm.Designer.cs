namespace eDrawingFinder
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
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.BatchDataGridView = new System.Windows.Forms.DataGridView();
            this.CurrentFileLabel = new System.Windows.Forms.Label();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.BatchPrintStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.BatchPrintStatusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.BatchPrintButton = new System.Windows.Forms.Button();
            this.BatchFileTextBox = new System.Windows.Forms.TextBox();
            this.BatchConfirmButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BatchDataGridView)).BeginInit();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
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
            // BatchDataGridView
            // 
            this.BatchDataGridView.AllowUserToAddRows = false;
            this.BatchDataGridView.AllowUserToDeleteRows = false;
            this.BatchDataGridView.AllowUserToResizeColumns = false;
            this.BatchDataGridView.AllowUserToResizeRows = false;
            this.BatchDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BatchDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BatchDataGridView.Location = new System.Drawing.Point(12, 43);
            this.BatchDataGridView.MultiSelect = false;
            this.BatchDataGridView.Name = "BatchDataGridView";
            this.BatchDataGridView.ReadOnly = true;
            this.BatchDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.BatchDataGridView.Size = new System.Drawing.Size(607, 521);
            this.BatchDataGridView.TabIndex = 1;
            this.BatchDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.BatchDataGridView_CellValueChanged);
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
            this.StatusStrip.Size = new System.Drawing.Size(633, 22);
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
            this.BatchPrintButton.Location = new System.Drawing.Point(522, 12);
            this.BatchPrintButton.Name = "BatchPrintButton";
            this.BatchPrintButton.Size = new System.Drawing.Size(97, 25);
            this.BatchPrintButton.TabIndex = 5;
            this.BatchPrintButton.Text = "Print Drawings";
            this.BatchPrintButton.UseVisualStyleBackColor = true;
            this.BatchPrintButton.Click += new System.EventHandler(this.BatchPrintButton_Click);
            // 
            // BatchFileTextBox
            // 
            this.BatchFileTextBox.Enabled = false;
            this.BatchFileTextBox.Location = new System.Drawing.Point(93, 15);
            this.BatchFileTextBox.Name = "BatchFileTextBox";
            this.BatchFileTextBox.Size = new System.Drawing.Size(320, 20);
            this.BatchFileTextBox.TabIndex = 6;
            // 
            // BatchConfirmButton
            // 
            this.BatchConfirmButton.Enabled = false;
            this.BatchConfirmButton.Location = new System.Drawing.Point(419, 12);
            this.BatchConfirmButton.Name = "BatchConfirmButton";
            this.BatchConfirmButton.Size = new System.Drawing.Size(97, 25);
            this.BatchConfirmButton.TabIndex = 7;
            this.BatchConfirmButton.Text = "Confirm";
            this.BatchConfirmButton.UseVisualStyleBackColor = true;
            this.BatchConfirmButton.Click += new System.EventHandler(this.BatchConfirmButton_Click);
            // 
            // BatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 594);
            this.Controls.Add(this.BatchConfirmButton);
            this.Controls.Add(this.BatchFileTextBox);
            this.Controls.Add(this.BatchPrintButton);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.CurrentFileLabel);
            this.Controls.Add(this.BatchDataGridView);
            this.Controls.Add(this.SelectFileButton);
            this.Name = "BatchForm";
            this.Text = "eDrawing Finder - Batch Print";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BatchForm_FormClosing);
            this.Load += new System.EventHandler(this.BatchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BatchDataGridView)).EndInit();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectFileButton;
        private System.Windows.Forms.DataGridView BatchDataGridView;
        private System.Windows.Forms.Label CurrentFileLabel;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel BatchPrintStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar BatchPrintStatusProgressBar;
        private System.Windows.Forms.Button BatchPrintButton;
        private System.Windows.Forms.TextBox BatchFileTextBox;
        private System.Windows.Forms.Button BatchConfirmButton;
    }
}