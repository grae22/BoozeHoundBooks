﻿using System.Xml;
using System.Reflection;
using System.Drawing.Imaging;
using System.Text;

namespace BoozeHoundBooks
{
    public class KAccount : IComparable
    {
        // static vars --------------------------------------------------
        public static ImageList m_iconList = new ImageList();

        // class constants ----------------------------------------------

        // misc
        public const char c_accountLevelSeparator = '>';

        public const char c_accountLevelSeparatorInFile = '|';
        public const string c_noColourName = "White";

        // account types
        public const byte c_unknown = 0;

        public const byte c_bank = 1;
        public const byte c_income = 2;
        public const byte c_expense = 3;
        public const byte c_debt = 4;
        public const byte c_credit = 5;

        // account type names
        public static readonly string[] m_accountTypeName =
        {
      "Unknown",
      "Bank",
      "Income",
      "Expense",
      "Debt",
      "Credit"
    };

        public TreeNode TreeNode => m_treeNode;

        // xml attrib constants
        private const string c_attrib_name = "Name";

        private const string c_attrib_description = "Description";
        private const string c_attrib_type = "AccountType"; // type name (not id)
        private const string c_attrib_colour = "Colour";
        private const string c_attrib_treeNodeExpanded = "TreeNodeExpanded";
        private const string c_attrib_lastTransContraName = "LastTransactionContra";
        private const string c_attrib_hideInTree = "HideInTree";

        // class static vars --------------------------------------------

        // class vars ---------------------------------------------------
        private string Name
        {
            get
            {
                return __name;
            }

            set
            {
                _nameHasChanged = true;
                __name = value;
            }
        }

        private string __name;
        private bool _nameHasChanged;
        private string _cachedQualifiedName;

        private string m_description;
        private byte m_type;
        private KAccount m_parent;
        private List<KAccount> m_children = new List<KAccount>();
        private List<KTransaction> m_transaction = new List<KTransaction>();
        private int m_iconId = -1;
        private Color m_colour = Color.FromName(c_noColourName);
        private string m_iconName;
        private KScaledImage m_icon;
        private bool m_treeNodeExpanded;
        private TreeNode m_treeNode;
        private string m_lastTransactionContraName;

        //---------------------------------------------------------------

        // Loading an existing account.

        public KAccount(
          XmlElement element,
          KAccount parent,
          IEnumerable<KPeriod> periods)
        {
            // load info from element
            // name
            if (element.HasAttribute(c_attrib_name))
            {
                Name = element.GetAttribute(c_attrib_name);
            }
            else
            {
                throw new Exception("KAccount.KAccount() : Name attribute not found.");
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

            // type
            if (parent == null)
            {
                if (element.HasAttribute(c_attrib_type))
                {
                    m_type = GetTypeIdFromName(element.GetAttribute(c_attrib_type));
                }
                else
                {
                    throw new Exception("KAccount.KAccount() : Type attribute not found.");
                }
            }
            else
            {
                m_type = parent.GetAccountType();
            }

            // colour
            if (element.HasAttribute(c_attrib_colour))
            {
                m_colour = KCommon.GetColourFromRgbString(element.GetAttribute(c_attrib_colour));
            }
            else
            {
                m_colour = Color.FromName(c_noColourName);
            }

            // icon
            m_iconId = -1;
            m_iconName = null;
            m_icon = null;

            // tree node expanded
            if (element.HasAttribute(c_attrib_treeNodeExpanded))
            {
                m_treeNodeExpanded = true;
            }
            else
            {
                m_treeNodeExpanded = false;
            }

            // last transaction contra account
            if (element.HasAttribute(c_attrib_lastTransContraName))
            {
                m_lastTransactionContraName =
                  element.GetAttribute(c_attrib_lastTransContraName).Replace(
                    c_accountLevelSeparatorInFile, c_accountLevelSeparator);
            }

            // hide in tree
            if (element.HasAttribute(c_attrib_hideInTree))
            {
                HideInTree = bool.Parse(element.Attributes[c_attrib_hideInTree].Value);
            }

            // parent
            m_parent = parent;

            if (parent != null)
            {
                parent.AddChild(this);
            }

            // load transactions
            if (element.GetElementsByTagName("Account").Count == 0)
            {
                XmlNodeList transactions = element.GetElementsByTagName("Transaction");

                foreach (XmlElement e in transactions)
                {
                    KTransaction trans = new KTransaction(e, this, periods);

                    m_transaction.Add(trans);
                }
            }
        }

        //---------------------------------------------------------------

        // Creating a new account.

        public KAccount(string name,
          string description,
          string typeName,
          KAccount parent,
          Color colour,
          bool hideInTree)
        {
            Name = name;
            m_description = description;
            m_type = GetTypeIdFromName(typeName);
            m_parent = parent;
            m_colour = colour;
            m_iconName = null;
            m_treeNodeExpanded = true;
            HideInTree = hideInTree;

            // create the icon from resource
            try
            {
                m_icon = new KScaledImage(KCommon.CreateImageFromResource(Assembly.GetExecutingAssembly(), m_iconName));
            }
            catch (Exception e)
            {
                if (e != null) // just to kill warnings (unused var)
                    m_icon = null;
            }

            // add this node to parent's child list
            if (parent != null)
            {
                parent.AddChild(this);
            }
        }

        //---------------------------------------------------------------

        override public string ToString()
        {
            if (IsMasterAccount())
            {
                return Name;
            }

            var parents = string.Empty;
            KAccount p = m_parent;

            do
            {
                parents = $"{p.GetAccountName()} {c_accountLevelSeparator} {parents}";

                p = p.GetParent();

            } while (p != null);

            return $"{parents}{Name}";
        }

        //---------------------------------------------------------------

        public int CompareTo(object obj)
        {
            if (obj is KAccount)
            {
                KAccount a = (KAccount)obj;

                return GetQualifiedAccountName().CompareTo(a.GetQualifiedAccountName());
            }
            else
            {
                throw new ArgumentException("Object is not a KAccount.");
            }
        }

        //---------------------------------------------------------------

        public static byte GetTypeIdFromName(string name)
        {
            // loop through type names to find the type id
            for (byte i = 0; i < m_accountTypeName.Length; i++)
            {
                // found the type name?
                if (m_accountTypeName[i].Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    // set the id & stop looking
                    return i;
                }
            }

            return c_unknown;
        }

        //---------------------------------------------------------------

        public XmlElement GetXml(XmlElement element)
        {
            // account xml
            // name
            element.SetAttribute(c_attrib_name, Name);

            // description
            if (m_description.Equals("") == false)
            {
                element.SetAttribute(c_attrib_description, m_description);
            }

            // type
            if (m_parent == null)
            {
                element.SetAttribute(c_attrib_type, GetAccountTypeName());
            }

            // colour
            if (m_colour != Color.FromName(c_noColourName))
            {
                element.SetAttribute(c_attrib_colour, KCommon.GetRgbString(m_colour));
            }

            // tree node expanded
            if (m_treeNodeExpanded)
            {
                element.SetAttribute(c_attrib_treeNodeExpanded, "");
            }

            // last transaction contra account
            if (m_lastTransactionContraName != null)
            {
                element.SetAttribute(
                  c_attrib_lastTransContraName,
                  m_lastTransactionContraName.Replace(c_accountLevelSeparator,
                    c_accountLevelSeparatorInFile));
            }

            // hide in tree
            element.SetAttribute(c_attrib_hideInTree, HideInTree.ToString());

            // transactions
            foreach (KTransaction trans in m_transaction)
            {
                XmlElement e = element.OwnerDocument.CreateElement("Transaction");

                element.AppendChild(trans.GetXml(e));
            }

            return element;
        }

        //---------------------------------------------------------------

        public bool IsMasterAccount()
        {
            return m_parent == null ? true : false;
        }

        //---------------------------------------------------------------

        public string GetAccountName()
        {
            return Name;
        }

        //---------------------------------------------------------------

        public void SetAccountName(string name)
        {
            Name = name;
        }

        //---------------------------------------------------------------

        public string GetQualifiedAccountName(char separator)
        {
            if (!_nameHasChanged)
            {
                return _cachedQualifiedName;
            }

            // no parents, just return name
            if (m_parent == null)
            {
                _cachedQualifiedName = Name;
                _nameHasChanged = false;
                return Name;
            }

            // has parents, create a qualified name
            var name = new StringBuilder();
            KAccount parent = m_parent;
            var nameStack = new Stack<string>();

            nameStack.Push(Name);

            while (parent != null)
            {
                nameStack.Push(parent.GetAccountName());
                parent = parent.GetParent();
            }

            while (nameStack.Any())
            {
                name.Append(nameStack.Pop());

                if (nameStack.Any())
                {
                    name.Append(separator);
                }
            }

            _cachedQualifiedName = name.ToString();
            _nameHasChanged = false;

            return _cachedQualifiedName;
        }

        //---------------------------------------------------------------

        public string GetQualifiedAccountName()
        {
            return GetQualifiedAccountName(c_accountLevelSeparator);
        }

        //---------------------------------------------------------------

        public string GetDescription()
        {
            return m_description;
        }

        //---------------------------------------------------------------

        public void SetDescription(string description)
        {
            m_description = description;
        }

        //---------------------------------------------------------------

        public byte GetAccountType()
        {
            if (m_parent == null)
            {
                return m_type;
            }
            else
            {
                return m_parent.GetAccountType();
            }
        }

        //---------------------------------------------------------------

        public string GetAccountTypeName()
        {
            return m_accountTypeName[(int)m_type];
        }

        //---------------------------------------------------------------

        public KAccount GetParent()
        {
            return m_parent;
        }

        //---------------------------------------------------------------

        public void SetParent(KAccount parent)
        {
            m_parent = parent;
            m_type = parent.GetAccountType();
        }

        //---------------------------------------------------------------

        public decimal GetBalance(DateTime date, bool includeBudget)
        {
            // add up account's transactions
            decimal balance = 0m;

            foreach (KTransaction t in m_transaction)
            {
                // include budget transactions?
                if (t.IsBudget &&
                    includeBudget == false)
                {
                    continue;
                }

                // in period?
                if (t.GetDate().Date <= date.Date)
                {
                    if (t.GetTransactionType() == KTransaction.TransactionType.c_debit)
                    {
                        balance -= t.GetAmount();
                    }
                    else
                    {
                        balance += t.GetAmount();
                    }
                }
            }

            // add up account's childrens' transactions
            foreach (KAccount child in m_children)
            {
                balance += child.GetBalance(date, includeBudget);
            }

            return balance;
        }

        //---------------------------------------------------------------

        public decimal GetBalance(DateTime start,
          DateTime end,
          bool includeBudget)
        {
            // add up account's transactions
            decimal balance = 0m;

            foreach (KTransaction t in m_transaction)
            {
                if (t.GetDate().Date >= start.Date &&
                    t.GetDate().Date <= end.Date)
                {
                    // include budget transactions?
                    if (t.IsBudget &&
                        includeBudget == false)
                    {
                        continue;
                    }

                    // update balance
                    if (t.GetTransactionType() == KTransaction.TransactionType.c_debit)
                    {
                        balance -= t.GetAmount();
                    }
                    else
                    {
                        balance += t.GetAmount();
                    }
                }
            }

            // add up account's childrens' transactions
            foreach (KAccount child in m_children)
            {
                balance += child.GetBalance(start, end, includeBudget);
            }

            return balance;
        }

        //---------------------------------------------------------------

        public void AddChild(KAccount child)
        {
            m_children.Add(child);
        }

        //---------------------------------------------------------------

        public bool RemoveChild(KAccount child)
        {
            try
            {
                m_children.Remove(child);

                return true;
            }
            catch
            {
                return false;
            }
        }

        //---------------------------------------------------------------

        public IEnumerable<KAccount> GetChildren(bool recurse)
        {
            // just return this account's children
            if (recurse == false)
            {
                return m_children;
            }

            // compile a list of all children
            List<KAccount> list = new List<KAccount>();

            foreach (KAccount a in m_children)
            {
                list.Add(a);

                IEnumerable<KAccount> list2 = a.GetChildren(true);

                foreach (KAccount a2 in list2)
                {
                    list.Add(a2);
                }
            }

            return list;
        }

        //---------------------------------------------------------------

        public bool HasChildren()
        {
            return m_children.Count > 0 ? true : false;
        }

        //---------------------------------------------------------------

        public void CreateTransaction(uint id,
          KTransaction.TransactionType type,
          KAccount contra,
          decimal amount,
          DateTime date,
          KPeriod period,
          string description,
          bool isAdjustment,
          bool isBudgetTransaction,
          bool setLastTransactionContra,
          bool isRecurring,
          bool isRecurringConfirmAmount,
          string[] tags)
        {
            // create the transaction
            KTransaction trans = new KTransaction(id,
              type,
              this,
              contra,
              amount,
              date,
              period,
              description,
              isAdjustment,
              isBudgetTransaction,
              isRecurring,
              isRecurringConfirmAmount,
              tags);

            // add to transactions
            m_transaction.Add(trans);

            // misc
            if (setLastTransactionContra)
            {
                m_lastTransactionContraName = contra.GetQualifiedAccountName();
            }

            // update balance
            //UpdateBalance(amount, type);
        }

        //---------------------------------------------------------------

        public void DeleteTransaction(uint id, bool deleteFromChildren)
        {
            // delete from this account
            foreach (KTransaction t in m_transaction)
            {
                if (t.GetId() == id)
                {
                    m_transaction.Remove(t);

                    break;
                }
            }

            // delete from children
            if (deleteFromChildren)
            {
                foreach (KAccount a in m_children)
                {
                    a.DeleteTransaction(id, true);
                }
            }
        }

        //---------------------------------------------------------------

        public IEnumerable<KTransaction> GetTransactions()
        {
            return m_transaction;
        }

        //---------------------------------------------------------------

        public static void GetTransactionsForPeriodRecursive(
          KAccount account,
          KPeriod period,
          List<KTransaction> transactions)
        {
            transactions.AddRange(
              account
                .GetTransactions()
                .Where(t =>
                  t.GetPeriod() == period &&
                  transactions.FirstOrDefault(x => x.GetId() == t.GetId()) == null));

            account
              .GetChildren(false)
              .ToList()
              .ForEach(c => GetTransactionsForPeriodRecursive(c, period, transactions));
        }

        //---------------------------------------------------------------

        public void ClearTransactions()
        {
            m_transaction.Clear();
        }

        //---------------------------------------------------------------

        // Typically called after loading a book - it is not possible to give
        // transaction objects a reference to their contra-account account objects
        // because all accounts are not yet loaded when transactions are loaded.
        // This method goes through this account's transactions and updates them
        // with the contra-account object.

        public void UpdateTransactionsWithContraAccounts(IEnumerable<KAccount> accounts)
        {
            // loop through transactions
            foreach (KTransaction t in m_transaction)
            {
                string accName = t.GetContraQualifiedAccountName();

                // loop through accounts looking for account
                foreach (KAccount a in accounts)
                {
                    // found it? set the contra-account and move on to next transaction
                    if (a.GetQualifiedAccountName().Equals(accName))
                    {
                        t.SetContraAccount(a);

                        break;
                    }
                }

                // account not found?
                if (t.GetContraAccount() == null)
                {
                    throw new Exception("Contra-account not found.");
                }
            }
        }

        //---------------------------------------------------------------

        public int GetIconId()
        {
            return m_iconId;
        }

        //---------------------------------------------------------------

        public void SetIconId(int id)
        {
            m_iconId = id;
        }

        //---------------------------------------------------------------

        public Color GetColour()
        {
            // no colour? get parent colour
            if (m_colour == Color.FromName(c_noColourName))
            {
                if (m_parent != null)
                {
                    return m_parent.GetColour();
                }
                else
                {
                    return Color.FromName(c_noColourName);
                }
            }

            // has a colour
            return m_colour;
        }

        //---------------------------------------------------------------

        public void SetColour(Color colour)
        {
            m_colour = colour;
        }

        //---------------------------------------------------------------

        public bool IsInheritsParentColour()
        {
            return (m_colour == Color.FromName(c_noColourName));
        }

        //---------------------------------------------------------------

        public Image GetIcon(Size size)
        {
            return m_icon.GetImage(size);
        }

        //---------------------------------------------------------------

        // Start date can be null.

        public void HasBudgetTransactions(
          DateTime start,
          DateTime end,
          bool useStart,
          out bool hasBudgetTransactions,
          out bool hasOverdueBudgetTransactions)
        {
            hasBudgetTransactions = false;
            hasOverdueBudgetTransactions = false;

            // check this account's transactions
            foreach (KTransaction t in m_transaction)
            {
                if (t.IsBudget)
                {
                    DateTime date = t.GetDate();

                    // after end date?
                    if (date.Date > end.Date)
                    {
                        continue;
                    }

                    // before start date?
                    if (useStart &
                        date.Date < start)
                    {
                        continue;
                    }

                    hasBudgetTransactions = true;
                    hasOverdueBudgetTransactions = date.Date < DateTime.Now;
                }

                if (hasOverdueBudgetTransactions)
                {
                    return;
                }
            }

            // check children
            var hasChildGotBudgetTransactions = false;
            var hasChildGotOverdueBudgetTransactions = false;

            foreach (KAccount a in m_children)
            {
                a.HasBudgetTransactions(
                  start,
                  end,
                  useStart,
                  out hasChildGotBudgetTransactions,
                  out hasChildGotOverdueBudgetTransactions);

                if (hasChildGotOverdueBudgetTransactions)
                {
                    break;
                }
            }

            hasBudgetTransactions |= hasChildGotBudgetTransactions;
            hasOverdueBudgetTransactions |= hasChildGotOverdueBudgetTransactions;
        }

        //---------------------------------------------------------------

        public int GetAccountLevel()
        {
            if (m_parent == null)
            {
                return 0;
            }
            else
            {
                return m_parent.GetAccountLevel() + 1;
            }
        }

        //---------------------------------------------------------------

        public bool IsTreeNodeExpanded()
        {
            return m_treeNodeExpanded;
        }

        //---------------------------------------------------------------

        public void SetTreeNodeExpanded(bool expanded)
        {
            m_treeNodeExpanded = expanded;

            if (m_treeNode != null)
            {
                if (m_treeNodeExpanded)
                {
                    m_treeNode.Expand();
                }
                else
                {
                    m_treeNode.Collapse();
                }
            }
        }

        //---------------------------------------------------------------

        public void SetTreeNode(TreeNode node)
        {
            m_treeNode = node;
        }

        //---------------------------------------------------------------

        public void ApplyTreeNodeState()
        {
            if (m_treeNode != null)
            {
                if (m_treeNodeExpanded)
                {
                    m_treeNode.Expand();
                }
                else
                {
                    m_treeNode.Collapse();
                }
            }
        }

        //---------------------------------------------------------------

        public string GetLastTransactionContraName()
        {
            return m_lastTransactionContraName;
        }

        //---------------------------------------------------------------

        public bool HideInTree { get; set; }

        //---------------------------------------------------------------

        public void SetupIcon(Size size, bool forceSetup)
        {
            // load icon & set the icon id
            try
            {
                bool shiftColours = false;

                // is a master account? use specific icon
                if (IsMasterAccount())
                {
                    switch (m_type)
                    {
                        case c_unknown:
                            return;

                        case c_bank:
                            m_iconName = KResourceManager.c_resourcePath + "Bank";
                            break;

                        case c_income:
                            m_iconName = KResourceManager.c_resourcePath + "Income";
                            break;

                        case c_expense:
                            m_iconName = KResourceManager.c_resourcePath + "Expense";
                            break;

                        case c_debt:
                            m_iconName = KResourceManager.c_resourcePath + "Debt";
                            break;

                        case c_credit:
                            m_iconName = KResourceManager.c_resourcePath + "Credit";
                            break;
                    }
                }
                // not a master account - icon depends on account level
                else
                {
                    m_iconName = KResourceManager.c_resourcePath + "AccountIcon" + GetAccountLevel();
                    shiftColours = true;
                }

                // icon already exists?
                bool createIcon = true;

                if (m_iconList.Images.ContainsKey(GetQualifiedAccountName()))
                {
                    // force the icon setup?
                    if (forceSetup)
                    {
                        m_iconList.Images.RemoveByKey(GetQualifiedAccountName());
                    }
                    else
                    {
                        createIcon = false;
                    }
                }

                // create icon if one doesn't already exist
                if (createIcon)
                {
                    // load icon resource
                    Image icon = KCommon.CreateImageFromResource(Assembly.GetExecutingAssembly(), m_iconName);

                    // shift the colours according to account settings?
                    if (shiftColours)
                    {
                        // get account colour & calc scaling factors
                        Color nodeCol = GetColour();

                        float[] scaleRGB = new float[3];
                        scaleRGB[0] = nodeCol.R / 255.0f;
                        scaleRGB[1] = nodeCol.G / 255.0f;
                        scaleRGB[2] = nodeCol.B / 255.0f;

                        // get image palette & apply colour scaling
                        ColorPalette palette = icon.Palette;

                        for (int i = 0; i < palette.Entries.Length; i++)
                        {
                            Color c = palette.Entries[i];

                            Color newC =
                              Color.FromArgb(c.A,
                                (int)(c.R * scaleRGB[0]),
                                (int)(c.G * scaleRGB[1]),
                                (int)(c.B * scaleRGB[2]));

                            palette.Entries[i] = newC;
                        }

                        // update image palette
                        icon.Palette = palette;
                    }

                    // add modified image to icon list
                    m_icon = new KScaledImage(icon);

                    m_iconList.Images.Add(GetQualifiedAccountName(), m_icon.GetImage(size));

                    // store the id (index in the image array)
                    m_iconId = m_iconList.Images.IndexOfKey(GetQualifiedAccountName());
                }
                // icon already exists
                else
                {
                    // get id
                    m_iconId = m_iconList.Images.IndexOfKey(GetQualifiedAccountName());

                    // get icon
                    if (m_iconId != -1)
                    {
                        m_icon = new KScaledImage(m_iconList.Images[m_iconId]);
                    }
                }
            }
            catch (Exception e)
            {
                if (e != null) // just to kill warnings (unused var)
                    m_icon = null;
            }
        }

        //---------------------------------------------------------------
    }
}