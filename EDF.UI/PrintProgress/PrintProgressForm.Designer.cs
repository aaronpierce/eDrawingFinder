namespace EDF.UI
{
    partial class PrintProgressForm
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
            this.PrintProgressBar = new System.Windows.Forms.ProgressBar();
            this.PrintProgressLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PrintProgressBar
            // 
            this.PrintProgressBar.Location = new System.Drawing.Point(12, 34);
            this.PrintProgressBar.Name = "PrintProgressBar";
            this.PrintProgressBar.Size = new System.Drawing.Size(284, 19);
            this.PrintProgressBar.TabIndex = 0;
            // 
            // PrintProgressLabel
            // 
            this.PrintProgressLabel.AutoSize = true;
            this.PrintProgressLabel.Location = new System.Drawing.Point(150, 9);
            this.PrintProgressLabel.Name = "PrintProgressLabel";
            this.PrintProgressLabel.Size = new System.Drawing.Size(0, 13);
            this.PrintProgressLabel.TabIndex = 1;
            // 
            // PrintProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 66);
            this.Controls.Add(this.PrintProgressLabel);
            this.Controls.Add(this.PrintProgressBar);
            this.Name = "PrintProgressForm";
            this.Text = "PrintProgress";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar PrintProgressBar;
        private System.Windows.Forms.Label PrintProgressLabel;
    }
}