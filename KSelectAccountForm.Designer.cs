
namespace BoozeHoundBooks
{
  partial class KSelectAccountForm
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.accountList = new System.Windows.Forms.ListBox();
      this.okBtn = new System.Windows.Forms.Button();
      this.cancelBtn = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.accountList);
      this.groupBox1.Location = new System.Drawing.Point(14, 14);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(9, 3, 9, 3);
      this.groupBox1.Size = new System.Drawing.Size(477, 436);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      // 
      // accountList
      // 
      this.accountList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.accountList.FormattingEnabled = true;
      this.accountList.ItemHeight = 15;
      this.accountList.Location = new System.Drawing.Point(9, 19);
      this.accountList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.accountList.Name = "accountList";
      this.accountList.Size = new System.Drawing.Size(459, 414);
      this.accountList.Sorted = true;
      this.accountList.TabIndex = 0;
      this.accountList.SelectedIndexChanged += new System.EventHandler(this.AccountListSelectedIndexChanged);
      // 
      // okBtn
      // 
      this.okBtn.Location = new System.Drawing.Point(309, 468);
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
      this.cancelBtn.Location = new System.Drawing.Point(404, 468);
      this.cancelBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.cancelBtn.Name = "cancelBtn";
      this.cancelBtn.Size = new System.Drawing.Size(88, 27);
      this.cancelBtn.TabIndex = 2;
      this.cancelBtn.Text = "Cancel";
      this.cancelBtn.UseVisualStyleBackColor = true;
      // 
      // KSelectAccountForm
      // 
      this.AcceptButton = this.okBtn;
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelBtn;
      this.ClientSize = new System.Drawing.Size(505, 509);
      this.ControlBox = false;
      this.Controls.Add(this.cancelBtn);
      this.Controls.Add(this.okBtn);
      this.Controls.Add(this.groupBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.Name = "KSelectAccountForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Select an Account";
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);

    }
    private System.Windows.Forms.Button cancelBtn;
    private System.Windows.Forms.Button okBtn;
    private System.Windows.Forms.ListBox accountList;
    private System.Windows.Forms.GroupBox groupBox1;
  }
}
