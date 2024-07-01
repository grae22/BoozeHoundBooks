using System.Xml;

namespace BoozeHoundBooks
{
    public class KPeriod : IComparable
    {
        // xml attribs --------------------------------------------------
        private const string c_attrib_id = "Id";

        private const string c_attrib_start = "Start";
        private const string c_attrib_end = "End";

        // static class vars --------------------------------------------
        private static ushort m_nextId = 1;

        // class vars ---------------------------------------------------
        private ushort m_id;

        private DateTime m_start;
        private DateTime m_end;

        //---------------------------------------------------------------

        public KPeriod(XmlElement element)
        {
            m_id = ushort.Parse(element.GetAttribute(c_attrib_id));
            m_start = DateTime.Parse(element.GetAttribute(c_attrib_start));
            m_end = DateTime.Parse(element.GetAttribute(c_attrib_end));
        }

        //---------------------------------------------------------------

        public KPeriod(DateTime start,
          DateTime end)
        {
            m_id = m_nextId++;
            m_start = start.Date;
            m_end = end.Date;
        }

        //---------------------------------------------------------------

        public override string ToString()
        {
            return "Period " + m_id;
        }

        //---------------------------------------------------------------

        public int CompareTo(object obj)
        {
            if (obj is KPeriod)
            {
                KPeriod p = (KPeriod)obj;

                if (p.GetStart().Date < m_start.Date)
                {
                    return 1;
                }
                else if (p.GetStart().Date == m_start.Date)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                throw new ArgumentException("Object is not a KPeriod.");
            }
        }

        //---------------------------------------------------------------

        public XmlElement GetXml(XmlElement element)
        {
            element.SetAttribute(c_attrib_id, "" + m_id);
            element.SetAttribute(c_attrib_start, m_start.ToString("yyyy/MM/dd"));
            element.SetAttribute(c_attrib_end, m_end.ToString("yyyy/MM/dd"));

            return element;
        }

        //---------------------------------------------------------------

        public bool DateInPeriod(DateTime date)
        {
            if (date.Date >= m_start.Date && date.Date <= m_end.Date)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //---------------------------------------------------------------

        public ushort GetId()
        {
            return m_id;
        }

        //---------------------------------------------------------------

        public void SetId(ushort id)
        {
            m_id = id;
        }

        //---------------------------------------------------------------

        public DateTime GetStart()
        {
            return m_start.Date;
        }

        //---------------------------------------------------------------

        public bool SetStart(DateTime start)
        {
            m_start = start.Date;

            return true;
        }

        //---------------------------------------------------------------

        public DateTime GetEnd()
        {
            return m_end.Date;
        }

        //---------------------------------------------------------------

        public bool SetEnd(DateTime end)
        {
            m_end = end.Date;

            return true;
        }

        //---------------------------------------------------------------
    }
}