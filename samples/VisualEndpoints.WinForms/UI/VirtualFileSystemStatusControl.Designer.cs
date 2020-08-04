namespace UI.WinForms.NewSdk.Tests.StatusControls
{
  partial class VirtualFileSystemStatusControl
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
            this.getFilesGrid = new System.Windows.Forms.DataGridView();
            this.getDirectoriesGrid = new System.Windows.Forms.DataGridView();
            this.getRootsGrid = new System.Windows.Forms.DataGridView();
            this.ExecuteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.getFilesGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getDirectoriesGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getRootsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // getFilesGrid
            // 
            this.getFilesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.getFilesGrid.Location = new System.Drawing.Point(16, 299);
            this.getFilesGrid.Name = "getFilesGrid";
            this.getFilesGrid.Size = new System.Drawing.Size(1086, 150);
            this.getFilesGrid.TabIndex = 8;
            // 
            // getDirectoriesGrid
            // 
            this.getDirectoriesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.getDirectoriesGrid.Location = new System.Drawing.Point(16, 143);
            this.getDirectoriesGrid.Name = "getDirectoriesGrid";
            this.getDirectoriesGrid.Size = new System.Drawing.Size(1086, 150);
            this.getDirectoriesGrid.TabIndex = 7;
            // 
            // getRootsGrid
            // 
            this.getRootsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.getRootsGrid.Location = new System.Drawing.Point(16, 14);
            this.getRootsGrid.Name = "getRootsGrid";
            this.getRootsGrid.Size = new System.Drawing.Size(1086, 123);
            this.getRootsGrid.TabIndex = 5;
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Location = new System.Drawing.Point(31, 465);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(194, 29);
            this.ExecuteButton.TabIndex = 9;
            this.ExecuteButton.Text = "Execute";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // VirtualFileSystemStatusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ExecuteButton);
            this.Controls.Add(this.getFilesGrid);
            this.Controls.Add(this.getDirectoriesGrid);
            this.Controls.Add(this.getRootsGrid);
            this.Name = "VirtualFileSystemStatusControl";
            this.Size = new System.Drawing.Size(1118, 521);
            ((System.ComponentModel.ISupportInitialize)(this.getFilesGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getDirectoriesGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getRootsGrid)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView getFilesGrid;
    private System.Windows.Forms.DataGridView getDirectoriesGrid;
    private System.Windows.Forms.DataGridView getRootsGrid;
    private System.Windows.Forms.Button ExecuteButton;
  }
}
