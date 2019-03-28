using EDF.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDF.UI
{
    public partial class AlertForm : Form
    {
        public static Thread CreateDBAlertThread {get; set;}
        public AlertForm(string message, string title)
        {
            InitializeComponent();
            Setup(message, title);
        }

        private void Setup(string message, string title)
        {
            this.MessageLabel.Text = message;
            this.Text = title;
        }

        public static void ShowCreateDBAlert()
        {
            Log.Write.Debug("In ShowCreateDBAlert Function");

            string message = "Creating initial database image.\n\n" +
                             "This is a one time process. Estimated wait is 15 seconds...\n\n" +
                             "This window will close on completion.";

            string title = "Creating Database";

            AlertForm alert = new AlertForm(message, title);
            CreateDBAlertThread = new Thread(() => alert.ShowDialog());
            CreateDBAlertThread.Start();
        }
    }


}
