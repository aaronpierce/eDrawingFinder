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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.FilePathTextbox = new System.Windows.Forms.TextBox();
            this.FileTreeButton = new System.Windows.Forms.Button();
            this.FilePathTextboxLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonTestPrint
            // 
            this.ButtonTestPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonTestPrint.Location = new System.Drawing.Point(19, 11);
            this.ButtonTestPrint.Name = "ButtonTestPrint";
            this.ButtonTestPrint.Size = new System.Drawing.Size(111, 25);
            this.ButtonTestPrint.TabIndex = 0;
            this.ButtonTestPrint.Text = "Print Test";
            this.ButtonTestPrint.UseVisualStyleBackColor = true;
            this.ButtonTestPrint.Click += new System.EventHandler(this.ButtonTestPrint_Click);
            // 
            // FilePathTextbox
            // 
            this.FilePathTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FilePathTextbox.Location = new System.Drawing.Point(88, 42);
            this.FilePathTextbox.Name = "FilePathTextbox";
            this.FilePathTextbox.Size = new System.Drawing.Size(281, 20);
            this.FilePathTextbox.TabIndex = 1;
            this.FilePathTextbox.Text = "C:\\Users\\apierce\\Desktop\\TestFolder";
            // 
            // FileTreeButton
            // 
            this.FileTreeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileTreeButton.Location = new System.Drawing.Point(270, 10);
            this.FileTreeButton.Name = "FileTreeButton";
            this.FileTreeButton.Size = new System.Drawing.Size(111, 26);
            this.FileTreeButton.TabIndex = 2;
            this.FileTreeButton.Text = "Directory Info";
            this.FileTreeButton.UseVisualStyleBackColor = true;
            this.FileTreeButton.Click += new System.EventHandler(this.FileTreeButton_Click);
            // 
            // FilePathTextboxLabel
            // 
            this.FilePathTextboxLabel.AutoSize = true;
            this.FilePathTextboxLabel.Location = new System.Drawing.Point(34, 45);
            this.FilePathTextboxLabel.Name = "FilePathTextboxLabel";
            this.FilePathTextboxLabel.Size = new System.Drawing.Size(48, 13);
            this.FilePathTextboxLabel.TabIndex = 3;
            this.FilePathTextboxLabel.Text = "File Path";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 159);
            this.Controls.Add(this.FilePathTextboxLabel);
            this.Controls.Add(this.FileTreeButton);
            this.Controls.Add(this.FilePathTextbox);
            this.Controls.Add(this.ButtonTestPrint);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "eDrawing Printer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button ButtonTestPrint;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox FilePathTextbox;
        private System.Windows.Forms.Button FileTreeButton;
        private System.Windows.Forms.Label FilePathTextboxLabel;
    }
}

