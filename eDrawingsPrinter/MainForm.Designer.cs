using System;

namespace eDrawingsPrinter
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
            this.ButtonTestPrint = new System.Windows.Forms.Button();
            this.FilePathTextbox = new System.Windows.Forms.TextBox();
            this.FileTreeButton = new System.Windows.Forms.Button();
            this.FilePathTextboxLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LoadDataSourceButton = new System.Windows.Forms.Button();
            this.FilterButton = new System.Windows.Forms.Button();
            this.FilterTextBox = new System.Windows.Forms.TextBox();
            this.ContainsFilterCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonTestPrint
            // 
            this.ButtonTestPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonTestPrint.Location = new System.Drawing.Point(20, 12);
            this.ButtonTestPrint.Name = "ButtonTestPrint";
            this.ButtonTestPrint.Size = new System.Drawing.Size(111, 26);
            this.ButtonTestPrint.TabIndex = 0;
            this.ButtonTestPrint.Text = "Print Test";
            this.ButtonTestPrint.UseVisualStyleBackColor = true;
            this.ButtonTestPrint.Click += new System.EventHandler(this.ButtonTestPrint_Click);
            // 
            // FilePathTextbox
            // 
            this.FilePathTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FilePathTextbox.Location = new System.Drawing.Point(270, 45);
            this.FilePathTextbox.Name = "FilePathTextbox";
            this.FilePathTextbox.Size = new System.Drawing.Size(281, 20);
            this.FilePathTextbox.TabIndex = 1;
            this.FilePathTextbox.Text = "H:\\DWG";
            // 
            // FileTreeButton
            // 
            this.FileTreeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileTreeButton.Location = new System.Drawing.Point(644, 12);
            this.FileTreeButton.Name = "FileTreeButton";
            this.FileTreeButton.Size = new System.Drawing.Size(111, 25);
            this.FileTreeButton.TabIndex = 2;
            this.FileTreeButton.Text = "Scan Network";
            this.FileTreeButton.UseVisualStyleBackColor = true;
            this.FileTreeButton.Click += new System.EventHandler(this.FileTreeButton_Click);
            // 
            // FilePathTextboxLabel
            // 
            this.FilePathTextboxLabel.AutoSize = true;
            this.FilePathTextboxLabel.Location = new System.Drawing.Point(216, 48);
            this.FilePathTextboxLabel.Name = "FilePathTextboxLabel";
            this.FilePathTextboxLabel.Size = new System.Drawing.Size(48, 13);
            this.FilePathTextboxLabel.TabIndex = 3;
            this.FilePathTextboxLabel.Text = "File Path";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 107);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(735, 408);
            this.dataGridView1.TabIndex = 4;
            // 
            // LoadDataSourceButton
            // 
            this.LoadDataSourceButton.Location = new System.Drawing.Point(219, 11);
            this.LoadDataSourceButton.Name = "LoadDataSourceButton";
            this.LoadDataSourceButton.Size = new System.Drawing.Size(332, 26);
            this.LoadDataSourceButton.TabIndex = 5;
            this.LoadDataSourceButton.Text = "Load Data Source";
            this.LoadDataSourceButton.UseVisualStyleBackColor = true;
            this.LoadDataSourceButton.Click += new System.EventHandler(this.LoadDataSourceButton_Click);
            // 
            // FilterButton
            // 
            this.FilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FilterButton.Location = new System.Drawing.Point(20, 76);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(111, 25);
            this.FilterButton.TabIndex = 6;
            this.FilterButton.Text = "Filter";
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // FilterTextBox
            // 
            this.FilterTextBox.Location = new System.Drawing.Point(137, 80);
            this.FilterTextBox.Name = "FilterTextBox";
            this.FilterTextBox.Size = new System.Drawing.Size(228, 20);
            this.FilterTextBox.TabIndex = 7;
            // 
            // ContainsFilterCheckBox
            // 
            this.ContainsFilterCheckBox.AutoSize = true;
            this.ContainsFilterCheckBox.Location = new System.Drawing.Point(371, 82);
            this.ContainsFilterCheckBox.Name = "ContainsFilterCheckBox";
            this.ContainsFilterCheckBox.Size = new System.Drawing.Size(67, 17);
            this.ContainsFilterCheckBox.TabIndex = 8;
            this.ContainsFilterCheckBox.Text = "Contains";
            this.ContainsFilterCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 543);
            this.Controls.Add(this.ContainsFilterCheckBox);
            this.Controls.Add(this.FilterTextBox);
            this.Controls.Add(this.FilterButton);
            this.Controls.Add(this.LoadDataSourceButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.FilePathTextboxLabel);
            this.Controls.Add(this.FileTreeButton);
            this.Controls.Add(this.FilePathTextbox);
            this.Controls.Add(this.ButtonTestPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "eDrawing Printer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button ButtonTestPrint;
        private System.Windows.Forms.TextBox FilePathTextbox;
        private System.Windows.Forms.Button FileTreeButton;
        private System.Windows.Forms.Label FilePathTextboxLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button LoadDataSourceButton;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.TextBox FilterTextBox;
        private System.Windows.Forms.CheckBox ContainsFilterCheckBox;
    }
}

