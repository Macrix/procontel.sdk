namespace ColaAutomat.Vending
{
  partial class StatusControl
  {
    /// <summary> 
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Komponenten-Designer generierter Code

    /// <summary> 
    /// Erforderliche Methode für die Designerunterstützung. 
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.label1 = new System.Windows.Forms.Label();
      this.Cola = new System.Windows.Forms.Button();
      this.Limonade = new System.Windows.Forms.Button();
      this.Wasser = new System.Windows.Forms.Button();
      this.Auffuellen = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.ColaInfo = new System.Windows.Forms.Label();
      this.LimonadeInfo = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.WasserInfo = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(31, 30);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(135, 20);
      this.label1.TabIndex = 0;
      this.label1.Text = "Getränkeautomat";
      // 
      // Cola
      // 
      this.Cola.Location = new System.Drawing.Point(67, 101);
      this.Cola.Name = "Cola";
      this.Cola.Size = new System.Drawing.Size(204, 71);
      this.Cola.TabIndex = 1;
      this.Cola.Text = "Cola kaufen";
      this.Cola.UseVisualStyleBackColor = true;
      this.Cola.Click += new System.EventHandler(this.Kaufen_Click);
      // 
      // Limonade
      // 
      this.Limonade.Location = new System.Drawing.Point(67, 211);
      this.Limonade.Name = "Limonade";
      this.Limonade.Size = new System.Drawing.Size(204, 72);
      this.Limonade.TabIndex = 2;
      this.Limonade.Text = "Limonade kaufen";
      this.Limonade.UseVisualStyleBackColor = true;
      this.Limonade.Click += new System.EventHandler(this.Kaufen_Click);
      // 
      // Wasser
      // 
      this.Wasser.Location = new System.Drawing.Point(67, 319);
      this.Wasser.Name = "Wasser";
      this.Wasser.Size = new System.Drawing.Size(204, 75);
      this.Wasser.TabIndex = 3;
      this.Wasser.Text = "Wasser kaufen";
      this.Wasser.UseVisualStyleBackColor = true;
      this.Wasser.Click += new System.EventHandler(this.Kaufen_Click);
      // 
      // Auffuellen
      // 
      this.Auffuellen.Location = new System.Drawing.Point(653, 319);
      this.Auffuellen.Name = "Auffuellen";
      this.Auffuellen.Size = new System.Drawing.Size(253, 81);
      this.Auffuellen.TabIndex = 4;
      this.Auffuellen.Text = "Automat auffüllen";
      this.Auffuellen.UseVisualStyleBackColor = true;
      this.Auffuellen.Click += new System.EventHandler(this.Auffuellen_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(334, 123);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(145, 20);
      this.label2.TabIndex = 6;
      this.label2.Text = "Flaschen verfügbar";
      // 
      // ColaInfo
      // 
      this.ColaInfo.AutoSize = true;
      this.ColaInfo.Location = new System.Drawing.Point(277, 123);
      this.ColaInfo.Name = "ColaInfo";
      this.ColaInfo.Size = new System.Drawing.Size(51, 20);
      this.ColaInfo.TabIndex = 7;
      this.ColaInfo.Text = "label3";
      // 
      // LimonadeInfo
      // 
      this.LimonadeInfo.AutoSize = true;
      this.LimonadeInfo.Location = new System.Drawing.Point(277, 237);
      this.LimonadeInfo.Name = "LimonadeInfo";
      this.LimonadeInfo.Size = new System.Drawing.Size(51, 20);
      this.LimonadeInfo.TabIndex = 9;
      this.LimonadeInfo.Text = "label3";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(334, 237);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(145, 20);
      this.label4.TabIndex = 8;
      this.label4.Text = "Flaschen verfügbar";
      // 
      // WasserInfo
      // 
      this.WasserInfo.AutoSize = true;
      this.WasserInfo.Location = new System.Drawing.Point(277, 346);
      this.WasserInfo.Name = "WasserInfo";
      this.WasserInfo.Size = new System.Drawing.Size(51, 20);
      this.WasserInfo.TabIndex = 11;
      this.WasserInfo.Text = "label3";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(334, 346);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(145, 20);
      this.label6.TabIndex = 10;
      this.label6.Text = "Flaschen verfügbar";
      // 
      // StatusControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.WasserInfo);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.LimonadeInfo);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.ColaInfo);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.Auffuellen);
      this.Controls.Add(this.Wasser);
      this.Controls.Add(this.Limonade);
      this.Controls.Add(this.Cola);
      this.Controls.Add(this.label1);
      this.Name = "StatusControl";
      this.Size = new System.Drawing.Size(939, 450);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Cola;
        private System.Windows.Forms.Button Limonade;
        private System.Windows.Forms.Button Wasser;
        private System.Windows.Forms.Button Auffuellen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ColaInfo;
        private System.Windows.Forms.Label LimonadeInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label WasserInfo;
        private System.Windows.Forms.Label label6;
    }
}
