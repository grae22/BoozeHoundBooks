using System.Xml;

namespace BoozeHoundBooks
{
    public class KTransaction
    {
        // class statics ------------------------------------------------
        private static uint m_nextTransactionId = 1;

        // class constants ----------------------------------------------
        public enum TransactionType
        {
            c_debit = 0,
            c_credit
        };

        // properties ---------------------------------------------------
        public bool IsBudget { get; set; }
        public KTagBag TagBag { get; private set; } = new KTagBag();

        // xml constants ------------------------------------------------
        private const string c_attrib_id = "Id";

        private const string c_attrib_type = "Type";
        private const string c_attrib_contra = "Contra";
        private const string c_attrib_amount = "Amount";
        private const string c_attrib_date = "Date";
        private const string c_attrib_description = "Description";
        private const string c_attrib_adjustment = "Adjustment";
        private const string c_attrib_budget = "Budget";
        private const string c_attrib_recurring = "Recurring";
        private const string c_attrib_recurringConfirmAmount = "RecurringConfirmAmount";
        private const string c_attrib_tags = "Tags";

        // class vars ---------------------------------------------------
        private uint m_id;

        private TransactionType m_type;
        private KAccount m_account;
        private KAccount m_contraAccount;
        private string m_contraQualifiedAccountName;
        private decimal m_amount;
        private DateTime m_date;
        private KPeriod m_period;
        private string m_description;
        private bool m_isAdjustment;
        private bool m_isRecurring;
        private bool m_isRecurringConfirmAmount;

        //---------------------------------------------------------------

        public static uint IssueId()
        {
            return m_nextTransactionId++;
        }

        //---------------------------------------------------------------

        public KTransaction(
          XmlElement element,
          KAccount account,
          IEnumerable<KPeriod> periods)
        {
            // grab from xml
            // id
            if (element.HasAttribute(c_attrib_id))
            {
                m_id = uint.Parse(element.GetAttribute(c_attrib_id));
            }
            else
            {
                throw new Exception("KTransaction.KTransaction() : Id attribute not found.");
            }

            // contra
            if (element.HasAttribute(c_attrib_contra))
            {
                m_contraQualifiedAccountName =
                  element.GetAttribute(c_attrib_contra).Replace(KAccount.c_accountLevelSeparatorInFile,
                    KAccount.c_accountLevelSeparator);
            }
            else
            {
                throw new Exception("KTransaction.KTransaction() : Contra Account attribute not found.");
            }

            // type
            if (element.HasAttribute(c_attrib_type))
            {
                m_type = (TransactionType)Enum.Parse(typeof(TransactionType), element.GetAttribute(c_attrib_type));
            }
            else
            {
                throw new Exception("KTransaction.KTransaction() : Type attribute not found.");
            }

            // amount
            if (element.HasAttribute(c_attrib_amount))
            {
                m_amount = decimal.Parse(element.GetAttribute(c_attrib_amount));
            }
            else
            {
                throw new Exception("KTransaction.KTransaction() : Amount attribute not found.");
            }

            // date
            if (element.HasAttribute(c_attrib_date))
            {
                m_date = DateTime.Parse(element.GetAttribute(c_attrib_date));
            }
            else
            {
                throw new Exception("KTransaction.KTransaction() : Date attribute not found.");
            }

            // description
            if (element.HasAttribute(c_attrib_description))
            {
                m_description = element.GetAttribute(c_attrib_description);
            }
            else
            {
                m_description = "";
            }

            // adjustment?
            if (element.HasAttribute(c_attrib_adjustment))
            {
                m_isAdjustment = true;
            }
            else
            {
                m_isAdjustment = false;
            }

            // budget transaction
            if (element.HasAttribute(c_attrib_budget))
            {
                IsBudget = true;
            }
            else
            {
                IsBudget = false;
            }

            // recurring?
            m_isRecurring = element.HasAttribute(c_attrib_recurring);
            m_isRecurringConfirmAmount = element.HasAttribute(c_attrib_recurringConfirmAmount);

            // tags
            if (element.HasAttribute(c_attrib_tags))
            {
                string tagsCsv = element.GetAttribute(c_attrib_tags);

                TagBag.Deserialise(tagsCsv);
            }

            // set class vars
            m_account = account;

            // update next id
            if (m_id >= m_nextTransactionId)
            {
                m_nextTransactionId = m_id + 1;
            }

            // period
            foreach (KPeriod p in periods)
            {
                if (p.DateInPeriod(m_date))
                {
                    m_period = p;

                    break;
                }
            }

            if (m_period == null)
            {
                throw new Exception("No period found for date.");
            }
        }

        //---------------------------------------------------------------

        public KTransaction(uint id,
          TransactionType type,
          KAccount account,
          KAccount contraAccount,
          decimal amount,
          DateTime date,
          KPeriod period,
          string description,
          bool isAdjustment,
          bool isBudgetTransaction,
          bool isRecurring,
          bool isRecurringConfirmAmount,
          string[] tags)
        {
            // set class vars
            m_id = id;
            m_type = type;
            m_account = account;
            m_contraAccount = contraAccount;
            m_contraQualifiedAccountName = m_contraAccount.GetQualifiedAccountName();
            m_amount = amount;
            m_date = date;
            m_period = period;
            m_description = description;
            m_isAdjustment = isAdjustment;
            IsBudget = isBudgetTransaction;
            m_isRecurring = isRecurring;
            m_isRecurringConfirmAmount = isRecurringConfirmAmount;

            // update next id
            if (m_id >= m_nextTransactionId)
            {
                m_nextTransactionId = m_id + 1;
            }

            foreach (var t in tags)
            {
                TagBag.Add(t);
            }
        }

        //---------------------------------------------------------------

        public XmlElement GetXml(XmlElement element)
        {
            element.SetAttribute(c_attrib_id, "" + m_id);
            element.SetAttribute(c_attrib_type, "" + m_type);
            element.SetAttribute(c_attrib_contra,
              GetContraQualifiedAccountName()
                .Replace(KAccount.c_accountLevelSeparator, KAccount.c_accountLevelSeparatorInFile));
            element.SetAttribute(c_attrib_amount, "" + m_amount);
            element.SetAttribute(c_attrib_date, m_date.ToString("yyyy/MM/dd"));

            if (m_description.Equals("") == false)
            {
                element.SetAttribute(c_attrib_description, m_description);
            }

            if (m_isAdjustment)
            {
                element.SetAttribute(c_attrib_adjustment, "");
            }

            if (IsBudget)
            {
                element.SetAttribute(c_attrib_budget, "");
            }

            if (m_isRecurring)
            {
                element.SetAttribute(c_attrib_recurring, "");
            }

            if (m_isRecurringConfirmAmount)
            {
                element.SetAttribute(c_attrib_recurringConfirmAmount, "");
            }

            if (TagBag.Count > 0)
            {
                element.SetAttribute(c_attrib_tags, TagBag.Serialise());
            }

            return element;
        }

        //---------------------------------------------------------------

        public uint GetId()
        {
            return m_id;
        }

        //---------------------------------------------------------------

        public TransactionType GetTransactionType()
        {
            return m_type;
        }

        //---------------------------------------------------------------

        public KAccount GetAccount()
        {
            return m_account;
        }

        //---------------------------------------------------------------

        public KAccount GetContraAccount()
        {
            return m_contraAccount;
        }

        //---------------------------------------------------------------

        public void SetContraAccount(KAccount contra)
        {
            m_contraAccount = contra;
            m_contraQualifiedAccountName = m_contraAccount.GetQualifiedAccountName();
        }

        //---------------------------------------------------------------

        public string GetContraQualifiedAccountName()
        {
            if (m_contraAccount == null)
            {
                return m_contraQualifiedAccountName;
            }
            else
            {
                m_contraQualifiedAccountName = m_contraAccount.GetQualifiedAccountName();

                return m_contraAccount.GetQualifiedAccountName();
            }
        }

        //---------------------------------------------------------------

        public decimal GetAmount()
        {
            return m_amount;
        }

        //---------------------------------------------------------------

        public decimal GetSignedAmount()
        {
            if (m_type == TransactionType.c_debit)
            {
                return m_amount * -1m;
            }
            else
            {
                return m_amount;
            }
        }

        //---------------------------------------------------------------

        public DateTime GetDate()
        {
            return m_date.Date;
        }

        //---------------------------------------------------------------

        public string GetDescription()
        {
            return m_description;
        }

        //---------------------------------------------------------------

        public KPeriod GetPeriod()
        {
            return m_period;
        }

        //---------------------------------------------------------------

        public bool IsAdjustment()
        {
            return m_isAdjustment;
        }

        //---------------------------------------------------------------

        public bool IsRecurring()
        {
            return m_isRecurring;
        }

        //---------------------------------------------------------------

        public bool IsRecurringConfirmAmount()
        {
            return m_isRecurringConfirmAmount;
        }

        //---------------------------------------------------------------
    }
}