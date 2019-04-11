using System;
using System.Collections.Generic;
using System.IO;
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
            else
                FilePrint.SelectedPrinter = Properties.Settings.Default.DefaultPrinter;

            if (!(Properties.Settings.Default.eDrawingDefault))
                MainReference.EDrawingsDefaultMainToolStipMenuReference.CheckState = System.Windows.Forms.CheckState.Unchecked;
            else
                FileOpen.EDrawingsInstall = Data.GetMostRecentEDrawingInstall();

            if (Properties.Settings.Default.ReactiveCheckbox)
                MainReference.CheckboxFilterMainToolStipMenuReference.CheckState = System.Windows.Forms.CheckState.Checked;


            string t = "\t\t\t\t\t\t\t\t\t\t";
            Log.Write.Info(String.Format("Loaded Settings:\n{0}\n{1}\n{2}\n{3}",
                                $"{t}Expanded Form: -- {Properties.Settings.Default.FormExpanded}",
                                $"{t}Printer Default: -- {(Properties.Settings.Default.DefaultPrinter.Contains(@"\") ? Properties.Settings.Default.DefaultPrinter.Split('\\').Last() : Properties.Settings.Default.DefaultPrinter)}",
                                $"{t}Open with eDrawings: -- {Properties.Settings.Default.eDrawingDefault}",
                                $"{t}Reactive Checkbox: -- {Properties.Settings.Default.ReactiveCheckbox}"
                            ));
        }

        public static void Save()
        {
            //Set and Save Settings
            Properties.Settings.Default.DefaultPrinter = FilePrint.SelectedPrinter;
            Properties.Settings.Default.FormExpanded = Preview.MainFormExpanded;
            Properties.Settings.Default.eDrawingDefault = MainReference.EDrawingsDefaultMainToolStipMenuReference.Checked;
            Properties.Settings.Default.ReactiveCheckbox = MainReference.CheckboxFilterMainToolStipMenuReference.Checked;

            string t = "\t\t\t\t\t\t\t\t\t\t";
            Log.Write.Info(String.Format("Saved Settings:\n{0}\n{1}\n{2}\n{3}",
                                $"{t}Expanded Form: -- {Preview.MainFormExpanded}",
                                $"{t}Printer Default: -- {(FilePrint.SelectedPrinter.Contains(@"\") ? FilePrint.SelectedPrinter.Split('\\').Last() : FilePrint.SelectedPrinter)}",
                                $"{t}Open with eDrawings: -- {MainReference.EDrawingsDefaultMainToolStipMenuReference.Checked}",
                                $"{t}Reactive Checkbox: -- {MainReference.CheckboxFilterMainToolStipMenuReference.Checked}"
                            ));

            Properties.Settings.Default.Save();
        }
    }
}
