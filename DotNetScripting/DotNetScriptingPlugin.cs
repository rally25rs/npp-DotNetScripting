using System;
using System.Windows.Forms;
using DotNetScripting.Forms;
using DotNetScripting.ScriptingEngines;
using NppPluginNET;

namespace DotNetScripting
{
    internal class DotNetScriptingPlugin
    {

        public const string APP_NAME = "DotNetScripting";
        public const string ERROR_WINDOW_TITLE = "DotNetScripting Plugin";
        
        private readonly NppData nppData;
        private readonly RunScript dlgRunScript;
        private readonly SettingsManager settingsManager;
        private Settings settings;

        public string PluginName { get { return APP_NAME; } }

        public DotNetScriptingPlugin(NppData nppData, SettingsManager settingsManager)
        {
            this.nppData = nppData;
            this.settingsManager = settingsManager;
            dlgRunScript = new RunScript();
        }

        public void CommandMenuInit()
        {
            try
            {
                if (settings == null)
                    settings = LoadSettings();

                PluginBase.SetCommand(0, "Run a .NET Script...", ShowScriptRunDialog, new ShortcutKey(settings.ShortcutKeyUseCtrl, settings.ShortcutKeyUseAlt, settings.ShortcutKeyUseShift, settings.ShortcutKey));
                PluginBase.SetCommand(1, "---", null);
                PluginBase.SetCommand(2, "Settings...", ShowSettings);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error in CommandMenuInit()." + e.Message);
            }
        }

        public void SetToolBarIcon()
        {
        }

        public void PluginCleanUp()
        {
            if (settings != null)
                SaveSettings();
        }

        private void ShowScriptRunDialog()
        {
            var result = dlgRunScript.ShowDialog();
            if (result == DialogResult.Cancel)
                return;
            RunScript(dlgRunScript.ScriptData);
        }

        private void ShowSettings()
        {
            using (var dlgSettings = new SettingsWindow(settings))
            {
                var dialogResult = dlgSettings.ShowDialog();
                if (dialogResult == DialogResult.OK)
                    settings = dlgSettings.Settings;
            }
        }

        private Settings LoadSettings()
        {
            try
            {
                return settingsManager.LoadSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading settings. " + ex.Message, ERROR_WINDOW_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            return null;
        }

        private void SaveSettings()
        {
            try
            {
                settingsManager.SaveSettings(settings);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving settings. " + ex.Message, ERROR_WINDOW_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void RunScript(RunScriptData scriptData)
        {
            try
            {
                var nppCommands = new NppCommands(nppData);
                IScriptingEngineRunner scriptingEngine;
                if (scriptData.Language == ScriptLanguage.CSharp)
                    scriptingEngine = new CSharpScriptingEngineRunner(scriptData.BeforeFileScript, scriptData.LineScript, scriptData.AfterFileScript);
                else if (scriptData.Language == ScriptLanguage.VisualBasic)
                    scriptingEngine = new VisualBasicScriptingEngineRunner();
                else
                    return;
                var runner = new ScriptRunner(scriptingEngine, nppCommands);
                runner.Run(scriptData.Scope);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error running script. " + e.Message, ERROR_WINDOW_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}