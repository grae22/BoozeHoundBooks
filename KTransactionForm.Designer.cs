﻿/*
 * Created by SharpDevelop.
 * User: Graeme
 * Date: 2009/10/01
 * Time: 08:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace BoozeHoundBooks
{
	partial class KTransactionForm : System.Windows.Forms.Form
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
      this.multiplyAmount = new System.Windows.Forms.TextBox();
      this.multiply = new System.Windows.Forms.Button();
      this.confirmAmount = new System.Windows.Forms.CheckBox();
      this.transactionRecurring = new System.Windows.Forms.CheckBox();
      this.transactionProcessAsNew = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.actionLoan = new System.Windows.Forms.RadioButton();
      this.actionRepayment = new System.Windows.Forms.RadioButton();
      this.label3 = new System.Windows.Forms.Label();
      this.transactionDebt = new System.Windows.Forms.RadioButton();
      this.transactionCredit = new System.Windows.Forms.RadioButton();
      this.periodName = new System.Windows.Forms.Label();
      this.transactionCancel = new System.Windows.Forms.Button();
      this.transactionBudget = new System.Windows.Forms.CheckBox();
      this.transactionInter = new System.Windows.Forms.RadioButton();
      this.transactionMasterAccount = new System.Windows.Forms.ComboBox();
      this.label8 = new System.Windows.Forms.Label();
      this.transactionDate = new System.Windows.Forms.DateTimePicker();
      this.label2 = new System.Windows.Forms.Label();
      this.transactionProcess = new System.Windows.Forms.Button();
      this.transactionAmount = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.transactionInfo = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.transactionToAcc = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.transactionFromAcc = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.transactionIncome = new System.Windows.Forms.RadioButton();
      this.transactionExpense = new System.Windows.Forms.RadioButton();
      this.groupBox1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.multiplyAmount);
      this.groupBox1.Controls.Add(this.multiply);
      this.groupBox1.Controls.Add(this.confirmAmount);
      this.groupBox1.Controls.Add(this.transactionRecurring);
      this.groupBox1.Controls.Add(this.transactionProcessAsNew);
      this.groupBox1.Controls.Add(this.panel1);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.transactionDebt);
      this.groupBox1.Controls.Add(this.transactionCredit);
      this.groupBox1.Controls.Add(this.periodName);
      this.groupBox1.Controls.Add(this.transactionCancel);
      this.groupBox1.Controls.Add(this.transactionBudget);
      this.groupBox1.Controls.Add(this.transactionInter);
      this.groupBox1.Controls.Add(this.transactionMasterAccount);
      this.groupBox1.Controls.Add(this.label8);
      this.groupBox1.Controls.Add(this.transactionDate);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.transactionProcess);
      this.groupBox1.Controls.Add(this.transactionAmount);
      this.groupBox1.Controls.Add(this.label7);
      this.groupBox1.Controls.Add(this.transactionInfo);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.transactionToAcc);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.transactionFromAcc);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.transactionIncome);
      this.groupBox1.Controls.Add(this.transactionExpense);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.groupBox1.Size = new System.Drawing.Size(390, 400);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      // 
      // multiplyAmount
      // 
      this.multiplyAmount.Location = new System.Drawing.Point(244, 261);
      this.multiplyAmount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.multiplyAmount.Name = "multiplyAmount";
      this.multiplyAmount.Size = new System.Drawing.Size(45, 23);
      this.multiplyAmount.TabIndex = 15;
      this.multiplyAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // multiply
      // 
      this.multiply.Location = new System.Drawing.Point(174, 261);
      this.multiply.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.multiply.Name = "multiply";
      this.multiply.Size = new System.Drawing.Size(52, 23);
      this.multiply.TabIndex = 14;
      this.multiply.Text = "X";
      this.multiply.UseVisualStyleBackColor = true;
      this.multiply.Click += new System.EventHandler(this.multiply_Click);
      // 
      // confirmAmount
      // 
      this.confirmAmount.AutoSize = true;
      this.confirmAmount.Location = new System.Drawing.Point(158, 317);
      this.confirmAmount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.confirmAmount.Name = "confirmAmount";
      this.confirmAmount.Size = new System.Drawing.Size(117, 19);
      this.confirmAmount.TabIndex = 18;
      this.confirmAmount.Text = "Confirm Amount";
      this.confirmAmount.UseVisualStyleBackColor = true;
      // 
      // transactionRecurring
      // 
      this.transactionRecurring.AutoSize = true;
      this.transactionRecurring.Location = new System.Drawing.Point(65, 317);
      this.transactionRecurring.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.transactionRecurring.Name = "transactionRecurring";
      this.transactionRecurring.Size = new System.Drawing.Size(77, 19);
      this.transactionRecurring.TabIndex = 17;
      this.transactionRecurring.Text = "Recurring";
      this.transactionRecurring.UseVisualStyleBackColor = true;
      // 
      // transactionProcessAsNew
      // 
      this.transactionProcessAsNew.Location = new System.Drawing.Point(9, 360);
      this.transactionProcessAsNew.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.transactionProcessAsNew.Name = "transactionProcessAsNew";
      this.transactionProcessAsNew.Size = new System.Drawing.Size(126, 27);
      this.transactionProcessAsNew.TabIndex = 20;
      this.transactionProcessAsNew.Text = "Process as New";
      this.transactionProcessAsNew.UseVisualStyleBackColor = true;
      this.transactionProcessAsNew.Click += new System.EventHandler(this.TransactionProcessAsNewClick);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.actionLoan);
      this.panel1.Controls.Add(this.actionRepayment);
      this.panel1.Location = new System.Drawing.Point(65, 112);
      this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(192, 17);
      this.panel1.TabIndex = 26;
      // 
      // actionLoan
      // 
      this.actionLoan.AutoSize = true;
      this.actionLoan.Checked = true;
      this.actionLoan.Location = new System.Drawing.Point(4, 0);
      this.actionLoan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.actionLoan.Name = "actionLoan";
      this.actionLoan.Size = new System.Drawing.Size(51, 19);
      this.actionLoan.TabIndex = 7;
      this.actionLoan.TabStop = true;
      this.actionLoan.Text = "Loan";
      this.actionLoan.UseVisualStyleBackColor = true;
      this.actionLoan.CheckedChanged += new System.EventHandler(this.DebtCreditActionUpdate);
      // 
      // actionRepayment
      // 
      this.actionRepayment.AutoSize = true;
      this.actionRepayment.Location = new System.Drawing.Point(84, 0);
      this.actionRepayment.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.actionRepayment.Name = "actionRepayment";
      this.actionRepayment.Size = new System.Drawing.Size(85, 19);
      this.actionRepayment.TabIndex = 8;
      this.actionRepayment.Text = "Repayment";
      this.actionRepayment.UseVisualStyleBackColor = true;
      this.actionRepayment.CheckedChanged += new System.EventHandler(this.DebtCreditActionUpdate);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(9, 112);
      this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(42, 15);
      this.label3.TabIndex = 25;
      this.label3.Text = "Action";
      // 
      // transactionDebt
      // 
      this.transactionDebt.AutoSize = true;
      this.transactionDebt.Location = new System.Drawing.Point(65, 54);
      this.transactionDebt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.transactionDebt.Name = "transactionDebt";
      this.transactionDebt.Size = new System.Drawing.Size(50, 19);
      this.transactionDebt.TabIndex = 4;
      this.transactionDebt.Text = "Debt";
      this.transactionDebt.UseVisualStyleBackColor = true;
      this.transactionDebt.CheckedChanged += new System.EventHandler(this.TransactionDebtClick);
      this.transactionDebt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TransactionTypeKeyPress);
      // 
      // transactionCredit
      // 
      this.transactionCredit.AutoSize = true;
      this.transactionCredit.Location = new System.Drawing.Point(146, 54);
      this.transactionCredit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.transactionCredit.Name = "transactionCredit";
      this.transactionCredit.Size = new System.Drawing.Size(57, 19);
      this.transactionCredit.TabIndex = 5;
      this.transactionCredit.Text = "Credit";
      this.transactionCredit.UseVisualStyleBackColor = true;
      this.transactionCredit.CheckedChanged += new System.EventHandler(this.TransactionCreditClick);
      this.transactionCredit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TransactionTypeKeyPress);
      // 
      // periodName
      // 
      this.periodName.AutoSize = true;
      this.periodName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.periodName.Location = new System.Drawing.Point(180, 203);
      this.periodName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.periodName.Name = "periodName";
      this.periodName.Size = new System.Drawing.Size(90, 15);
      this.periodName.TabIndex = 22;
      this.periodName.Text = "<period name>";
      // 
      // transactionCancel
      // 
      this.transactionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.transactionCancel.Location = new System.Drawing.Point(296, 360);
      this.transactionCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.transactionCancel.Name = "transactionCancel";
      this.transactionCancel.Size = new System.Drawing.Size(75, 27);
      this.transactionCancel.TabIndex = 21;
      this.transactionCancel.Text = "Cancel";
      this.transactionCancel.UseVisualStyleBackColor = true;
      this.transactionCancel.Click += new System.EventHandler(this.TransactionCancelClick);
      // 
      // transactionBudget
      // 
      this.transactionBudget.AutoSize = true;
      this.transactionBudget.Location = new System.Drawing.Point(65, 291);
      this.transactionBudget.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.transactionBudget.Name = "transactionBudget";
      this.transactionBudget.Size = new System.Drawing.Size(127, 19);
      this.transactionBudget.TabIndex = 16;
      this.transactionBudget.Text = "Budget Transaction";
      this.transactionBudget.UseVisualStyleBackColor = true;
      // 
      // transactionInter
      // 
      this.transactionInter.AutoSize = true;
      this.transactionInter.Location = new System.Drawing.Point(230, 28);
      this.transactionInter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.transactionInter.Name = "transactionInter";
      this.transactionInter.Size = new System.Drawing.Size(99, 19);
      this.transactionInter.TabIndex = 3;
      this.transactionInter.Text = "Inter-Account";
      this.transactionInter.UseVisualStyleBackColor = true;
      this.transactionInter.CheckedChanged += new System.EventHandler(this.TransactionInterClick);
      this.transactionInter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TransactionTypeKeyPress);
      // 
      // transactionMasterAccount
      // 
      this.transactionMasterAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.transactionMasterAccount.FormattingEnabled = true;
      this.transactionMasterAccount.Location = new System.Drawing.Point(65, 81);
      this.transactionMasterAccount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.transactionMasterAccount.Name = "transactionMasterAccount";
      this.transactionMasterAccount.Size = new System.Drawing.Size(157, 23);
      this.transactionMasterAccount.TabIndex = 6;
      this.transactionMasterAccount.SelectedIndexChanged += new System.EventHandler(this.transactionMasterAccountSelectedIndexChanged);
      this.transactionMasterAccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TransactionMasterAccountKeyPress);
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(9, 84);
      this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(43, 15);
      this.label8.TabIndex = 18;
      this.label8.Text = "Master";
      // 
      // transactionDate
      // 
      this.transactionDate.CustomFormat = "dd/MM/yyyy";
      this.transactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.transactionDate.Location = new System.Drawing.Point(65, 198);
      this.transactionDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.transactionDate.Name = "transactionDate";
      this.transactionDate.Size = new System.Drawing.Size(106, 23);
      this.transactionDate.TabIndex = 11;
      this.transactionDate.ValueChanged += new System.EventHandler(this.transactionDate_ValueChanged);
      this.transactionDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TransactionDateKeyPress);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(9, 204);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(31, 15);
      this.label2.TabIndex = 16;
      this.label2.Text = "Date";
      // 
      // transactionProcess
      // 
      this.transactionProcess.Location = new System.Drawing.Point(198, 360);
      this.transactionProcess.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.transactionProcess.Name = "transactionProcess";
      this.transactionProcess.Size = new System.Drawing.Size(91, 27);
      this.transactionProcess.TabIndex = 19;
      this.transactionProcess.Text = "Process";
      this.transactionProcess.UseVisualStyleBackColor = true;
      this.transactionProcess.Click += new System.EventHandler(this.TransactionProcessClick);
      // 
      // transactionAmount
      // 
      this.transactionAmount.Location = new System.Drawing.Point(65, 261);
      this.transactionAmount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.transactionAmount.Name = "transactionAmount";
      this.transactionAmount.Size = new System.Drawing.Size(89, 23);
      this.transactionAmount.TabIndex = 13;
      this.transactionAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.transactionAmount.Click += new System.EventHandler(this.transactionAmount_Click);
      this.transactionAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TransactionAmountKeyPress);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(9, 264);
      this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(51, 15);
      this.label7.TabIndex = 13;
      this.label7.Text = "Amount";
      // 
      // transactionInfo
      // 
      this.transactionInfo.Location = new System.Drawing.Point(65, 230);
      this.transactionInfo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.transactionInfo.Name = "transactionInfo";
      this.transactionInfo.Size = new System.Drawing.Size(305, 23);
      this.transactionInfo.TabIndex = 12;
      this.transactionInfo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TransactionInfoKeyPress);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(9, 233);
      this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(28, 15);
      this.label6.TabIndex = 11;
      this.label6.Text = "Info";
      // 
      // transactionToAcc
      // 
      this.transactionToAcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.transactionToAcc.FormattingEnabled = true;
      this.transactionToAcc.Location = new System.Drawing.Point(65, 167);
      this.transactionToAcc.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.transactionToAcc.Name = "transactionToAcc";
      this.transactionToAcc.Size = new System.Drawing.Size(305, 23);
      this.transactionToAcc.TabIndex = 10;
      this.transactionToAcc.SelectedIndexChanged += new System.EventHandler(this.TransactionToAccSelectedIndexChanged);
      this.transactionToAcc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TransactionToAccKeyPress);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(9, 171);
      this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(19, 15);
      this.label4.TabIndex = 9;
      this.label4.Text = "To";
      // 
      // transactionFromAcc
      // 
      this.transactionFromAcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.transactionFromAcc.FormattingEnabled = true;
      this.transactionFromAcc.Location = new System.Drawing.Point(65, 136);
      this.transactionFromAcc.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.transactionFromAcc.Name = "transactionFromAcc";
      this.transactionFromAcc.Size = new System.Drawing.Size(305, 23);
      this.transactionFromAcc.TabIndex = 9;
      this.transactionFromAcc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TransactionFromAccKeyPress);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(9, 140);
      this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(35, 15);
      this.label5.TabIndex = 7;
      this.label5.Text = "From";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 30);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(31, 15);
      this.label1.TabIndex = 2;
      this.label1.Text = "Type";
      // 
      // transactionIncome
      // 
      this.transactionIncome.AutoSize = true;
      this.transactionIncome.Checked = true;
      this.transactionIncome.Location = new System.Drawing.Point(65, 28);
      this.transactionIncome.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.transactionIncome.Name = "transactionIncome";
      this.transactionIncome.Size = new System.Drawing.Size(65, 19);
      this.transactionIncome.TabIndex = 0;
      this.transactionIncome.TabStop = true;
      this.transactionIncome.Text = "Income";
      this.transactionIncome.UseVisualStyleBackColor = true;
      this.transactionIncome.CheckedChanged += new System.EventHandler(this.TransactionIncomeClick);
      this.transactionIncome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TransactionTypeKeyPress);
      // 
      // transactionExpense
      // 
      this.transactionExpense.AutoSize = true;
      this.transactionExpense.Location = new System.Drawing.Point(146, 28);
      this.transactionExpense.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.transactionExpense.Name = "transactionExpense";
      this.transactionExpense.Size = new System.Drawing.Size(68, 19);
      this.transactionExpense.TabIndex = 1;
      this.transactionExpense.Text = "Expense";
      this.transactionExpense.UseVisualStyleBackColor = true;
      this.transactionExpense.CheckedChanged += new System.EventHandler(this.TransactionExpenseClick);
      this.transactionExpense.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TransactionTypeKeyPress);
      // 
      // KTransactionForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.transactionCancel;
      this.ClientSize = new System.Drawing.Size(390, 400);
      this.ControlBox = false;
      this.Controls.Add(this.groupBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "KTransactionForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Transaction";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

		}
		private System.Windows.Forms.Button transactionProcessAsNew;
		private System.Windows.Forms.RadioButton transactionCredit;
		private System.Windows.Forms.RadioButton transactionDebt;
		private System.Windows.Forms.Button transactionCancel;
		private System.Windows.Forms.RadioButton transactionExpense;
		private System.Windows.Forms.RadioButton transactionIncome;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox transactionFromAcc;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox transactionToAcc;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox transactionInfo;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox transactionAmount;
		private System.Windows.Forms.Button transactionProcess;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker transactionDate;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox transactionMasterAccount;
		private System.Windows.Forms.RadioButton transactionInter;
		private System.Windows.Forms.CheckBox transactionBudget;
		private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label periodName;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.RadioButton actionLoan;
    private System.Windows.Forms.RadioButton actionRepayment;
    private System.Windows.Forms.CheckBox transactionRecurring;
    private System.Windows.Forms.CheckBox confirmAmount;
    private System.Windows.Forms.TextBox multiplyAmount;
    private System.Windows.Forms.Button multiply;
  }
}
