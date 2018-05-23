using System;
using System.Drawing;
using System.Windows.Forms;

namespace BoozeHoundBooks
{
  public partial class KAdjustmentForm
  {
    // class vars --------------------------------------------------------------

    private KBook m_book;
    private bool m_editingAdjustment = false;
    private uint m_editingAdjustmentId = 0;

    //--------------------------------------------------------------------------

    public KAdjustmentForm(KBook book)
    {
      // init components
      InitializeComponent();

      // title
      this.Text = "New Adjustment";

      // init vars
      m_book = book;

      // populate account box
      PopulateAccountBox();

      // set today's date
      dateBox.Value = DateTime.Now;
      DateBox_ValueChanged(null, null);
    }

    //--------------------------------------------------------------------------

    public KAdjustmentForm(KBook book, KAccount account)
    {
      // init components
      InitializeComponent();

      // title
      this.Text = "New Adjustment";

      // init vars
      m_book = book;

      // populate account box
      PopulateAccountBox();

      accountBox.SelectedItem = account;

      // set today's date
      dateBox.Value = DateTime.Now;
      DateBox_ValueChanged(null, null);
    }

    //---------------------------------------------------------------

    public KAdjustmentForm(KBook book, KTransaction trans)
    {
      // init components
      InitializeComponent();

      // title
      this.Text = "Edit Adjustment";

      // change 'process' button to 'save'
      processBtn.Text = "Save";

      // init vars
      m_book = book;
      m_editingAdjustment = true;
      m_editingAdjustmentId = trans.GetId();

      // populate account box
      PopulateAccountBox();

      // account
      accountBox.Text = trans.GetAccount().ToString();

      // date
      dateBox.Value = trans.GetDate();

      // description
      infoBox.Text = trans.GetDescription();

      // amount
      if (trans.GetTransactionType() == KTransaction.TransactionType.c_debit)
      {
        amountBox.Text = (trans.GetAmount() * -1m).ToString("0.00");
      }
      else
      {
        amountBox.Text = trans.GetAmount().ToString("0.00");
      }

      // budget transaction
      budgetBox.Checked = trans.IsBudgetTransaction();

      // recuring
      recuringBox.Checked = trans.IsRecuring();
    }

    //---------------------------------------------------------------

    private void PopulateAccountBox()
    {
      foreach (KAccount a in m_book.GetAccountList())
      {
        if (a.HasChildren() == false &&
            a.GetAccountType() != KAccount.c_unknown)
        {
          accountBox.Items.Add(a);
        }
      }

      if (accountBox.Items.Count > 0)
      {
        accountBox.SelectedIndex = 0;
      }
    }

    //---------------------------------------------------------------

    void ProcessBtnClick(object sender, System.EventArgs e)
    {
      try
      {
        // sure?
        if (budgetBox.Checked)
        {
          if (MessageBox.Show("BUDGET TRANSACTION: Are you sure?",
                processBtn.Text + " BUDGET TRANSACTION?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Asterisk,
                MessageBoxDefaultButton.Button1) == DialogResult.No)
          {
            return;
          }
        }
        else if (MessageBox.Show("Are you sure?",
                   processBtn.Text + "?",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Asterisk,
                   MessageBoxDefaultButton.Button1) == DialogResult.No)
        {
          return;
        }

        // get the account
        KAccount account = (KAccount) accountBox.SelectedItem;

        // get the amount
        decimal amount;

        // valid number?
        try
        {
          amount = decimal.Parse(amountBox.Text);
        }
        catch (Exception ex)
        {
          MessageBox.Show("Amount is not a valid number.\n\n" + ex.Message,
            "Amount",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);

          return;
        }

        // figure out whether to debit or credit
        KTransaction.TransactionType type;

        switch (account.GetAccountType())
        {
          case KAccount.c_bank: // BANK

            if (amount > 0.0m)
            {
              type = KTransaction.TransactionType.c_credit;
            }
            else
            {
              type = KTransaction.TransactionType.c_debit;
            }

            break;

          case KAccount.c_income: // INCOME

            if (amount > 0.0m)
            {
              type = KTransaction.TransactionType.c_debit;
            }
            else
            {
              type = KTransaction.TransactionType.c_credit;
            }

            break;

          case KAccount.c_expense: // EXPENSE

            if (amount > 0.0m)
            {
              type = KTransaction.TransactionType.c_credit;
            }
            else
            {
              type = KTransaction.TransactionType.c_debit;
            }

            break;

          case KAccount.c_debt: // DEBT

            if (amount > 0.0m)
            {
              type = KTransaction.TransactionType.c_debit;
            }
            else
            {
              type = KTransaction.TransactionType.c_credit;
            }

            break;

          case KAccount.c_credit: // CREDIT

            if (amount > 0.0m)
            {
              type = KTransaction.TransactionType.c_credit;
            }
            else
            {
              type = KTransaction.TransactionType.c_debit;
            }

            break;

          default:
            KMainForm.ErrorMsg("Unknown account type", "Error");
            return;
        }

        // create transaction
        m_book.CreateTransaction(account,
          type,
          Math.Abs(amount),
          dateBox.Value,
          infoBox.Text,
          budgetBox.Checked,
          recuringBox.Checked);

        // updating an existing transaction? delete the orig transaction
        if (m_editingAdjustment)
        {
          m_book.DeleteTransaction(m_editingAdjustmentId);
        }

        m_book.Save();

        Dispose();
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //--------------------------------------------------------------------------

    void CancelBtnClick(object sender, System.EventArgs e)
    {
      Dispose();
    }

    //--------------------------------------------------------------------------

    void AccountBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
      // enter? move to next box
      if (e.KeyChar == (char) System.Windows.Forms.Keys.Enter)
      {
        dateBox.Focus();
      }
    }

    //--------------------------------------------------------------------------

    void DateBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
      // enter? move to next box
      if (e.KeyChar == (char) System.Windows.Forms.Keys.Enter)
      {
        infoBox.Focus();
      }
    }

    //--------------------------------------------------------------------------

    void InfoBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
      // enter? move to next box
      if (e.KeyChar == (char) System.Windows.Forms.Keys.Enter)
      {
        amountBox.Focus();
      }
    }

    //--------------------------------------------------------------------------

    void AmountBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
      // enter? move to next box
      if (e.KeyChar == (char) System.Windows.Forms.Keys.Enter)
      {
        processBtn.PerformClick();
      }
    }

    //--------------------------------------------------------------------------

    private void DateBox_ValueChanged(object sender, EventArgs e)
    {
      // find period
      String s = m_book.GetPeriodName(dateBox.Value);

      if (s != null)
      {
        periodName.Text = s;

        processBtn.Enabled = true;
      }
      else
      {
        periodName.Text = "Unknown Period";

        processBtn.Enabled = false;
      }
    }

    //--------------------------------------------------------------------------
  }
}