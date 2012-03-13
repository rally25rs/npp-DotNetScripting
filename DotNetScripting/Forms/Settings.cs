using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NppPluginNET.Forms
{
    public partial class Settings : Form
    {
        private readonly PluginBase pluginBase;

        public Settings(PluginBase plgBase)
        {
            pluginBase = plgBase;
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            pluginBase.SaveSettings();
            Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
        }
    }
}