using System.Collections;
using System.Xml;

namespace BoozeHoundBooks
{
    public class KSettingFile
    {
        // class vars -------------------------------------------------------------

        private readonly string m_filename;
        private readonly Dictionary<string, object> m_setting = new Dictionary<string, object>();

        //-------------------------------------------------------------------------

        public KSettingFile(string filename)
        {
            // init class vars
            m_filename = filename;

            // create the xml doc
            XmlDocument doc = new XmlDocument();

            if (File.Exists(filename) == false)
            {
                return;
            }

            doc.Load(m_filename);

            XmlNodeList settingList = doc.GetElementsByTagName("Setting");

            // get settings
            foreach (XmlElement e in settingList)
            {
                // setup an object for the setting
                string name = e.GetAttribute("Name");
                string type = e.GetAttribute("Type");
                string value = e.GetAttribute("Value");

                if (type.Equals(typeof(String).FullName)) // String
                {
                    m_setting.Add(name, value);
                }
                else if (type.Equals(typeof(bool).FullName)) // bool
                {
                    bool ob = bool.Parse(value);
                    m_setting.Add(name, ob);
                }
                else if (type.Equals(typeof(char).FullName)) // char
                {
                    char ob = char.Parse(value);
                    m_setting.Add(name, ob);
                }
                else if (type.Equals(typeof(byte).FullName)) // byte
                {
                    byte ob = byte.Parse(value);
                    m_setting.Add(name, ob);
                }
                else if (type.Equals(typeof(short).FullName)) // short
                {
                    short ob = short.Parse(value);
                    m_setting.Add(name, ob);
                }
                else if (type.Equals(typeof(ushort).FullName)) // ushort
                {
                    ushort ob = ushort.Parse(value);
                    m_setting.Add(name, ob);
                }
                else if (type.Equals(typeof(int).FullName)) // int
                {
                    int ob = int.Parse(value);
                    m_setting.Add(name, ob);
                }
                else if (type.Equals(typeof(uint).FullName)) // uint
                {
                    uint ob = uint.Parse(value);
                    m_setting.Add(name, ob);
                }
                else if (type.Equals(typeof(long).FullName)) // long
                {
                    long ob = long.Parse(value);
                    m_setting.Add(name, ob);
                }
                else if (type.Equals(typeof(ulong).FullName)) // ulong
                {
                    ulong ob = ulong.Parse(value);
                    m_setting.Add(name, ob);
                }
                else if (type.Equals(typeof(float).FullName)) // float
                {
                    float ob = float.Parse(value);
                    m_setting.Add(name, ob);
                }
                else if (type.Equals(typeof(double).FullName)) // double
                {
                    double ob = double.Parse(value);
                    m_setting.Add(name, ob);
                }
                else if (type.Equals(typeof(decimal).FullName)) // decimal
                {
                    decimal ob = decimal.Parse(value);
                    m_setting.Add(name, ob);
                }
                else
                {
                    throw new Exception("KSettingFile.KSettingFile() : '" + e.GetAttribute("Name") + "' has unknown type.");
                }
            }
        }

        //-------------------------------------------------------------------------

        public void Save()
        {
            // create the xml doc
            XmlDocument doc = new XmlDocument();

            XmlElement settingList = doc.CreateElement("SettingList");

            doc.AppendChild(settingList);

            // add settings
            IDictionaryEnumerator settingEnum = m_setting.GetEnumerator();

            while (settingEnum.MoveNext())
            {
                // create element
                XmlElement setting = doc.CreateElement("Setting");

                setting.SetAttribute("Name", settingEnum.Key.ToString());
                setting.SetAttribute("Type", settingEnum.Value.GetType().FullName);
                setting.SetAttribute("Value", settingEnum.Value.ToString());

                // add to book
                settingList.AppendChild(setting);
            }

            // save the xml doc
            doc.Save(m_filename);
        }

        //-------------------------------------------------------------------------

        public void SetSetting(string name, object value)
        {
            if (m_setting.ContainsKey(name))
            {
                m_setting[name] = value;
                return;
            }

            m_setting.Add(name, value);
        }

        //-------------------------------------------------------------------------

        public object GetSetting(string name, object defaultValue)
        {
            // setting exists?
            if (m_setting.ContainsKey(name))
            {
                return m_setting[name];
            }

            SetSetting(name, defaultValue);

            // setting doesn't exist, return default value
            return defaultValue;
        }

        //-------------------------------------------------------------------------
    }
}