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
        private readonly char[] newlineDelimiters = new[] { '\n' };

        #region " StartUp/CleanUp "

        private void CommandMenuInit()
        {
            try
            {
                if (Settings == null)
                    Settings = LoadSettings();

                SetCommand(0, "Run a .NET Script...", ShowScriptRunDialog, new ShortcutKey(true, false, true, Keys.Z));
                SetCommand(1, "---", null);
                SetCommand(2, "Settings...", ShowSettings);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error in CommandMenuInit()." + e.Message);
            }
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

        internal void ShowScriptRunDialog()
        {
            var dlgRun = new Forms.RunScript();
            var result = dlgRun.ShowDialog();
            if (result == DialogResult.Cancel)
                return;
            RunScript(dlgRun.Language, dlgRun.Scope, dlgRun.ScriptBefore, dlgRun.ScriptLine, dlgRun.ScriptAfter);
        }

        internal void ShowSettings()
        {
            var dlgSettings = new Forms.Settings(this);
            dlgSettings.ShowDialog();
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
            try
            {
                var sbIniFilePath = new StringBuilder(Win32.MAX_PATH);
                Win32.SendMessage(nppData._nppHandle, NppMsg.NPPM_GETPLUGINSCONFIGDIR, Win32.MAX_PATH, sbIniFilePath);
                var iniFilePath = sbIniFilePath.ToString();
                if (!Directory.Exists(iniFilePath)) Directory.CreateDirectory(iniFilePath);
                iniFilePath = Path.Combine(iniFilePath, _pluginBaseName + ".ini");
                return iniFilePath;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to load settings path. " + e.Message);
            }
            return null;
        }

        #endregion

        private void CharAdded(char character)
        {
        }

        private void RunScript(ScriptLanguage language, ScriptScope scope, string scriptBefore, string scriptLine, string scriptAfter)
        {
            var performUndo = false;
            var nppCommands = new NppCommands(nppData);
            nppCommands.StartUndoAction();
            try
            {
                var runner = new CSharpProgramRunner(nppCommands, scriptBefore, scriptLine, scriptAfter);
                runner.RunBefore();
                RunEachLine(nppCommands, runner);
                runner.RunAfter();
                nppCommands.ClearSelection();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                performUndo = true;
            }
            finally
            {
                nppCommands.EndUndoAction();
                if(performUndo)
                    nppCommands.UndoAction();
            }
        }

        private void RunEachLine(NppCommands nppCommands, CSharpProgramRunner runner)
        {
            var lineNum = 0;
            var numOfLoops = 0;
            var lastLine = false;
            while(lastLine || lineNum < nppCommands.GetLineCount())
            {
                // simple infinite loop protection.
                numOfLoops++;
                if (numOfLoops == 50)//Int32.MaxValue)
                {
                    MessageBox.Show(
                        "Line " + lineNum + " caused the .NET Scripting Plugin to infinite loop. Execution has been halted.",
                        APP_NAME,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }

                // see if we are on the last line.
                // if so, then this should be the last loop.
                if (lineNum == nppCommands.GetLineCount())
                    lastLine = true;

                // process the current line.
                nppCommands.SetSelectedText(nppCommands.GetLineStartPosition(lineNum), nppCommands.GetLineEndPosition(lineNum));
                var line = nppCommands.GetSelectedText();
                var newLine = runner.RunLine(line);

                // replace the line of text if it changed.
                if (line == null)
                {
                    nppCommands.DeleteLine(lineNum);
                }
                else if (line != newLine)
                {
                    nppCommands.ReplaceSelectedText(newLine);
                    lineNum += GetNumberOfNewlines(newLine);
                }
                else
                {
                    lineNum += 1;
                }
            }
        }

        private int GetNumberOfNewlines(string line)
        {
            var numOfNewlines = line.Split(newlineDelimiters).Length;
            return numOfNewlines > 0 ? numOfNewlines : 1;
        }
    }
}