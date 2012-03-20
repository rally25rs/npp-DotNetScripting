using System;
using System.Windows.Forms;
using DotNetScripting.ScriptingEngines;
using NppPluginNET;

namespace DotNetScripting
{
    internal class DotNetScriptingPlugin
    {
        private readonly NppData nppData;
        public const string APP_NAME = "DotNetScripting";
        public const string ERROR_WINDOW_TITLE = "DotNetScripting Plugin";

        private readonly SettingsManager settingsManager;
        private Settings settings;

        public string PluginName { get { return APP_NAME; } }

        public DotNetScriptingPlugin(NppData nppData, SettingsManager settingsManager)
        {
            this.nppData = nppData;
            this.settingsManager = settingsManager;
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
            using (var dlgRun = new Forms.RunScript())
            {
                var result = dlgRun.ShowDialog();
                if (result == DialogResult.Cancel)
                    return;
                RunScript(dlgRun.Language, dlgRun.Scope, dlgRun.ScriptBefore, dlgRun.ScriptLine, dlgRun.ScriptAfter);
            }
        }

        private void ShowSettings()
        {
            using (var dlgSettings = new Forms.SettingsWindow(settings))
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

        private void RunScript(ScriptLanguage language, ScriptScope scope, string scriptBefore, string scriptLine, string scriptAfter)
        {
            try
            {
                var nppCommands = new NppCommands(nppData);
                IScriptingEngineRunner scriptingEngine;
                if (language == ScriptLanguage.CSharp)
                    scriptingEngine = new CSharpScriptingEngineRunner(scriptBefore, scriptLine, scriptAfter);
                else if (language == ScriptLanguage.VisualBasic)
                    scriptingEngine = new VisualBasicScriptingEngineRunner();
                else
                    return;
                var runner = new ScriptRunner(scriptingEngine, nppCommands);
                runner.Run(scope);
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