namespace EDF.UI
{
    partial class TestForm
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
            this.TestDataGridView = new System.Windows.Forms.DataGridView();
            this.LoadSQLButton = new System.Windows.Forms.Button();
            this.ScanToDbButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TestDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TestDataGridView
            // 
            this.TestDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TestDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TestDataGridView.Location = new System.Drawing.Point(12, 98);
            this.TestDataGridView.Name = "TestDataGridView";
            this.TestDataGridView.Size = new System.Drawing.Size(776, 340);
            this.TestDataGridView.TabIndex = 0;
            // 
            // LoadSQLButton
            // 
            this.LoadSQLButton.Location = new System.Drawing.Point(12, 12);
            this.LoadSQLButton.Name = "LoadSQLButton";
            this.LoadSQLButton.Size = new System.Drawing.Size(75, 23);
            this.LoadSQLButton.TabIndex = 1;
            this.LoadSQLButton.Text = "Load";
            this.LoadSQLButton.UseVisualStyleBackColor = true;
            this.LoadSQLButton.Click += new System.EventHandler(this.LoadSQLButton_Click);
            // 
            // ScanToDbButton
            // 
            this.ScanToDbButton.Location = new System.Drawing.Point(93, 12);
            this.ScanToDbButton.Name = "ScanToDbButton";
            this.ScanToDbButton.Size = new System.Drawing.Size(123, 23);
            this.ScanToDbButton.TabIndex = 2;
            this.ScanToDbButton.Text = "Scan To Database";
            this.ScanToDbButton.UseVisualStyleBackColor = true;
            this.ScanToDbButton.Click += new System.EventHandler(this.ScanToDbButton_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ScanToDbButton);
            this.Controls.Add(this.LoadSQLButton);
            this.Controls.Add(this.TestDataGridView);
            this.Name = "TestForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "TestForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.TestDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TestDataGridView;
        private System.Windows.Forms.Button LoadSQLButton;
        private System.Windows.Forms.Button ScanToDbButton;
    }
}