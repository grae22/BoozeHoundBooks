﻿/*
 * Created by SharpDevelop.
 * User: Graeme
 * Date: 2009/09/27
 * Time: 11:59 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace BoozeHoundBooks
{
	partial class KPeriodSetupForm : System.Windows.Forms.Form
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
      this.periodBox = new System.Windows.Forms.ListBox();
      this.startPicker = new System.Windows.Forms.DateTimePicker();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.endPicker = new System.Windows.Forms.DateTimePicker();
      this.okBtn = new System.Windows.Forms.Button();
      this.addBtn = new System.Windows.Forms.Button();
      this.updateBtn = new System.Windows.Forms.Button();
      this.removeBtn = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // periodBox
      // 
      this.periodBox.FormattingEnabled = true;
      this.periodBox.Location = new System.Drawing.Point(12, 12);
      this.periodBox.Name = "periodBox";
      this.periodBox.Size = new System.Drawing.Size(161, 355);
      this.periodBox.TabIndex = 0;
      // 
      // startPicker
      // 
      this.startPicker.CustomFormat = "dd/MM/yyyy";
      this.startPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.startPicker.Location = new System.Drawing.Point(216, 12);
      this.startPicker.Name = "startPicker";
      this.startPicker.Size = new System.Drawing.Size(91, 20);
      this.startPicker.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(179, 18);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(29, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Start";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(179, 45);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(26, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "End";
      // 
      // endPicker
      // 
      this.endPicker.CustomFormat = "dd/MM/yyyy";
      this.endPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.endPicker.Location = new System.Drawing.Point(216, 39);
      this.endPicker.Name = "endPicker";
      this.endPicker.Size = new System.Drawing.Size(91, 20);
      this.endPicker.TabIndex = 3;
      // 
      // okBtn
      // 
      this.okBtn.Location = new System.Drawing.Point(232, 342);
      this.okBtn.Name = "okBtn";
      this.okBtn.Size = new System.Drawing.Size(75, 23);
      this.okBtn.TabIndex = 5;
      this.okBtn.Text = "Ok";
      this.okBtn.UseVisualStyleBackColor = true;
      this.okBtn.Click += new System.EventHandler(this.OkBtnClick);
      // 
      // addBtn
      // 
      this.addBtn.Location = new System.Drawing.Point(232, 75);
      this.addBtn.Name = "addBtn";
      this.addBtn.Size = new System.Drawing.Size(75, 23);
      this.addBtn.TabIndex = 6;
      this.addBtn.Text = "Add";
      this.addBtn.UseVisualStyleBackColor = true;
      this.addBtn.Click += new System.EventHandler(this.AddBtnClick);
      // 
      // updateBtn
      // 
      this.updateBtn.Location = new System.Drawing.Point(232, 133);
      this.updateBtn.Name = "updateBtn";
      this.updateBtn.Size = new System.Drawing.Size(75, 23);
      this.updateBtn.TabIndex = 7;
      this.updateBtn.Text = "Update";
      this.updateBtn.UseVisualStyleBackColor = true;
      this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
      // 
      // removeBtn
      // 
      this.removeBtn.Location = new System.Drawing.Point(232, 104);
      this.removeBtn.Name = "removeBtn";
      this.removeBtn.Size = new System.Drawing.Size(75, 23);
      this.removeBtn.TabIndex = 8;
      this.removeBtn.Text = "Remove";
      this.removeBtn.UseVisualStyleBackColor = true;
      this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
      // 
      // KPeriodSetupForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(315, 377);
      this.ControlBox = false;
      this.Controls.Add(this.removeBtn);
      this.Controls.Add(this.updateBtn);
      this.Controls.Add(this.addBtn);
      this.Controls.Add(this.okBtn);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.endPicker);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.startPicker);
      this.Controls.Add(this.periodBox);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "KPeriodSetupForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Period Setup";
      this.ResumeLayout(false);
      this.PerformLayout();

		}
		private System.Windows.Forms.Button addBtn;
		private System.Windows.Forms.ListBox periodBox;
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.DateTimePicker endPicker;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker startPicker;
    private System.Windows.Forms.Button updateBtn;
    private System.Windows.Forms.Button removeBtn;
	}
}
