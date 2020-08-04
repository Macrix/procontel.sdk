namespace UI.WinForms.NewSdk.Tests.Configurations
{
  partial class VirtualFileSystemConfigurationDialog
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
            this.getFilesGrid = new System.Windows.Forms.DataGridView();
            this.getDirectoriesGrid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.getRootsGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.getFilesGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getDirectoriesGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getRootsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // getFilesGrid
            // 
            this.getFilesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.getFilesGrid.Location = new System.Drawing.Point(25, 259);
            this.getFilesGrid.Name = "getFilesGrid";
            this.getFilesGrid.Size = new System.Drawing.Size(1086, 150);
            this.getFilesGrid.TabIndex = 8;
            // 
            // getDirectoriesGrid
            // 
            this.getDirectoriesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.getDirectoriesGrid.Location = new System.Drawing.Point(25, 103);
            this.getDirectoriesGrid.Name = "getDirectoriesGrid";
            this.getDirectoriesGrid.Size = new System.Drawing.Size(1086, 150);
            this.getDirectoriesGrid.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 421);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Execute test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // getRootsGrid
            // 
            this.getRootsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.getRootsGrid.Location = new System.Drawing.Point(25, 7);
            this.getRootsGrid.Name = "getRootsGrid";
            this.getRootsGrid.Size = new System.Drawing.Size(1086, 90);
            this.getRootsGrid.TabIndex = 5;
            // 
            // VirtualFileSystemConfigurationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 450);
            this.Controls.Add(this.getFilesGrid);
            this.Controls.Add(this.getDirectoriesGrid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.getRootsGrid);
            this.Name = "VirtualFileSystemConfigurationDialog";
            this.Text = "VirtualFileSystemConfigurationDialog";
            this.Load += new System.EventHandler(this.VirtualFileSystemConfigurationDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.getFilesGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getDirectoriesGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getRootsGrid)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView getFilesGrid;
    private System.Windows.Forms.DataGridView getDirectoriesGrid;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.DataGridView getRootsGrid;
  }
}
