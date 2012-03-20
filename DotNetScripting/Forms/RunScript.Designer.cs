namespace DotNetScripting.Forms
{
    partial class RunScript
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
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdRun = new System.Windows.Forms.Button();
            this.pnlScript = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtScriptAfter = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtScriptLine = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtScriptBefore = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.rdoScopeCurrent = new System.Windows.Forms.RadioButton();
            this.rdoScopeAllOpen = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rdoLanguageCSharp = new System.Windows.Forms.RadioButton();
            this.rdoLanguageVBasic = new System.Windows.Forms.RadioButton();
            this.pnlButtons.SuspendLayout();
            this.pnlScript.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlButtons.Controls.Add(this.cmdCancel);
            this.pnlButtons.Controls.Add(this.cmdRun);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 482);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(534, 30);
            this.pnlButtons.TabIndex = 0;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(366, 3);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdRun
            // 
            this.cmdRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRun.Location = new System.Drawing.Point(447, 3);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(75, 23);
            this.cmdRun.TabIndex = 0;
            this.cmdRun.Text = "Run";
            this.cmdRun.UseVisualStyleBackColor = true;
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
            // 
            // pnlScript
            // 
            this.pnlScript.AutoScroll = true;
            this.pnlScript.Controls.Add(this.groupBox5);
            this.pnlScript.Controls.Add(this.groupBox4);
            this.pnlScript.Controls.Add(this.groupBox3);
            this.pnlScript.Controls.Add(this.panel1);
            this.pnlScript.Controls.Add(this.groupBox2);
            this.pnlScript.Controls.Add(this.groupBox1);
            this.pnlScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScript.Location = new System.Drawing.Point(0, 0);
            this.pnlScript.Name = "pnlScript";
            this.pnlScript.Padding = new System.Windows.Forms.Padding(3);
            this.pnlScript.Size = new System.Drawing.Size(534, 482);
            this.pnlScript.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtScriptAfter);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 350);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(528, 128);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "After Each File, Do:";
            // 
            // txtScriptAfter
            // 
            this.txtScriptAfter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScriptAfter.Location = new System.Drawing.Point(3, 16);
            this.txtScriptAfter.Multiline = true;
            this.txtScriptAfter.Name = "txtScriptAfter";
            this.txtScriptAfter.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtScriptAfter.Size = new System.Drawing.Size(522, 109);
            this.txtScriptAfter.TabIndex = 1;
            this.txtScriptAfter.WordWrap = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtScriptLine);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 222);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(528, 128);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "For Each Line, Do:";
            // 
            // txtScriptLine
            // 
            this.txtScriptLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScriptLine.Location = new System.Drawing.Point(3, 16);
            this.txtScriptLine.Multiline = true;
            this.txtScriptLine.Name = "txtScriptLine";
            this.txtScriptLine.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtScriptLine.Size = new System.Drawing.Size(522, 109);
            this.txtScriptLine.TabIndex = 1;
            this.txtScriptLine.WordWrap = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtScriptBefore);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 94);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(528, 128);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Before Each File, Do:";
            // 
            // txtScriptBefore
            // 
            this.txtScriptBefore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScriptBefore.Location = new System.Drawing.Point(3, 16);
            this.txtScriptBefore.Multiline = true;
            this.txtScriptBefore.Name = "txtScriptBefore";
            this.txtScriptBefore.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtScriptBefore.Size = new System.Drawing.Size(522, 109);
            this.txtScriptBefore.TabIndex = 0;
            this.txtScriptBefore.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 3);
            this.panel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(528, 44);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scope";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.rdoScopeCurrent);
            this.flowLayoutPanel2.Controls.Add(this.rdoScopeAllOpen);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(522, 25);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // rdoScopeCurrent
            // 
            this.rdoScopeCurrent.AutoSize = true;
            this.rdoScopeCurrent.Checked = true;
            this.rdoScopeCurrent.Location = new System.Drawing.Point(3, 3);
            this.rdoScopeCurrent.Name = "rdoScopeCurrent";
            this.rdoScopeCurrent.Size = new System.Drawing.Size(111, 17);
            this.rdoScopeCurrent.TabIndex = 0;
            this.rdoScopeCurrent.TabStop = true;
            this.rdoScopeCurrent.Text = "Current Document";
            this.rdoScopeCurrent.UseVisualStyleBackColor = true;
            // 
            // rdoScopeAllOpen
            // 
            this.rdoScopeAllOpen.AutoSize = true;
            this.rdoScopeAllOpen.Location = new System.Drawing.Point(120, 3);
            this.rdoScopeAllOpen.Name = "rdoScopeAllOpen";
            this.rdoScopeAllOpen.Size = new System.Drawing.Size(119, 17);
            this.rdoScopeAllOpen.TabIndex = 1;
            this.rdoScopeAllOpen.TabStop = true;
            this.rdoScopeAllOpen.Text = "All OpenDocuments";
            this.rdoScopeAllOpen.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Script Language";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.rdoLanguageCSharp);
            this.flowLayoutPanel1.Controls.Add(this.rdoLanguageVBasic);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(522, 25);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // rdoLanguageCSharp
            // 
            this.rdoLanguageCSharp.AutoSize = true;
            this.rdoLanguageCSharp.Checked = true;
            this.rdoLanguageCSharp.Enabled = false;
            this.rdoLanguageCSharp.Location = new System.Drawing.Point(3, 3);
            this.rdoLanguageCSharp.Name = "rdoLanguageCSharp";
            this.rdoLanguageCSharp.Size = new System.Drawing.Size(39, 17);
            this.rdoLanguageCSharp.TabIndex = 0;
            this.rdoLanguageCSharp.TabStop = true;
            this.rdoLanguageCSharp.Text = "C#";
            this.rdoLanguageCSharp.UseVisualStyleBackColor = true;
            // 
            // rdoLanguageVBasic
            // 
            this.rdoLanguageVBasic.AutoSize = true;
            this.rdoLanguageVBasic.Enabled = false;
            this.rdoLanguageVBasic.Location = new System.Drawing.Point(48, 3);
            this.rdoLanguageVBasic.Name = "rdoLanguageVBasic";
            this.rdoLanguageVBasic.Size = new System.Drawing.Size(319, 17);
            this.rdoLanguageVBasic.TabIndex = 1;
            this.rdoLanguageVBasic.Text = "Visual Basic (Sorry, VB.NET is not supported by Roslyn... yet?)";
            this.rdoLanguageVBasic.UseVisualStyleBackColor = true;
            // 
            // RunScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(534, 512);
            this.Controls.Add(this.pnlScript);
            this.Controls.Add(this.pnlButtons);
            this.Name = "RunScript";
            this.ShowIcon = false;
            this.Text = "Run a .NET Script";
            this.Shown += new System.EventHandler(this.RunScript_Shown);
            this.pnlButtons.ResumeLayout(false);
            this.pnlScript.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdRun;
        private System.Windows.Forms.Panel pnlScript;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtScriptAfter;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtScriptLine;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtScriptBefore;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton rdoScopeCurrent;
        private System.Windows.Forms.RadioButton rdoScopeAllOpen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton rdoLanguageCSharp;
        private System.Windows.Forms.RadioButton rdoLanguageVBasic;
    }
}