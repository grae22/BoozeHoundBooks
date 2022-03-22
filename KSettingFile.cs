using System;
using System.Collections;
using System.Xml;
using System.IO;

namespace BoozeHoundBooks
{
  public class KSettingFile
  {
    // class vars -------------------------------------------------------------

    private string m_filename;
    private Hashtable m_setting = new Hashtable(10);

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
        string type = e.GetAttribute("Type");
        string value = e.GetAttribute("Value");

        Object ob;

//		    ob = (Type.GetType( type ))value;

        if (type.Equals(typeof(String).FullName)) // String
        {
          ob = value;
        }
        else if (type.Equals(typeof(bool).FullName)) // bool
        {
          ob = bool.Parse(value);
        }
        else if (type.Equals(typeof(char).FullName)) // char
        {
          ob = char.Parse(value);
        }
        else if (type.Equals(typeof(byte).FullName)) // byte
        {
          ob = byte.Parse(value);
        }
        else if (type.Equals(typeof(short).FullName)) // short
        {
          ob = short.Parse(value);
        }
        else if (type.Equals(typeof(ushort).FullName)) // ushort
        {
          ob = ushort.Parse(value);
        }
        else if (type.Equals(typeof(int).FullName)) // int
        {
          ob = int.Parse(value);
        }
        else if (type.Equals(typeof(uint).FullName)) // uint
        {
          ob = uint.Parse(value);
        }
        else if (type.Equals(typeof(long).FullName)) // long
        {
          ob = long.Parse(value);
        }
        else if (type.Equals(typeof(ulong).FullName)) // ulong
        {
          ob = ulong.Parse(value);
        }
        else if (type.Equals(typeof(float).FullName)) // float
        {
          ob = float.Parse(value);
        }
        else if (type.Equals(typeof(double).FullName)) // double
        {
          ob = double.Parse(value);
        }
        else if (type.Equals(typeof(double).FullName)) // decimal
        {
          ob = decimal.Parse(value);
        }
        else
        {
          throw new Exception("KSettingFile.KSettingFile() : '" + e.GetAttribute("Name") + "' has unknown type.");
        }

        // add to the settings list
        m_setting.Add(e.GetAttribute("Name"),
          ob);
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

    public void SetSetting(string name, Object value)
    {
      if (m_setting.ContainsKey(name))
      {
        m_setting.Remove(name);
      }

      m_setting.Add(name, value);
    }

    //-------------------------------------------------------------------------

    public Object GetSetting(string name, Object defaultValue)
    {
      // setting exists?
      if (m_setting.ContainsKey(name))
      {
        // find the setting and return the value
        IDictionaryEnumerator settingEnum = m_setting.GetEnumerator();

        while (settingEnum.MoveNext())
        {
          if (settingEnum.Key.Equals(name))
          {
            return settingEnum.Value;
          }
        }
      }

      // setting doesn't exist, return default value
      return defaultValue;
    }

    //-------------------------------------------------------------------------
  }
}