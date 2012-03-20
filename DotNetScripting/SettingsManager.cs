using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using NppPluginNET;

namespace DotNetScripting
{
    /// <summary>
    /// Loads and Saves settings to a file.
    /// The settings file itself is managed by Notepad++.
    /// </summary>
    internal class SettingsManager
    {
        private const string SETTING_SHORTCUT_ALT = "ShortcutAlt";
        private const string SETTING_SHORTCUT_SHIFT = "ShortcutShift";
        private const string SETTING_SHORTCUT_CTRL = "ShortcutCtrl";
        private const string SETTING_SHORTCUT_KEY = "ShortcutKey";

        private readonly NppData nppData;
        private readonly string pluginName;

        public SettingsManager(NppData nppData, string pluginName)
        {
            this.nppData = nppData;
            this.pluginName = pluginName;
        }

        internal Settings LoadSettings()
        {
            var settings = new Settings();
            var iniFilePath = GetSettingsFile();

            settings.ShortcutKey = StringToKey(GetSettingValue(iniFilePath, SETTING_SHORTCUT_KEY, KeyToString(Keys.S)));
            settings.ShortcutKeyUseAlt = StringToBool(GetSettingValue(iniFilePath, SETTING_SHORTCUT_ALT, BoolToString(true)));
            settings.ShortcutKeyUseCtrl = StringToBool(GetSettingValue(iniFilePath, SETTING_SHORTCUT_CTRL, BoolToString(true)));
            settings.ShortcutKeyUseShift = StringToBool(GetSettingValue(iniFilePath, SETTING_SHORTCUT_SHIFT, BoolToString(true)));

            return settings;
        }

        internal void SaveSettings(Settings settings)
        {
            var iniFilePath = GetSettingsFile();

            SaveSettingValue(iniFilePath, SETTING_SHORTCUT_KEY, KeyToString(settings.ShortcutKey));
            SaveSettingValue(iniFilePath, SETTING_SHORTCUT_ALT, BoolToString(settings.ShortcutKeyUseAlt));
            SaveSettingValue(iniFilePath, SETTING_SHORTCUT_CTRL, BoolToString(settings.ShortcutKeyUseCtrl));
            SaveSettingValue(iniFilePath, SETTING_SHORTCUT_SHIFT, BoolToString(settings.ShortcutKeyUseShift));
        }

        private string GetSettingsFile()
        {
            try
            {
                var sbIniFilePath = new StringBuilder(Win32.MAX_PATH);
                Win32.SendMessage(nppData._nppHandle, NppMsg.NPPM_GETPLUGINSCONFIGDIR, Win32.MAX_PATH, sbIniFilePath);
                var iniFilePath = sbIniFilePath.ToString();
                if (!Directory.Exists(iniFilePath)) Directory.CreateDirectory(iniFilePath);
                iniFilePath = Path.Combine(iniFilePath, pluginName + ".ini");
                return iniFilePath;
            }
            catch (Exception e)
            {
                throw new Exception("Unable to load settings path. " + e.Message, e);
            }
        }

        private string GetSettingValue(string iniFilePath, string settingName, string defaultValue)
        {
            var returnString = new StringBuilder(Win32.MAX_PATH);
            Win32.GetPrivateProfileString(DotNetScriptingPlugin.APP_NAME, settingName, defaultValue, returnString, Win32.MAX_PATH, iniFilePath);
            return returnString.ToString();
        }

        private void SaveSettingValue(string iniFilePath, string settingName, string settingValue)
        {
            Win32.WritePrivateProfileString(DotNetScriptingPlugin.APP_NAME, settingName, settingValue, iniFilePath);
        }

        private bool StringToBool(string value)
        {
            return value == "1";
        }

        private string BoolToString(bool value)
        {
            return value ? "1" : "0";
        }

        private Keys StringToKey(string value)
        {
            return (Keys)Enum.Parse(typeof(Keys), value);
        }

        private string KeyToString(Keys value)
        {
            return Enum.GetName(typeof(Keys), value);
        }
    }
}