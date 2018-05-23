using System;
using System.Xml;
using System.Collections;

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

    // xml constants ------------------------------------------------
    private const String c_attrib_id = "Id";

    private const String c_attrib_type = "Type";
    private const String c_attrib_contra = "Contra";
    private const String c_attrib_amount = "Amount";
    private const String c_attrib_date = "Date";
    private const String c_attrib_description = "Description";
    private const String c_attrib_adjustment = "Adjustment";
    private const String c_attrib_budget = "Budget";
    private const String c_attrib_recuring = "Recuring";

    // class vars ---------------------------------------------------
    private uint m_id;

    private TransactionType m_type;
    private KAccount m_account;
    private KAccount m_contraAccount;
    private String m_contraQualifiedAccountName;
    private decimal m_amount;
    private DateTime m_date;
    private KPeriod m_period;
    private String m_description;
    private bool m_isAdjustment;
    private bool m_isBudgetTransaction;
    private bool m_isRecuring;

    //---------------------------------------------------------------

    public static uint IssueId()
    {
      return m_nextTransactionId++;
    }

    //---------------------------------------------------------------

    public KTransaction(XmlElement element,
      KAccount account,
      ArrayList periods)
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
        m_type = (TransactionType) Enum.Parse(typeof(TransactionType), element.GetAttribute(c_attrib_type));
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
        m_isBudgetTransaction = true;
      }
      else
      {
        m_isBudgetTransaction = false;
      }

      // recuring?
      m_isRecuring = element.HasAttribute(c_attrib_recuring);

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
      String description,
      bool isAdjustment,
      bool isBudgetTransaction,
      bool isRecuring)
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
      m_isBudgetTransaction = isBudgetTransaction;
      m_isRecuring = isRecuring;

      // update next id
      if (m_id >= m_nextTransactionId)
      {
        m_nextTransactionId = m_id + 1;
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

      if (m_isBudgetTransaction)
      {
        element.SetAttribute(c_attrib_budget, "");
      }

      if (m_isRecuring)
      {
        element.SetAttribute(c_attrib_recuring, "");
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

    public String GetContraQualifiedAccountName()
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

    public String GetDescription()
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

    public bool IsBudgetTransaction()
    {
      return m_isBudgetTransaction;
    }

    //---------------------------------------------------------------

    public bool IsRecuring()
    {
      return m_isRecuring;
    }

    //---------------------------------------------------------------
  }
}