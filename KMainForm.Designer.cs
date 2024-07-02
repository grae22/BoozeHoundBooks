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
            var dataGridViewCellStyle1 = new DataGridViewCellStyle();
            var dataGridViewCellStyle2 = new DataGridViewCellStyle();
            var dataGridViewCellStyle3 = new DataGridViewCellStyle();
            var dataGridViewCellStyle4 = new DataGridViewCellStyle();
            var dataGridViewCellStyle5 = new DataGridViewCellStyle();
            var dataGridViewCellStyle6 = new DataGridViewCellStyle();
            var dataGridViewCellStyle7 = new DataGridViewCellStyle();
            var dataGridViewCellStyle8 = new DataGridViewCellStyle();
            var dataGridViewCellStyle9 = new DataGridViewCellStyle();
            var dataGridViewCellStyle10 = new DataGridViewCellStyle();
            var dataGridViewCellStyle11 = new DataGridViewCellStyle();
            var dataGridViewCellStyle12 = new DataGridViewCellStyle();
            var dataGridViewCellStyle13 = new DataGridViewCellStyle();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(KMainForm));
            topMenu = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            newBook = new ToolStripMenuItem();
            openBook = new ToolStripMenuItem();
            viewMenu = new ToolStripMenuItem();
            viewTransactionGridBGAccount = new ToolStripMenuItem();
            viewTransactionGridBGContra = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            showHiddenAccountsToolStripMenuItem = new ToolStripMenuItem();
            accountMenu = new ToolStripMenuItem();
            addAccount = new ToolStripMenuItem();
            editAccount = new ToolStripMenuItem();
            periodMenu = new ToolStripMenuItem();
            editPeriods = new ToolStripMenuItem();
            summaryExpressionMenu = new ToolStripMenuItem();
            addSummaryExpressionItem = new ToolStripMenuItem();
            transactionsToolStripMenuItem = new ToolStripMenuItem();
            generateRecurringTransactions = new ToolStripMenuItem();
            toggleBudgetStatus = new ToolStripMenuItem();
            mainPanel = new TableLayoutPanel();
            panel1 = new Panel();
            splitContainerHoriz = new SplitContainer();
            accountTree = new TreeView();
            splitContainerVert = new SplitContainer();
            panel3 = new Panel();
            splitContainer1 = new SplitContainer();
            summaryExpressionGrid = new DataGridView();
            SummaryNameCol = new DataGridViewTextBoxColumn();
            ValueCol = new DataGridViewTextBoxColumn();
            Unused = new DataGridViewTextBoxColumn();
            uiTags = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            transactionGrid = new DataGridView();
            panel2 = new Panel();
            label2 = new Label();
            currentVsAvgPriorBalance = new ComboBox();
            viewBudget = new CheckBox();
            label1 = new Label();
            defaultDate = new DateTimePicker();
            viewByDateTo = new CheckBox();
            viewByDateFrom = new CheckBox();
            viewByPeriod = new CheckBox();
            newAdjustment = new Button();
            deleteTransaction = new Button();
            viewPeriod = new ComboBox();
            viewTo = new DateTimePicker();
            viewFrom = new DateTimePicker();
            transactionCountLbl = new Label();
            Id = new DataGridViewTextBoxColumn();
            Budget = new DataGridViewCheckBoxColumn();
            Date = new DataGridViewTextBoxColumn();
            DayOfWeekIcon = new DataGridViewImageColumn();
            Amount = new DataGridViewTextBoxColumn();
            AccountIcon = new DataGridViewImageColumn();
            Account = new DataGridViewTextBoxColumn();
            ContraIcon = new DataGridViewImageColumn();
            Contra = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            Tags = new DataGridViewTextBoxColumn();
            topMenu.SuspendLayout();
            mainPanel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerHoriz).BeginInit();
            splitContainerHoriz.Panel1.SuspendLayout();
            splitContainerHoriz.Panel2.SuspendLayout();
            splitContainerHoriz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerVert).BeginInit();
            splitContainerVert.Panel1.SuspendLayout();
            splitContainerVert.Panel2.SuspendLayout();
            splitContainerVert.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)summaryExpressionGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uiTags).BeginInit();
            ((System.ComponentModel.ISupportInitialize)transactionGrid).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // topMenu
            // 
            topMenu.ImageScalingSize = new Size(20, 20);
            topMenu.Items.AddRange(new ToolStripItem[] { fileMenu, viewMenu, accountMenu, periodMenu, summaryExpressionMenu, transactionsToolStripMenuItem });
            topMenu.Location = new Point(0, 0);
            topMenu.Name = "topMenu";
            topMenu.Padding = new Padding(5, 2, 0, 2);
            topMenu.Size = new Size(1308, 24);
            topMenu.TabIndex = 0;
            topMenu.Text = "topMenu";
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { newBook, openBook });
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(37, 20);
            fileMenu.Text = "&File";
            // 
            // newBook
            // 
            newBook.Name = "newBook";
            newBook.Size = new Size(133, 22);
            newBook.Text = "&New Book";
            newBook.Click += NewBookClick;
            // 
            // openBook
            // 
            openBook.Name = "openBook";
            openBook.Size = new Size(133, 22);
            openBook.Text = "&Open Book";
            openBook.Click += OpenBookClick;
            // 
            // viewMenu
            // 
            viewMenu.DropDownItems.AddRange(new ToolStripItem[] { viewTransactionGridBGAccount, viewTransactionGridBGContra, toolStripSeparator2, showHiddenAccountsToolStripMenuItem });
            viewMenu.Name = "viewMenu";
            viewMenu.Size = new Size(44, 20);
            viewMenu.Text = "&View";
            // 
            // viewTransactionGridBGAccount
            // 
            viewTransactionGridBGAccount.CheckOnClick = true;
            viewTransactionGridBGAccount.Name = "viewTransactionGridBGAccount";
            viewTransactionGridBGAccount.Size = new Size(356, 22);
            viewTransactionGridBGAccount.Text = "Use Account colours for Transaction Grid background";
            viewTransactionGridBGAccount.CheckedChanged += ViewTransactionGridBGCheckedChanged;
            // 
            // viewTransactionGridBGContra
            // 
            viewTransactionGridBGContra.CheckOnClick = true;
            viewTransactionGridBGContra.Name = "viewTransactionGridBGContra";
            viewTransactionGridBGContra.Size = new Size(356, 22);
            viewTransactionGridBGContra.Text = "Use Contra colours for Transaction Grid background";
            viewTransactionGridBGContra.CheckedChanged += ViewTransactionGridBGCheckedChanged;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(353, 6);
            // 
            // showHiddenAccountsToolStripMenuItem
            // 
            showHiddenAccountsToolStripMenuItem.CheckOnClick = true;
            showHiddenAccountsToolStripMenuItem.Name = "showHiddenAccountsToolStripMenuItem";
            showHiddenAccountsToolStripMenuItem.Size = new Size(356, 22);
            showHiddenAccountsToolStripMenuItem.Text = "Show Hidden Accounts";
            showHiddenAccountsToolStripMenuItem.CheckedChanged += showHiddenAccountsToolStripMenuItem_CheckedChanged;
            // 
            // accountMenu
            // 
            accountMenu.DropDownItems.AddRange(new ToolStripItem[] { addAccount, editAccount });
            accountMenu.Name = "accountMenu";
            accountMenu.Size = new Size(69, 20);
            accountMenu.Text = "&Accounts";
            // 
            // addAccount
            // 
            addAccount.Name = "addAccount";
            addAccount.Size = new Size(144, 22);
            addAccount.Text = "&Add Account";
            addAccount.Click += AddAccountClick;
            // 
            // editAccount
            // 
            editAccount.Name = "editAccount";
            editAccount.Size = new Size(144, 22);
            editAccount.Text = "&Edit Account";
            editAccount.Click += EditAccountClick;
            // 
            // periodMenu
            // 
            periodMenu.DropDownItems.AddRange(new ToolStripItem[] { editPeriods });
            periodMenu.Name = "periodMenu";
            periodMenu.Size = new Size(58, 20);
            periodMenu.Text = "&Periods";
            // 
            // editPeriods
            // 
            editPeriods.Name = "editPeriods";
            editPeriods.Size = new Size(136, 22);
            editPeriods.Text = "&Edit Periods";
            editPeriods.Click += EditPeriodsClick;
            // 
            // summaryExpressionMenu
            // 
            summaryExpressionMenu.DropDownItems.AddRange(new ToolStripItem[] { addSummaryExpressionItem });
            summaryExpressionMenu.Name = "summaryExpressionMenu";
            summaryExpressionMenu.Size = new Size(103, 20);
            summaryExpressionMenu.Text = "&Summary Fields";
            // 
            // addSummaryExpressionItem
            // 
            addSummaryExpressionItem.Name = "addSummaryExpressionItem";
            addSummaryExpressionItem.Size = new Size(124, 22);
            addSummaryExpressionItem.Text = "&Add Field";
            addSummaryExpressionItem.Click += AddSummaryExpressionItemClick;
            // 
            // transactionsToolStripMenuItem
            // 
            transactionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generateRecurringTransactions, toggleBudgetStatus });
            transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            transactionsToolStripMenuItem.Size = new Size(84, 20);
            transactionsToolStripMenuItem.Text = "&Transactions";
            // 
            // generateRecurringTransactions
            // 
            generateRecurringTransactions.Name = "generateRecurringTransactions";
            generateRecurringTransactions.Size = new Size(185, 22);
            generateRecurringTransactions.Text = "&Generate Recurring";
            generateRecurringTransactions.Click += generateRecurringTransactions_Click;
            // 
            // toggleBudgetStatus
            // 
            toggleBudgetStatus.Name = "toggleBudgetStatus";
            toggleBudgetStatus.Size = new Size(185, 22);
            toggleBudgetStatus.Text = "&Toggle Budget Status";
            toggleBudgetStatus.Click += toggleBudgetStatus_Click;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = SystemColors.Control;
            mainPanel.ColumnCount = 1;
            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.95723F));
            mainPanel.Controls.Add(panel1, 0, 1);
            mainPanel.Controls.Add(panel2, 0, 0);
            mainPanel.Controls.Add(transactionCountLbl, 0, 2);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 24);
            mainPanel.Margin = new Padding(4, 3, 4, 3);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(6, 0, 6, 12);
            mainPanel.RowCount = 3;
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            mainPanel.Size = new Size(1308, 744);
            mainPanel.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(splitContainerHoriz);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(10, 39);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1288, 667);
            panel1.TabIndex = 5;
            // 
            // splitContainerHoriz
            // 
            splitContainerHoriz.Dock = DockStyle.Fill;
            splitContainerHoriz.Location = new Point(0, 0);
            splitContainerHoriz.Margin = new Padding(4, 3, 4, 3);
            splitContainerHoriz.Name = "splitContainerHoriz";
            // 
            // splitContainerHoriz.Panel1
            // 
            splitContainerHoriz.Panel1.Controls.Add(accountTree);
            // 
            // splitContainerHoriz.Panel2
            // 
            splitContainerHoriz.Panel2.Controls.Add(splitContainerVert);
            splitContainerHoriz.Size = new Size(1288, 667);
            splitContainerHoriz.SplitterDistance = 338;
            splitContainerHoriz.SplitterWidth = 5;
            splitContainerHoriz.TabIndex = 0;
            // 
            // accountTree
            // 
            accountTree.Dock = DockStyle.Fill;
            accountTree.HideSelection = false;
            accountTree.Indent = 27;
            accountTree.ItemHeight = 20;
            accountTree.Location = new Point(0, 0);
            accountTree.Margin = new Padding(4, 3, 4, 3);
            accountTree.Name = "accountTree";
            accountTree.Size = new Size(338, 667);
            accountTree.TabIndex = 2;
            accountTree.AfterCollapse += accountTree_AfterCollapse;
            accountTree.AfterExpand += accountTree_AfterExpand;
            accountTree.AfterSelect += accountTree_AfterSelect;
            accountTree.DoubleClick += AccountTreeDoubleClick;
            // 
            // splitContainerVert
            // 
            splitContainerVert.Dock = DockStyle.Fill;
            splitContainerVert.Location = new Point(0, 0);
            splitContainerVert.Margin = new Padding(4, 3, 4, 3);
            splitContainerVert.Name = "splitContainerVert";
            splitContainerVert.Orientation = Orientation.Horizontal;
            // 
            // splitContainerVert.Panel1
            // 
            splitContainerVert.Panel1.Controls.Add(panel3);
            // 
            // splitContainerVert.Panel2
            // 
            splitContainerVert.Panel2.Controls.Add(transactionGrid);
            splitContainerVert.Size = new Size(945, 667);
            splitContainerVert.SplitterDistance = 167;
            splitContainerVert.SplitterWidth = 5;
            splitContainerVert.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(splitContainer1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(945, 167);
            panel3.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(summaryExpressionGrid);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(uiTags);
            splitContainer1.Size = new Size(943, 165);
            splitContainer1.SplitterDistance = 457;
            splitContainer1.TabIndex = 1;
            // 
            // summaryExpressionGrid
            // 
            summaryExpressionGrid.AllowUserToAddRows = false;
            summaryExpressionGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(230, 230, 255);
            summaryExpressionGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            summaryExpressionGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            summaryExpressionGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            summaryExpressionGrid.Columns.AddRange(new DataGridViewColumn[] { SummaryNameCol, ValueCol, Unused });
            summaryExpressionGrid.Dock = DockStyle.Fill;
            summaryExpressionGrid.Location = new Point(0, 0);
            summaryExpressionGrid.Margin = new Padding(4, 3, 4, 3);
            summaryExpressionGrid.Name = "summaryExpressionGrid";
            summaryExpressionGrid.ReadOnly = true;
            summaryExpressionGrid.RowHeadersWidth = 51;
            summaryExpressionGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            summaryExpressionGrid.Size = new Size(457, 165);
            summaryExpressionGrid.TabIndex = 0;
            summaryExpressionGrid.Click += summaryExpressionGrid_Click;
            summaryExpressionGrid.DoubleClick += SummaryExpressionGridDoubleClick;
            // 
            // SummaryNameCol
            // 
            SummaryNameCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Padding = new Padding(5, 0, 0, 0);
            SummaryNameCol.DefaultCellStyle = dataGridViewCellStyle2;
            SummaryNameCol.FillWeight = 40F;
            SummaryNameCol.HeaderText = "Summary";
            SummaryNameCol.MinimumWidth = 6;
            SummaryNameCol.Name = "SummaryNameCol";
            SummaryNameCol.ReadOnly = true;
            // 
            // ValueCol
            // 
            ValueCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Padding = new Padding(0, 0, 5, 0);
            ValueCol.DefaultCellStyle = dataGridViewCellStyle3;
            ValueCol.FillWeight = 20F;
            ValueCol.HeaderText = "Value";
            ValueCol.MinimumWidth = 6;
            ValueCol.Name = "ValueCol";
            ValueCol.ReadOnly = true;
            // 
            // Unused
            // 
            Unused.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(224, 224, 224);
            Unused.DefaultCellStyle = dataGridViewCellStyle4;
            Unused.FillWeight = 40F;
            Unused.HeaderText = "";
            Unused.MinimumWidth = 6;
            Unused.Name = "Unused";
            Unused.ReadOnly = true;
            // 
            // uiTags
            // 
            uiTags.AllowUserToAddRows = false;
            uiTags.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(230, 230, 255);
            uiTags.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            uiTags.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            uiTags.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            uiTags.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            uiTags.Dock = DockStyle.Fill;
            uiTags.Location = new Point(0, 0);
            uiTags.Margin = new Padding(4, 3, 4, 3);
            uiTags.Name = "uiTags";
            uiTags.ReadOnly = true;
            uiTags.RowHeadersWidth = 51;
            uiTags.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            uiTags.Size = new Size(482, 165);
            uiTags.TabIndex = 1;
            uiTags.Click += uiTags_Click;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Padding = new Padding(5, 0, 0, 0);
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewTextBoxColumn1.FillWeight = 40F;
            dataGridViewTextBoxColumn1.HeaderText = "Summary";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Padding = new Padding(0, 0, 5, 0);
            dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewTextBoxColumn2.FillWeight = 20F;
            dataGridViewTextBoxColumn2.HeaderText = "Value";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewTextBoxColumn3.FillWeight = 40F;
            dataGridViewTextBoxColumn3.HeaderText = "";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // transactionGrid
            // 
            transactionGrid.AllowUserToAddRows = false;
            transactionGrid.AllowUserToDeleteRows = false;
            transactionGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            transactionGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            transactionGrid.Columns.AddRange(new DataGridViewColumn[] { Id, Budget, Date, DayOfWeekIcon, Amount, AccountIcon, Account, ContraIcon, Contra, Description, Tags });
            transactionGrid.Dock = DockStyle.Fill;
            transactionGrid.Location = new Point(0, 0);
            transactionGrid.Margin = new Padding(4, 3, 4, 3);
            transactionGrid.Name = "transactionGrid";
            transactionGrid.RowHeadersWidth = 51;
            transactionGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            transactionGrid.Size = new Size(945, 495);
            transactionGrid.TabIndex = 8;
            transactionGrid.CellMouseUp += transactionGrid_CellMouseUp;
            transactionGrid.CellValueChanged += transactionGrid_CellValueChanged;
            transactionGrid.DoubleClick += transactionGrid_DoubleClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(currentVsAvgPriorBalance);
            panel2.Controls.Add(viewBudget);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(defaultDate);
            panel2.Controls.Add(viewByDateTo);
            panel2.Controls.Add(viewByDateFrom);
            panel2.Controls.Add(viewByPeriod);
            panel2.Controls.Add(newAdjustment);
            panel2.Controls.Add(deleteTransaction);
            panel2.Controls.Add(viewPeriod);
            panel2.Controls.Add(viewTo);
            panel2.Controls.Add(viewFrom);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(10, 3);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1288, 30);
            panel2.TabIndex = 6;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(736, 8);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 31;
            label2.Text = "Vs Prior Period(s)";
            // 
            // currentVsAvgPriorBalance
            // 
            currentVsAvgPriorBalance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            currentVsAvgPriorBalance.DropDownStyle = ComboBoxStyle.DropDownList;
            currentVsAvgPriorBalance.FormattingEnabled = true;
            currentVsAvgPriorBalance.Items.AddRange(new object[] { "-", "1", "3", "6", "12", "18", "24", "60", "120" });
            currentVsAvgPriorBalance.Location = new Point(845, 3);
            currentVsAvgPriorBalance.Margin = new Padding(4, 3, 4, 3);
            currentVsAvgPriorBalance.Name = "currentVsAvgPriorBalance";
            currentVsAvgPriorBalance.Size = new Size(58, 23);
            currentVsAvgPriorBalance.TabIndex = 30;
            currentVsAvgPriorBalance.SelectedIndexChanged += currentVsAvgPriorBalance_SelectedIndexChanged;
            // 
            // viewBudget
            // 
            viewBudget.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            viewBudget.Appearance = Appearance.Button;
            viewBudget.Location = new Point(910, 2);
            viewBudget.Margin = new Padding(4, 3, 4, 3);
            viewBudget.Name = "viewBudget";
            viewBudget.Size = new Size(68, 27);
            viewBudget.TabIndex = 28;
            viewBudget.Text = "Budget";
            viewBudget.TextAlign = ContentAlignment.MiddleCenter;
            viewBudget.UseVisualStyleBackColor = true;
            viewBudget.CheckedChanged += viewBudget_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ImageAlign = ContentAlignment.MiddleRight;
            label1.Location = new Point(541, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 27;
            label1.Text = "Default date";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // defaultDate
            // 
            defaultDate.Format = DateTimePickerFormat.Short;
            defaultDate.Location = new Point(628, 6);
            defaultDate.Margin = new Padding(4, 3, 4, 3);
            defaultDate.Name = "defaultDate";
            defaultDate.Size = new Size(98, 23);
            defaultDate.TabIndex = 26;
            // 
            // viewByDateTo
            // 
            viewByDateTo.Location = new Point(364, 5);
            viewByDateTo.Margin = new Padding(4, 3, 4, 3);
            viewByDateTo.Name = "viewByDateTo";
            viewByDateTo.RightToLeft = RightToLeft.Yes;
            viewByDateTo.Size = new Size(49, 28);
            viewByDateTo.TabIndex = 25;
            viewByDateTo.Text = "To";
            viewByDateTo.UseVisualStyleBackColor = true;
            viewByDateTo.CheckedChanged += RefreshAccountTreeAndTransactionGrid;
            // 
            // viewByDateFrom
            // 
            viewByDateFrom.Location = new Point(182, 5);
            viewByDateFrom.Margin = new Padding(4, 3, 4, 3);
            viewByDateFrom.Name = "viewByDateFrom";
            viewByDateFrom.RightToLeft = RightToLeft.Yes;
            viewByDateFrom.Size = new Size(69, 28);
            viewByDateFrom.TabIndex = 24;
            viewByDateFrom.Text = "From";
            viewByDateFrom.UseVisualStyleBackColor = true;
            viewByDateFrom.CheckedChanged += RefreshAccountTreeAndTransactionGrid;
            // 
            // viewByPeriod
            // 
            viewByPeriod.Location = new Point(0, 5);
            viewByPeriod.Margin = new Padding(4, 3, 4, 3);
            viewByPeriod.Name = "viewByPeriod";
            viewByPeriod.RightToLeft = RightToLeft.Yes;
            viewByPeriod.Size = new Size(69, 28);
            viewByPeriod.TabIndex = 23;
            viewByPeriod.Text = "Period";
            viewByPeriod.UseVisualStyleBackColor = true;
            viewByPeriod.CheckedChanged += ViewByPeriodCheckedChanged;
            // 
            // newAdjustment
            // 
            newAdjustment.Anchor = AnchorStyles.Right;
            newAdjustment.Location = new Point(999, 3);
            newAdjustment.Margin = new Padding(4, 3, 4, 3);
            newAdjustment.Name = "newAdjustment";
            newAdjustment.Size = new Size(141, 27);
            newAdjustment.TabIndex = 22;
            newAdjustment.Text = "Adjustment";
            newAdjustment.UseVisualStyleBackColor = true;
            newAdjustment.Click += NewAdjustmentClick;
            // 
            // deleteTransaction
            // 
            deleteTransaction.Anchor = AnchorStyles.Right;
            deleteTransaction.Location = new Point(1147, 3);
            deleteTransaction.Margin = new Padding(4, 3, 4, 3);
            deleteTransaction.Name = "deleteTransaction";
            deleteTransaction.Size = new Size(141, 27);
            deleteTransaction.TabIndex = 20;
            deleteTransaction.Text = "Delete Transaction";
            deleteTransaction.UseVisualStyleBackColor = true;
            deleteTransaction.Click += deleteTransaction_Click;
            // 
            // viewPeriod
            // 
            viewPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            viewPeriod.FormattingEnabled = true;
            viewPeriod.Location = new Point(76, 5);
            viewPeriod.Margin = new Padding(4, 3, 4, 3);
            viewPeriod.Name = "viewPeriod";
            viewPeriod.Size = new Size(98, 23);
            viewPeriod.TabIndex = 18;
            viewPeriod.SelectedIndexChanged += ViewPeriodSelectedIndexChanged;
            // 
            // viewTo
            // 
            viewTo.Format = DateTimePickerFormat.Short;
            viewTo.Location = new Point(420, 6);
            viewTo.Margin = new Padding(4, 3, 4, 3);
            viewTo.Name = "viewTo";
            viewTo.Size = new Size(98, 23);
            viewTo.TabIndex = 16;
            viewTo.ValueChanged += RefreshAccountTreeAndTransactionGrid;
            // 
            // viewFrom
            // 
            viewFrom.Format = DateTimePickerFormat.Short;
            viewFrom.Location = new Point(258, 6);
            viewFrom.Margin = new Padding(4, 3, 4, 3);
            viewFrom.Name = "viewFrom";
            viewFrom.Size = new Size(98, 23);
            viewFrom.TabIndex = 15;
            viewFrom.ValueChanged += RefreshAccountTreeAndTransactionGrid;
            // 
            // transactionCountLbl
            // 
            transactionCountLbl.AutoSize = true;
            transactionCountLbl.Location = new Point(10, 709);
            transactionCountLbl.Margin = new Padding(4, 0, 4, 0);
            transactionCountLbl.Name = "transactionCountLbl";
            transactionCountLbl.Size = new Size(84, 15);
            transactionCountLbl.TabIndex = 7;
            transactionCountLbl.Text = "Transactions: x";
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            // 
            // Budget
            // 
            Budget.FillWeight = 5F;
            Budget.HeaderText = "Budget";
            Budget.MinimumWidth = 6;
            Budget.Name = "Budget";
            // 
            // Date
            // 
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Padding = new Padding(2, 0, 2, 0);
            Date.DefaultCellStyle = dataGridViewCellStyle9;
            Date.FillWeight = 7.5F;
            Date.HeaderText = "Date";
            Date.MinimumWidth = 6;
            Date.Name = "Date";
            Date.ReadOnly = true;
            // 
            // DayOfWeekIcon
            // 
            DayOfWeekIcon.FillWeight = 2.5F;
            DayOfWeekIcon.HeaderText = "";
            DayOfWeekIcon.MinimumWidth = 6;
            DayOfWeekIcon.Name = "DayOfWeekIcon";
            DayOfWeekIcon.ReadOnly = true;
            DayOfWeekIcon.Resizable = DataGridViewTriState.True;
            DayOfWeekIcon.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // Amount
            // 
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.NullValue = null;
            dataGridViewCellStyle10.Padding = new Padding(2, 0, 2, 0);
            Amount.DefaultCellStyle = dataGridViewCellStyle10;
            Amount.FillWeight = 8F;
            Amount.HeaderText = "Amount";
            Amount.MinimumWidth = 6;
            Amount.Name = "Amount";
            Amount.ReadOnly = true;
            // 
            // AccountIcon
            // 
            AccountIcon.FillWeight = 2.5F;
            AccountIcon.HeaderText = "";
            AccountIcon.MinimumWidth = 6;
            AccountIcon.Name = "AccountIcon";
            AccountIcon.ReadOnly = true;
            // 
            // Account
            // 
            dataGridViewCellStyle11.Font = new Font("Microsoft Sans Serif", 6.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle11.Padding = new Padding(2, 0, 2, 0);
            Account.DefaultCellStyle = dataGridViewCellStyle11;
            Account.FillWeight = 20F;
            Account.HeaderText = "Account";
            Account.MinimumWidth = 6;
            Account.Name = "Account";
            Account.ReadOnly = true;
            // 
            // ContraIcon
            // 
            ContraIcon.FillWeight = 2.5F;
            ContraIcon.HeaderText = "";
            ContraIcon.MinimumWidth = 6;
            ContraIcon.Name = "ContraIcon";
            ContraIcon.ReadOnly = true;
            // 
            // Contra
            // 
            dataGridViewCellStyle12.Font = new Font("Microsoft Sans Serif", 6.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle12.Padding = new Padding(2, 0, 2, 0);
            Contra.DefaultCellStyle = dataGridViewCellStyle12;
            Contra.FillWeight = 20F;
            Contra.HeaderText = "Contra";
            Contra.MinimumWidth = 6;
            Contra.Name = "Contra";
            Contra.ReadOnly = true;
            // 
            // Description
            // 
            dataGridViewCellStyle13.Padding = new Padding(2, 0, 0, 0);
            Description.DefaultCellStyle = dataGridViewCellStyle13;
            Description.FillWeight = 20F;
            Description.HeaderText = "Description";
            Description.MinimumWidth = 6;
            Description.Name = "Description";
            Description.ReadOnly = true;
            // 
            // Tags
            // 
            Tags.FillWeight = 12F;
            Tags.HeaderText = "Tags";
            Tags.Name = "Tags";
            Tags.ReadOnly = true;
            // 
            // KMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1308, 768);
            Controls.Add(mainPanel);
            Controls.Add(topMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = topMenu;
            Margin = new Padding(4, 3, 4, 3);
            Name = "KMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Booze Hound Books";
            FormClosed += MainForm_FormClosed;
            Load += KMainFormLoad;
            topMenu.ResumeLayout(false);
            topMenu.PerformLayout();
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            panel1.ResumeLayout(false);
            splitContainerHoriz.Panel1.ResumeLayout(false);
            splitContainerHoriz.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerHoriz).EndInit();
            splitContainerHoriz.ResumeLayout(false);
            splitContainerVert.Panel1.ResumeLayout(false);
            splitContainerVert.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerVert).EndInit();
            splitContainerVert.ResumeLayout(false);
            panel3.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)summaryExpressionGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)uiTags).EndInit();
            ((System.ComponentModel.ISupportInitialize)transactionGrid).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
    private System.Windows.Forms.CheckBox viewBudget;
    private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem generateRecurringTransactions;
    private System.Windows.Forms.ComboBox currentVsAvgPriorBalance;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ToolStripMenuItem toggleBudgetStatus;
        private SplitContainer splitContainer1;
        private DataGridView uiTags;
        private DataGridViewTextBoxColumn SummaryNameCol;
        private DataGridViewTextBoxColumn ValueCol;
        private DataGridViewTextBoxColumn Unused;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewCheckBoxColumn Budget;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewImageColumn DayOfWeekIcon;
        private DataGridViewTextBoxColumn Amount;
        private DataGridViewImageColumn AccountIcon;
        private DataGridViewTextBoxColumn Account;
        private DataGridViewImageColumn ContraIcon;
        private DataGridViewTextBoxColumn Contra;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Tags;
    }
}
