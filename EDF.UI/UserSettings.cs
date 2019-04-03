using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDF.Common;
using EDF.DL;

namespace EDF.UI
{
    class UserSettings
    {
        public static void Apply()
        {
            if (!(Properties.Settings.Default.FormExpanded == Preview.MainFormExpanded))
                Preview.Expand();

            if (!(string.IsNullOrEmpty(Properties.Settings.Default.DefaultPrinter)))
                FilePrint.SelectedPrinter = Properties.Settings.Default.DefaultPrinter;

            if (!(Properties.Settings.Default.eDrawingDefault))
                MainReference.EDrawingsDefaultMainToolStipMenuReference.CheckState = System.Windows.Forms.CheckState.Unchecked;
            else
                FileOpen.EDrawingsInstall = Data.GetMostRecentEDrawingInstall();


            Log.Write.Debug($"Loaded Settings - Expanded {Properties.Settings.Default.FormExpanded}, " +
                            $"Printer {Properties.Settings.Default.DefaultPrinter}, " +
                            $"eDrawing {Properties.Settings.Default.eDrawingDefault}"
                            );
        }

        public static void Save()
        {
            //Set and Save Settings
            Properties.Settings.Default.DefaultPrinter = FilePrint.SelectedPrinter;
            Properties.Settings.Default.FormExpanded = Preview.MainFormExpanded;
            Properties.Settings.Default.eDrawingDefault = MainReference.EDrawingsDefaultMainToolStipMenuReference.Checked;

            Log.Write.Debug($"Saved Settings - Expanded {Preview.MainFormExpanded}, " +
                            $"Printer {FilePrint.SelectedPrinter}, " +
                            $"eDrawing {MainReference.EDrawingsDefaultMainToolStipMenuReference.Checked}"
                            );

            Properties.Settings.Default.Save();
        }
    }
}
