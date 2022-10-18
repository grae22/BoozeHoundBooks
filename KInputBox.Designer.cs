
namespace BoozeHoundBooks
{
  partial class KInputBox
  {
    /// <summary>
    /// Designer variable used to keep track of non-visual components.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    
    /// <summary>
    /// Disposes resources used by the form.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing) {
        if (components != null) {
          components.Dispose();
        }
      }
      base.Dispose(disposing);
    }
    
    /// <summary>
    /// This method is required for Windows Forms designer support.
    /// Do not change the method contents inside the source code editor. The Forms designer might
    /// not be able to load this method if it was changed manually.
    /// </summary>
    private void InitializeComponent()
    {
      this.groupBox = new System.Windows.Forms.GroupBox();
      this.inputBox = new System.Windows.Forms.TextBox();
      this.okBtn = new System.Windows.Forms.Button();
      this.cancelBtn = new System.Windows.Forms.Button();
      this.groupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox
      // 
      this.groupBox.Controls.Add(this.inputBox);
      this.groupBox.Location = new System.Drawing.Point(14, 14);
      this.groupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.groupBox.Name = "groupBox";
      this.groupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.groupBox.Size = new System.Drawing.Size(196, 76);
      this.groupBox.TabIndex = 0;
      this.groupBox.TabStop = false;
      this.groupBox.Text = "<set by code>";
      // 
      // inputBox
      // 
      this.inputBox.Location = new System.Drawing.Point(7, 33);
      this.inputBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.inputBox.Name = "inputBox";
      this.inputBox.Size = new System.Drawing.Size(181, 23);
      this.inputBox.TabIndex = 0;
      // 
      // okBtn
      // 
      this.okBtn.Location = new System.Drawing.Point(225, 30);
      this.okBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.okBtn.Name = "okBtn";
      this.okBtn.Size = new System.Drawing.Size(88, 27);
      this.okBtn.TabIndex = 1;
      this.okBtn.Text = "OK";
      this.okBtn.UseVisualStyleBackColor = true;
      this.okBtn.Click += new System.EventHandler(this.OkBtnClick);
      // 
      // cancelBtn
      // 
      this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelBtn.Location = new System.Drawing.Point(225, 63);
      this.cancelBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.cancelBtn.Name = "cancelBtn";
      this.cancelBtn.Size = new System.Drawing.Size(88, 27);
      this.cancelBtn.TabIndex = 2;
      this.cancelBtn.Text = "Cancel";
      this.cancelBtn.UseVisualStyleBackColor = true;
      this.cancelBtn.Click += new System.EventHandler(this.CancelBtnClick);
      // 
      // KInputBox
      // 
      this.AcceptButton = this.okBtn;
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelBtn;
      this.ClientSize = new System.Drawing.Size(327, 104);
      this.ControlBox = false;
      this.Controls.Add(this.cancelBtn);
      this.Controls.Add(this.okBtn);
      this.Controls.Add(this.groupBox);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.Name = "KInputBox";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "<set by code>";
      this.groupBox.ResumeLayout(false);
      this.groupBox.PerformLayout();
      this.ResumeLayout(false);

    }
    private System.Windows.Forms.TextBox inputBox;
    private System.Windows.Forms.Button okBtn;
    private System.Windows.Forms.Button cancelBtn;
    private System.Windows.Forms.GroupBox groupBox;
  }
}
