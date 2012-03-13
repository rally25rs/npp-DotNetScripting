using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace NppPluginNET
{
    public partial class PluginBase
    {
        private const string APP_NAME = "DotNetScripting";
        private const string ERROR_WINDOW_TITLE = "DotNetScripting Plugin";

        internal Settings Settings;

        #region " StartUp/CleanUp "

        private void CommandMenuInit()
        {
            if (Settings == null)
                Settings = LoadSettings();

            //SetCommand(0, "Run Ruby Script(This File)", runTestClass, new ShortcutKey(true, false, true, Keys.Y));
            //SetCommand(1, "Run Test (Single Method)", runTestMethod, new ShortcutKey(true, false, true, Keys.T));
            //SetCommand(2, "---", null);
            //SetCommand(3, "Toggle Output Window", toggleOutputDialog, new ShortcutKey(true, false, true, Keys.R));
            //SetCommand(4, "Toggle Auto-Insert 'end's", toggleInsertEnds, Settings.InsertEnds);
            //SetCommand(5, "---", null);
            SetCommand(0, "Settings...", ShowSettings);
        }

        private void SetToolBarIcon()
        {
        }

        private void PluginCleanUp()
        {
            if (Settings != null)
                SaveSettings();
        }

        #endregion

        #region " Menu functions "

        internal void ShowSettings()
        {
            var dlgSettings = new Forms.Settings(this);
            dlgSettings.ShowDialog();
        }

        #endregion

        #region Scintilla messaging convenience methods.

        public int SendScintillaMessage(SciMsg msg)
        {
            return SendScintillaMessage(msg, 0);
        }

        public int SendScintillaMessage(SciMsg msg, int lparam)
        {
            return SendScintillaMessage(msg, lparam, 0);
        }

        public int SendScintillaMessage(SciMsg msg, int lparam, int rparam)
        {
            return (int)Win32.SendMessage(GetCurrentScintilla(), msg, lparam, rparam);
        }

        #endregion

        #region Load and Save Settings

        private Settings LoadSettings()
        {
            var settings = new Settings();
            try
            {
                var iniFilePath = GetSettingsFile();
                var returnString = new StringBuilder(Win32.MAX_PATH);

                //Win32.GetPrivateProfileString(SETTINGS_APP_NAME, "RubyPath", "", returnString, Win32.MAX_PATH, iniFilePath);
                //settings.RubyPath = returnString.ToString();

                //Win32.GetPrivateProfileString(SETTINGS_APP_NAME, "InsertEnds", "1", returnString, Win32.MAX_PATH, iniFilePath);
                //settings.InsertEnds = returnString.ToString() == "1";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading settings. " + ex.Message, ERROR_WINDOW_TITLE, MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            return settings;
        }

        internal void SaveSettings()
        {
            try
            {
                var iniFilePath = GetSettingsFile();

                //Win32.WritePrivateProfileString(SETTINGS_APP_NAME, "RubyPath", Settings.RubyPath, iniFilePath);
                //Win32.WritePrivateProfileString(SETTINGS_APP_NAME, "InsertEnds", Settings.InsertEnds ? "1" : "0", iniFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving settings. " + ex.Message, ERROR_WINDOW_TITLE, MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private string GetSettingsFile()
        {
            var sbIniFilePath = new StringBuilder(Win32.MAX_PATH);
            Win32.SendMessage(nppData._nppHandle, NppMsg.NPPM_GETPLUGINSCONFIGDIR, Win32.MAX_PATH, sbIniFilePath);
            var iniFilePath = sbIniFilePath.ToString();
            if (!Directory.Exists(iniFilePath)) Directory.CreateDirectory(iniFilePath);
            iniFilePath = Path.Combine(iniFilePath, _pluginBaseName + ".ini");
            return iniFilePath;
        }

        #endregion

        private void CharAdded(char character)
        {
        }
    }
}