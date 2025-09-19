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
        private string m_contraQualifiedAccountName;
        private DateTime m_date;

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
                Id = uint.Parse(element.GetAttribute(c_attrib_id));
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
                TransType = (TransactionType)Enum.Parse(typeof(TransactionType), element.GetAttribute(c_attrib_type));
            }
            else
            {
                throw new Exception("KTransaction.KTransaction() : Type attribute not found.");
            }

            // amount
            if (element.HasAttribute(c_attrib_amount))
            {
                Amount = decimal.Parse(element.GetAttribute(c_attrib_amount));
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
                Description = element.GetAttribute(c_attrib_description);
            }
            else
            {
                Description = "";
            }

            // adjustment?
            if (element.HasAttribute(c_attrib_adjustment))
            {
                IsAdjustment = true;
            }
            else
            {
                IsAdjustment = false;
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
            IsRecurring = element.HasAttribute(c_attrib_recurring);
            IsRecurringConfirmAmount = element.HasAttribute(c_attrib_recurringConfirmAmount);

            // tags
            if (element.HasAttribute(c_attrib_tags))
            {
                string tagsCsv = element.GetAttribute(c_attrib_tags);

                TagBag.Deserialise(tagsCsv);
            }

            // set class vars
            Account = account;

            // update next id
            if (Id >= m_nextTransactionId)
            {
                m_nextTransactionId = Id + 1;
            }

            // period
            foreach (KPeriod p in periods)
            {
                if (p.DateInPeriod(m_date))
                {
                    Period = p;

                    break;
                }
            }

            if (Period == null)
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
            Id = id;
            TransType = type;
            Account = account;
            ContraAccount = contraAccount;
            m_contraQualifiedAccountName = ContraAccount.GetQualifiedAccountName();
            Amount = amount;
            m_date = date;
            Period = period;
            Description = description;
            IsAdjustment = isAdjustment;
            IsBudget = isBudgetTransaction;
            IsRecurring = isRecurring;
            IsRecurringConfirmAmount = isRecurringConfirmAmount;

            // update next id
            if (Id >= m_nextTransactionId)
            {
                m_nextTransactionId = Id + 1;
            }

            foreach (var t in tags)
            {
                TagBag.Add(t);
            }
        }

        //---------------------------------------------------------------

        public XmlElement GetXml(XmlElement element)
        {
            element.SetAttribute(c_attrib_id, "" + Id);
            element.SetAttribute(c_attrib_type, "" + TransType);
            element.SetAttribute(c_attrib_contra,
              GetContraQualifiedAccountName()
                .Replace(KAccount.c_accountLevelSeparator, KAccount.c_accountLevelSeparatorInFile));
            element.SetAttribute(c_attrib_amount, "" + Amount);
            element.SetAttribute(c_attrib_date, m_date.ToString("yyyy/MM/dd"));

            if (Description.Length > 0)
            {
                element.SetAttribute(c_attrib_description, Description);
            }

            if (IsAdjustment)
            {
                element.SetAttribute(c_attrib_adjustment, "");
            }

            if (IsBudget)
            {
                element.SetAttribute(c_attrib_budget, "");
            }

            if (IsRecurring)
            {
                element.SetAttribute(c_attrib_recurring, "");
            }

            if (IsRecurringConfirmAmount)
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

        public uint Id { get; private set; }

        //---------------------------------------------------------------

        public TransactionType TransType { get; private set; }

        //---------------------------------------------------------------

        public KAccount Account { get; private set; }

        //---------------------------------------------------------------

        public KAccount ContraAccount { get; private set; }

        //---------------------------------------------------------------

        public void SetContraAccount(KAccount contra)
        {
            ContraAccount = contra;
            m_contraQualifiedAccountName = ContraAccount.GetQualifiedAccountName();
        }

        //---------------------------------------------------------------

        public string GetContraQualifiedAccountName()
        {
            if (ContraAccount == null)
            {
                return m_contraQualifiedAccountName;
            }
            else
            {
                m_contraQualifiedAccountName = ContraAccount.GetQualifiedAccountName();

                return ContraAccount.GetQualifiedAccountName();
            }
        }

        //---------------------------------------------------------------

        public decimal Amount { get; private set; }

        //---------------------------------------------------------------

        public decimal GetSignedAmount()
        {
            if (TransType == TransactionType.c_debit)
            {
                return Amount * -1m;
            }
            else
            {
                return Amount;
            }
        }

        //---------------------------------------------------------------

        public DateTime Date => m_date.Date;

        //---------------------------------------------------------------

        public string Description { get; private set; }

        //---------------------------------------------------------------

        public KPeriod Period { get; private set; }

        //---------------------------------------------------------------

        public bool IsAdjustment { get; private set; }

        //---------------------------------------------------------------

        public bool IsRecurring { get; private set; }

        //---------------------------------------------------------------

        public bool IsRecurringConfirmAmount { get; private set; }

        //---------------------------------------------------------------
    }
}