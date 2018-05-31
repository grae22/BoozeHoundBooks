using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace BoozeHoundBooks
{
  public partial class KMainForm
  {
    // constants ----------------------------------------------------

    // settings
    private const String c_setting_accountTreeWidth = "AccountTreeWidth";

    private const String c_setting_transactionGridHeight = "TransactionGridHeight";
    private const String c_setting_viewByPeriod = "ViewByPeriod";
    private const String c_setting_viewByDateFrom = "ViewByDateFrom";
    private const String c_setting_viewByDateTo = "ViewByDateTo";
    private const String c_setting_windowX = "WindowX";
    private const String c_setting_windowY = "WindowY";
    private const String c_setting_windowW = "WindowW";
    private const String c_setting_windowH = "WindowH";

    // colours
    private Color c_col_budget = Color.Blue;

    private Color c_col_negativeBalance = Color.Red;

    // class vars ---------------------------------------------------

    private KBook m_activeBook = null;
    private bool m_allowAccountTreeAndTransactionGridRefresh = false;

    //---------------------------------------------------------------

    public KMainForm(String bookPath)
    {
      try
      {
        // init components
        InitializeComponent();

        this.Text = this.Text + " (build: " + KMain.c_build + ")";

        // view by date pickers
        DateTime now = DateTime.Now;

        viewFrom.Value = (now.AddDays((now.Day - 1) * -1));
        viewTo.Value = (now.AddDays(DateTime.DaysInMonth(now.Year, now.Month) - now.Day));

        // parsed a book path to open? open the book
        if (bookPath.Equals("") == false)
        {
          OpenBook(bookPath);
        }
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    void KMainFormLoad(object sender, EventArgs e)
    {
      try
      {
        Location = new Point
        {
          X = (int) KMain.m_appSetting.GetSetting(c_setting_windowX, 0),
          Y = (int) KMain.m_appSetting.GetSetting(c_setting_windowY, 0)
        };

        Width = (int) KMain.m_appSetting.GetSetting(c_setting_windowW, Width);
        Height = (int) KMain.m_appSetting.GetSetting(c_setting_windowH, Height);

        WindowState = FormWindowState.Maximized;

        splitContainerHoriz.SplitterDistance =
          (int) KMain.m_appSetting.GetSetting(c_setting_accountTreeWidth,
            splitContainerHoriz.SplitterDistance);

        splitContainerVert.SplitterDistance =
          (int) KMain.m_appSetting.GetSetting(c_setting_transactionGridHeight,
            splitContainerVert.SplitterDistance);

        viewByPeriod.Checked =
          (bool) KMain.m_appSetting.GetSetting(c_setting_viewByPeriod, false);

        viewByDateFrom.Checked =
          (bool) KMain.m_appSetting.GetSetting(c_setting_viewByDateFrom, false);

        viewByDateTo.Checked =
          (bool) KMain.m_appSetting.GetSetting(c_setting_viewByDateTo, false);

        defaultDate.Value = DateTime.Now;

        m_allowAccountTreeAndTransactionGridRefresh = true;
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      try
      {
        // save the active book
        if (m_activeBook != null)
        {
          m_activeBook.Save();
        }

        // save settings
        KMain.m_appSetting.SetSetting(c_setting_windowX, Location.X);
        KMain.m_appSetting.SetSetting(c_setting_windowY, Location.Y);
        KMain.m_appSetting.SetSetting(c_setting_windowW, Width);
        KMain.m_appSetting.SetSetting(c_setting_windowH, Height);
        KMain.m_appSetting.SetSetting(c_setting_accountTreeWidth, splitContainerHoriz.SplitterDistance);
        KMain.m_appSetting.SetSetting(c_setting_transactionGridHeight, splitContainerVert.SplitterDistance);
        KMain.m_appSetting.SetSetting(c_setting_viewByPeriod, viewByPeriod.Checked);
        KMain.m_appSetting.SetSetting(c_setting_viewByDateFrom, viewByDateFrom.Checked);
        KMain.m_appSetting.SetSetting(c_setting_viewByDateTo, viewByDateTo.Checked);

        // save
        KMain.m_appSetting.Save();
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    public static void ErrorMsg(String message, String header)
    {
      MessageBox.Show(message,
        header,
        MessageBoxButtons.OK,
        MessageBoxIcon.Error);
    }

    //---------------------------------------------------------------

    public static void InfoMsg(String message, String header)
    {
      MessageBox.Show(message,
        header,
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
    }

    //---------------------------------------------------------------

    public static void WarningMsg(String message, String header)
    {
      MessageBox.Show(message,
        header,
        MessageBoxButtons.OK,
        MessageBoxIcon.Warning);
    }

    //---------------------------------------------------------------

    public static DialogResult ConfirmMsg(String message, String header)
    {
      return MessageBox.Show(message,
        header,
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);
    }

    //---------------------------------------------------------------

    void NewBookClick(object sender, System.EventArgs e)
    {
      try
      {
        // do save file dialog
        SaveFileDialog dlg = new SaveFileDialog();

        dlg.DefaultExt = "bhb";
        dlg.AddExtension = true;
        dlg.CheckPathExists = true;
        dlg.Filter = "Book | *.bhb";
        dlg.OverwritePrompt = true;
        dlg.CheckPathExists = true;

        dlg.ShowDialog();

        // user cancelled?
        if (dlg.FileName.Equals(""))
        {
          return;
        }

        // get file name & path
        String name = KCommon.GetFilenameFromPath(dlg.FileName);
        String path = dlg.FileName;

        // delete file if it exists
        if (File.Exists(path))
        {
          File.Delete(path);
        }

        // setup new book
        m_activeBook = new KBook(path, true);

        m_activeBook.Save();

        OpenBook(path);
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    void OpenBookClick(object sender, System.EventArgs e)
    {
      try
      {
        // do save file dialog
        OpenFileDialog dlg = new OpenFileDialog();

        dlg.DefaultExt = "bhb";
        dlg.AddExtension = true;
        dlg.CheckPathExists = true;
        dlg.Filter = "Book | *.bhb";
        dlg.CheckPathExists = true;

        dlg.ShowDialog();

        // user cancelled?
        if (dlg.FileName.Equals(""))
        {
          return;
        }

        // get file path
        String path = dlg.FileName;

        // open the book
        OpenBook(path);
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    private void OpenBook(String path)
    {
      try
      {
        // get name
        String name = KCommon.GetFilenameFromPath(path);

        // setup new book
        m_activeBook = new KBook(path, false);

        // update form
        PopulateAccountTree(false);
        PopulateViewPeriodBox(true);
        PopulateSummaryExpressionGrid();

        // apply settings
        String value;

        // set transaction grid bg
        viewTransactionGridBGAccount.Checked = false;
        viewTransactionGridBGContra.Checked = false;

        value = m_activeBook.GetSetting(KBook.c_setting_setTransactionGridBg);

        if (value != null)
        {
          if (bool.Parse(value))
          {
            // use account colour?
            value = m_activeBook.GetSetting(KBook.c_setting_setTransactionGridBgWithAccount);

            if (value != null)
            {
              viewTransactionGridBGAccount.Checked = bool.Parse(value);
              viewTransactionGridBGContra.Checked = !bool.Parse(value);
            }
          }
        }
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    private bool CheckForActiveBook(bool doMessage)
    {
      try
      {
        // no active book?
        if (m_activeBook == null)
        {
          if (doMessage)
          {
            MessageBox.Show("There is no active Book - create or open one first.",
              "No Active Book",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information);
          }

          return false;
        }

        // there is an active book
        return true;
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);

        return false;
      }
    }

    //---------------------------------------------------------------

    void AddAccountClick(object sender, System.EventArgs e)
    {
      try
      {
        // active book?
        if (CheckForActiveBook(true) == false)
        {
          return;
        }

        // do account settings dlg
        KAccountSetupForm dlg = new KAccountSetupForm(m_activeBook);

        dlg.ShowDialog(this);

        if (dlg.IsDisposed == false) // not disposed? user clicked ok (not cancel)
        {
          m_activeBook.CreateAccount(dlg.GetName(),
            dlg.GetDescription(),
            dlg.GetMasterAccount(),
            dlg.GetColour(),
            dlg.GetHideInTree());

          m_activeBook.Save();
        }

        // udate form
        PopulateAccountTree(true);

        BringToFront();
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    void EditAccountClick(object sender, EventArgs e)
    {
      try
      {
        // active book?
        if (CheckForActiveBook(true) == false)
        {
          return;
        }

        // get selected account
        KAccount acc = m_activeBook.GetAccount(accountTree.SelectedNode.Name);

        if (acc == null)
        {
          InfoMsg("Select an account to edit first.", "Edit Account");
          return;
        }

        // do account settings dlg
        KAccountSetupForm dlg = new KAccountSetupForm(m_activeBook, acc);

        dlg.ShowDialog(this);

        if (dlg.IsDisposed == false) // not disposed? user clicked ok (not cancel)
        {
          if (acc.IsMasterAccount() == false)
          {
            acc.GetParent().RemoveChild(acc);
            acc.SetParent(dlg.GetMasterAccount());
            acc.GetParent().AddChild(acc);
          }

          acc.SetAccountName(dlg.GetName());
          acc.SetDescription(dlg.GetDescription());
          acc.SetColour(dlg.GetColour());
          acc.SetupIcon(m_activeBook.GetAccountTreeIconSize(), true);
          acc.HideInTree = dlg.GetHideInTree();

          m_activeBook.Save();
        }

        // udate form
        PopulateAccountTree(true);

        BringToFront();
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    void EditPeriodsClick(object sender, System.EventArgs e)
    {
      try
      {
        // active book?
        if (CheckForActiveBook(true) == false)
        {
          return;
        }

        // do period setup dialog
        KPeriodSetupForm dlg = new KPeriodSetupForm();

        foreach (KPeriod p in m_activeBook.GetPeriodList())
        {
          dlg.AddPeriod(p);
        }

        dlg.ShowDialog(this);

        // TODO : check for transaction that don't fall in a period.

        m_activeBook.SetPeriodList(dlg.GetPeriodList());

        m_activeBook.Save();

        // update form
        PopulateViewPeriodBox(true);

        BringToFront();
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    void PopulateAccountTree(bool rememberSelected)
    {
      try
      {
        // active book?
        if (CheckForActiveBook(false) == false)
        {
          return;
        }

        accountTree.ImageList = KAccount.m_iconList;
        accountTree.ImageList.ColorDepth = ColorDepth.Depth16Bit;
        accountTree.ImageList.ImageSize = m_activeBook.GetAccountTreeIconSize();

        // remember selected?
        String selected = null;

        if (rememberSelected &&
            accountTree.SelectedNode != null)
        {
          selected = accountTree.SelectedNode.Name;
        }

        // hide tree
        accountTree.Hide();

        // clear tree
        accountTree.Nodes.Clear();

        // get viewing end date
        DateTime start = DateTime.MinValue;
        DateTime end = DateTime.MaxValue;
        DateTime previousPeriodStart = DateTime.MinValue;
        DateTime previousPeriodEnd = DateTime.MinValue;

        if (viewByPeriod.Checked)
        {
          foreach (KPeriod p in m_activeBook.GetPeriodList())
          {
            if (p.ToString().Equals(viewPeriod.Text, StringComparison.OrdinalIgnoreCase))
            {
              start = p.GetStart().Date;
              end = p.GetEnd().Date;

              break;
            }

            previousPeriodStart = p.GetStart();
            previousPeriodEnd = p.GetEnd();
          }
        }

        if (viewByDateFrom.Checked)
        {
          start = viewFrom.Value.Date;
        }

        if (viewByDateTo.Checked)
        {
          end = viewTo.Value.Date;
        }

        // add accounts
        ArrayList retryAccountName = new ArrayList();

        foreach (KAccount a in m_activeBook.GetAccountList())
        {
          byte accountType = a.GetAccountType();
          decimal bal;

          // don't include hidden accounts
          if (showHiddenAccountsToolStripMenuItem.Checked == false &&
              a.HideInTree)
          {
            continue;
          }

          // if current node is a master node just add it, otherwise find master node
          if (a.GetParent() == null)
          {
            TreeNode node;
            bool hasBudgetTrans = false;

            // don't add 'unknown' type
            if (accountType != KAccount.c_unknown)
            {
              // non-cumulative accounts
              if (accountType != KAccount.c_bank &&
                  accountType != KAccount.c_debt &&
                  accountType != KAccount.c_credit)
              {
                if (viewCurrentVsPriorPeriod.Checked)
                {
                  bal =
                    a.GetBalance(start, end, viewBudget.Checked) -
                    a.GetBalance(previousPeriodStart, previousPeriodEnd, viewBudget.Checked);
                }
                else
                {
                  bal = a.GetBalance(start, end, viewBudget.Checked);
                }

                node =
                  accountTree.Nodes.Add(a.GetQualifiedAccountName(),
                    $"{a.GetAccountName()} ( {bal:0.00} )",
                    a.GetIconId(),
                    a.GetIconId());

                a.SetTreeNode(node);

                hasBudgetTrans = a.HasBudgetTransactions(start, end, true);
              }
              // view account balance
              else
              {
                if (viewCurrentVsPriorPeriod.Checked)
                {
                  bal =
                    a.GetBalance(end, viewBudget.Checked) -
                    a.GetBalance(previousPeriodEnd, viewBudget.Checked);
                }
                else
                {
                  bal = a.GetBalance(end, viewBudget.Checked);
                }

                node =
                  accountTree.Nodes.Add(a.GetQualifiedAccountName(),
                    $"{a.GetAccountName()} ( {bal:0.00} )",
                    a.GetIconId(),
                    a.GetIconId());

                a.SetTreeNode(node);

                hasBudgetTrans = a.HasBudgetTransactions(start, end, false);
              }

              // has budget transactions?
              if (viewBudget.Checked && hasBudgetTrans)
              {
                node.ForeColor = c_col_budget;
              }

              // 'negative' balance?
              if (!viewCurrentVsPriorPeriod.Checked)
              {
                if ((bal > 0.0m &&
                     (accountType == KAccount.c_income ||
                      accountType == KAccount.c_debt)) ||
                    (bal < 0.0m &&
                     (accountType == KAccount.c_bank ||
                      accountType == KAccount.c_expense ||
                      accountType == KAccount.c_credit)))
                {
                  node.BackColor = c_col_negativeBalance;
                }
              }
              else
              {
                if ((bal < 0.0m &&
                     (accountType == KAccount.c_bank)) ||
                    (bal > 0.0m &&
                     (accountType == KAccount.c_income ||
                      accountType == KAccount.c_expense ||
                      accountType == KAccount.c_credit ||
                      accountType == KAccount.c_debt)))
                {
                  node.BackColor = c_col_negativeBalance;
                }
              }
            }
          }
          // find master node & add current node to it
          else
          {
            TreeNode[] list = accountTree.Nodes.Find(a.GetParent().GetQualifiedAccountName(), true);

            if (list.Length == 1) // found it?
            {
              TreeNode node;
              bool hasBudgetTrans = false;

              // add current account to master account node
              // non-cumulative accounts
              if (accountType != KAccount.c_bank &&
                  accountType != KAccount.c_debt &&
                  accountType != KAccount.c_credit)
              {
                if (viewCurrentVsPriorPeriod.Checked)
                {
                  bal =
                    a.GetBalance(start, end, viewBudget.Checked) -
                    a.GetBalance(previousPeriodStart, previousPeriodEnd, viewBudget.Checked);
                }
                else
                {
                  bal = a.GetBalance(start, end, viewBudget.Checked);
                }

                node =
                  list[0].Nodes.Add(a.GetQualifiedAccountName(),
                    $"{a.GetAccountName()} ( {bal:0.00} )",
                    a.GetIconId(),
                    a.GetIconId());

                a.SetTreeNode(node);

                hasBudgetTrans = a.HasBudgetTransactions(start, end, true);
              }
              // view account balance
              else
              {
                if (viewCurrentVsPriorPeriod.Checked)
                {
                  bal =
                    a.GetBalance(end, viewBudget.Checked) -
                    a.GetBalance(previousPeriodEnd, viewBudget.Checked);
                }
                else
                {
                  bal = a.GetBalance(end, viewBudget.Checked);
                }

                node =
                  list[0].Nodes.Add(a.GetQualifiedAccountName(),
                    $"{a.GetAccountName()} ( {bal:0.00} )",
                    a.GetIconId(),
                    a.GetIconId());

                a.SetTreeNode(node);

                hasBudgetTrans = a.HasBudgetTransactions(start, end, false);
              }

              // has budget transactions?
              if (viewBudget.Checked && hasBudgetTrans)
              {
                node.ForeColor = c_col_budget;
              }

              // 'negative' balance?
              if (!viewCurrentVsPriorPeriod.Checked)
              {
                if ((bal > 0.0m &&
                     (accountType == KAccount.c_income ||
                      accountType == KAccount.c_debt)) ||
                    (bal < 0.0m &&
                     (accountType == KAccount.c_bank ||
                      accountType == KAccount.c_expense ||
                      accountType == KAccount.c_credit)))
                {
                  node.BackColor = c_col_negativeBalance;
                }
              }
              else
              {
                if ((bal < 0.0m &&
                     (accountType == KAccount.c_bank)) ||
                    (bal > 0.0m &&
                     (accountType == KAccount.c_income ||
                      accountType == KAccount.c_expense ||
                      accountType == KAccount.c_credit ||
                      accountType == KAccount.c_debt)))
                {
                  node.BackColor = c_col_negativeBalance;
                }
              }
            }
            else if (list.Length > 1) // duplicate accounts found?
            {
              // TODO : Error handling/message...
            }
            else // master account not found - prob just not added yet, add to list to retry
            {
              retryAccountName.Add(a.GetAccountName());
            }
          }
        }

        // debugging
        if (retryAccountName.Count > 0)
          MessageBox.Show("retryAccountName.Count > 0");

        // show tree
        accountTree.Show();

        // restore the selected item?
        if (rememberSelected &&
            selected != null)
        {
          TreeNode[] list = accountTree.Nodes.Find(selected, true);

          if (list != null &&
              list.Length > 0)
          {
            accountTree.SelectedNode = list[0];

            accountTree.SelectedNode.EnsureVisible();
          }
        }

        // expand/collapse nodes according to settings
        foreach (KAccount a in m_activeBook.GetAccountList())
        {
          a.ApplyTreeNodeState();
        }

        // refresh transaction count
        RefreshTransactionCount();
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    private void PopulateViewPeriodBox(bool selectCurrent)
    {
      try
      {
        // active book?
        if (CheckForActiveBook(false) == false)
        {
          return;
        }

        // loop through book's periods & add to box
        viewPeriod.Items.Clear();

        foreach (KPeriod p in m_activeBook.GetPeriodList())
        {
          viewPeriod.Items.Add(p);
        }

        if (viewPeriod.Items.Count > 0)
        {
          viewPeriod.SelectedIndex = 0;
        }

        // select the current period?
        if (selectCurrent)
        {
          foreach (KPeriod p in m_activeBook.GetPeriodList())
          {
            if (p.DateInPeriod(DateTime.Today))
            {
              viewPeriod.Text = p.ToString();

              break;
            }
          }
        }
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    private void accountTree_AfterSelect(object sender, TreeViewEventArgs e)
    {
      try
      {
        // active book?
        if (CheckForActiveBook(false) == false)
        {
          return;
        }

        // get account name
        String selectedAcc = accountTree.SelectedNode.Name;

        // clear box
        transactionGrid.Rows.Clear();

        // populate box
        PopulateAccountTransactionGrid(m_activeBook.GetAccount(selectedAcc));
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    private void PopulateAccountTransactionGrid(KAccount account)
    {
      try
      {
        // active book?
        if (CheckForActiveBook(false) == false)
        {
          return;
        }

        // loop through account's transactions
        foreach (KTransaction trans in account.GetTransactions())
        {
          // include budget transactions?
          if (viewBudget.Checked == false &&
              trans.IsBudget)
          {
            continue;
          }

          // transaction is in selected period?
          if (viewByPeriod.Checked &&
              trans.GetPeriod() != viewPeriod.SelectedItem)
          {
            continue;
          }

          // transaction is before selected 'from' date?
          if (viewByDateFrom.Checked &&
              trans.GetDate().Date < viewFrom.Value.Date)
          {
            continue;
          }

          // transaction is after selected 'to' date?
          if (viewByDateTo.Checked &&
              trans.GetDate().Date > viewTo.Value.Date)
          {
            continue;
          }

          // is budget trans? special description
          String extraDesc = "";

          if (trans.IsBudget)
          {
            extraDesc = "[BUDGET] ";
          }

          // add transaction row to grid
          Object[] row =
          {
            trans.GetId().ToString(),
            trans.IsBudget,
            trans.GetDate().ToString("yyyy/MM/dd"),
            KMain.m_resourceManager.m_dayOfWeek[(int) trans.GetDate().DayOfWeek].GetImage(m_activeBook.GetTransactionGridIconSize()),
            trans.GetSignedAmount().ToString("C"),
            trans.GetAccount().GetIcon(m_activeBook.GetTransactionGridIconSize()),
            trans.GetAccount().ToString(),
            trans.GetContraAccount().GetIcon(m_activeBook.GetTransactionGridIconSize()),
            trans.GetContraAccount().ToString(),
            extraDesc + trans.GetDescription()
          };

          int rowNum = transactionGrid.Rows.Add(row);

          transactionGrid.Rows[rowNum].Tag = trans;

          // is a budget transaction, change forecolour
          if (trans.IsBudget)
          {
            transactionGrid.Rows[rowNum].DefaultCellStyle.ForeColor = c_col_budget;
          }

          // set the row background colour with contra account colour?
          if (viewTransactionGridBGAccount.Checked)
          {
            transactionGrid.Rows[rowNum].DefaultCellStyle.BackColor = trans.GetAccount().GetColour();
          }
          else if (viewTransactionGridBGContra.Checked)
          {
            transactionGrid.Rows[rowNum].DefaultCellStyle.BackColor = trans.GetContraAccount().GetColour();
          }
        }

        // add transactions from children accounts
        foreach (KAccount acc in account.GetChildren(false))
        {
          PopulateAccountTransactionGrid(acc);
        }

        // sort
        transactionGrid.Sort(transactionGrid.Columns["Date"], ListSortDirection.Descending);

        // select nothing
        transactionGrid.ClearSelection();
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    private void PopulateAccountTransactionGrid()
    {
      try
      {
        // clear box
        transactionGrid.Rows.Clear();

        // populate transaction box if an account is selected
        if (accountTree.SelectedNode != null)
        {
          // get account name
          String selectedAcc = accountTree.SelectedNode.Name;

          // populate box
          PopulateAccountTransactionGrid(m_activeBook.GetAccount(selectedAcc));
        }
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    private void RefreshTransactionCount()
    {
      if (m_activeBook != null)
      {
        transactionCountLbl.Text = "Transactions: " + m_activeBook.GetTransactionCount();
      }
      else
      {
        transactionCountLbl.Text = "";
      }
    }

    //---------------------------------------------------------------

    private void RefreshAccountTreeAndTransactionGrid()
    {
      try
      {
        if (m_allowAccountTreeAndTransactionGridRefresh == false)
        {
          return;
        }

        RefreshAccountTreeAndTransactionGrid(null, null);
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    private void RefreshAccountTreeAndTransactionGrid(object sender, EventArgs e)
    {
      try
      {
        if (m_allowAccountTreeAndTransactionGridRefresh == false)
        {
          return;
        }

        PopulateAccountTree(true);
        PopulateAccountTransactionGrid();
        PopulateSummaryExpressionGrid();
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    void ViewByPeriodCheckedChanged(object sender, EventArgs e)
    {
      try
      {
        m_allowAccountTreeAndTransactionGridRefresh = false;

        if (viewByPeriod.Checked)
        {
          KPeriod period = (KPeriod) viewPeriod.SelectedItem;

          // set min & max values to extremes so we can set any date
          viewFrom.MinDate = DateTimePicker.MinDateTime;
          viewFrom.MaxDate = DateTimePicker.MaxDateTime;

          viewTo.MinDate = DateTimePicker.MinDateTime;
          viewTo.MaxDate = DateTimePicker.MaxDateTime;

          // set selected period's dates
          viewFrom.Value = period.GetStart();
          viewTo.Value = period.GetEnd();

          // set min & max date values
          viewFrom.MinDate = period.GetStart();
          viewFrom.MaxDate = period.GetEnd();

          viewTo.MinDate = period.GetStart();
          viewTo.MaxDate = period.GetEnd();
        }
        else
        {
          // set min & max values to extremes so we can set any date
          viewFrom.MinDate = DateTimePicker.MinDateTime;
          viewFrom.MaxDate = DateTimePicker.MaxDateTime;

          viewTo.MinDate = DateTimePicker.MinDateTime;
          viewTo.MaxDate = DateTimePicker.MaxDateTime;
        }

        m_allowAccountTreeAndTransactionGridRefresh = true;

        RefreshAccountTreeAndTransactionGrid();
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    void ViewPeriodSelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        if (viewByPeriod.Checked)
        {
          ViewByPeriodCheckedChanged(null, null);
        }
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    private void viewMovement_CheckedChanged(object sender, EventArgs e)
    {
      try
      {
        PopulateAccountTree(true);
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    private void viewBudget_CheckedChanged(object sender, EventArgs e)
    {
      try
      {
        PopulateAccountTree(true);
        PopulateAccountTransactionGrid();
        PopulateSummaryExpressionGrid();
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    void ViewTransactionGridBGCheckedChanged(object sender, EventArgs e)
    {
      try
      {
        // use account colour
        if (sender == viewTransactionGridBGAccount &&
            viewTransactionGridBGAccount.Checked)
        {
          m_activeBook.SetSetting(KBook.c_setting_setTransactionGridBg, true.ToString());
          m_activeBook.SetSetting(KBook.c_setting_setTransactionGridBgWithAccount, true.ToString());

          viewTransactionGridBGContra.Checked = false;
        }
        // use contra account colour
        if (sender == viewTransactionGridBGContra &&
            viewTransactionGridBGContra.Checked)
        {
          m_activeBook.SetSetting(KBook.c_setting_setTransactionGridBg, true.ToString());
          m_activeBook.SetSetting(KBook.c_setting_setTransactionGridBgWithAccount, false.ToString());

          viewTransactionGridBGAccount.Checked = false;
        }

        // don't colour the background
        if (viewTransactionGridBGAccount.Checked == false &&
            viewTransactionGridBGContra.Checked == false)
        {
          m_activeBook.SetSetting(KBook.c_setting_setTransactionGridBg, false.ToString());
          m_activeBook.SetSetting(KBook.c_setting_setTransactionGridBgWithAccount, false.ToString());
        }

        PopulateAccountTransactionGrid();
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    private void deleteTransaction_Click(object sender, EventArgs e)
    {
      try
      {
        // nothing selected?
        if (transactionGrid.SelectedRows.Count == 0)
        {
          InfoMsg("Select a transaction first.", "Delete Transaction");

          return;
        }

        // sure?
        if (ConfirmMsg("Delete this transaction - are you sure?", "Delete Transaction") == DialogResult.No)
        {
          return;
        }

        // delete it
        m_activeBook.DeleteTransaction(uint.Parse((String) transactionGrid.SelectedRows[0].Cells[0].Value));

        m_activeBook.Save();

        // refresh form
        PopulateAccountTree(true);
        PopulateSummaryExpressionGrid();
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    void NewAdjustmentClick(object sender, System.EventArgs e)
    {
      try
      {
        KAdjustmentForm dlg = new KAdjustmentForm(m_activeBook);

        dlg.ShowDialog(this);

        PopulateAccountTree(true);
        PopulateSummaryExpressionGrid();

        BringToFront();
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    void AccountTreeDoubleClick(object sender, System.EventArgs e)
    {
      try
      {
        // get account
        KAccount account = m_activeBook.GetAccount(accountTree.SelectedNode.Name);

        if (account.HasChildren())
        {
          return;
        }

        // do transaction dialog
        switch (account.GetAccountType())
        {
          case KAccount.c_bank:
          case KAccount.c_income:
          case KAccount.c_expense:
          case KAccount.c_debt:
          case KAccount.c_credit:

            KTransactionForm d1 = new KTransactionForm(m_activeBook, account, defaultDate.Value);
            d1.ShowDialog(this);
            break;
        }

        // update form
        PopulateAccountTree(true);
        PopulateAccountTransactionGrid();
        PopulateSummaryExpressionGrid();

        BringToFront();
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    private void transactionGrid_DoubleClick(object sender, EventArgs e)
    {
      try
      {
        // get the transaction id
        uint id = uint.Parse((String) transactionGrid.SelectedCells[0].Value);

        // get the transaction object
        ArrayList list = m_activeBook.GetTransaction(id);

        if (list.Count == 0)
        {
          ErrorMsg("Transaction not found.",
            "Error");

          return;
        }

        // normal transaction?
        if (((KTransaction) list[0]).IsAdjustment() == false)
        {
          // should have 2 parts (double entry)
          if (list.Count != 2)
          {
            ErrorMsg(list.Count + " transaction parts found for this transaction (should be 2).",
              "Error");

            return;
          }

          // do dialog
          Object[] trans = list.ToArray();
          KTransaction debit;
          KTransaction credit;

          if (((KTransaction) trans[0]).GetTransactionType() == KTransaction.TransactionType.c_debit)
          {
            debit = (KTransaction) trans[0];
            credit = (KTransaction) trans[1];
          }
          else
          {
            debit = (KTransaction) trans[1];
            credit = (KTransaction) trans[0];
          }

          KTransactionForm dlg = new KTransactionForm(m_activeBook, debit, credit);

          dlg.ShowDialog(this);
        }
        // adjustment transaction?
        else
        {
          // should have 1 part only (single adjustment entry)
          if (list.Count != 1)
          {
            ErrorMsg(list.Count + " transaction parts found for this transaction (should be 1).",
              "Error");

            return;
          }

          // do dialog
          Object[] trans = list.ToArray();
          KTransaction transaction = (KTransaction) trans[0];

          KAdjustmentForm dlg = new KAdjustmentForm(m_activeBook, transaction);

          dlg.ShowDialog(this);
        }

        // update form
        PopulateAccountTree(true);
        PopulateAccountTransactionGrid();
        PopulateSummaryExpressionGrid();

        BringToFront();
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    private void accountTree_AfterExpand(object sender, TreeViewEventArgs e)
    {
      try
      {
        // no node selected? shouldn't really happen...
        if (e.Node == null)
        {
          return;
        }

        // get account name
        String accountName = e.Node.Name;

        KAccount account = m_activeBook.GetAccount(accountName);

        account.SetTreeNodeExpanded(true);
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    private void accountTree_AfterCollapse(object sender, TreeViewEventArgs e)
    {
      try
      {
        // no node selected? shouldn't really happen...
        if (e.Node == null)
        {
          return;
        }

        // get account name
        String accountName = e.Node.Name;

        KAccount account = m_activeBook.GetAccount(accountName);

        account.SetTreeNodeExpanded(false);
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    private void PopulateSummaryExpressionGrid()
    {
      try
      {
        // get start & end dates
        DateTime start = DateTime.MinValue;
        DateTime end = DateTime.MaxValue;

        if (viewByPeriod.Checked)
        {
          foreach (KPeriod p in m_activeBook.GetPeriodList())
          {
            if (p.ToString().Equals(viewPeriod.Text))
            {
              start = p.GetStart().Date;
              end = p.GetEnd().Date;

              break;
            }
          }
        }

        if (viewByDateFrom.Checked)
        {
          start = viewFrom.Value;
        }

        if (viewByDateTo.Checked)
        {
          end = viewTo.Value;
        }

        // populate
        summaryExpressionGrid.Rows.Clear();

        IEnumerator expressions = m_activeBook.GetSummaryExpressionList().GetEnumerator();

        while (expressions.MoveNext())
        {
          KSummaryExpression expression = (KSummaryExpression) expressions.Current;

          Object[] cols = {expression.GetName(), expression.CalculateValue(start, end, viewBudget.Checked)};

          summaryExpressionGrid.Rows.Add(cols);
        }
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    void AddSummaryExpressionItemClick(object sender, EventArgs e)
    {
      try
      {
        KSummaryExpressionBuilderForm dlg = new KSummaryExpressionBuilderForm(m_activeBook);

        dlg.ShowDialog(this);

        PopulateSummaryExpressionGrid();

        BringToFront();
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    void SummaryExpressionGridDoubleClick(object sender, EventArgs e)
    {
      try
      {
        String name = (String) summaryExpressionGrid.SelectedRows[0].Cells[0].Value;

        KSummaryExpression expression = m_activeBook.GetSummaryExpression(name);

        KSummaryExpressionBuilderForm dlg =
          new KSummaryExpressionBuilderForm(expression, m_activeBook);

        dlg.ShowDialog(this);

        PopulateSummaryExpressionGrid();

        BringToFront();
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    private void showHiddenAccountsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
      try
      {
        PopulateAccountTree(true);
        PopulateAccountTransactionGrid();
        PopulateSummaryExpressionGrid();
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    private void summaryExpressionGrid_Click(object sender, EventArgs e)
    {
      try
      {
        // active book?
        if (CheckForActiveBook(false) == false &&
            summaryExpressionGrid.SelectedRows.Count > 0)
        {
          return;
        }

        // populate transaction grid
        transactionGrid.Rows.Clear();

        String name = (String) summaryExpressionGrid.SelectedRows[0].Cells[0].Value;
        KSummaryExpression expression = m_activeBook.GetSummaryExpression(name);

        foreach (KSummaryExpression.KField field in expression.Fields)
        {
          if (field.IsAccount())
          {
            String selectedAcc = field.GetAccount().GetQualifiedAccountName();

            PopulateAccountTransactionGrid(m_activeBook.GetAccount(selectedAcc));
          }
        }
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    private void transactionGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      try
      {
        // 'Budget' checkbox changes.
        if (e.ColumnIndex != transactionGrid.Columns["Budget"]?.Index ||
            e.RowIndex == -1 ||
            transactionGrid.CurrentRow == null)
        {
          return;
        }

        var checkboxCell = (DataGridViewCheckBoxCell)transactionGrid.CurrentRow.Cells["Budget"];

        var transaction = (KTransaction)transactionGrid.CurrentRow.Tag;
        transaction.IsBudget = (bool)checkboxCell.Value;

        m_activeBook.Save();

        PopulateAccountTransactionGrid();
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------

    private void transactionGrid_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
    {
      try
      {
        // This is specifically for 'budget' checkbox changes so that the
        // "cell value changed" event is raised immediately (and not when the row loses focus).
        if (e.ColumnIndex != transactionGrid.Columns["Budget"].Index ||
            e.RowIndex == -1)
        {
          return;
        }

        transactionGrid.EndEdit();
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //---------------------------------------------------------------
  }
}