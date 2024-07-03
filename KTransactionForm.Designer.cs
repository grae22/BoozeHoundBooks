/*
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
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            transactionBudget = new CheckBox();
            transactionRecurring = new CheckBox();
            confirmAmount = new CheckBox();
            uiTags = new KTagControl();
            multiplyAmount = new TextBox();
            multiply = new Button();
            transactionProcessAsNew = new Button();
            panel1 = new Panel();
            actionLoan = new RadioButton();
            actionRepayment = new RadioButton();
            label3 = new Label();
            transactionDebt = new RadioButton();
            transactionCredit = new RadioButton();
            periodName = new Label();
            transactionCancel = new Button();
            transactionInter = new RadioButton();
            transactionMasterAccount = new ComboBox();
            label8 = new Label();
            transactionDate = new DateTimePicker();
            label2 = new Label();
            transactionProcess = new Button();
            transactionAmount = new TextBox();
            label7 = new Label();
            transactionInfo = new TextBox();
            label6 = new Label();
            transactionToAcc = new ComboBox();
            label4 = new Label();
            transactionFromAcc = new ComboBox();
            label5 = new Label();
            label1 = new Label();
            transactionIncome = new RadioButton();
            transactionExpense = new RadioButton();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(uiTags);
            groupBox1.Controls.Add(multiplyAmount);
            groupBox1.Controls.Add(multiply);
            groupBox1.Controls.Add(transactionProcessAsNew);
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(transactionDebt);
            groupBox1.Controls.Add(transactionCredit);
            groupBox1.Controls.Add(periodName);
            groupBox1.Controls.Add(transactionCancel);
            groupBox1.Controls.Add(transactionInter);
            groupBox1.Controls.Add(transactionMasterAccount);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(transactionDate);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(transactionProcess);
            groupBox1.Controls.Add(transactionAmount);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(transactionInfo);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(transactionToAcc);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(transactionFromAcc);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(transactionIncome);
            groupBox1.Controls.Add(transactionExpense);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(4, 0);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(381, 612);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(transactionBudget);
            groupBox2.Controls.Add(transactionRecurring);
            groupBox2.Controls.Add(confirmAmount);
            groupBox2.Location = new Point(9, 473);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(361, 75);
            groupBox2.TabIndex = 28;
            groupBox2.TabStop = false;
            // 
            // transactionBudget
            // 
            transactionBudget.AutoSize = true;
            transactionBudget.Location = new Point(18, 22);
            transactionBudget.Margin = new Padding(4, 3, 4, 3);
            transactionBudget.Name = "transactionBudget";
            transactionBudget.Size = new Size(127, 19);
            transactionBudget.TabIndex = 16;
            transactionBudget.Text = "Budget Transaction";
            transactionBudget.UseVisualStyleBackColor = true;
            // 
            // transactionRecurring
            // 
            transactionRecurring.AutoSize = true;
            transactionRecurring.Location = new Point(18, 48);
            transactionRecurring.Margin = new Padding(4, 3, 4, 3);
            transactionRecurring.Name = "transactionRecurring";
            transactionRecurring.Size = new Size(77, 19);
            transactionRecurring.TabIndex = 17;
            transactionRecurring.Text = "Recurring";
            transactionRecurring.UseVisualStyleBackColor = true;
            // 
            // confirmAmount
            // 
            confirmAmount.AutoSize = true;
            confirmAmount.Location = new Point(111, 48);
            confirmAmount.Margin = new Padding(4, 3, 4, 3);
            confirmAmount.Name = "confirmAmount";
            confirmAmount.Size = new Size(117, 19);
            confirmAmount.TabIndex = 18;
            confirmAmount.Text = "Confirm Amount";
            confirmAmount.UseVisualStyleBackColor = true;
            // 
            // uiTags
            // 
            uiTags.Location = new Point(9, 299);
            uiTags.Name = "uiTags";
            uiTags.Size = new Size(361, 168);
            uiTags.TabIndex = 27;
            // 
            // multiplyAmount
            // 
            multiplyAmount.Location = new Point(244, 261);
            multiplyAmount.Margin = new Padding(4, 3, 4, 3);
            multiplyAmount.Name = "multiplyAmount";
            multiplyAmount.Size = new Size(45, 23);
            multiplyAmount.TabIndex = 15;
            multiplyAmount.TextAlign = HorizontalAlignment.Center;
            // 
            // multiply
            // 
            multiply.Location = new Point(174, 261);
            multiply.Margin = new Padding(4, 3, 4, 3);
            multiply.Name = "multiply";
            multiply.Size = new Size(52, 23);
            multiply.TabIndex = 14;
            multiply.Text = "X";
            multiply.UseVisualStyleBackColor = true;
            multiply.Click += multiply_Click;
            // 
            // transactionProcessAsNew
            // 
            transactionProcessAsNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            transactionProcessAsNew.Location = new Point(9, 569);
            transactionProcessAsNew.Margin = new Padding(4, 3, 4, 3);
            transactionProcessAsNew.Name = "transactionProcessAsNew";
            transactionProcessAsNew.Size = new Size(126, 27);
            transactionProcessAsNew.TabIndex = 20;
            transactionProcessAsNew.Text = "Process as New";
            transactionProcessAsNew.UseVisualStyleBackColor = true;
            transactionProcessAsNew.Click += TransactionProcessAsNewClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(actionLoan);
            panel1.Controls.Add(actionRepayment);
            panel1.Location = new Point(65, 112);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(192, 17);
            panel1.TabIndex = 26;
            // 
            // actionLoan
            // 
            actionLoan.AutoSize = true;
            actionLoan.Checked = true;
            actionLoan.Location = new Point(4, 0);
            actionLoan.Margin = new Padding(4, 3, 4, 3);
            actionLoan.Name = "actionLoan";
            actionLoan.Size = new Size(51, 19);
            actionLoan.TabIndex = 7;
            actionLoan.TabStop = true;
            actionLoan.Text = "Loan";
            actionLoan.UseVisualStyleBackColor = true;
            actionLoan.CheckedChanged += DebtCreditActionUpdate;
            // 
            // actionRepayment
            // 
            actionRepayment.AutoSize = true;
            actionRepayment.Location = new Point(84, 0);
            actionRepayment.Margin = new Padding(4, 3, 4, 3);
            actionRepayment.Name = "actionRepayment";
            actionRepayment.Size = new Size(85, 19);
            actionRepayment.TabIndex = 8;
            actionRepayment.Text = "Repayment";
            actionRepayment.UseVisualStyleBackColor = true;
            actionRepayment.CheckedChanged += DebtCreditActionUpdate;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 105);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 25;
            label3.Text = "Action";
            // 
            // transactionDebt
            // 
            transactionDebt.AutoSize = true;
            transactionDebt.Location = new Point(59, 47);
            transactionDebt.Margin = new Padding(4, 3, 4, 3);
            transactionDebt.Name = "transactionDebt";
            transactionDebt.Size = new Size(50, 19);
            transactionDebt.TabIndex = 4;
            transactionDebt.Text = "Debt";
            transactionDebt.UseVisualStyleBackColor = true;
            transactionDebt.CheckedChanged += TransactionDebtClick;
            transactionDebt.KeyPress += TransactionTypeKeyPress;
            // 
            // transactionCredit
            // 
            transactionCredit.AutoSize = true;
            transactionCredit.Location = new Point(140, 47);
            transactionCredit.Margin = new Padding(4, 3, 4, 3);
            transactionCredit.Name = "transactionCredit";
            transactionCredit.Size = new Size(57, 19);
            transactionCredit.TabIndex = 5;
            transactionCredit.Text = "Credit";
            transactionCredit.UseVisualStyleBackColor = true;
            transactionCredit.CheckedChanged += TransactionCreditClick;
            transactionCredit.KeyPress += TransactionTypeKeyPress;
            // 
            // periodName
            // 
            periodName.AutoSize = true;
            periodName.ForeColor = SystemColors.ActiveCaption;
            periodName.Location = new Point(174, 196);
            periodName.Margin = new Padding(4, 0, 4, 0);
            periodName.Name = "periodName";
            periodName.Size = new Size(90, 15);
            periodName.TabIndex = 22;
            periodName.Text = "<period name>";
            // 
            // transactionCancel
            // 
            transactionCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            transactionCancel.DialogResult = DialogResult.Cancel;
            transactionCancel.Location = new Point(295, 569);
            transactionCancel.Margin = new Padding(4, 3, 4, 3);
            transactionCancel.Name = "transactionCancel";
            transactionCancel.Size = new Size(75, 27);
            transactionCancel.TabIndex = 21;
            transactionCancel.Text = "Cancel";
            transactionCancel.UseVisualStyleBackColor = true;
            transactionCancel.Click += TransactionCancelClick;
            // 
            // transactionInter
            // 
            transactionInter.AutoSize = true;
            transactionInter.Location = new Point(224, 21);
            transactionInter.Margin = new Padding(4, 3, 4, 3);
            transactionInter.Name = "transactionInter";
            transactionInter.Size = new Size(99, 19);
            transactionInter.TabIndex = 3;
            transactionInter.Text = "Inter-Account";
            transactionInter.UseVisualStyleBackColor = true;
            transactionInter.CheckedChanged += TransactionInterClick;
            transactionInter.KeyPress += TransactionTypeKeyPress;
            // 
            // transactionMasterAccount
            // 
            transactionMasterAccount.DropDownStyle = ComboBoxStyle.DropDownList;
            transactionMasterAccount.FormattingEnabled = true;
            transactionMasterAccount.Location = new Point(65, 81);
            transactionMasterAccount.Margin = new Padding(4, 3, 4, 3);
            transactionMasterAccount.Name = "transactionMasterAccount";
            transactionMasterAccount.Size = new Size(157, 23);
            transactionMasterAccount.TabIndex = 6;
            transactionMasterAccount.SelectedIndexChanged += transactionMasterAccountSelectedIndexChanged;
            transactionMasterAccount.KeyPress += TransactionMasterAccountKeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(3, 77);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(43, 15);
            label8.TabIndex = 18;
            label8.Text = "Master";
            // 
            // transactionDate
            // 
            transactionDate.CustomFormat = "dd/MM/yyyy";
            transactionDate.Format = DateTimePickerFormat.Custom;
            transactionDate.Location = new Point(65, 198);
            transactionDate.Margin = new Padding(4, 3, 4, 3);
            transactionDate.Name = "transactionDate";
            transactionDate.Size = new Size(106, 23);
            transactionDate.TabIndex = 11;
            transactionDate.ValueChanged += transactionDate_ValueChanged;
            transactionDate.KeyPress += TransactionDateKeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 197);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 16;
            label2.Text = "Date";
            // 
            // transactionProcess
            // 
            transactionProcess.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            transactionProcess.Location = new Point(197, 569);
            transactionProcess.Margin = new Padding(4, 3, 4, 3);
            transactionProcess.Name = "transactionProcess";
            transactionProcess.Size = new Size(91, 27);
            transactionProcess.TabIndex = 19;
            transactionProcess.Text = "Process";
            transactionProcess.UseVisualStyleBackColor = true;
            transactionProcess.Click += TransactionProcessClick;
            // 
            // transactionAmount
            // 
            transactionAmount.Location = new Point(65, 261);
            transactionAmount.Margin = new Padding(4, 3, 4, 3);
            transactionAmount.Name = "transactionAmount";
            transactionAmount.Size = new Size(89, 23);
            transactionAmount.TabIndex = 13;
            transactionAmount.TextAlign = HorizontalAlignment.Right;
            transactionAmount.Click += transactionAmount_Click;
            transactionAmount.KeyPress += TransactionAmountKeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 257);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(51, 15);
            label7.TabIndex = 13;
            label7.Text = "Amount";
            // 
            // transactionInfo
            // 
            transactionInfo.Location = new Point(65, 230);
            transactionInfo.Margin = new Padding(4, 3, 4, 3);
            transactionInfo.Name = "transactionInfo";
            transactionInfo.Size = new Size(305, 23);
            transactionInfo.TabIndex = 12;
            transactionInfo.KeyPress += TransactionInfoKeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 226);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(28, 15);
            label6.TabIndex = 11;
            label6.Text = "Info";
            // 
            // transactionToAcc
            // 
            transactionToAcc.DropDownStyle = ComboBoxStyle.DropDownList;
            transactionToAcc.FormattingEnabled = true;
            transactionToAcc.Location = new Point(65, 167);
            transactionToAcc.Margin = new Padding(4, 3, 4, 3);
            transactionToAcc.Name = "transactionToAcc";
            transactionToAcc.Size = new Size(305, 23);
            transactionToAcc.TabIndex = 10;
            transactionToAcc.SelectedIndexChanged += TransactionToAccSelectedIndexChanged;
            transactionToAcc.KeyPress += TransactionToAccKeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 164);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(19, 15);
            label4.TabIndex = 9;
            label4.Text = "To";
            // 
            // transactionFromAcc
            // 
            transactionFromAcc.DropDownStyle = ComboBoxStyle.DropDownList;
            transactionFromAcc.FormattingEnabled = true;
            transactionFromAcc.Location = new Point(65, 136);
            transactionFromAcc.Margin = new Padding(4, 3, 4, 3);
            transactionFromAcc.Name = "transactionFromAcc";
            transactionFromAcc.Size = new Size(305, 23);
            transactionFromAcc.TabIndex = 9;
            transactionFromAcc.KeyPress += TransactionFromAccKeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 133);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 7;
            label5.Text = "From";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 23);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 2;
            label1.Text = "Type";
            // 
            // transactionIncome
            // 
            transactionIncome.AutoSize = true;
            transactionIncome.Checked = true;
            transactionIncome.Location = new Point(59, 21);
            transactionIncome.Margin = new Padding(4, 3, 4, 3);
            transactionIncome.Name = "transactionIncome";
            transactionIncome.Size = new Size(65, 19);
            transactionIncome.TabIndex = 0;
            transactionIncome.TabStop = true;
            transactionIncome.Text = "Income";
            transactionIncome.UseVisualStyleBackColor = true;
            transactionIncome.CheckedChanged += TransactionIncomeClick;
            transactionIncome.KeyPress += TransactionTypeKeyPress;
            // 
            // transactionExpense
            // 
            transactionExpense.AutoSize = true;
            transactionExpense.Location = new Point(140, 21);
            transactionExpense.Margin = new Padding(4, 3, 4, 3);
            transactionExpense.Name = "transactionExpense";
            transactionExpense.Size = new Size(68, 19);
            transactionExpense.TabIndex = 1;
            transactionExpense.Text = "Expense";
            transactionExpense.UseVisualStyleBackColor = true;
            transactionExpense.CheckedChanged += TransactionExpenseClick;
            transactionExpense.KeyPress += TransactionTypeKeyPress;
            // 
            // KTransactionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = transactionCancel;
            ClientSize = new Size(389, 616);
            ControlBox = false;
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "KTransactionForm";
            Padding = new Padding(4, 0, 4, 4);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Transaction";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
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
        private KTagControl uiTags;
        private GroupBox groupBox2;
    }
}
