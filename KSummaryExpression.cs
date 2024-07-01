using System.Collections;
using System.Xml;

namespace BoozeHoundBooks
{
    public class KSummaryExpression
    {
        // xml constants ----------------------------------------------------------

        private const string c_element_expression = "ExpressionField";

        private const string c_attrib_name = "Name";
        private const string c_attrib_description = "Description";
        private const string c_attrib_type = "Type";
        private const string c_attrib_value = "Value";

        // class vars -------------------------------------------------------------

        private string m_name;
        private string m_description;
        private List<KField> m_field = new List<KField>();

        //-------------------------------------------------------------------------

        public KSummaryExpression(string name, string description)
        {
            m_name = name;
            m_description = description;
        }

        //---------------------------------------------------------------

        public KSummaryExpression(XmlElement expression, KBook book)
        {
            // load info
            m_name = expression.GetAttribute(c_attrib_name);
            m_description = expression.GetAttribute(c_attrib_description);

            // load fields
            IEnumerator fields = expression.GetEnumerator();

            while (fields.MoveNext())
            {
                XmlElement fieldXml = (XmlElement)fields.Current;

                string type = fieldXml.GetAttribute(c_attrib_type);
                string val = fieldXml.GetAttribute(c_attrib_value);

                KField.FieldType fieldType = KField.GetFieldTypeFromText(type);

                KField field = null;

                switch (fieldType)
                {
                    // OPERATOR
                    case KField.FieldType.Operator:

                        field = new KField(KField.GetOperatorTypeFromText(val));
                        break;

                    // ACCOUNT
                    case KField.FieldType.Account:

                        val = val.Replace(KAccount.c_accountLevelSeparatorInFile, KAccount.c_accountLevelSeparator);

                        KAccount acc = book.GetAccount(val);

                        if (acc == null)
                        {
                            throw new Exception("KSummaryExpression.KSummaryExpression( '" + m_name + "' ) : Failed to load - " +
                                                "unknown account - '" + val + "'.");
                        }

                        field = new KField(acc);
                        break;

                    // VALUE
                    case KField.FieldType.Value:

                        field = new KField(decimal.Parse(val));
                        break;
                }

                m_field.Add(field);
            }
        }

        //-------------------------------------------------------------------------

        override public string ToString()
        {
            IEnumerator fields = m_field.GetEnumerator();
            string s = "";

            while (fields.MoveNext())
            {
                KField field = (KField)fields.Current;

                s += " " + field.ToString() + " ";
            }

            return s.Trim();
        }

        //---------------------------------------------------------------

        public XmlElement GetXml(XmlElement element)
        {
            // set info
            element.SetAttribute(c_attrib_name, m_name);
            element.SetAttribute(c_attrib_description, m_description);

            // loop through fields
            IEnumerator fields = m_field.GetEnumerator();
            string fieldType = "";
            string fieldVal = "";

            while (fields.MoveNext())
            {
                KField field = (KField)fields.Current;

                fieldType = KField.GetFieldTypeText(field.GetFieldType());

                switch (field.GetFieldType())
                {
                    // OPERATOR
                    case KField.FieldType.Operator:

                        fieldVal = KField.GetOperatorTypeText(field.GetOperatorType());
                        break;

                    // ACCOUNT
                    case KField.FieldType.Account:

                        fieldVal = field.GetAccount().GetQualifiedAccountName().Replace(KAccount.c_accountLevelSeparator,
                          KAccount.c_accountLevelSeparatorInFile);
                        break;

                    // VALUE
                    case KField.FieldType.Value:

                        fieldVal = field.GetValue().ToString();
                        break;

                    // UNKNOWN
                    default:

                        fieldType = "unknown";
                        break;
                }

                // create xml
                XmlElement fieldXml = element.OwnerDocument.CreateElement(c_element_expression);

                fieldXml.SetAttribute(c_attrib_type, fieldType);
                fieldXml.SetAttribute(c_attrib_value, fieldVal);

                element.AppendChild(fieldXml);
            }

            return element;
        }

        //-------------------------------------------------------------------------

        public void AddField(KField field)
        {
            m_field.Add(field);
        }

        //-------------------------------------------------------------------------

        public void RemoveAllFields()
        {
            m_field.Clear();
        }

        //-------------------------------------------------------------------------

        public bool BuildExpression(out string returnMessage)
        {
            try
            {
                // check brackets
                IEnumerator fields = m_field.GetEnumerator();
                short bracketCount = 0;

                while (fields.MoveNext())
                {
                    KField field = (KField)fields.Current;

                    // is an operator field?
                    if (field.GetFieldType() == KField.FieldType.Operator)
                    {
                        // is bracket?
                        switch (field.GetOperatorType())
                        {
                            case KField.OperatorType.OpenBracket:
                                bracketCount++;
                                break;

                            case KField.OperatorType.CloseBracket:
                                bracketCount--;
                                break;
                        }

                        // counter cannot be negative - indicates close bracket before an open bracket
                        if (bracketCount < 0)
                        {
                            returnMessage = "Closing bracket found before an opening bracket.";
                            return false;
                        }
                    }
                }

                // non-zero bracket count indicates an unmatched opening bracket
                if (bracketCount != 0)
                {
                    returnMessage = "There is an opening bracket without a closing bracket.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                returnMessage = ex.Message;
                return false;
            }

            // success
            returnMessage = "Success";
            return true;
        }

        //-------------------------------------------------------------------------

        public decimal CalculateValue(DateTime start, DateTime end, bool includeBudget)
        {
            return CalculateValue(m_field.GetEnumerator(), start, end, includeBudget);
        }

        //-------------------------------------------------------------------------

        public decimal CalculateValue(IEnumerator fields, DateTime start, DateTime end, bool includeBudget)
        {
            try
            {
                decimal value = 0.0m;
                KField.OperatorType activeOperator = KField.OperatorType.Add;

                // loop through fields
                while (fields.MoveNext())
                {
                    KField field = (KField)fields.Current;

                    // field type?
                    switch (field.GetFieldType())
                    {
                        // OPERATOR -------------------------
                        case KField.FieldType.Operator:

                            // what kind of operator?
                            switch (field.GetOperatorType())
                            {
                                // open bracket - compile a list of items inside this bracket pair
                                // and calc the value.
                                case KField.OperatorType.OpenBracket:

                                    var temp = new List<KField>();
                                    int bracketCount = 1;

                                    // loop until we get to the closing bracket
                                    while (fields.MoveNext())
                                    {
                                        field = (KField)fields.Current;

                                        // is an operator?
                                        if (field.IsOperator())
                                        {
                                            // what kind of operator?
                                            switch (field.GetOperatorType())
                                            {
                                                case KField.OperatorType.OpenBracket:
                                                    bracketCount++;
                                                    break;

                                                case KField.OperatorType.CloseBracket:
                                                    bracketCount--;
                                                    break;
                                            }
                                        }

                                        temp.Add(field);

                                        // found the closing bracket?
                                        if (bracketCount == 0)
                                        {
                                            break;
                                        }
                                    }

                                    // calc value
                                    decimal bracketValue = CalculateValue(temp.GetEnumerator(), start, end, includeBudget);

                                    // apply value according to the active operator
                                    switch (activeOperator)
                                    {
                                        case KField.OperatorType.Add: // ADD
                                            value += bracketValue;
                                            break;

                                        case KField.OperatorType.Subtract: // SUBTRACT
                                            value -= bracketValue;
                                            break;

                                        case KField.OperatorType.Multiply: // MULTIPLY
                                            value *= bracketValue;
                                            break;

                                        case KField.OperatorType.Divide: // DIVIDE
                                            value /= bracketValue;
                                            break;
                                    }
                                    break;

                                case KField.OperatorType.CloseBracket:
                                    break;

                                case KField.OperatorType.Add:
                                case KField.OperatorType.Subtract:
                                case KField.OperatorType.Multiply:
                                case KField.OperatorType.Divide:
                                    activeOperator = field.GetOperatorType();
                                    break;
                            }

                            break;

                        // ACCOUNT --------------------------
                        case KField.FieldType.Account:

                            // apply value according to the active operator
                            switch (activeOperator)
                            {
                                case KField.OperatorType.Add: // ADD
                                    value += field.GetAccountBalance(start, end, includeBudget);
                                    break;

                                case KField.OperatorType.Subtract: // SUBTRACT
                                    value -= field.GetAccountBalance(start, end, includeBudget);
                                    break;

                                case KField.OperatorType.Multiply: // MULTIPLY
                                    value *= field.GetAccountBalance(start, end, includeBudget);
                                    break;

                                case KField.OperatorType.Divide: // DIVIDE
                                    value /= field.GetAccountBalance(start, end, includeBudget);
                                    break;
                            }

                            break;

                        // VALUE ----------------------------
                        case KField.FieldType.Value:

                            // apply value according to the active operator
                            switch (activeOperator)
                            {
                                case KField.OperatorType.Add: // ADD
                                    value += field.GetValue();
                                    break;

                                case KField.OperatorType.Subtract: // SUBTRACT
                                    value -= field.GetValue();
                                    break;

                                case KField.OperatorType.Multiply: // MULTIPLY
                                    value *= field.GetValue();
                                    break;

                                case KField.OperatorType.Divide: // DIVIDE
                                    value /= field.GetValue();
                                    break;
                            }

                            break;
                    }
                }

                // return the value
                return value;
            }
            catch
            {
                throw;
            }
        }

        //-------------------------------------------------------------------------

        public string GetName()
        {
            return m_name;
        }

        //-------------------------------------------------------------------------

        public string GetDescription()
        {
            return m_description;
        }

        //-------------------------------------------------------------------------

        public IEnumerable<KField> Fields
        {
            get { return m_field; }
        }

        //-------------------------------------------------------------------------

        public class KField
        {
            // defs -----------------------------------------------------------------

            // field type
            public enum FieldType
            {
                Unknown,
                Operator,
                Account,
                Value
            }

            private static String[] m_fieldTypeText =
            {
        "Unknown",
        "Operator",
        "Account",
        "Value"
      };

            // operator type
            public enum OperatorType
            {
                Unknown = 0,
                Add,
                Subtract,
                Multiply,
                Divide,
                OpenBracket,
                CloseBracket
            }

            private static String[] m_operatorTypeText =
            {
        "unknown",
        "+",
        "-",
        "x",
        "/",
        "(",
        ")"
      };

            // class vars -----------------------------------------------------------

            private FieldType m_fieldType;
            private OperatorType m_operatorType;
            private KAccount m_account; // only used if field type is 'Account'
            private decimal m_value; // only used if field type is 'Value'

            //-----------------------------------------------------------------------

            public KField(OperatorType type)
            {
                m_fieldType = FieldType.Operator;
                m_operatorType = type;
                m_account = null;
                m_value = 0.0m;
            }

            //-----------------------------------------------------------------------

            public KField(KAccount account)
            {
                m_fieldType = FieldType.Account;
                m_account = account;
                m_value = 0.0m;
            }

            //-----------------------------------------------------------------------

            public KField(decimal value)
            {
                m_fieldType = FieldType.Value;
                m_account = null;
                m_value = value;
            }

            //-----------------------------------------------------------------------

            override public string ToString()
            {
                switch (m_fieldType)
                {
                    case FieldType.Operator:
                        return m_operatorTypeText[(int)m_operatorType];

                    case FieldType.Account:
                        return m_account.GetQualifiedAccountName();

                    case FieldType.Value:
                        return "" + m_value;
                }

                return "error";
            }

            //-----------------------------------------------------------------------

            public static string GetFieldTypeText(FieldType type)
            {
                return m_fieldTypeText[(int)type];
            }

            //-----------------------------------------------------------------------

            public static FieldType GetFieldTypeFromText(string type)
            {
                int i = 0;

                foreach (string s in m_fieldTypeText)
                {
                    if (s.Equals(type))
                    {
                        return (FieldType)i;
                    }

                    i++;
                }

                // unknown
                return FieldType.Unknown;
            }

            //-----------------------------------------------------------------------

            public static string GetOperatorTypeText(OperatorType type)
            {
                return m_operatorTypeText[(int)type];
            }

            //-----------------------------------------------------------------------

            public static OperatorType GetOperatorTypeFromText(string type)
            {
                int i = 0;

                foreach (string s in m_operatorTypeText)
                {
                    if (s.Equals(type))
                    {
                        return (OperatorType)i;
                    }

                    i++;
                }

                // unknown
                return OperatorType.Unknown;
            }

            //-----------------------------------------------------------------------

            public FieldType GetFieldType()
            {
                return m_fieldType;
            }

            //-----------------------------------------------------------------------

            public OperatorType GetOperatorType()
            {
                if (m_fieldType != FieldType.Operator)
                {
                    throw new Exception("GetOperatorType() called with non-operator type.");
                }

                return m_operatorType;
            }

            //-----------------------------------------------------------------------

            public bool IsOperator()
            {
                return (m_fieldType == FieldType.Operator);
            }

            //-----------------------------------------------------------------------

            public KAccount GetAccount()
            {
                if (m_fieldType != FieldType.Account)
                {
                    throw new Exception("GetAccount() called with non-account type.");
                }

                return m_account;
            }

            //-----------------------------------------------------------------------

            public decimal GetAccountBalance(DateTime start, DateTime end, bool includeBudget)
            {
                if (m_fieldType != FieldType.Account)
                {
                    throw new Exception("GetAccountBalance() called with non-account type.");
                }

                decimal bal;

                if (m_account.GetAccountType() == KAccount.c_bank ||
                    m_account.GetAccountType() == KAccount.c_debt ||
                    m_account.GetAccountType() == KAccount.c_credit)
                {
                    bal = m_account.GetBalance(end, includeBudget);
                }
                else
                {
                    bal = m_account.GetBalance(start, end, includeBudget);
                }

                switch (m_account.GetAccountType())
                {
                    case KAccount.c_income:
                    case KAccount.c_debt:

                        bal *= -1.0m;

                        break;
                }

                return bal;
            }

            //-----------------------------------------------------------------------

            public bool IsAccount()
            {
                return (m_fieldType == FieldType.Account);
            }

            //-----------------------------------------------------------------------

            public decimal GetValue()
            {
                if (m_fieldType != FieldType.Value)
                {
                    throw new Exception("GetValue() called with non-value type.");
                }

                return m_value;
            }

            //-----------------------------------------------------------------------

            public bool IsValue()
            {
                return (m_fieldType == FieldType.Value);
            }

            //-----------------------------------------------------------------------
        }
    }
}