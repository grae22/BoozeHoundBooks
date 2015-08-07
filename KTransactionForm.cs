﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace BoozeHoundBooks
{
	public partial class KTransactionForm
	{
	  // class vars --------------------------------------------------------------
	  
	  private KBook m_book;
	  private bool m_editingTransaction = false;
	  private uint m_editingTransactionId = 0;
	  private bool m_formLoading = true;
	  
	  //--------------------------------------------------------------------------
	  
		public KTransactionForm( KBook book )
		{
		  // init components
			InitializeComponent();
			
			// title
			this.Text = "New Transaction";
			
			// init vars
			m_book = book;
			
			transactionIncome.Checked = false;
			transactionIncome.Checked = true;

      // set today's date
      transactionDate.Value = DateTime.Now;
      transactionDate_ValueChanged( null, null );
      
      // hide 'process as new' by default
      transactionProcessAsNew.Hide();
      
      // load complete
      m_formLoading = false;
		}

	  //--------------------------------------------------------------------------
	  
		public KTransactionForm( KBook    book,
	                           KAccount account,
	                           DateTime transDate )
		{
		  // init components
			InitializeComponent();
			
			// title
			this.Text = "New Transaction";
			
			// init vars
			m_book = book;
			
			// income/expense/inter/debt/credit
      switch (account.GetAccountType() )
      {
        case KAccount.c_income:
  			  transactionIncome.Checked = false;
  			  transactionIncome.Checked = true;

  			  transactionFromAcc.SelectedItem = account;
          break;

        case KAccount.c_expense:
  			  transactionExpense.Checked = false;
  			  transactionExpense.Checked = true;

  			  transactionToAcc.SelectedItem = account;
          break;

        case KAccount.c_bank:
  			  transactionInter.Checked = false;
  			  transactionInter.Checked = true;
  			
  			  transactionFromAcc.SelectedItem = account;
  			  transactionToAcc.SelectedItem = account;
          break;

        case KAccount.c_debt:
  			  transactionDebt.Checked = false;
  			  transactionDebt.Checked = true;

          actionLoan.Checked = false;
          actionLoan.Checked = true;
  			
  			  transactionFromAcc.SelectedItem = account;
          break;

        case KAccount.c_credit:
  			  transactionCredit.Checked = false;
  			  transactionCredit.Checked = true;

          actionLoan.Checked = false;
          actionLoan.Checked = true;

  			  transactionToAcc.SelectedItem = account;
          break;
      }

      // set today's date
      transactionDate.Value = transDate;
      transactionDate_ValueChanged( null, null );
      
      // hide 'process as new' by default
      transactionProcessAsNew.Hide();

      // load complete
      m_formLoading = false;
	  }

    //---------------------------------------------------------------

    public KTransactionForm( KBook book, KTransaction debit, KTransaction credit )
    {
		  // init components
			InitializeComponent();
			
			// title
			this.Text = "Edit Transaction";
			
			// change 'process' button to 'save'
			transactionProcess.Text = "Save";

			// init vars
			m_book = book;
			m_editingTransaction = true;
			m_editingTransactionId = debit.GetId();
			
			// show the 'process as new' button
			transactionProcessAsNew.Show();

			// type?
      // inter-account transfer
      if ( debit.GetAccount().GetAccountType() == credit.GetAccount().GetAccountType() )
      {
        transactionInter.Checked = true;
      }
      // expense
      else if ( debit.GetAccount().GetAccountType() == KAccount.c_bank &&
                credit.GetAccount().GetAccountType() == KAccount.c_expense )
      {
        transactionExpense.Checked = true;
      }
      // income
      else if ( debit.GetAccount().GetAccountType() == KAccount.c_income &&
                credit.GetAccount().GetAccountType() == KAccount.c_bank )
      {
        transactionIncome.Checked = false;
        transactionIncome.Checked = true;
      }
      // debt - loan
      else if ( debit.GetAccount().GetAccountType() == KAccount.c_debt &&
                credit.GetAccount().GetAccountType() == KAccount.c_bank )
      {
        transactionDebt.Checked = false;
        transactionDebt.Checked = true;

        actionLoan.Checked = false;
        actionLoan.Checked = true;
      }
      // debt - repayment
      else if ( debit.GetAccount().GetAccountType() == KAccount.c_bank &&
                credit.GetAccount().GetAccountType() == KAccount.c_debt )
      {
        transactionDebt.Checked = false;
        transactionDebt.Checked = true;

        actionRepayment.Checked = false;
        actionRepayment.Checked = true;
      }
      // credit - loan
      else if ( debit.GetAccount().GetAccountType() == KAccount.c_bank &&
                credit.GetAccount().GetAccountType() == KAccount.c_credit )
      {
        transactionCredit.Checked = false;
        transactionCredit.Checked = true;

        actionLoan.Checked = false;
        actionLoan.Checked = true;
      }
      // creidt - repayment
      else if ( debit.GetAccount().GetAccountType() == KAccount.c_credit &&
                credit.GetAccount().GetAccountType() == KAccount.c_bank )
      {
        transactionCredit.Checked = false;
        transactionCredit.Checked = true;

        actionRepayment.Checked = false;
        actionRepayment.Checked = true;
      }
      else
      {
        KMainForm.ErrorMsg( "Unknown transaction type!", "Error" );
      }
      
      // debit account
      transactionFromAcc.Text = debit.GetAccount().ToString();

      // credit account
      transactionToAcc.Text = credit.GetAccount().ToString();

      // date
      transactionDate.Value = debit.GetDate();
      
      // description
      transactionInfo.Text = debit.GetDescription();
      
      // amount
      transactionAmount.Text = debit.GetAmount().ToString( "0.00" );
      
      // budget transaction
      transactionBudget.Checked = debit.IsBudgetTransaction();

      // recuring
      transactionRecuring.Checked = debit.IsRecuring();

      // load complete
      m_formLoading = false;
    }

    //---------------------------------------------------------------
		
		void TransactionIncomeClick(object sender, System.EventArgs e)
		{
      // unchecked? do nothing
      if ( transactionIncome.Checked == false )
      {
        return;
      }

      // disable master account box
      transactionMasterAccount.Enabled = false;

      // disable debit/credit role boxes
      actionLoan.Enabled = false;
      actionRepayment.Enabled = false;

      // add income accounts to 'from' accounts box
		  transactionFromAcc.Items.Clear();
		  
		  foreach ( KAccount acc in m_book.GetAccountList() )
		  {
		    if ( acc.GetAccountType() == KAccount.c_income &&
             acc.HasChildren() == false )
		    {
		      transactionFromAcc.Items.Add( acc );//.GetAccountName() );
		    }
		  }
		  
      if ( transactionFromAcc.Items.Count > 0 )
      {
		    transactionFromAcc.SelectedIndex = 0;
      }

		  // add bank accounts to 'to' accounts box
		  transactionToAcc.Items.Clear();
		  
		  foreach ( KAccount acc in m_book.GetAccountList() )
		  {
		    if ( acc.GetAccountType() == KAccount.c_bank &&
             acc.HasChildren() == false )
		    {
		      transactionToAcc.Items.Add( acc );//.GetAccountName() );
		    }
		  }
		  
      if ( transactionToAcc.Items.Count > 0 )
      {
		    transactionToAcc.SelectedIndex = 0;
      }
		}
		
		//---------------------------------------------------------------
		
		void TransactionExpenseClick(object sender, System.EventArgs e)
		{
      // unchecked? do nothing
      if ( transactionExpense.Checked == false )
      {
        return;
      }

      // disable master account box
      transactionMasterAccount.Enabled = false;

      // disable debit/credit role boxes
      actionLoan.Enabled = false;
      actionRepayment.Enabled = false;

      // add bank accounts to 'from' accounts box
		  transactionFromAcc.Items.Clear();
		  
		  foreach ( KAccount acc in m_book.GetAccountList() )
		  {
		    if ( acc.GetAccountType() == KAccount.c_bank &&
             acc.HasChildren() == false )
		    {
		      transactionFromAcc.Items.Add( acc );//.GetAccountName() );
		    }
		  }
		  
      if ( transactionFromAcc.Items.Count > 0 )
      {
		    transactionFromAcc.SelectedIndex = 0;
      }

		  // add expense accounts to 'to' accounts box
		  transactionToAcc.Items.Clear();
		  
		  foreach ( KAccount acc in m_book.GetAccountList() )
		  {
		    if ( acc.GetAccountType() == KAccount.c_expense &&
             acc.HasChildren() == false )
		    {
		      transactionToAcc.Items.Add( acc );//.GetAccountName() );
		    }
		  }
		  
      if ( transactionToAcc.Items.Count > 0 )
      {
		    transactionToAcc.SelectedIndex = 0;
      }
		}
		
		//---------------------------------------------------------------
		
		void TransactionInterClick(object sender, System.EventArgs e)
		{
      // unchecked? do nothing
      if ( transactionInter.Checked == false )
      {
        return;
      }

      // enable master account box
      transactionMasterAccount.Enabled = true;

      // disable debit/credit role boxes
      actionLoan.Enabled = false;
      actionRepayment.Enabled = false;

      // add master accounts to 'master' accounts box
		  transactionMasterAccount.Items.Clear();
		  
		  foreach ( KAccount acc in m_book.GetAccountList() )
		  {
		    if ( acc.IsMasterAccount() &&
             acc.GetAccountType() != KAccount.c_unknown )
		    {
		      transactionMasterAccount.Items.Add( acc.GetAccountName() );
		    }
		  }
		  
      if ( transactionMasterAccount.Items.Count > 0 )
      {
		    transactionMasterAccount.SelectedIndex = 0;
      }
		}

		//---------------------------------------------------------------
		
		void TransactionDebtClick(object sender, System.EventArgs e)
		{
      // unchecked? do nothing
      if ( transactionDebt.Checked == false )
      {
        return;
      }

      // disable master account box
      transactionMasterAccount.Enabled = false;

      // enable debit/credit role boxes
      actionLoan.Enabled = true;
      actionRepayment.Enabled = true;

      // update to/from accounts
      DebtCreditActionUpdate( null, null );
		}

    //---------------------------------------------------------------
		
		void TransactionCreditClick(object sender, System.EventArgs e)
		{
      // unchecked? do nothing
      if ( transactionCredit.Checked == false )
      {
        return;
      }

      // disable master account box
      transactionMasterAccount.Enabled = false;

      // enable debit/credit role boxes
      actionLoan.Enabled = true;
      actionRepayment.Enabled = true;

      // update to/from accounts
      DebtCreditActionUpdate( null, null );
		}

    //---------------------------------------------------------------

    private void transactionMasterAccountSelectedIndexChanged(object sender, EventArgs e)
    {
      // add all accounts from selected master to 'from'/'to' accounts box
		  transactionFromAcc.Items.Clear();
      transactionToAcc.Items.Clear();

      KAccount master = m_book.GetAccount( transactionMasterAccount.Text );

      if ( master != null && master.HasChildren() )
      {		  
		    foreach ( KAccount acc in master.GetChildren( true ) )
		    {
		      if ( acc.HasChildren() == false )
		      {
		        transactionFromAcc.Items.Add( acc );//.GetAccountName() );
            transactionToAcc.Items.Add( acc );//.GetAccountName() );
		      }
		    }
  		  
		    transactionFromAcc.SelectedIndex = 0;
		    transactionToAcc.SelectedIndex = 0;
      }
    }		
		
    //---------------------------------------------------------------

    private void DebtCreditActionUpdate(object sender, System.EventArgs e)
    {
      int fromAccType;
      int toAccType;

      // debt
      if ( transactionDebt.Checked )
      {
        // loan
        if ( actionLoan.Checked )
        {
          fromAccType = KAccount.c_debt;
          toAccType = KAccount.c_bank;
        }
        // repayment
        else
        {
          fromAccType = KAccount.c_bank;
          toAccType = KAccount.c_debt;
        }
      }
      // credit
      else
      {
        // loan
        if ( actionLoan.Checked )
        {
          fromAccType = KAccount.c_bank;
          toAccType = KAccount.c_credit;
        }
        // repayment
        else
        {
          fromAccType = KAccount.c_credit;
          toAccType = KAccount.c_bank;
        }
      }

      // add accounts to 'from' accounts box
      transactionFromAcc.Items.Clear();
		  
      foreach ( KAccount acc in m_book.GetAccountList() )
      {
        if ( acc.GetAccountType() == fromAccType &&
             acc.HasChildren() == false )
        {
          transactionFromAcc.Items.Add( acc );//.GetAccountName() );
        }
      }
		  
      if ( transactionFromAcc.Items.Count > 0 )
      {
        transactionFromAcc.SelectedIndex = 0;
      }

      // add accounts to 'to' accounts box
      transactionToAcc.Items.Clear();
		  
      foreach ( KAccount acc in m_book.GetAccountList() )
      {
        if ( acc.GetAccountType() == toAccType &&
             acc.HasChildren() == false )
        {
          transactionToAcc.Items.Add( acc );//.GetAccountName() );
        }
      }
		  
      if ( transactionToAcc.Items.Count > 0 )
      {
        transactionToAcc.SelectedIndex = 0;
      }
    }

    //---------------------------------------------------------------
		
		void TransactionProcessClick(object sender, System.EventArgs e)
		{
		  try {
        // sure?
        if ( transactionBudget.Checked )
        {
          if ( MessageBox.Show( "BUDGET TRANSACTION: Are you sure?",
                              transactionProcess.Text + " BUDGET TRANSACTION?",
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Asterisk,
                              MessageBoxDefaultButton.Button1 ) == DialogResult.No )
          {
            return;
          }
        }
        else if ( MessageBox.Show( "Are you sure?",
                              transactionProcess.Text + "?",
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Asterisk,
                              MessageBoxDefaultButton.Button1 ) == DialogResult.No )
        {
          return;
        }
  
        // don't allow from & to accounts to be same
        if ( transactionFromAcc.Text.Equals( transactionToAcc.Text ) )
        {
          KMainForm.ErrorMsg( "'From' and 'To' accounts can not be the same.", "Accounts" );
  
          return;
        }
  
        // get the amount
        decimal amount;
  		  
  		    // valid number?
  		    try {
  
            amount = decimal.Parse( transactionAmount.Text );
  		      
  		      if ( amount < 0m )
  		      {
  		        throw new Exception( "Negative amounts not allowed." );
  		      }
  		      
  		    } catch ( Exception ex )
  		    {
  		      MessageBox.Show( "Amount is not a valid number.\n\n" + ex.Message,
  		                       "Amount",
  		                       MessageBoxButtons.OK,
  		                       MessageBoxIcon.Error );
  		      
  		      return;
  		    }
  		    
  		  // create transaction
  			m_book.CreateTransaction( (KAccount)transactionFromAcc.SelectedItem,
  		                            (KAccount)transactionToAcc.SelectedItem,
  		                            amount,
  		                            transactionDate.Value,
  		                            transactionInfo.Text,
                                  transactionBudget.Checked,
                                  transactionRecuring.Checked );

  		  // updating an existing transaction? delete the orig transaction
  		  if ( m_editingTransaction )
  		  {
  		    m_book.DeleteTransaction( m_editingTransactionId );
  		  }
  		  
  		  m_book.Save();
  		  
  		  Dispose();
  
		  }
		  catch ( Exception ex )
		  {
		    KMain.HandleException( ex, true );
		  }
    }

		//--------------------------------------------------------------------------
		
		void TransactionCancelClick(object sender, System.EventArgs e)
		{
		  Dispose();
		}
		
		//--------------------------------------------------------------------------
		
		void TransactionProcessAsNewClick(object sender, EventArgs e)
		{
		  try {
        // sure?
        if ( MessageBox.Show( "Process as NEW Transaction - are you sure?",
                              "Process as NEW Transaction?",
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Asterisk,
                              MessageBoxDefaultButton.Button1 ) == DialogResult.No )
        {
          return;
        }
  
        // don't allow from & to accounts to be same
        if ( transactionFromAcc.Text.Equals( transactionToAcc.Text ) )
        {
          KMainForm.ErrorMsg( "'From' and 'To' accounts can not be the same.", "Accounts" );
  
          return;
        }
  
        // get the amount
        decimal amount;
  		  
  		    // valid number?
  		    try {
  
            amount = decimal.Parse( transactionAmount.Text );
  		      
  		      if ( amount < 0m )
  		      {
  		        throw new Exception( "Negative amounts not allowed." );
  		      }
  		      
  		    } catch ( Exception ex )
  		    {
  		      MessageBox.Show( "Amount is not a valid number.\n\n" + ex.Message,
  		                       "Amount",
  		                       MessageBoxButtons.OK,
  		                       MessageBoxIcon.Error );
  		      
  		      return;
  		    }
  		    
  		  // create transaction
  			m_book.CreateTransaction( (KAccount)transactionFromAcc.SelectedItem,
  		                            (KAccount)transactionToAcc.SelectedItem,
  		                            amount,
  		                            transactionDate.Value,
  		                            transactionInfo.Text,
                                  transactionBudget.Checked,
                                  transactionRecuring.Checked );

  		  m_book.Save();
  		  
  		  Dispose();
		  }
		  catch ( Exception ex )
		  {
		    KMain.HandleException( ex, true );
		  }
		}
		
		//--------------------------------------------------------------------------

		void TransactionTypeKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			// enter? move to next box
			if ( e.KeyChar == (char)System.Windows.Forms.Keys.Enter )
			{
			  transactionFromAcc.Focus();
			}
		}

		//--------------------------------------------------------------------------
		
		void TransactionMasterAccountKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			// enter? move to next box
			if ( e.KeyChar == (char)System.Windows.Forms.Keys.Enter )
			{
			  transactionFromAcc.Focus();
			}
		}

		//--------------------------------------------------------------------------
		
		void TransactionFromAccKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			// enter? move to next box
			if ( e.KeyChar == (char)System.Windows.Forms.Keys.Enter )
			{
			  transactionToAcc.Focus();
			}
		}
		
		//--------------------------------------------------------------------------
		
		void TransactionToAccKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			// enter? move to next box
			if ( e.KeyChar == (char)System.Windows.Forms.Keys.Enter )
			{
			  transactionDate.Focus();
			}
		}
		
		//--------------------------------------------------------------------------

		void TransactionDateKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			// enter? move to next box
			if ( e.KeyChar == (char)System.Windows.Forms.Keys.Enter )
			{
			  transactionInfo.Focus();
			}
		}
		
		//--------------------------------------------------------------------------
		
		void TransactionInfoKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			// enter? move to next box
			if ( e.KeyChar == (char)System.Windows.Forms.Keys.Enter )
			{
			  transactionAmount.Focus();
			}
		}
		
		//--------------------------------------------------------------------------
		
		void TransactionAmountKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			// enter? move to next box
			if ( e.KeyChar == (char)System.Windows.Forms.Keys.Enter )
			{
			  transactionProcess.PerformClick();
			}
		}

    //--------------------------------------------------------------------------

    private void transactionDate_ValueChanged(object sender, EventArgs e)
    {
      // find period
      String s = m_book.GetPeriodName( transactionDate.Value );

      if ( s != null )
      {
        periodName.Text = s;

        transactionProcess.Enabled = true;
      }
      else
      {
        periodName.Text = "Unknown Period";

        transactionProcess.Enabled = false;
      }
    }
		
		//--------------------------------------------------------------------------
		
		void TransactionToAccSelectedIndexChanged(object sender, EventArgs e)
		{
		  // do nothing if form loading for transaction edit
		  if ( m_editingTransaction &&
           m_formLoading )
		  {
		    return;
		  }

		  // select last transaction 'to' acc (if there is one)
      string contraAccName =
        ((KAccount)transactionToAcc.SelectedItem).GetLastTransactionContraName();
      
      if ( contraAccName != null )
      {
        KAccount contraAcc = m_book.GetAccount( contraAccName );
        
        if ( contraAcc != null &&
             transactionFromAcc.Items.Contains( contraAcc ) )
        {
          transactionFromAcc.SelectedItem = contraAcc;
        }
      }
		}
	}
}
