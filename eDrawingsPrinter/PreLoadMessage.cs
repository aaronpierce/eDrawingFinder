using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDrawingsPrinter
{
    class PreLoadMessage
    {
        public static void ShowMessageBox(string text, string caption)
        {
            Thread t = new Thread(() => CustomMessageBox(text, caption));
            t.Start();
        }

        private static void CustomMessageBox(object text, object caption) => MessageBox.Show((string)text, (string)caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
