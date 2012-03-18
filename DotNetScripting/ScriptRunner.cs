using System;
using System.Threading;
using System.Windows.Forms;
using NppPluginNET.ScriptingEngines;

namespace NppPluginNET
{
    /// <summary>
    /// This class handles running the user-entered script code against files open in Notepad++.
    /// </summary>
    internal class ScriptRunner
    {
        private readonly char[] newlineDelimiters = new[] { '\n' };
        private readonly IScriptingEngineRunner scriptingEngine;
        private readonly NppCommands nppCommands;

        public ScriptRunner(IScriptingEngineRunner scriptingEngine, NppCommands nppCommands)
        {
            this.scriptingEngine = scriptingEngine;
            this.nppCommands = nppCommands;
        }

        public void Run(ScriptScope scope)
        {
            if (scope == ScriptScope.CurrentFile)
                RunFile();
            else if (scope == ScriptScope.AllOpenFiles)
                RunAllFiles();
        }

        private void RunAllFiles()
        {
            uint numberOfOpenFiles;
            try
            {
                numberOfOpenFiles = nppCommands.GetNumberOfOpenFiles();
            }
            catch
            {
                MessageBox.Show("Could not determine the number of open files.");
                return;
            }
            for (var fileIndex = 0; fileIndex < numberOfOpenFiles; fileIndex++)
            {
                try
                {
                    nppCommands.SwitchToFile(fileIndex);
                }
                catch
                {
                    MessageBox.Show("Unable to switch to document with index " + fileIndex);
                }
                RunFile();
            }
        }

        private void RunFile()
        {
            var performUndo = false;
            nppCommands.StartUndoAction();
            try
            {
                scriptingEngine.RunBefore();
                RunEachLine();
                scriptingEngine.RunAfter();
                nppCommands.ClearSelection();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, PluginBase.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                performUndo = true;
            }
            finally
            {
                nppCommands.EndUndoAction();
                if (performUndo)
                    nppCommands.UndoAction();
            }
        }

        private void RunEachLine()
        {
            var lineNum = 0;
            var numOfLoops = 0;
            var lastLine = false;
            while (lastLine || lineNum < nppCommands.GetLineCount())
            {
                numOfLoops++;
                if (ScriptHasRunTooLong(lineNum, numOfLoops))
                    return;
                lastLine = IsOnLastLine(lineNum);
                var line = GetCurrentLine(lineNum);
                var newLine = scriptingEngine.RunLine(line);
                lineNum += ReplaceTextIfItChanged(lineNum, line, newLine);
                Thread.Sleep(0);
            }
        }

        /// <summary>
        /// See if we are on the last line.
        /// if so, then this should be the last loop.
        /// This was done to prevent an infinite loop at the end when
        /// the script adds a newline to the end of the file, then
        /// it shouldnt process that added newline.
        /// </summary>
        private bool IsOnLastLine(int lineNum)
        {
            return lineNum == nppCommands.GetLineCount();
        }

        private int ReplaceTextIfItChanged(int lineNum, string oldLine, string newLine)
        {
            if (oldLine == null)
            {
                nppCommands.DeleteLine(lineNum);
                return 0;
            }
            if (oldLine != newLine)
            {
                nppCommands.ReplaceSelectedText(newLine);
                return GetNumberOfNewlines(newLine);
            }
            return 1;
        }

        private string GetCurrentLine(int lineNum)
        {
            var startPos = nppCommands.GetLineStartPosition(lineNum);
            var endPos = nppCommands.GetLineEndPosition(lineNum);
            nppCommands.SetSelectedText(startPos, endPos);
            return nppCommands.GetSelectedText(endPos - startPos + 1);
        }

        private static bool ScriptHasRunTooLong(int lineNum, int numOfLoops)
        {
            if (numOfLoops == Int32.MaxValue)
            {
                MessageBox.Show(
                    "Line " + lineNum + " caused the .NET Scripting Plugin to infinite loop. Execution has been halted.",
                    PluginBase.APP_NAME,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return true;
            }
            return false;
        }

        private int GetNumberOfNewlines(string line)
        {
            var numOfNewlines = line.Split(newlineDelimiters).Length;
            return numOfNewlines > 0 ? numOfNewlines : 1;
        }
    }
}