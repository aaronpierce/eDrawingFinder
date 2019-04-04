using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDF.UI
{
    class MessageBoxes
    {
        public static void TooManyFilesSelected(string title)
        {
            MessageBox.Show("Too many files are currently selected.",
                            title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        public static void EDrawingsRequirmentError()
        {
            MessageBox.Show("Installation of eDrawings 2018 or newer was not found.",
                            "Error - Installation Missing",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
    }
}
