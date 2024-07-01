namespace BoozeHoundBooks
{
    public partial class KPeriodSetupForm
    {
        private List<KPeriod> m_period = new List<KPeriod>();

        //---------------------------------------------------------------

        public KPeriodSetupForm()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------------

        private void PopulateListBox()
        {
            // clear out existing data
            periodBox.Items.Clear();

            // add periods
            foreach (KPeriod p in m_period)
            {
                periodBox.Items.Add(p.GetStart().ToString("dd/MM/yy") +
                                    " -> " +
                                    p.GetEnd().ToString("dd/MM/yy"));
            }
        }

        //---------------------------------------------------------------

        public void AddPeriod(KPeriod period)
        {
            m_period.Add(period);

            UpdatePeriods();

            PopulateListBox();
        }

        //---------------------------------------------------------------

        void AddBtnClick(object sender, System.EventArgs e)
        {
            KPeriod period = new KPeriod(startPicker.Value, endPicker.Value);

            AddPeriod(period);
        }

        //---------------------------------------------------------------

        void OkBtnClick(object sender, System.EventArgs e)
        {
            Hide();
        }

        //---------------------------------------------------------------

        public IEnumerable<KPeriod> GetPeriodList()
        {
            return m_period;
        }

        //---------------------------------------------------------------

        private void removeBtn_Click(object sender, EventArgs e)
        {
            // nothing selected?
            if (periodBox.SelectedIndex == -1)
            {
                KMainForm.InfoMsg("Select a Period first.", "Update");

                return;
            }

            // remove
            m_period.RemoveAt(periodBox.SelectedIndex);

            // update periods & form
            UpdatePeriods();
            PopulateListBox();
        }

        //---------------------------------------------------------------

        private void updateBtn_Click(object sender, EventArgs e)
        {
            // nothing selected?
            if (periodBox.SelectedIndex == -1)
            {
                KMainForm.InfoMsg("Select a Period first.", "Update");

                return;
            }

            // update selected period
            KPeriod p = (KPeriod)m_period.ToArray()[periodBox.SelectedIndex];

            p.SetStart(startPicker.Value);
            p.SetEnd(endPicker.Value);

            m_period.RemoveAt(periodBox.SelectedIndex);
            m_period.Add(p);

            UpdatePeriods();

            // populate the list
            PopulateListBox();
        }

        //---------------------------------------------------------------

        private void UpdatePeriods()
        {
            // sort the list
            m_period.Sort();

            // do period id's
            ushort i = 1;

            foreach (KPeriod per in m_period)
            {
                per.SetId(i++);
            }
        }

        //---------------------------------------------------------------
    }
}