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
            this.PrintButton = new System.Windows.Forms.Button();
            this.MainDataGridView = new System.Windows.Forms.DataGridView();
            this.FilterSearchButton = new System.Windows.Forms.Button();
            this.FilterTextBox = new System.Windows.Forms.TextBox();
            this.StartsWithFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.OpenButton = new System.Windows.Forms.Button();
            this.OPRadioButton = new System.Windows.Forms.RadioButton();
            this.BMRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PrintButton
            // 
            this.PrintButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.PrintButton.Location = new System.Drawing.Point(612, 9);
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
            this.MainDataGridView.Location = new System.Drawing.Point(20, 41);
            this.MainDataGridView.Name = "MainDataGridView";
            this.MainDataGridView.ReadOnly = true;
            this.MainDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MainDataGridView.Size = new System.Drawing.Size(815, 474);
            this.MainDataGridView.TabIndex = 4;
            this.MainDataGridView.DoubleClick += new System.EventHandler(this.OpenButton_Click);
            // 
            // FilterSearchButton
            // 
            this.FilterSearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FilterSearchButton.Location = new System.Drawing.Point(20, 10);
            this.FilterSearchButton.Name = "FilterSearchButton";
            this.FilterSearchButton.Size = new System.Drawing.Size(93, 25);
            this.FilterSearchButton.TabIndex = 6;
            this.FilterSearchButton.Text = "Search";
            this.FilterSearchButton.UseVisualStyleBackColor = true;
            this.FilterSearchButton.Click += new System.EventHandler(this.FilterSearchButton_Click);
            // 
            // FilterTextBox
            // 
            this.FilterTextBox.Location = new System.Drawing.Point(137, 14);
            this.FilterTextBox.Name = "FilterTextBox";
            this.FilterTextBox.Size = new System.Drawing.Size(254, 20);
            this.FilterTextBox.TabIndex = 7;
            // 
            // StartsWithFilterCheckBox
            // 
            this.StartsWithFilterCheckBox.AutoSize = true;
            this.StartsWithFilterCheckBox.Location = new System.Drawing.Point(397, 16);
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
            this.OpenButton.Location = new System.Drawing.Point(711, 8);
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
            this.OPRadioButton.Location = new System.Drawing.Point(498, 15);
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
            this.BMRadioButton.Location = new System.Drawing.Point(544, 15);
            this.BMRadioButton.Name = "BMRadioButton";
            this.BMRadioButton.Size = new System.Drawing.Size(41, 17);
            this.BMRadioButton.TabIndex = 11;
            this.BMRadioButton.Text = "BM";
            this.BMRadioButton.UseVisualStyleBackColor = false;
            this.BMRadioButton.CheckedChanged += new System.EventHandler(this.BMRadioButton_CheckedChanged);
            // 
            // MainForm
            // 
            this.AcceptButton = this.FilterSearchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(856, 543);
            this.Controls.Add(this.BMRadioButton);
            this.Controls.Add(this.OPRadioButton);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.StartsWithFilterCheckBox);
            this.Controls.Add(this.FilterTextBox);
            this.Controls.Add(this.FilterSearchButton);
            this.Controls.Add(this.MainDataGridView);
            this.Controls.Add(this.PrintButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "eDrawing Finder";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGridView)).EndInit();
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
    }
}

