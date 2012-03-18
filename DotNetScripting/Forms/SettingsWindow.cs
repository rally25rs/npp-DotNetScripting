using System;
using System.Windows.Forms;

namespace NppPluginNET.Forms
{
    public partial class SettingsWindow : Form
    {
        public Settings Settings { get; private set; }

        public SettingsWindow(Settings settings)
        {
            InitializeComponent();
            CopySettingsValuesToUI(settings);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            CopyUIValuesToSettings();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CopyUIValuesToSettings()
        {
            Settings = new Settings
                           {
                               ShortcutKey = (Keys)Enum.Parse(typeof(Keys), txtShortcutKey.Text),
                               ShortcutKeyUseAlt = chkShortcutKeyAlt.Checked,
                               ShortcutKeyUseCtrl = chkShortcutKeyCtrl.Checked,
                               ShortcutKeyUseShift = chkShortcutKeyShift.Checked
                           };
        }

        private void CopySettingsValuesToUI(Settings settings)
        {
            txtShortcutKey.Text = Enum.GetName(typeof(Keys), settings.ShortcutKey);
            chkShortcutKeyAlt.Checked = settings.ShortcutKeyUseAlt;
            chkShortcutKeyCtrl.Checked = settings.ShortcutKeyUseCtrl;
            chkShortcutKeyShift.Checked = settings.ShortcutKeyUseShift;
        }

        private void txtShortcutKey_KeyUp(object sender, KeyEventArgs e)
        {
            txtShortcutKey.Text = Enum.GetName(typeof(Keys), e.KeyCode);
        }
    }
}