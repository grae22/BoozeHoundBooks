using System;
using System.Xml;
using System.IO;
using System.Collections;
using System.Drawing;

namespace BoozeHoundBooks
{
	public class KBook
	{
	  // class constants ----------------------------------------------
	  
	  // settings
	  public const String c_setting_setTransactionGridBg              = "SetTransactionGridBg";
	  public const String c_setting_setTransactionGridBgWithAccount   = "SetTransactionGridBgWithAccount";
	  
	  // class vars ---------------------------------------------------
	  
	  private String m_path;
	  private ArrayList m_account = new ArrayList( 10 );
	  private ArrayList m_period = new ArrayList( 10 );
	  private Hashtable m_setting = new Hashtable( 10 );
	  private ArrayList m_summaryExpression = new ArrayList( 5 );
	  
	  private Size m_accountTreeIconSize = new Size( 20, 20 );
	  private Size m_transactionGridIconSize = new Size( 16, 16 );
	  
	  //---------------------------------------------------------------
	  
		public KBook( String path,
	                bool newBook )
		{
	    // set class vars
		  m_path = path;

      // clear out account icons
      KAccount.m_iconList.Images.Clear();

      // create base account types
      if ( newBook )
      {
        foreach ( String s in KAccount.m_accountTypeName )
        {
          KAccount acc = new KAccount( s, s, s, null, Color.FromName( KAccount.c_noColourName ), false );

          acc.SetupIcon( m_accountTreeIconSize, false );

          m_account.Add( acc );
        }
      }
		  
		  // init class
		  ProcessXml();
		  
      // sort the accounts
      SortAccounts();
		}
		
		//---------------------------------------------------------------
		
		private void ProcessXml()
		{
		  // xml doc doesn't exist? do nothing
		  if ( File.Exists( m_path ) == false )
		  {
		    return;
		  }
		  
		  // load xml doc
		  XmlDocument doc = new XmlDocument();
		  
		  doc.Load( m_path );
		  
		  // load settings
		  XmlNodeList settingList = doc.GetElementsByTagName( "Setting" );
		  
		  foreach ( XmlElement settingNode in settingList )
		  {
		    m_setting.Add( settingNode.GetAttribute( "Name" ), settingNode.GetAttribute( "Value" ) );
		  }

		  // load periods
		  XmlNodeList periodList = doc.GetElementsByTagName( "Period" );
		  
		  foreach ( XmlElement periodNode in periodList )
		  {
		    KPeriod period = new KPeriod( periodNode );
		    
		    m_period.Add( period );
		  }

		  // load accounts
		  XmlNodeList accList = doc.GetElementsByTagName( "MasterAccount" );
		  
		  foreach ( XmlElement accNode in accList )
		  {
        LoadAccountFromXml( accNode, null );
		  }

      // update account transactions with contra-accounts
      // now that all accounts are loaded.
      foreach ( KAccount a in m_account )
      {
        a.UpdateTransactionsWithContraAccounts( m_account );
        a.SetupIcon( m_accountTreeIconSize, false );
      }
      
      // load summary fields
      XmlNodeList summaryExpressionList = doc.GetElementsByTagName( "SummaryExpression" );
      
      foreach ( XmlElement e in summaryExpressionList )
      {
        KSummaryExpression expression = new KSummaryExpression( e, this );
        
        m_summaryExpression.Add( expression );
      }
		}

    //---------------------------------------------------------------

    private void LoadAccountFromXml( XmlElement element, KAccount parent )
    {
      // load the account
      KAccount acc = new KAccount( element, parent, m_account, m_period );

      m_account.Add( acc );

      // does it have any sub accounts? load them too
      XmlNodeList list = element.SelectNodes( "./Account" );

      foreach ( XmlElement e in list )
      {
        LoadAccountFromXml( e, acc );
      }
    }
		
		//---------------------------------------------------------------
		
		public bool Save()
		{
		  try
		  {
        // sort the accounts
        SortAccounts();

        // create the xml doc
  		  XmlDocument doc = new XmlDocument();
  		  
  		  XmlElement bookElement = doc.CreateElement( "Book" );
  		  
  		  doc.AppendChild( bookElement );
  
  		  // add settings
  		  XmlElement settingListElement = doc.CreateElement( "Settings" );
  		  
  		  bookElement.AppendChild( settingListElement );
  		  
  		  IDictionaryEnumerator settingEnum = m_setting.GetEnumerator();
  		  
  		  while ( settingEnum.MoveNext() )
  		  {
  		    // create element
  		    XmlElement settingElement = doc.CreateElement( "Setting" );
  		    
  		    settingElement.SetAttribute( "Name", (String)settingEnum.Key );
  		    settingElement.SetAttribute( "Value", (String)settingEnum.Value );
  		    
  		    // add to book
  		    settingListElement.AppendChild( settingElement );
  		  }
  		  
  		  // add summary expressions
  		  XmlElement summaryExpressionElement = doc.CreateElement( "SummaryExpressionList" );
  		  
  		  bookElement.AppendChild( summaryExpressionElement );
  		  
  		  foreach ( KSummaryExpression expression in m_summaryExpression )
  		  {
  		    // create expression element
  		    XmlElement expressionElement = doc.CreateElement( "SummaryExpression" );
  		    
  		    // get period xml
  		    expression.GetXml( expressionElement );
  		    
  		    // add period xml to book
  		    summaryExpressionElement.AppendChild( expressionElement );
  		  }

  		  // add periods
  		  XmlElement periodListElement = doc.CreateElement( "PeriodList" );
  		  
  		  bookElement.AppendChild( periodListElement );
  		  
  		  foreach ( KPeriod period in m_period )
  		  {
  		    // create period element
  		    XmlElement periodElement = doc.CreateElement( "Period" );
  		    
  		    // get period xml
  		    period.GetXml( periodElement );
  		    
  		    // add period xml to book
  		    periodListElement.AppendChild( periodElement );
  		  }
  
  		  // add accounts
  		  XmlElement accListElement = doc.CreateElement( "AccountList" );
  		  
  		  bookElement.AppendChild( accListElement );
  		  
  		  foreach ( KAccount acc in m_account )
  		  {
          // create master account elements
          if ( acc.GetParent() == null )
          {
            XmlElement accountElement = doc.CreateElement( "MasterAccount" );
  
  	        // get account xml
  	        accountElement = acc.GetXml( accountElement );
  	        
  	        // add children
  	        accountElement = AddChildAccountsToXml( doc, accountElement, acc );
  
  	        // add account xml to book
  	        accListElement.AppendChild( accountElement );
          }
  		  }
  
  		  // save the xml doc
  		  doc.Save( m_path );

        // write zip
        var compressedPath = m_path.Replace( Path.GetExtension( m_path ), ".zip" );

        KCompressedFileWriter.WriteFile(
          compressedPath,
          "Backup.bhb",
          File.ReadAllText( m_path ) );
  
  		  // success
  		  return true;
		  }
		  catch (Exception)
		  {
		    return false;
		  }
		}

    //---------------------------------------------------------------

    private XmlElement AddChildAccountsToXml( XmlDocument doc, XmlElement element, KAccount account )
    {
      foreach ( KAccount child in account.GetChildren( false ) )
      {
        XmlElement childElement = doc.CreateElement( "Account" );
        
        childElement = child.GetXml( childElement );
        
        childElement = AddChildAccountsToXml( doc, childElement, child );
        
        element.AppendChild( childElement );
      }
      
      return element;
    }
		
		//---------------------------------------------------------------
		
		private void SortAccounts()
		{
      // sort the accounts, but keep master accounts at the top of the list
      bool keepSorting;
      
      m_account.Sort();
      
      do
      {
        keepSorting = false;
        
        // loop through accounts
        foreach ( KAccount a in m_account )
        {
          // is a master account?
          if ( a.IsMasterAccount() )
          {
            // not where it should be in the list?
            if ( m_account.IndexOf( a ) != a.GetAccountType() )
            {
              // move it to where it should be
              m_account.Remove( a );
              m_account.Insert( a.GetAccountType(), a );
              
              // keep sorting
              keepSorting = true;
              break;
            }
          }
        }
        
      } while ( keepSorting );
		}
		
		//---------------------------------------------------------------
		
		public void CreateAccount( String name,
		                           String description,
		                           KAccount parent,
		                           Color colour,
                               bool hideInTree )
		{
      // create the account
		  KAccount acc = new KAccount( name,
		                               description,
		                               parent.GetAccountTypeName(),
		                               parent,
		                               colour,
                                   hideInTree );
      
      acc.SetupIcon( m_accountTreeIconSize, false );

      // check we're not creating a duplicate
      if ( GetAccount( acc.GetQualifiedAccountName() ) != null )
      {
        throw new Exception( "KBook.CreateAccount() : Tried to create duplicate account." );
      }

      // does the parent have transactiosn? move them to the new account
      if ( parent.GetTransactions().Count > 0 )
      {
        foreach ( KTransaction t in parent.GetTransactions() )
        {
          acc.CreateTransaction( t.GetId(),
                                 t.GetTransactionType(),
                                 t.GetContraAccount(),
                                 t.GetAmount(),
                                 t.GetDate(),
                                 t.GetPeriod(),
                                 t.GetDescription(),
                                 t.IsAdjustment(),
                                 t.IsBudgetTransaction(),
                                 false,
                                 t.IsRecuring() );
        }
      }

      parent.ClearTransactions();

      // add new account to list
      m_account.Add( acc );
      
      // sort the accounts
      SortAccounts();
		}
		
		//---------------------------------------------------------------
		
		public void CreateTransaction( KAccount debitAccount,
                                   KAccount creditAccount,
                                   decimal amount,
                                   DateTime date,
                                   String description,
                                   bool isBudgetTransaction,
                                   bool isRecuring )
		{
      // find the period
      KPeriod period = null;

      foreach ( KPeriod p in m_period )
      {
        if ( p.DateInPeriod( date ) )
        {
          period = p;

          break;
        }
      }

      if ( period == null )
      {
        throw new Exception( "Date does not fall in any existing Period." );
      }
		  
      // issue transaction id
      uint id = KTransaction.IssueId();

      // create transactions in accounts
      debitAccount.CreateTransaction( id,
                                      KTransaction.TransactionType.c_debit,
                                      creditAccount,
                                      amount,
                                      date,
                                      period,
                                      description,
                                      false,
                                      isBudgetTransaction,
                                      false,
                                      isRecuring );

      creditAccount.CreateTransaction( id,
                                       KTransaction.TransactionType.c_credit,
                                       debitAccount,
                                       amount,
                                       date,
                                       period,
                                       description,
                                       false,
                                       isBudgetTransaction,
                                       true,
                                       isRecuring );
    }

		//---------------------------------------------------------------
		
		// Adjustment (one sided) transaction.
		
		public void CreateTransaction( KAccount account,
		                               KTransaction.TransactionType transactionType,
                                   decimal amount,
                                   DateTime date,
                                   String description,
                                   bool budgetTransaction,
                                   bool isRecuring )
		{
      // find the period
      KPeriod period = null;

      foreach ( KPeriod p in m_period )
      {
        if ( p.DateInPeriod( date ) )
        {
          period = p;

          break;
        }
      }

      if ( period == null )
      {
        throw new Exception( "Date does not fall in any existing Period." );
      }
		  
      // issue transaction id
      uint id = KTransaction.IssueId();

      // create transaction in the account
      account.CreateTransaction( id,
                                 transactionType,
                                 account,
                                 amount,
                                 date,
                                 period,
                                 description,
                                 true,
                                 budgetTransaction,
                                 false,
                                 isRecuring );
    }

  	//---------------------------------------------------------------

    public void DeleteTransaction( uint id )
    {
      // loop through accounts
      foreach ( KAccount a in m_account )
      {
        a.DeleteTransaction( id, false );
      }
    }

    //---------------------------------------------------------------

    public ArrayList GetTransaction( uint id )
    {
      ArrayList list = new ArrayList( 2 );

      // loop through accounts
      foreach ( KAccount account in m_account )
      {
        // loop though account's transactions
        foreach ( KTransaction t in account.GetTransactions() )
        {
          if ( t.GetId() == id )
          {
            list.Add( t );
          }
        }
      }

      return list;
    }

		//---------------------------------------------------------------

    public int GetTransactionCount()
    {
      int count = 0;

      // loop through accounts
      foreach ( KAccount account in m_account )
      {
        foreach( KTransaction transaction in account.GetTransactions() )
        {
          if( transaction.IsAdjustment() == false &&
              transaction.IsBudgetTransaction() == false &&
              transaction.GetTransactionType() == KTransaction.TransactionType.c_debit )
          {
            count++;
          }
        }
      }

      return count;
    }

    //---------------------------------------------------------------

		public ArrayList GetAccountList()
		{
		  return m_account;
		}

    //---------------------------------------------------------------

    public KAccount GetAccount( String qualifiedName )
    {
      // look for account with specified name
      foreach ( KAccount acc in m_account )
      {
        if ( acc.GetQualifiedAccountName().Equals( qualifiedName ) )
        {
          return acc;
        }
      }

      // not found?
      return null;
    }
		
		//---------------------------------------------------------------

		public void SetPeriodList( ArrayList periodList )
		{
		  m_period = periodList;
		}
		
		//---------------------------------------------------------------

		public ArrayList GetPeriodList()
		{
		  return m_period;
		}
		
		//---------------------------------------------------------------

    public String GetPeriodName( DateTime date )
    {
      // look for period for specified date
      foreach ( KPeriod p in m_period )
      {
        if ( p.DateInPeriod( date ) )
        {
          return p.ToString();
        }
      }

      // no period found?
      return null;
    }
    
    //---------------------------------------------------------------
    
    public ArrayList GetSummaryExpressionList()
    {
      return m_summaryExpression;
    }
    
    //---------------------------------------------------------------
    
    public KSummaryExpression GetSummaryExpression( String name )
    {
      IEnumerator expressions = m_summaryExpression.GetEnumerator();
      
      while ( expressions.MoveNext() )
      {
        KSummaryExpression expression = (KSummaryExpression)expressions.Current;
        
        if ( expression.GetName().Equals( name ) )
        {
          return expression;
        }
      }
      
      return null;
    }

    //---------------------------------------------------------------

    public void AddSummaryExpression( KSummaryExpression expression )
    {
      m_summaryExpression.Add( expression );
    }
    
    //---------------------------------------------------------------
    
    public String GetSetting( String name )
    {
      // doesn't exist?
      if ( m_setting.Contains( name ) == false )
      {
        return null;
      }
      
      // find and return value
      IDictionaryEnumerator e = m_setting.GetEnumerator();
      
      while ( e.MoveNext() )
      {
        if ( e.Key.Equals( name ) )
        {
          return (String)e.Value;
        }
      }
      
      return null;
    }
    
    //---------------------------------------------------------------
    
    public void SetSetting( String name, String value )
    {
      if ( m_setting.Contains( name ) )
      {
        m_setting.Remove( name );
      }
      
      m_setting.Add( name, value );
    }
    
    //---------------------------------------------------------------
    
    public void SetAccountTreeIconSize( Size size )
    {
      m_accountTreeIconSize = size;
    }
    
    //---------------------------------------------------------------
    
    public Size GetAccountTreeIconSize()
    {
      return m_accountTreeIconSize;
    }
    
    //---------------------------------------------------------------

    public void SetTransactionGridIconSize( Size size )
    {
      m_transactionGridIconSize = size;
    }
    
    //---------------------------------------------------------------
    
    public Size GetTransactionGridIconSize()
    {
      return m_transactionGridIconSize;
    }
    
    //---------------------------------------------------------------
	}
}
