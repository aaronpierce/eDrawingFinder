using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace eDrawingFinder
{
    public class UserPreferences
    {
        public string Printer { get; set; }
        public bool Expanded { get; set; }

        public UserPreferences()
        {
            RegistryKey UserPrefs = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Pan-Oston\eDrawingFinder", true);

            if (UserPrefs != null)
            {
                Printer = UserPrefs.GetValue("DefaultPrinter").ToString();
                Expanded = Convert.ToBoolean(UserPrefs.GetValue("PreviewExpanded"));
            }
            else
            {
                Printer = String.Empty;
                Expanded = false;
            }
        }

        public void Save()
        {
            RegistryKey UserPrefs = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Pan-Oston\eDrawingFinder", true);

            if (UserPrefs == null)
            {
                // Value does not already exist so create it
                RegistryKey newKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Pan-Oston", true);
                UserPrefs = newKey.CreateSubKey("eDrawingFinder", true);
            }

            UserPrefs.SetValue("DefaultPrinter", Printer);
            UserPrefs.SetValue("PreviewExpanded", Expanded);
            UserPrefs.SetValue("CurrentVersion", MainForm.VERSION);
        }
    }
}
