using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DotNetScripting.Forms
{
    public partial class RunScript : Form
    {
        private readonly List<RunScriptData> scriptHistory;
        private int scriptHistoryIndex;

        public RunScriptData ScriptData { get; private set; }

        public RunScript()
        {
            scriptHistory = new List<RunScriptData>();
            InitializeComponent();
            UpdateScriptHistoryCountLabel();
        }

        private void UpdateScriptHistoryCountLabel()
        {
            lblScriptCount.Text = string.Format("({0}/{1})", scriptHistory.Any() ? scriptHistoryIndex + 1 : 0, scriptHistory.Count);
        }

        private void SetUIElementsToSelectedScriptData(RunScriptData data)
        {
            ScriptData = data;
            rdoLanguageCSharp.Checked = data.Language == ScriptLanguage.CSharp;
            rdoLanguageVBasic.Checked = data.Language == ScriptLanguage.VisualBasic;
            rdoScopeCurrent.Checked = data.Scope == ScriptScope.CurrentFile;
            rdoScopeAllOpen.Checked = data.Scope == ScriptScope.AllOpenFiles;
            txtScriptBefore.Text = data.BeforeFileScript;
            txtScriptLine.Text = data.LineScript;
            txtScriptAfter.Text = data.AfterFileScript;
        }

        private RunScriptData CreateScriptDataInstanceFromUIElements()
        {
            var data = new RunScriptData();
            data.Language = rdoLanguageCSharp.Checked ? ScriptLanguage.CSharp : ScriptLanguage.VisualBasic;
            data.Scope = rdoScopeCurrent.Checked ? ScriptScope.CurrentFile : ScriptScope.AllOpenFiles;
            data.BeforeFileScript = txtScriptBefore.Text;
            data.LineScript = txtScriptLine.Text;
            data.AfterFileScript = txtScriptAfter.Text;
            return data;
        }

        private void cmdRun_Click(object sender, EventArgs e)
        {
            ScriptData = CreateScriptDataInstanceFromUIElements();
            scriptHistoryIndex = scriptHistory.FindIndex(x => x.Equals(ScriptData));
            if (scriptHistoryIndex < 0)
            {
                scriptHistory.Add(ScriptData);
                scriptHistoryIndex = scriptHistory.Count - 1;
            }
            else
            {
                ScriptData = scriptHistory[scriptHistoryIndex];
            }
            UpdateScriptHistoryCountLabel();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void RunScript_Shown(object sender, EventArgs e)
        {
            txtScriptBefore.Focus();
        }

        private void cmdPreviousScript_Click(object sender, EventArgs e)
        {
            if (scriptHistory.Count == 0)
                return;
            if (scriptHistoryIndex <= 0)
                scriptHistoryIndex = scriptHistory.Count;
            scriptHistoryIndex -= 1;
            ScriptData = scriptHistory[scriptHistoryIndex];
            SetUIElementsToSelectedScriptData(ScriptData);
            UpdateScriptHistoryCountLabel();
        }
    }
}
