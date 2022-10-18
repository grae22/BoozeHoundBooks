
namespace BoozeHoundBooks
{
  partial class KSummaryExpressionBuilderForm
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
      this.accountBtn = new System.Windows.Forms.Button();
      this.valueBtn = new System.Windows.Forms.Button();
      this.divideBtn = new System.Windows.Forms.Button();
      this.multiplyBtn = new System.Windows.Forms.Button();
      this.subtractBtn = new System.Windows.Forms.Button();
      this.addBtn = new System.Windows.Forms.Button();
      this.closeBracketBtn = new System.Windows.Forms.Button();
      this.openBracketBtn = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.removeBtn = new System.Windows.Forms.Button();
      this.shiftRightBtn = new System.Windows.Forms.Button();
      this.shiftLeftBtn = new System.Windows.Forms.Button();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.descriptionBox = new System.Windows.Forms.TextBox();
      this.nameBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.saveBtn = new System.Windows.Forms.Button();
      this.cancelBtn = new System.Windows.Forms.Button();
      this.fieldGrpBox = new System.Windows.Forms.GroupBox();
      this.fieldPnl = new System.Windows.Forms.FlowLayoutPanel();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.fieldGrpBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.accountBtn);
      this.groupBox1.Controls.Add(this.valueBtn);
      this.groupBox1.Controls.Add(this.divideBtn);
      this.groupBox1.Controls.Add(this.multiplyBtn);
      this.groupBox1.Controls.Add(this.subtractBtn);
      this.groupBox1.Controls.Add(this.addBtn);
      this.groupBox1.Controls.Add(this.closeBracketBtn);
      this.groupBox1.Controls.Add(this.openBracketBtn);
      this.groupBox1.Location = new System.Drawing.Point(14, 103);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
      this.groupBox1.Size = new System.Drawing.Size(420, 45);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      // 
      // accountBtn
      // 
      this.accountBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.accountBtn.Location = new System.Drawing.Point(331, 13);
      this.accountBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.accountBtn.Name = "accountBtn";
      this.accountBtn.Size = new System.Drawing.Size(79, 27);
      this.accountBtn.TabIndex = 7;
      this.accountBtn.Text = "Account";
      this.accountBtn.UseVisualStyleBackColor = true;
      this.accountBtn.Click += new System.EventHandler(this.AccountBtnClick);
      // 
      // valueBtn
      // 
      this.valueBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.valueBtn.Location = new System.Drawing.Point(259, 13);
      this.valueBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.valueBtn.Name = "valueBtn";
      this.valueBtn.Size = new System.Drawing.Size(65, 27);
      this.valueBtn.TabIndex = 6;
      this.valueBtn.Text = "Value";
      this.valueBtn.UseVisualStyleBackColor = true;
      this.valueBtn.Click += new System.EventHandler(this.ValueBtnClick);
      // 
      // divideBtn
      // 
      this.divideBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.divideBtn.Location = new System.Drawing.Point(217, 13);
      this.divideBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.divideBtn.Name = "divideBtn";
      this.divideBtn.Size = new System.Drawing.Size(35, 27);
      this.divideBtn.TabIndex = 5;
      this.divideBtn.Text = "/";
      this.divideBtn.UseVisualStyleBackColor = true;
      this.divideBtn.Click += new System.EventHandler(this.OperatorSelected);
      // 
      // multiplyBtn
      // 
      this.multiplyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.multiplyBtn.Location = new System.Drawing.Point(175, 13);
      this.multiplyBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.multiplyBtn.Name = "multiplyBtn";
      this.multiplyBtn.Size = new System.Drawing.Size(35, 27);
      this.multiplyBtn.TabIndex = 4;
      this.multiplyBtn.Text = "x";
      this.multiplyBtn.UseVisualStyleBackColor = true;
      this.multiplyBtn.Click += new System.EventHandler(this.OperatorSelected);
      // 
      // subtractBtn
      // 
      this.subtractBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.subtractBtn.Location = new System.Drawing.Point(133, 13);
      this.subtractBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.subtractBtn.Name = "subtractBtn";
      this.subtractBtn.Size = new System.Drawing.Size(35, 27);
      this.subtractBtn.TabIndex = 3;
      this.subtractBtn.Text = "-";
      this.subtractBtn.UseVisualStyleBackColor = true;
      this.subtractBtn.Click += new System.EventHandler(this.OperatorSelected);
      // 
      // addBtn
      // 
      this.addBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.addBtn.Location = new System.Drawing.Point(91, 13);
      this.addBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.addBtn.Name = "addBtn";
      this.addBtn.Size = new System.Drawing.Size(35, 27);
      this.addBtn.TabIndex = 2;
      this.addBtn.Text = "+";
      this.addBtn.UseVisualStyleBackColor = true;
      this.addBtn.Click += new System.EventHandler(this.OperatorSelected);
      // 
      // closeBracketBtn
      // 
      this.closeBracketBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.closeBracketBtn.Location = new System.Drawing.Point(49, 13);
      this.closeBracketBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.closeBracketBtn.Name = "closeBracketBtn";
      this.closeBracketBtn.Size = new System.Drawing.Size(35, 27);
      this.closeBracketBtn.TabIndex = 1;
      this.closeBracketBtn.Text = ")";
      this.closeBracketBtn.UseVisualStyleBackColor = true;
      this.closeBracketBtn.Click += new System.EventHandler(this.OperatorSelected);
      // 
      // openBracketBtn
      // 
      this.openBracketBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.openBracketBtn.Location = new System.Drawing.Point(7, 13);
      this.openBracketBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.openBracketBtn.Name = "openBracketBtn";
      this.openBracketBtn.Size = new System.Drawing.Size(35, 27);
      this.openBracketBtn.TabIndex = 0;
      this.openBracketBtn.Text = "(";
      this.openBracketBtn.UseVisualStyleBackColor = true;
      this.openBracketBtn.Click += new System.EventHandler(this.OperatorSelected);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.removeBtn);
      this.groupBox2.Controls.Add(this.shiftRightBtn);
      this.groupBox2.Controls.Add(this.shiftLeftBtn);
      this.groupBox2.Location = new System.Drawing.Point(441, 103);
      this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
      this.groupBox2.Size = new System.Drawing.Size(176, 45);
      this.groupBox2.TabIndex = 2;
      this.groupBox2.TabStop = false;
      // 
      // removeBtn
      // 
      this.removeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.removeBtn.Location = new System.Drawing.Point(91, 13);
      this.removeBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.removeBtn.Name = "removeBtn";
      this.removeBtn.Size = new System.Drawing.Size(77, 27);
      this.removeBtn.TabIndex = 2;
      this.removeBtn.Text = "Remove";
      this.removeBtn.UseVisualStyleBackColor = true;
      this.removeBtn.Click += new System.EventHandler(this.RemoveBtnClick);
      // 
      // shiftRightBtn
      // 
      this.shiftRightBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.shiftRightBtn.Location = new System.Drawing.Point(49, 13);
      this.shiftRightBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.shiftRightBtn.Name = "shiftRightBtn";
      this.shiftRightBtn.Size = new System.Drawing.Size(35, 27);
      this.shiftRightBtn.TabIndex = 1;
      this.shiftRightBtn.Text = ">";
      this.shiftRightBtn.UseVisualStyleBackColor = true;
      this.shiftRightBtn.Click += new System.EventHandler(this.ShiftRightBtnClick);
      // 
      // shiftLeftBtn
      // 
      this.shiftLeftBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.shiftLeftBtn.Location = new System.Drawing.Point(7, 13);
      this.shiftLeftBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.shiftLeftBtn.Name = "shiftLeftBtn";
      this.shiftLeftBtn.Size = new System.Drawing.Size(35, 27);
      this.shiftLeftBtn.TabIndex = 0;
      this.shiftLeftBtn.Text = "<";
      this.shiftLeftBtn.UseVisualStyleBackColor = true;
      this.shiftLeftBtn.Click += new System.EventHandler(this.ShiftLeftBtnClick);
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.descriptionBox);
      this.groupBox3.Controls.Add(this.nameBox);
      this.groupBox3.Controls.Add(this.label2);
      this.groupBox3.Controls.Add(this.label1);
      this.groupBox3.Location = new System.Drawing.Point(14, 14);
      this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.groupBox3.Size = new System.Drawing.Size(298, 82);
      this.groupBox3.TabIndex = 3;
      this.groupBox3.TabStop = false;
      // 
      // descriptionBox
      // 
      this.descriptionBox.Location = new System.Drawing.Point(91, 47);
      this.descriptionBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.descriptionBox.Name = "descriptionBox";
      this.descriptionBox.Size = new System.Drawing.Size(199, 23);
      this.descriptionBox.TabIndex = 3;
      // 
      // nameBox
      // 
      this.nameBox.Location = new System.Drawing.Point(91, 20);
      this.nameBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.nameBox.Name = "nameBox";
      this.nameBox.Size = new System.Drawing.Size(199, 23);
      this.nameBox.TabIndex = 2;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(7, 51);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(70, 15);
      this.label2.TabIndex = 1;
      this.label2.Text = "Description:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(8, 23);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(42, 15);
      this.label1.TabIndex = 0;
      this.label1.Text = "Name:";
      // 
      // saveBtn
      // 
      this.saveBtn.Location = new System.Drawing.Point(439, 375);
      this.saveBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.saveBtn.Name = "saveBtn";
      this.saveBtn.Size = new System.Drawing.Size(88, 27);
      this.saveBtn.TabIndex = 4;
      this.saveBtn.Text = "Save";
      this.saveBtn.UseVisualStyleBackColor = true;
      this.saveBtn.Click += new System.EventHandler(this.SaveBtnClick);
      // 
      // cancelBtn
      // 
      this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelBtn.Location = new System.Drawing.Point(533, 375);
      this.cancelBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.cancelBtn.Name = "cancelBtn";
      this.cancelBtn.Size = new System.Drawing.Size(88, 27);
      this.cancelBtn.TabIndex = 5;
      this.cancelBtn.Text = "Cancel";
      this.cancelBtn.UseVisualStyleBackColor = true;
      this.cancelBtn.Click += new System.EventHandler(this.CancelBtnClick);
      // 
      // fieldGrpBox
      // 
      this.fieldGrpBox.Controls.Add(this.fieldPnl);
      this.fieldGrpBox.Location = new System.Drawing.Point(14, 155);
      this.fieldGrpBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.fieldGrpBox.Name = "fieldGrpBox";
      this.fieldGrpBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.fieldGrpBox.Size = new System.Drawing.Size(603, 207);
      this.fieldGrpBox.TabIndex = 7;
      this.fieldGrpBox.TabStop = false;
      // 
      // fieldPnl
      // 
      this.fieldPnl.AutoScroll = true;
      this.fieldPnl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.fieldPnl.Location = new System.Drawing.Point(4, 19);
      this.fieldPnl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.fieldPnl.Name = "fieldPnl";
      this.fieldPnl.Size = new System.Drawing.Size(595, 185);
      this.fieldPnl.TabIndex = 0;
      // 
      // KSummaryExpressionBuilderForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelBtn;
      this.ClientSize = new System.Drawing.Size(635, 415);
      this.ControlBox = false;
      this.Controls.Add(this.fieldGrpBox);
      this.Controls.Add(this.cancelBtn);
      this.Controls.Add(this.saveBtn);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.Name = "KSummaryExpressionBuilderForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Summary Expression Builder";
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.fieldGrpBox.ResumeLayout(false);
      this.ResumeLayout(false);

    }
    private System.Windows.Forms.GroupBox fieldGrpBox;
    private System.Windows.Forms.Button cancelBtn;
    private System.Windows.Forms.Button saveBtn;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox nameBox;
    private System.Windows.Forms.TextBox descriptionBox;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.FlowLayoutPanel fieldPnl;
    private System.Windows.Forms.Button shiftLeftBtn;
    private System.Windows.Forms.Button shiftRightBtn;
    private System.Windows.Forms.Button removeBtn;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button addBtn;
    private System.Windows.Forms.Button subtractBtn;
    private System.Windows.Forms.Button multiplyBtn;
    private System.Windows.Forms.Button divideBtn;
    private System.Windows.Forms.Button valueBtn;
    private System.Windows.Forms.Button accountBtn;
    private System.Windows.Forms.Button closeBracketBtn;
    private System.Windows.Forms.Button openBracketBtn;
    private System.Windows.Forms.GroupBox groupBox1;
  }
}
