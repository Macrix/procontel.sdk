namespace VisualEndpoints.WinForms.UI
{
  partial class WinFormsStatusControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.label1 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.txtCommand = new System.Windows.Forms.TextBox();
      this.gbNotifications = new System.Windows.Forms.GroupBox();
      this.gbConsole = new System.Windows.Forms.GroupBox();
      this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      this.txtConsole = new System.Windows.Forms.TextBox();
      this.txtNotifications = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.gbNotifications.SuspendLayout();
      this.gbConsole.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.label1);
      this.splitContainer1.Panel1.Controls.Add(this.button1);
      this.splitContainer1.Panel1.Controls.Add(this.txtCommand);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.gbNotifications);
      this.splitContainer1.Panel2.Controls.Add(this.gbConsole);
      this.splitContainer1.Size = new System.Drawing.Size(800, 500);
      this.splitContainer1.SplitterDistance = 266;
      this.splitContainer1.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(4, 61);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(107, 39);
      this.label1.TabIndex = 2;
      this.label1.Text = "Available commands:\r\n- dowork\r\n- notify";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(4, 31);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(259, 23);
      this.button1.TabIndex = 1;
      this.button1.Text = "Send Command";
      this.button1.Click += new System.EventHandler(this.Button_Click);
      this.button1.UseVisualStyleBackColor = true;
      // 
      // txtCommand
      // 
      this.txtCommand.Location = new System.Drawing.Point(4, 4);
      this.txtCommand.Name = "txtCommand";
      this.txtCommand.Size = new System.Drawing.Size(259, 20);
      this.txtCommand.TabIndex = 0;
      // 
      // gbNotifications
      // 
      this.gbNotifications.Controls.Add(this.txtNotifications);
      this.gbNotifications.Location = new System.Drawing.Point(3, 259);
      this.gbNotifications.Name = "gbNotifications";
      this.gbNotifications.Size = new System.Drawing.Size(527, 250);
      this.gbNotifications.TabIndex = 1;
      this.gbNotifications.TabStop = false;
      this.gbNotifications.Text = "Notifications";
      // 
      // gbConsole
      // 
      this.gbConsole.Controls.Add(this.txtConsole);
      this.gbConsole.Location = new System.Drawing.Point(3, 3);
      this.gbConsole.Name = "gbConsole";
      this.gbConsole.Size = new System.Drawing.Size(527, 250);
      this.gbConsole.TabIndex = 0;
      this.gbConsole.TabStop = false;
      this.gbConsole.Text = "Console";
      // 
      // txtConsole
      // 
      this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtConsole.Location = new System.Drawing.Point(3, 16);
      this.txtConsole.Multiline = true;
      this.txtConsole.Name = "txtConsole";
      this.txtConsole.Size = new System.Drawing.Size(521, 231);
      this.txtConsole.TabIndex = 0;
      // 
      // txtNotifications
      // 
      this.txtNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtNotifications.Location = new System.Drawing.Point(3, 16);
      this.txtNotifications.Multiline = true;
      this.txtNotifications.Name = "txtNotifications";
      this.txtNotifications.Size = new System.Drawing.Size(521, 231);
      this.txtNotifications.TabIndex = 1;
      // 
      // WinFormsStatusControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitContainer1);
      this.Name = "WinFormsStatusControl";
      this.Size = new System.Drawing.Size(800, 500);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.gbNotifications.ResumeLayout(false);
      this.gbNotifications.PerformLayout();
      this.gbConsole.ResumeLayout(false);
      this.gbConsole.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.TextBox txtCommand;
    private System.Windows.Forms.GroupBox gbNotifications;
    private System.Windows.Forms.GroupBox gbConsole;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox txtNotifications;
    private System.Windows.Forms.TextBox txtConsole;
  }
}
