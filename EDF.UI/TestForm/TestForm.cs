using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using EDF.DL;
using EDF.BL;

namespace EDF.UI
{
    public partial class TestForm : Form
    {
        private static bool IsOpen { get; set; } = false;
        public TestForm()
        {
            InitializeComponent();
        }
        public static TestForm New()
        {
            if (!IsOpen)
            {
                IsOpen = true;
                return new TestForm();
            }
            else
            {
                MainForm.testForm.BringToFront();
                return MainForm.testForm;
            }
        }

        private void LoadSQLButton_Click(object sender, EventArgs e)
        {
            List<EDF.DL.Drawing> drawings = SqliteDataAccess.LoadAllDrawings();
            using (DataTable dt = new DataTable())
            {
                TestDataGridView.DataSource = drawings;
            }
        }

        private void TestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsOpen = false;
        }

        private void ScanToDbButton_Click(object sender, EventArgs e)
        {
            DirectoryScan.DirectorySearch();
        }
    }
}
