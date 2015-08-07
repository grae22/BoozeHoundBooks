/*
 * Created by SharpDevelop.
 * User: Graeme
 * Date: 2009/10/10
 * Time: 12:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace BoozeHoundBooks
{
	partial class KAdjustmentForm : System.Windows.Forms.Form
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
      this.periodName = new System.Windows.Forms.Label();
      this.cancelButton = new System.Windows.Forms.Button();
      this.budgetBox = new System.Windows.Forms.CheckBox();
      this.dateBox = new System.Windows.Forms.DateTimePicker();
      this.label2 = new System.Windows.Forms.Label();
      this.processBtn = new System.Windows.Forms.Button();
      this.amountBox = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.infoBox = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.accountBox = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.recuringBox = new System.Windows.Forms.CheckBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.recuringBox);
      this.groupBox1.Controls.Add(this.periodName);
      this.groupBox1.Controls.Add(this.cancelButton);
      this.groupBox1.Controls.Add(this.budgetBox);
      this.groupBox1.Controls.Add(this.dateBox);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.processBtn);
      this.groupBox1.Controls.Add(this.amountBox);
      this.groupBox1.Controls.Add(this.label7);
      this.groupBox1.Controls.Add(this.infoBox);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.accountBox);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(333, 218);
      this.groupBox1.TabIndex = 6;
      this.groupBox1.TabStop = false;
      // 
      // periodName
      // 
      this.periodName.AutoSize = true;
      this.periodName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.periodName.Location = new System.Drawing.Point(153, 51);
      this.periodName.Name = "periodName";
      this.periodName.Size = new System.Drawing.Size(77, 13);
      this.periodName.TabIndex = 22;
      this.periodName.Text = "<period name>";
      // 
      // cancelButton
      // 
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(226, 183);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(91, 23);
      this.cancelButton.TabIndex = 7;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelBtnClick);
      // 
      // budgetBox
      // 
      this.budgetBox.AutoSize = true;
      this.budgetBox.Location = new System.Drawing.Point(55, 127);
      this.budgetBox.Name = "budgetBox";
      this.budgetBox.Size = new System.Drawing.Size(119, 17);
      this.budgetBox.TabIndex = 4;
      this.budgetBox.Text = "Budget Transaction";
      this.budgetBox.UseVisualStyleBackColor = true;
      // 
      // dateBox
      // 
      this.dateBox.CustomFormat = "dd/MM/yyyy";
      this.dateBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dateBox.Location = new System.Drawing.Point(55, 47);
      this.dateBox.Name = "dateBox";
      this.dateBox.Size = new System.Drawing.Size(91, 20);
      this.dateBox.TabIndex = 1;
      this.dateBox.ValueChanged += new System.EventHandler(this.DateBox_ValueChanged);
      this.dateBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DateBoxKeyPress);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(7, 52);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(30, 13);
      this.label2.TabIndex = 16;
      this.label2.Text = "Date";
      // 
      // processBtn
      // 
      this.processBtn.Location = new System.Drawing.Point(129, 183);
      this.processBtn.Name = "processBtn";
      this.processBtn.Size = new System.Drawing.Size(91, 23);
      this.processBtn.TabIndex = 6;
      this.processBtn.Text = "Process";
      this.processBtn.UseVisualStyleBackColor = true;
      this.processBtn.Click += new System.EventHandler(this.ProcessBtnClick);
      // 
      // amountBox
      // 
      this.amountBox.Location = new System.Drawing.Point(55, 101);
      this.amountBox.Name = "amountBox";
      this.amountBox.Size = new System.Drawing.Size(77, 20);
      this.amountBox.TabIndex = 3;
      this.amountBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.amountBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AmountBoxKeyPress);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(7, 104);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(43, 13);
      this.label7.TabIndex = 13;
      this.label7.Text = "Amount";
      // 
      // infoBox
      // 
      this.infoBox.Location = new System.Drawing.Point(55, 74);
      this.infoBox.Name = "infoBox";
      this.infoBox.Size = new System.Drawing.Size(262, 20);
      this.infoBox.TabIndex = 2;
      this.infoBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InfoBoxKeyPress);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(7, 77);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(25, 13);
      this.label6.TabIndex = 11;
      this.label6.Text = "Info";
      // 
      // accountBox
      // 
      this.accountBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.accountBox.FormattingEnabled = true;
      this.accountBox.Location = new System.Drawing.Point(55, 20);
      this.accountBox.Name = "accountBox";
      this.accountBox.Size = new System.Drawing.Size(262, 21);
      this.accountBox.Sorted = true;
      this.accountBox.TabIndex = 0;
      this.accountBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AccountBoxKeyPress);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(7, 23);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(47, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "Account";
      // 
      // recuringBox
      // 
      this.recuringBox.AutoSize = true;
      this.recuringBox.Location = new System.Drawing.Point(55, 150);
      this.recuringBox.Name = "recuringBox";
      this.recuringBox.Size = new System.Drawing.Size(69, 17);
      this.recuringBox.TabIndex = 5;
      this.recuringBox.Text = "Recuring";
      this.recuringBox.UseVisualStyleBackColor = true;
      // 
      // KAdjustmentForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(333, 218);
      this.ControlBox = false;
      this.Controls.Add(this.groupBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "KAdjustmentForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Adjustment";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

		}
		private System.Windows.Forms.ComboBox accountBox;
		private System.Windows.Forms.TextBox infoBox;
		private System.Windows.Forms.TextBox amountBox;
		private System.Windows.Forms.Button processBtn;
		private System.Windows.Forms.DateTimePicker dateBox;
		private System.Windows.Forms.CheckBox budgetBox;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label periodName;
		private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.CheckBox recuringBox;
	}
}
