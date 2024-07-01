using System.Xml;
using System.Collections;

namespace BoozeHoundBooks
{
    public class KBook
    {
        //---------------------------------------------------------------

        public const string c_setting_setTransactionGridBg = "SetTransactionGridBg";
        public const string c_setting_setTransactionGridBgWithAccount = "SetTransactionGridBgWithAccount";

        private string m_path;
        private List<KAccount> m_accounts = new List<KAccount>();
        private List<KPeriod> m_periods = new List<KPeriod>();
        private Hashtable m_settings = new Hashtable(10);
        private List<KSummaryExpression> m_summaryExpressions = new List<KSummaryExpression>();

        private Size m_accountTreeIconSize = new Size(20, 20);
        private Size m_transactionGridIconSize = new Size(16, 16);

        //---------------------------------------------------------------

        public KBook(string path, bool newBook)
        {
            // set class vars
            m_path = path;

            // clear out account icons
            KAccount.m_iconList.Images.Clear();

            // create base account types
            if (newBook)
            {
                foreach (string s in KAccount.m_accountTypeName)
                {
                    KAccount acc = new KAccount(s, s, s, null, Color.FromName(KAccount.c_noColourName), false);

                    acc.SetupIcon(m_accountTreeIconSize, false);

                    m_accounts.Add(acc);
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
            if (File.Exists(m_path) == false)
            {
                return;
            }

            // load xml doc
            XmlDocument doc = new XmlDocument();

            doc.Load(m_path);

            // load settings
            var settingList = doc
              .SelectNodes("Book/Settings/Setting")
              .OfType<XmlElement>();

            foreach (XmlElement settingNode in settingList)
            {
                m_settings.Add(settingNode.GetAttribute("Name"), settingNode.GetAttribute("Value"));
            }

            // load periods
            var periodList = doc
              .SelectNodes("Book/PeriodList/Period")
              .OfType<XmlElement>();

            foreach (XmlElement periodNode in periodList)
            {
                KPeriod period = new KPeriod(periodNode);

                m_periods.Add(period);
            }

            // load accounts
            var accounts = doc
              .SelectNodes("Book/AccountList/MasterAccount")
              .OfType<XmlElement>();

            foreach (XmlElement account in accounts)
            {
                LoadAccountFromXml(account, null);
            }

            // update account transactions with contra-accounts
            // now that all accounts are loaded.
            foreach (KAccount a in m_accounts)
            {
                a.UpdateTransactionsWithContraAccounts(m_accounts);
                a.SetupIcon(m_accountTreeIconSize, false);
            }

            // load summary fields
            var summaryExpression = doc
              .SelectNodes("Book/SummaryExpressionList/SummaryExpression")
              .OfType<XmlElement>();

            foreach (XmlElement e in summaryExpression)
            {
                KSummaryExpression expression = new KSummaryExpression(e, this);

                m_summaryExpressions.Add(expression);
            }
        }

        //---------------------------------------------------------------

        private void LoadAccountFromXml(XmlElement element, KAccount parent)
        {
            // load the account
            KAccount acc = new KAccount(element, parent, m_periods);

            m_accounts.Add(acc);

            // does it have any sub accounts? load them too
            XmlNodeList list = element.SelectNodes("./Account");

            foreach (XmlElement e in list)
            {
                LoadAccountFromXml(e, acc);
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

                XmlElement bookElement = doc.CreateElement("Book");

                doc.AppendChild(bookElement);

                // add settings
                XmlElement settingListElement = doc.CreateElement("Settings");

                bookElement.AppendChild(settingListElement);

                IDictionaryEnumerator settingEnum = m_settings.GetEnumerator();

                while (settingEnum.MoveNext())
                {
                    // create element
                    XmlElement settingElement = doc.CreateElement("Setting");

                    settingElement.SetAttribute("Name", (String)settingEnum.Key);
                    settingElement.SetAttribute("Value", (String)settingEnum.Value);

                    // add to book
                    settingListElement.AppendChild(settingElement);
                }

                // add summary expressions
                XmlElement summaryExpressionElement = doc.CreateElement("SummaryExpressionList");

                bookElement.AppendChild(summaryExpressionElement);

                foreach (KSummaryExpression expression in m_summaryExpressions)
                {
                    // create expression element
                    XmlElement expressionElement = doc.CreateElement("SummaryExpression");

                    // get period xml
                    expression.GetXml(expressionElement);

                    // add period xml to book
                    summaryExpressionElement.AppendChild(expressionElement);
                }

                // add periods
                XmlElement periodListElement = doc.CreateElement("PeriodList");

                bookElement.AppendChild(periodListElement);

                foreach (KPeriod period in m_periods)
                {
                    // create period element
                    XmlElement periodElement = doc.CreateElement("Period");

                    // get period xml
                    period.GetXml(periodElement);

                    // add period xml to book
                    periodListElement.AppendChild(periodElement);
                }

                // add accounts
                XmlElement accListElement = doc.CreateElement("AccountList");

                bookElement.AppendChild(accListElement);

                foreach (KAccount acc in m_accounts)
                {
                    // create master account elements
                    if (acc.GetParent() == null)
                    {
                        XmlElement accountElement = doc.CreateElement("MasterAccount");

                        // get account xml
                        accountElement = acc.GetXml(accountElement);

                        // add children
                        accountElement = AddChildAccountsToXml(doc, accountElement, acc);

                        // add account xml to book
                        accListElement.AppendChild(accountElement);
                    }
                }

                // save the xml doc
                doc.Save(m_path);

                // write zip
                var compressedPath = m_path.Replace(Path.GetExtension(m_path), ".zip");

                KCompressedFileWriter.WriteFile(
                  compressedPath,
                  "Backup.bhb",
                  File.ReadAllText(m_path));

                // success
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //---------------------------------------------------------------

        private XmlElement AddChildAccountsToXml(XmlDocument doc, XmlElement element, KAccount account)
        {
            foreach (KAccount child in account.GetChildren(false))
            {
                XmlElement childElement = doc.CreateElement("Account");

                childElement = child.GetXml(childElement);

                childElement = AddChildAccountsToXml(doc, childElement, child);

                element.AppendChild(childElement);
            }

            return element;
        }

        //---------------------------------------------------------------

        private void SortAccounts()
        {
            // sort the accounts, but keep master accounts at the top of the list
            bool keepSorting;

            m_accounts.Sort();

            do
            {
                keepSorting = false;

                // loop through accounts
                foreach (KAccount a in m_accounts)
                {
                    // is a master account?
                    if (a.IsMasterAccount())
                    {
                        // not where it should be in the list?
                        if (m_accounts.IndexOf(a) != a.GetAccountType())
                        {
                            // move it to where it should be
                            m_accounts.Remove(a);
                            m_accounts.Insert(a.GetAccountType(), a);

                            // keep sorting
                            keepSorting = true;
                            break;
                        }
                    }
                }
            } while (keepSorting);
        }

        //---------------------------------------------------------------

        public void CreateAccount(string name,
          string description,
          KAccount parent,
          Color colour,
          bool hideInTree)
        {
            // create the account
            KAccount acc = new KAccount(name,
              description,
              parent.GetAccountTypeName(),
              parent,
              colour,
              hideInTree);

            acc.SetupIcon(m_accountTreeIconSize, false);

            // check we're not creating a duplicate
            if (GetAccount(acc.GetQualifiedAccountName()) != null)
            {
                throw new Exception("KBook.CreateAccount() : Tried to create duplicate account.");
            }

            // does the parent have transactiosn? move them to the new account
            if (parent.GetTransactions().Any())
            {
                foreach (KTransaction t in parent.GetTransactions())
                {
                    acc.CreateTransaction(t.GetId(),
                      t.GetTransactionType(),
                      t.GetContraAccount(),
                      t.GetAmount(),
                      t.GetDate(),
                      t.GetPeriod(),
                      t.GetDescription(),
                      t.IsAdjustment(),
                      t.IsBudget,
                      false,
                      t.IsRecurring(),
                      t.IsRecurringConfirmAmount());
                }
            }

            parent.ClearTransactions();

            // add new account to list
            m_accounts.Add(acc);

            // sort the accounts
            SortAccounts();
        }

        //---------------------------------------------------------------

        public void CreateTransaction(KAccount debitAccount,
          KAccount creditAccount,
          decimal amount,
          DateTime date,
          string description,
          bool isBudgetTransaction,
          bool isRecurring,
          bool isRecurringConfirmAmount)
        {
            // find the period
            KPeriod period = null;

            foreach (KPeriod p in m_periods)
            {
                if (p.DateInPeriod(date))
                {
                    period = p;

                    break;
                }
            }

            if (period == null)
            {
                throw new Exception("Date does not fall in any existing Period.");
            }

            // issue transaction id
            uint id = KTransaction.IssueId();

            // create transactions in accounts
            debitAccount.CreateTransaction(id,
              KTransaction.TransactionType.c_debit,
              creditAccount,
              amount,
              date,
              period,
              description,
              false,
              isBudgetTransaction,
              false,
              isRecurring,
              isRecurringConfirmAmount);

            creditAccount.CreateTransaction(id,
              KTransaction.TransactionType.c_credit,
              debitAccount,
              amount,
              date,
              period,
              description,
              false,
              isBudgetTransaction,
              true,
              isRecurring,
              isRecurringConfirmAmount);
        }

        //---------------------------------------------------------------

        // Adjustment (one sided) transaction.

        public void CreateTransaction(KAccount account,
          KTransaction.TransactionType transactionType,
          decimal amount,
          DateTime date,
          string description,
          bool budgetTransaction,
          bool isRecurring,
          bool isRecurringConfirmAmount)
        {
            // find the period
            KPeriod period = null;

            foreach (KPeriod p in m_periods)
            {
                if (p.DateInPeriod(date))
                {
                    period = p;

                    break;
                }
            }

            if (period == null)
            {
                throw new Exception("Date does not fall in any existing Period.");
            }

            // issue transaction id
            uint id = KTransaction.IssueId();

            // create transaction in the account
            account.CreateTransaction(id,
              transactionType,
              account,
              amount,
              date,
              period,
              description,
              true,
              budgetTransaction,
              false,
              isRecurring,
              isRecurringConfirmAmount);
        }

        //---------------------------------------------------------------

        public void DeleteTransaction(uint id)
        {
            // loop through accounts
            foreach (KAccount a in m_accounts)
            {
                a.DeleteTransaction(id, false);
            }
        }

        //---------------------------------------------------------------

        public IEnumerable<KTransaction> GetTransaction(uint id)
        {
            var list = new List<KTransaction>();

            // loop through accounts
            foreach (KAccount account in m_accounts)
            {
                // loop though account's transactions
                foreach (KTransaction t in account.GetTransactions())
                {
                    if (t.GetId() == id)
                    {
                        list.Add(t);
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
            foreach (KAccount account in m_accounts)
            {
                foreach (KTransaction transaction in account.GetTransactions())
                {
                    if (transaction.IsAdjustment() == false &&
                        transaction.IsBudget == false &&
                        transaction.GetTransactionType() == KTransaction.TransactionType.c_debit)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        //---------------------------------------------------------------

        public IEnumerable<KTransaction> GetTransactionsForPeriod(KPeriod period)
        {
            var transactions = new List<KTransaction>();

            m_accounts
              .ForEach(a => KAccount.GetTransactionsForPeriodRecursive(
                a,
                period,
                transactions));

            return transactions;
        }

        //---------------------------------------------------------------

        public IEnumerable<KAccount> GetAccountList()
        {
            return m_accounts;
        }

        //---------------------------------------------------------------

        public KAccount GetAccount(string qualifiedName)
        {
            // look for account with specified name
            foreach (KAccount acc in m_accounts)
            {
                if (acc.GetQualifiedAccountName().Equals(qualifiedName))
                {
                    return acc;
                }
            }

            // not found?
            return null;
        }

        //---------------------------------------------------------------

        public void SetPeriodList(IEnumerable<KPeriod> periodList)
        {
            m_periods = periodList.ToList();
        }

        //---------------------------------------------------------------

        public IEnumerable<KPeriod> GetPeriodList()
        {
            return m_periods;
        }

        //---------------------------------------------------------------

        public string GetPeriodName(DateTime date)
        {
            // look for period for specified date
            foreach (KPeriod p in m_periods)
            {
                if (p.DateInPeriod(date))
                {
                    return p.ToString();
                }
            }

            // no period found?
            return null;
        }

        //---------------------------------------------------------------

        public KPeriod GetPeriodForDate(DateTime date)
        {
            return m_periods.FirstOrDefault(p => p.DateInPeriod(date));
        }

        //---------------------------------------------------------------

        public IEnumerable<KSummaryExpression> GetSummaryExpressionList()
        {
            return m_summaryExpressions;
        }

        //---------------------------------------------------------------

        public KSummaryExpression GetSummaryExpression(string name)
        {
            IEnumerator expressions = m_summaryExpressions.GetEnumerator();

            while (expressions.MoveNext())
            {
                KSummaryExpression expression = (KSummaryExpression)expressions.Current;

                if (expression.GetName().Equals(name))
                {
                    return expression;
                }
            }

            return null;
        }

        //---------------------------------------------------------------

        public void AddSummaryExpression(KSummaryExpression expression)
        {
            m_summaryExpressions.Add(expression);
        }

        //---------------------------------------------------------------

        public string GetSetting(string name)
        {
            // doesn't exist?
            if (m_settings.Contains(name) == false)
            {
                return null;
            }

            // find and return value
            IDictionaryEnumerator e = m_settings.GetEnumerator();

            while (e.MoveNext())
            {
                if (e.Key.Equals(name))
                {
                    return (String)e.Value;
                }
            }

            return null;
        }

        //---------------------------------------------------------------

        public void SetSetting(string name, string value)
        {
            if (m_settings.Contains(name))
            {
                m_settings.Remove(name);
            }

            m_settings.Add(name, value);
        }

        //---------------------------------------------------------------

        public void SetAccountTreeIconSize(Size size)
        {
            m_accountTreeIconSize = size;
        }

        //---------------------------------------------------------------

        public Size GetAccountTreeIconSize()
        {
            return m_accountTreeIconSize;
        }

        //---------------------------------------------------------------

        public void SetTransactionGridIconSize(Size size)
        {
            m_transactionGridIconSize = size;
        }

        //---------------------------------------------------------------

        public Size GetTransactionGridIconSize()
        {
            return m_transactionGridIconSize;
        }

        //---------------------------------------------------------------

        public Dictionary<KAccount, Dictionary<KPeriod, OpeningAndClosingBalances>> GetAccountBalancesByPeriod(bool useBudget)
        {
            var balances = new Dictionary<KAccount, Dictionary<KPeriod, OpeningAndClosingBalances>>();

            m_accounts.ForEach(a => balances.Add(a, new Dictionary<KPeriod, OpeningAndClosingBalances>()));

            KPeriod previousPeriod = null;

            foreach (var period in m_periods)
            {
                foreach (var account in m_accounts)
                {
                    decimal openingBalance = 0;
                    decimal closingBalance = 0;

                    if (account.GetAccountType() != KAccount.c_bank &&
                        account.GetAccountType() != KAccount.c_debt &&
                        account.GetAccountType() != KAccount.c_credit)
                    {
                        closingBalance = account.GetBalance(period.GetStart(), period.GetEnd(), useBudget);
                    }
                    else
                    {
                        closingBalance = account.GetBalance(period.GetEnd(), useBudget);
                    }

                    if (previousPeriod != null)
                    {
                        openingBalance = balances[account][previousPeriod].ClosingBalance;
                    }

                    var periodBalances = new OpeningAndClosingBalances(openingBalance, closingBalance);

                    balances[account].Add(period, periodBalances);
                }

                previousPeriod = period;
            }

            return balances;
        }

        //---------------------------------------------------------------
    }
}