namespace BoozeHoundBooks
{
    public partial class KSelectAccountForm : Form
    {
        // class vars -------------------------------------------------------------

        private KAccount m_selected;

        //-------------------------------------------------------------------------

        public KSelectAccountForm(KBook book)
        {
            InitializeComponent();

            // populate account list
            foreach (KAccount acc in book.GetAccountList())
            {
                if (acc.GetAccountType() != KAccount.c_unknown)
                {
                    accountList.Items.Add(acc);
                }
            }

            if (accountList.Items.Count > 0)
            {
                accountList.SelectedIndex = 0;
            }
        }

        //-------------------------------------------------------------------------

        void AccountListSelectedIndexChanged(object sender, EventArgs e)
        {
            m_selected = (KAccount)accountList.SelectedItem;
        }

        //-------------------------------------------------------------------------

        public KAccount GetSelectedAccount()
        {
            return m_selected;
        }

        //-------------------------------------------------------------------------

        void OkBtnClick(object sender, EventArgs e)
        {
            Dispose();

            DialogResult = DialogResult.OK;
        }

        //-------------------------------------------------------------------------
    }
}