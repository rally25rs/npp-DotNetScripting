using System.Windows.Forms;

namespace NppPluginNET.Forms
{
    public partial class RunScript : Form
    {
        public RunScript()
        {
            InitializeComponent();
        }

        public ScriptLanguage Language
        {
            get { return rdoLanguageCSharp.Checked ? ScriptLanguage.CSharp : ScriptLanguage.VisualBasic; }
        }

        public ScriptScope Scope
        {
            get { return rdoScopeCurrent.Checked ? ScriptScope.CurrentFile : ScriptScope.AllOpenFiles; }
        }

        public string ScriptBefore
        {
            get { return txtScriptBefore.Text; }
        }

        public string ScriptLine
        {
            get { return txtScriptLine.Text; }
        }

        public string ScriptAfter
        {
            get { return txtScriptAfter.Text; }
        }

        private void cmdRun_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void RunScript_Shown(object sender, System.EventArgs e)
        {
            txtScriptBefore.Focus();
        }
    }
}
