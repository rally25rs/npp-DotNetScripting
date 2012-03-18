namespace NppPluginNET.Forms
{
  partial class SettingsWindow
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.panel1 = new System.Windows.Forms.Panel();
        this.cmdCancel = new System.Windows.Forms.Button();
        this.cmdSave = new System.Windows.Forms.Button();
        this.panel2 = new System.Windows.Forms.Panel();
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
        this.chkShortcutKeyShift = new System.Windows.Forms.CheckBox();
        this.chkShortcutKeyCtrl = new System.Windows.Forms.CheckBox();
        this.chkShortcutKeyAlt = new System.Windows.Forms.CheckBox();
        this.txtShortcutKey = new System.Windows.Forms.TextBox();
        this.panel1.SuspendLayout();
        this.panel2.SuspendLayout();
        this.groupBox1.SuspendLayout();
        this.flowLayoutPanel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // panel1
        // 
        this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
        this.panel1.Controls.Add(this.cmdCancel);
        this.panel1.Controls.Add(this.cmdSave);
        this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.panel1.Location = new System.Drawing.Point(0, 232);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(413, 30);
        this.panel1.TabIndex = 3;
        // 
        // cmdCancel
        // 
        this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.cmdCancel.Location = new System.Drawing.Point(244, 4);
        this.cmdCancel.Name = "cmdCancel";
        this.cmdCancel.Size = new System.Drawing.Size(75, 23);
        this.cmdCancel.TabIndex = 1;
        this.cmdCancel.Text = "Cancel";
        this.cmdCancel.UseVisualStyleBackColor = true;
        // 
        // cmdSave
        // 
        this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.cmdSave.Location = new System.Drawing.Point(326, 3);
        this.cmdSave.Name = "cmdSave";
        this.cmdSave.Size = new System.Drawing.Size(75, 23);
        this.cmdSave.TabIndex = 0;
        this.cmdSave.Text = "Save";
        this.cmdSave.UseVisualStyleBackColor = true;
        this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
        // 
        // panel2
        // 
        this.panel2.AutoScroll = true;
        this.panel2.Controls.Add(this.groupBox1);
        this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.panel2.Location = new System.Drawing.Point(0, 0);
        this.panel2.Name = "panel2";
        this.panel2.Padding = new System.Windows.Forms.Padding(3);
        this.panel2.Size = new System.Drawing.Size(413, 232);
        this.panel2.TabIndex = 4;
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.flowLayoutPanel1);
        this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
        this.groupBox1.Location = new System.Drawing.Point(3, 3);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(407, 45);
        this.groupBox1.TabIndex = 0;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Run .NET Script Shortcut Key (Requires Restart of Notepad++)";
        // 
        // flowLayoutPanel1
        // 
        this.flowLayoutPanel1.Controls.Add(this.chkShortcutKeyShift);
        this.flowLayoutPanel1.Controls.Add(this.chkShortcutKeyCtrl);
        this.flowLayoutPanel1.Controls.Add(this.chkShortcutKeyAlt);
        this.flowLayoutPanel1.Controls.Add(this.txtShortcutKey);
        this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
        this.flowLayoutPanel1.Name = "flowLayoutPanel1";
        this.flowLayoutPanel1.Size = new System.Drawing.Size(401, 26);
        this.flowLayoutPanel1.TabIndex = 0;
        // 
        // chkShortcutKeyShift
        // 
        this.chkShortcutKeyShift.AutoSize = true;
        this.chkShortcutKeyShift.Location = new System.Drawing.Point(3, 3);
        this.chkShortcutKeyShift.Name = "chkShortcutKeyShift";
        this.chkShortcutKeyShift.Size = new System.Drawing.Size(47, 17);
        this.chkShortcutKeyShift.TabIndex = 0;
        this.chkShortcutKeyShift.Text = "Shift";
        this.chkShortcutKeyShift.UseVisualStyleBackColor = true;
        // 
        // chkShortcutKeyCtrl
        // 
        this.chkShortcutKeyCtrl.AutoSize = true;
        this.chkShortcutKeyCtrl.Location = new System.Drawing.Point(56, 3);
        this.chkShortcutKeyCtrl.Name = "chkShortcutKeyCtrl";
        this.chkShortcutKeyCtrl.Size = new System.Drawing.Size(41, 17);
        this.chkShortcutKeyCtrl.TabIndex = 1;
        this.chkShortcutKeyCtrl.Text = "Ctrl";
        this.chkShortcutKeyCtrl.UseVisualStyleBackColor = true;
        // 
        // chkShortcutKeyAlt
        // 
        this.chkShortcutKeyAlt.AutoSize = true;
        this.chkShortcutKeyAlt.Location = new System.Drawing.Point(103, 3);
        this.chkShortcutKeyAlt.Name = "chkShortcutKeyAlt";
        this.chkShortcutKeyAlt.Size = new System.Drawing.Size(38, 17);
        this.chkShortcutKeyAlt.TabIndex = 2;
        this.chkShortcutKeyAlt.Text = "Alt";
        this.chkShortcutKeyAlt.UseVisualStyleBackColor = true;
        // 
        // txtShortcutKey
        // 
        this.txtShortcutKey.Location = new System.Drawing.Point(147, 3);
        this.txtShortcutKey.Name = "txtShortcutKey";
        this.txtShortcutKey.Size = new System.Drawing.Size(100, 20);
        this.txtShortcutKey.TabIndex = 3;
        this.txtShortcutKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtShortcutKey_KeyUp);
        // 
        // SettingsWindow
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.cmdCancel;
        this.ClientSize = new System.Drawing.Size(413, 262);
        this.Controls.Add(this.panel2);
        this.Controls.Add(this.panel1);
        this.Name = "SettingsWindow";
        this.Text = "Dot Net Scripting (Settings)";
        this.panel1.ResumeLayout(false);
        this.panel2.ResumeLayout(false);
        this.groupBox1.ResumeLayout(false);
        this.flowLayoutPanel1.ResumeLayout(false);
        this.flowLayoutPanel1.PerformLayout();
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button cmdCancel;
    private System.Windows.Forms.Button cmdSave;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.CheckBox chkShortcutKeyShift;
    private System.Windows.Forms.CheckBox chkShortcutKeyCtrl;
    private System.Windows.Forms.CheckBox chkShortcutKeyAlt;
    private System.Windows.Forms.TextBox txtShortcutKey;
  }
}