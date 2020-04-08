/*
 * Created by SharpDevelop.
 * User: Graeme
 * Date: 2009/09/26
 * Time: 02:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace BoozeHoundBooks
{
	partial class KMainForm : System.Windows.Forms.Form
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KMainForm));
      this.topMenu = new System.Windows.Forms.MenuStrip();
      this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.newBook = new System.Windows.Forms.ToolStripMenuItem();
      this.openBook = new System.Windows.Forms.ToolStripMenuItem();
      this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.viewTransactionGridBGAccount = new System.Windows.Forms.ToolStripMenuItem();
      this.viewTransactionGridBGContra = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.showHiddenAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.accountMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.addAccount = new System.Windows.Forms.ToolStripMenuItem();
      this.editAccount = new System.Windows.Forms.ToolStripMenuItem();
      this.periodMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.editPeriods = new System.Windows.Forms.ToolStripMenuItem();
      this.summaryExpressionMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.addSummaryExpressionItem = new System.Windows.Forms.ToolStripMenuItem();
      this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.generateRecurringTransactions = new System.Windows.Forms.ToolStripMenuItem();
      this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.splitContainerHoriz = new System.Windows.Forms.SplitContainer();
      this.accountTree = new System.Windows.Forms.TreeView();
      this.splitContainerVert = new System.Windows.Forms.SplitContainer();
      this.panel3 = new System.Windows.Forms.Panel();
      this.summaryExpressionGrid = new System.Windows.Forms.DataGridView();
      this.transactionGrid = new System.Windows.Forms.DataGridView();
      this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Budget = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.DayOfWeekIcon = new System.Windows.Forms.DataGridViewImageColumn();
      this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.AccountIcon = new System.Windows.Forms.DataGridViewImageColumn();
      this.Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ContraIcon = new System.Windows.Forms.DataGridViewImageColumn();
      this.Contra = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label2 = new System.Windows.Forms.Label();
      this.currentVsAvgPriorBalance = new System.Windows.Forms.ComboBox();
      this.viewBudget = new System.Windows.Forms.CheckBox();
      this.label1 = new System.Windows.Forms.Label();
      this.defaultDate = new System.Windows.Forms.DateTimePicker();
      this.viewByDateTo = new System.Windows.Forms.CheckBox();
      this.viewByDateFrom = new System.Windows.Forms.CheckBox();
      this.viewByPeriod = new System.Windows.Forms.CheckBox();
      this.newAdjustment = new System.Windows.Forms.Button();
      this.deleteTransaction = new System.Windows.Forms.Button();
      this.viewPeriod = new System.Windows.Forms.ComboBox();
      this.viewTo = new System.Windows.Forms.DateTimePicker();
      this.viewFrom = new System.Windows.Forms.DateTimePicker();
      this.transactionCountLbl = new System.Windows.Forms.Label();
      this.SummaryNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ValueCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Unused = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.topMenu.SuspendLayout();
      this.mainPanel.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).BeginInit();
      this.splitContainerHoriz.Panel1.SuspendLayout();
      this.splitContainerHoriz.Panel2.SuspendLayout();
      this.splitContainerHoriz.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).BeginInit();
      this.splitContainerVert.Panel1.SuspendLayout();
      this.splitContainerVert.Panel2.SuspendLayout();
      this.splitContainerVert.SuspendLayout();
      this.panel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.summaryExpressionGrid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.transactionGrid)).BeginInit();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // topMenu
      // 
      this.topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.viewMenu,
            this.accountMenu,
            this.periodMenu,
            this.summaryExpressionMenu,
            this.transactionsToolStripMenuItem});
      this.topMenu.Location = new System.Drawing.Point(0, 0);
      this.topMenu.Name = "topMenu";
      this.topMenu.Size = new System.Drawing.Size(1121, 24);
      this.topMenu.TabIndex = 0;
      this.topMenu.Text = "topMenu";
      // 
      // fileMenu
      // 
      this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBook,
            this.openBook});
      this.fileMenu.Name = "fileMenu";
      this.fileMenu.Size = new System.Drawing.Size(37, 20);
      this.fileMenu.Text = "&File";
      // 
      // newBook
      // 
      this.newBook.Name = "newBook";
      this.newBook.Size = new System.Drawing.Size(133, 22);
      this.newBook.Text = "&New Book";
      this.newBook.Click += new System.EventHandler(this.NewBookClick);
      // 
      // openBook
      // 
      this.openBook.Name = "openBook";
      this.openBook.Size = new System.Drawing.Size(133, 22);
      this.openBook.Text = "&Open Book";
      this.openBook.Click += new System.EventHandler(this.OpenBookClick);
      // 
      // viewMenu
      // 
      this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewTransactionGridBGAccount,
            this.viewTransactionGridBGContra,
            this.toolStripSeparator2,
            this.showHiddenAccountsToolStripMenuItem});
      this.viewMenu.Name = "viewMenu";
      this.viewMenu.Size = new System.Drawing.Size(44, 20);
      this.viewMenu.Text = "&View";
      // 
      // viewTransactionGridBGAccount
      // 
      this.viewTransactionGridBGAccount.CheckOnClick = true;
      this.viewTransactionGridBGAccount.Name = "viewTransactionGridBGAccount";
      this.viewTransactionGridBGAccount.Size = new System.Drawing.Size(357, 22);
      this.viewTransactionGridBGAccount.Text = "Use Account colours for Transaction Grid background";
      this.viewTransactionGridBGAccount.CheckedChanged += new System.EventHandler(this.ViewTransactionGridBGCheckedChanged);
      // 
      // viewTransactionGridBGContra
      // 
      this.viewTransactionGridBGContra.CheckOnClick = true;
      this.viewTransactionGridBGContra.Name = "viewTransactionGridBGContra";
      this.viewTransactionGridBGContra.Size = new System.Drawing.Size(357, 22);
      this.viewTransactionGridBGContra.Text = "Use Contra colours for Transaction Grid background";
      this.viewTransactionGridBGContra.CheckedChanged += new System.EventHandler(this.ViewTransactionGridBGCheckedChanged);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(354, 6);
      // 
      // showHiddenAccountsToolStripMenuItem
      // 
      this.showHiddenAccountsToolStripMenuItem.CheckOnClick = true;
      this.showHiddenAccountsToolStripMenuItem.Name = "showHiddenAccountsToolStripMenuItem";
      this.showHiddenAccountsToolStripMenuItem.Size = new System.Drawing.Size(357, 22);
      this.showHiddenAccountsToolStripMenuItem.Text = "Show Hidden Accounts";
      this.showHiddenAccountsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showHiddenAccountsToolStripMenuItem_CheckedChanged);
      // 
      // accountMenu
      // 
      this.accountMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAccount,
            this.editAccount});
      this.accountMenu.Name = "accountMenu";
      this.accountMenu.Size = new System.Drawing.Size(69, 20);
      this.accountMenu.Text = "&Accounts";
      // 
      // addAccount
      // 
      this.addAccount.Name = "addAccount";
      this.addAccount.Size = new System.Drawing.Size(144, 22);
      this.addAccount.Text = "&Add Account";
      this.addAccount.Click += new System.EventHandler(this.AddAccountClick);
      // 
      // editAccount
      // 
      this.editAccount.Name = "editAccount";
      this.editAccount.Size = new System.Drawing.Size(144, 22);
      this.editAccount.Text = "&Edit Account";
      this.editAccount.Click += new System.EventHandler(this.EditAccountClick);
      // 
      // periodMenu
      // 
      this.periodMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editPeriods});
      this.periodMenu.Name = "periodMenu";
      this.periodMenu.Size = new System.Drawing.Size(58, 20);
      this.periodMenu.Text = "&Periods";
      // 
      // editPeriods
      // 
      this.editPeriods.Name = "editPeriods";
      this.editPeriods.Size = new System.Drawing.Size(136, 22);
      this.editPeriods.Text = "&Edit Periods";
      this.editPeriods.Click += new System.EventHandler(this.EditPeriodsClick);
      // 
      // summaryExpressionMenu
      // 
      this.summaryExpressionMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSummaryExpressionItem});
      this.summaryExpressionMenu.Name = "summaryExpressionMenu";
      this.summaryExpressionMenu.Size = new System.Drawing.Size(103, 20);
      this.summaryExpressionMenu.Text = "&Summary Fields";
      // 
      // addSummaryExpressionItem
      // 
      this.addSummaryExpressionItem.Name = "addSummaryExpressionItem";
      this.addSummaryExpressionItem.Size = new System.Drawing.Size(124, 22);
      this.addSummaryExpressionItem.Text = "&Add Field";
      this.addSummaryExpressionItem.Click += new System.EventHandler(this.AddSummaryExpressionItemClick);
      // 
      // transactionsToolStripMenuItem
      // 
      this.transactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateRecurringTransactions});
      this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
      this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
      this.transactionsToolStripMenuItem.Text = "&Transactions";
      // 
      // generateRecurringTransactions
      // 
      this.generateRecurringTransactions.Name = "generateRecurringTransactions";
      this.generateRecurringTransactions.Size = new System.Drawing.Size(175, 22);
      this.generateRecurringTransactions.Text = "&Generate Recurring";
      this.generateRecurringTransactions.Click += new System.EventHandler(this.generateRecurringTransactions_Click);
      // 
      // mainPanel
      // 
      this.mainPanel.BackColor = System.Drawing.SystemColors.Control;
      this.mainPanel.ColumnCount = 1;
      this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.95723F));
      this.mainPanel.Controls.Add(this.panel1, 0, 1);
      this.mainPanel.Controls.Add(this.panel2, 0, 0);
      this.mainPanel.Controls.Add(this.transactionCountLbl, 0, 2);
      this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainPanel.Location = new System.Drawing.Point(0, 24);
      this.mainPanel.Name = "mainPanel";
      this.mainPanel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 10);
      this.mainPanel.RowCount = 3;
      this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
      this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.mainPanel.Size = new System.Drawing.Size(1121, 642);
      this.mainPanel.TabIndex = 1;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.splitContainerHoriz);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(8, 34);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1105, 575);
      this.panel1.TabIndex = 5;
      // 
      // splitContainerHoriz
      // 
      this.splitContainerHoriz.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainerHoriz.Location = new System.Drawing.Point(0, 0);
      this.splitContainerHoriz.Name = "splitContainerHoriz";
      // 
      // splitContainerHoriz.Panel1
      // 
      this.splitContainerHoriz.Panel1.Controls.Add(this.accountTree);
      // 
      // splitContainerHoriz.Panel2
      // 
      this.splitContainerHoriz.Panel2.Controls.Add(this.splitContainerVert);
      this.splitContainerHoriz.Size = new System.Drawing.Size(1105, 575);
      this.splitContainerHoriz.SplitterDistance = 291;
      this.splitContainerHoriz.TabIndex = 0;
      // 
      // accountTree
      // 
      this.accountTree.Dock = System.Windows.Forms.DockStyle.Fill;
      this.accountTree.HideSelection = false;
      this.accountTree.Indent = 27;
      this.accountTree.ItemHeight = 20;
      this.accountTree.Location = new System.Drawing.Point(0, 0);
      this.accountTree.Name = "accountTree";
      this.accountTree.Size = new System.Drawing.Size(291, 575);
      this.accountTree.TabIndex = 2;
      this.accountTree.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.accountTree_AfterCollapse);
      this.accountTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.accountTree_AfterExpand);
      this.accountTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.accountTree_AfterSelect);
      this.accountTree.DoubleClick += new System.EventHandler(this.AccountTreeDoubleClick);
      // 
      // splitContainerVert
      // 
      this.splitContainerVert.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainerVert.Location = new System.Drawing.Point(0, 0);
      this.splitContainerVert.Name = "splitContainerVert";
      this.splitContainerVert.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainerVert.Panel1
      // 
      this.splitContainerVert.Panel1.Controls.Add(this.panel3);
      // 
      // splitContainerVert.Panel2
      // 
      this.splitContainerVert.Panel2.Controls.Add(this.transactionGrid);
      this.splitContainerVert.Size = new System.Drawing.Size(810, 575);
      this.splitContainerVert.SplitterDistance = 145;
      this.splitContainerVert.TabIndex = 0;
      // 
      // panel3
      // 
      this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel3.Controls.Add(this.summaryExpressionGrid);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel3.Location = new System.Drawing.Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(810, 145);
      this.panel3.TabIndex = 0;
      // 
      // summaryExpressionGrid
      // 
      this.summaryExpressionGrid.AllowUserToAddRows = false;
      this.summaryExpressionGrid.AllowUserToDeleteRows = false;
      this.summaryExpressionGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.summaryExpressionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.summaryExpressionGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SummaryNameCol,
            this.ValueCol,
            this.Unused});
      this.summaryExpressionGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.summaryExpressionGrid.Location = new System.Drawing.Point(0, 0);
      this.summaryExpressionGrid.Name = "summaryExpressionGrid";
      this.summaryExpressionGrid.ReadOnly = true;
      this.summaryExpressionGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.summaryExpressionGrid.Size = new System.Drawing.Size(808, 143);
      this.summaryExpressionGrid.TabIndex = 0;
      this.summaryExpressionGrid.Click += new System.EventHandler(this.summaryExpressionGrid_Click);
      this.summaryExpressionGrid.DoubleClick += new System.EventHandler(this.SummaryExpressionGridDoubleClick);
      // 
      // transactionGrid
      // 
      this.transactionGrid.AllowUserToAddRows = false;
      this.transactionGrid.AllowUserToDeleteRows = false;
      this.transactionGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.transactionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.transactionGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Budget,
            this.Date,
            this.DayOfWeekIcon,
            this.Amount,
            this.AccountIcon,
            this.Account,
            this.ContraIcon,
            this.Contra,
            this.Description});
      this.transactionGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.transactionGrid.Location = new System.Drawing.Point(0, 0);
      this.transactionGrid.Name = "transactionGrid";
      this.transactionGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.transactionGrid.Size = new System.Drawing.Size(810, 426);
      this.transactionGrid.TabIndex = 8;
      this.transactionGrid.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.transactionGrid_CellMouseUp);
      this.transactionGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.transactionGrid_CellValueChanged);
      this.transactionGrid.DoubleClick += new System.EventHandler(this.transactionGrid_DoubleClick);
      // 
      // Id
      // 
      this.Id.HeaderText = "Id";
      this.Id.Name = "Id";
      this.Id.ReadOnly = true;
      this.Id.Visible = false;
      // 
      // Budget
      // 
      this.Budget.FillWeight = 5F;
      this.Budget.HeaderText = "Budget";
      this.Budget.Name = "Budget";
      // 
      // Date
      // 
      this.Date.FillWeight = 15F;
      this.Date.HeaderText = "Date";
      this.Date.Name = "Date";
      this.Date.ReadOnly = true;
      // 
      // DayOfWeekIcon
      // 
      this.DayOfWeekIcon.FillWeight = 5.543147F;
      this.DayOfWeekIcon.HeaderText = "";
      this.DayOfWeekIcon.Name = "DayOfWeekIcon";
      this.DayOfWeekIcon.ReadOnly = true;
      this.DayOfWeekIcon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.DayOfWeekIcon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
      // 
      // Amount
      // 
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle3.Format = "C2";
      dataGridViewCellStyle3.NullValue = null;
      this.Amount.DefaultCellStyle = dataGridViewCellStyle3;
      this.Amount.FillWeight = 15F;
      this.Amount.HeaderText = "Amount";
      this.Amount.Name = "Amount";
      this.Amount.ReadOnly = true;
      // 
      // AccountIcon
      // 
      this.AccountIcon.FillWeight = 4.619289F;
      this.AccountIcon.HeaderText = "";
      this.AccountIcon.Name = "AccountIcon";
      this.AccountIcon.ReadOnly = true;
      // 
      // Account
      // 
      dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Account.DefaultCellStyle = dataGridViewCellStyle4;
      this.Account.FillWeight = 20F;
      this.Account.HeaderText = "Account";
      this.Account.Name = "Account";
      this.Account.ReadOnly = true;
      // 
      // ContraIcon
      // 
      this.ContraIcon.FillWeight = 4.619289F;
      this.ContraIcon.HeaderText = "";
      this.ContraIcon.Name = "ContraIcon";
      this.ContraIcon.ReadOnly = true;
      // 
      // Contra
      // 
      dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Contra.DefaultCellStyle = dataGridViewCellStyle5;
      this.Contra.FillWeight = 20F;
      this.Contra.HeaderText = "Contra";
      this.Contra.Name = "Contra";
      this.Contra.ReadOnly = true;
      // 
      // Description
      // 
      this.Description.FillWeight = 25F;
      this.Description.HeaderText = "Description";
      this.Description.Name = "Description";
      this.Description.ReadOnly = true;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.label2);
      this.panel2.Controls.Add(this.currentVsAvgPriorBalance);
      this.panel2.Controls.Add(this.viewBudget);
      this.panel2.Controls.Add(this.label1);
      this.panel2.Controls.Add(this.defaultDate);
      this.panel2.Controls.Add(this.viewByDateTo);
      this.panel2.Controls.Add(this.viewByDateFrom);
      this.panel2.Controls.Add(this.viewByPeriod);
      this.panel2.Controls.Add(this.newAdjustment);
      this.panel2.Controls.Add(this.deleteTransaction);
      this.panel2.Controls.Add(this.viewPeriod);
      this.panel2.Controls.Add(this.viewTo);
      this.panel2.Controls.Add(this.viewFrom);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(8, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(1105, 25);
      this.panel2.TabIndex = 6;
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(632, 7);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(87, 13);
      this.label2.TabIndex = 31;
      this.label2.Text = "Vs Prior Period(s)";
      // 
      // currentVsAvgPriorBalance
      // 
      this.currentVsAvgPriorBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.currentVsAvgPriorBalance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.currentVsAvgPriorBalance.FormattingEnabled = true;
      this.currentVsAvgPriorBalance.Items.AddRange(new object[] {
            "-",
            "1",
            "3",
            "6",
            "12",
            "18",
            "24"});
      this.currentVsAvgPriorBalance.Location = new System.Drawing.Point(725, 3);
      this.currentVsAvgPriorBalance.Name = "currentVsAvgPriorBalance";
      this.currentVsAvgPriorBalance.Size = new System.Drawing.Size(50, 21);
      this.currentVsAvgPriorBalance.TabIndex = 30;
      this.currentVsAvgPriorBalance.SelectedIndexChanged += new System.EventHandler(this.currentVsAvgPriorBalance_SelectedIndexChanged);
      // 
      // viewBudget
      // 
      this.viewBudget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.viewBudget.Appearance = System.Windows.Forms.Appearance.Button;
      this.viewBudget.Location = new System.Drawing.Point(781, 2);
      this.viewBudget.Name = "viewBudget";
      this.viewBudget.Size = new System.Drawing.Size(58, 23);
      this.viewBudget.TabIndex = 28;
      this.viewBudget.Text = "Budget";
      this.viewBudget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.viewBudget.UseVisualStyleBackColor = true;
      this.viewBudget.CheckedChanged += new System.EventHandler(this.viewBudget_CheckedChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.label1.Location = new System.Drawing.Point(464, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(65, 13);
      this.label1.TabIndex = 27;
      this.label1.Text = "Default date";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // defaultDate
      // 
      this.defaultDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.defaultDate.Location = new System.Drawing.Point(538, 5);
      this.defaultDate.Name = "defaultDate";
      this.defaultDate.Size = new System.Drawing.Size(85, 20);
      this.defaultDate.TabIndex = 26;
      // 
      // viewByDateTo
      // 
      this.viewByDateTo.Location = new System.Drawing.Point(312, 4);
      this.viewByDateTo.Name = "viewByDateTo";
      this.viewByDateTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.viewByDateTo.Size = new System.Drawing.Size(42, 24);
      this.viewByDateTo.TabIndex = 25;
      this.viewByDateTo.Text = "To";
      this.viewByDateTo.UseVisualStyleBackColor = true;
      this.viewByDateTo.CheckedChanged += new System.EventHandler(this.RefreshAccountTreeAndTransactionGrid);
      // 
      // viewByDateFrom
      // 
      this.viewByDateFrom.Location = new System.Drawing.Point(156, 4);
      this.viewByDateFrom.Name = "viewByDateFrom";
      this.viewByDateFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.viewByDateFrom.Size = new System.Drawing.Size(59, 24);
      this.viewByDateFrom.TabIndex = 24;
      this.viewByDateFrom.Text = "From";
      this.viewByDateFrom.UseVisualStyleBackColor = true;
      this.viewByDateFrom.CheckedChanged += new System.EventHandler(this.RefreshAccountTreeAndTransactionGrid);
      // 
      // viewByPeriod
      // 
      this.viewByPeriod.Location = new System.Drawing.Point(0, 4);
      this.viewByPeriod.Name = "viewByPeriod";
      this.viewByPeriod.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.viewByPeriod.Size = new System.Drawing.Size(59, 24);
      this.viewByPeriod.TabIndex = 23;
      this.viewByPeriod.Text = "Period";
      this.viewByPeriod.UseVisualStyleBackColor = true;
      this.viewByPeriod.CheckedChanged += new System.EventHandler(this.ViewByPeriodCheckedChanged);
      // 
      // newAdjustment
      // 
      this.newAdjustment.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.newAdjustment.Location = new System.Drawing.Point(857, 2);
      this.newAdjustment.Name = "newAdjustment";
      this.newAdjustment.Size = new System.Drawing.Size(121, 23);
      this.newAdjustment.TabIndex = 22;
      this.newAdjustment.Text = "Adjustment";
      this.newAdjustment.UseVisualStyleBackColor = true;
      this.newAdjustment.Click += new System.EventHandler(this.NewAdjustmentClick);
      // 
      // deleteTransaction
      // 
      this.deleteTransaction.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.deleteTransaction.Location = new System.Drawing.Point(984, 2);
      this.deleteTransaction.Name = "deleteTransaction";
      this.deleteTransaction.Size = new System.Drawing.Size(121, 23);
      this.deleteTransaction.TabIndex = 20;
      this.deleteTransaction.Text = "Delete Transaction";
      this.deleteTransaction.UseVisualStyleBackColor = true;
      this.deleteTransaction.Click += new System.EventHandler(this.deleteTransaction_Click);
      // 
      // viewPeriod
      // 
      this.viewPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.viewPeriod.FormattingEnabled = true;
      this.viewPeriod.Location = new System.Drawing.Point(65, 4);
      this.viewPeriod.Name = "viewPeriod";
      this.viewPeriod.Size = new System.Drawing.Size(85, 21);
      this.viewPeriod.TabIndex = 18;
      this.viewPeriod.SelectedIndexChanged += new System.EventHandler(this.ViewPeriodSelectedIndexChanged);
      // 
      // viewTo
      // 
      this.viewTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.viewTo.Location = new System.Drawing.Point(360, 5);
      this.viewTo.Name = "viewTo";
      this.viewTo.Size = new System.Drawing.Size(85, 20);
      this.viewTo.TabIndex = 16;
      this.viewTo.ValueChanged += new System.EventHandler(this.RefreshAccountTreeAndTransactionGrid);
      // 
      // viewFrom
      // 
      this.viewFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.viewFrom.Location = new System.Drawing.Point(221, 5);
      this.viewFrom.Name = "viewFrom";
      this.viewFrom.Size = new System.Drawing.Size(85, 20);
      this.viewFrom.TabIndex = 15;
      this.viewFrom.ValueChanged += new System.EventHandler(this.RefreshAccountTreeAndTransactionGrid);
      // 
      // transactionCountLbl
      // 
      this.transactionCountLbl.AutoSize = true;
      this.transactionCountLbl.Location = new System.Drawing.Point(8, 612);
      this.transactionCountLbl.Name = "transactionCountLbl";
      this.transactionCountLbl.Size = new System.Drawing.Size(79, 13);
      this.transactionCountLbl.TabIndex = 7;
      this.transactionCountLbl.Text = "Transactions: x";
      // 
      // SummaryNameCol
      // 
      this.SummaryNameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.SummaryNameCol.FillWeight = 20F;
      this.SummaryNameCol.HeaderText = "Summary";
      this.SummaryNameCol.Name = "SummaryNameCol";
      this.SummaryNameCol.ReadOnly = true;
      // 
      // ValueCol
      // 
      this.ValueCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
      this.ValueCol.DefaultCellStyle = dataGridViewCellStyle1;
      this.ValueCol.FillWeight = 10F;
      this.ValueCol.HeaderText = "Value";
      this.ValueCol.Name = "ValueCol";
      this.ValueCol.ReadOnly = true;
      // 
      // Unused
      // 
      this.Unused.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.Unused.DefaultCellStyle = dataGridViewCellStyle2;
      this.Unused.FillWeight = 70F;
      this.Unused.HeaderText = "";
      this.Unused.Name = "Unused";
      this.Unused.ReadOnly = true;
      // 
      // KMainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1121, 666);
      this.Controls.Add(this.mainPanel);
      this.Controls.Add(this.topMenu);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.topMenu;
      this.Name = "KMainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Booze Hound Books";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
      this.Load += new System.EventHandler(this.KMainFormLoad);
      this.topMenu.ResumeLayout(false);
      this.topMenu.PerformLayout();
      this.mainPanel.ResumeLayout(false);
      this.mainPanel.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.splitContainerHoriz.Panel1.ResumeLayout(false);
      this.splitContainerHoriz.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).EndInit();
      this.splitContainerHoriz.ResumeLayout(false);
      this.splitContainerVert.Panel1.ResumeLayout(false);
      this.splitContainerVert.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).EndInit();
      this.splitContainerVert.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.summaryExpressionGrid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.transactionGrid)).EndInit();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }
		private System.Windows.Forms.DateTimePicker defaultDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView summaryExpressionGrid;
		private System.Windows.Forms.ToolStripMenuItem addSummaryExpressionItem;
		private System.Windows.Forms.ToolStripMenuItem summaryExpressionMenu;
		private System.Windows.Forms.ToolStripMenuItem editAccount;
		private System.Windows.Forms.CheckBox viewByDateFrom;
		private System.Windows.Forms.CheckBox viewByDateTo;
		private System.Windows.Forms.SplitContainer splitContainerVert;
		private System.Windows.Forms.SplitContainer splitContainerHoriz;
		private System.Windows.Forms.ToolStripMenuItem viewTransactionGridBGContra;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem viewTransactionGridBGAccount;
		private System.Windows.Forms.Button newAdjustment;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ToolStripMenuItem editPeriods;
		private System.Windows.Forms.ToolStripMenuItem periodMenu;
		private System.Windows.Forms.ToolStripMenuItem addAccount;
		private System.Windows.Forms.ToolStripMenuItem accountMenu;
		private System.Windows.Forms.ToolStripMenuItem newBook;
		private System.Windows.Forms.TableLayoutPanel mainPanel;
		private System.Windows.Forms.ToolStripMenuItem openBook;
		private System.Windows.Forms.ToolStripMenuItem fileMenu;
    private System.Windows.Forms.MenuStrip topMenu;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.DataGridView transactionGrid;
    private System.Windows.Forms.ToolStripMenuItem viewMenu;
		private System.Windows.Forms.CheckBox viewByPeriod;
    private System.Windows.Forms.TreeView accountTree;
    private System.Windows.Forms.ComboBox viewPeriod;
    private System.Windows.Forms.DateTimePicker viewTo;
    private System.Windows.Forms.DateTimePicker viewFrom;
    private System.Windows.Forms.Button deleteTransaction;
    private System.Windows.Forms.Label transactionCountLbl;
    private System.Windows.Forms.ToolStripMenuItem showHiddenAccountsToolStripMenuItem;
    private System.Windows.Forms.DataGridViewTextBoxColumn Id;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Budget;
    private System.Windows.Forms.DataGridViewTextBoxColumn Date;
    private System.Windows.Forms.DataGridViewImageColumn DayOfWeekIcon;
    private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
    private System.Windows.Forms.DataGridViewImageColumn AccountIcon;
    private System.Windows.Forms.DataGridViewTextBoxColumn Account;
    private System.Windows.Forms.DataGridViewImageColumn ContraIcon;
    private System.Windows.Forms.DataGridViewTextBoxColumn Contra;
    private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    private System.Windows.Forms.CheckBox viewBudget;
    private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem generateRecurringTransactions;
    private System.Windows.Forms.ComboBox currentVsAvgPriorBalance;
    private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SummaryNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unused;
    }
}
