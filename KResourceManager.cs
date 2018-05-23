using System;
using System.Reflection;
using System.Drawing;

namespace BoozeHoundBooks
{
  public class KResourceManager
  {
    // statics ----------------------------------------------------------------

    public const String c_resourcePath = "BoozeHoundBooks.Resources.";

    // class vars -------------------------------------------------------------

    public KScaledImage[] m_dayOfWeek = new KScaledImage[7];

    //-------------------------------------------------------------------------

    public KResourceManager()
    {
      try
      {
        Assembly assembly = Assembly.GetExecutingAssembly();

        // day of week icons
        Image img;

        img = KCommon.CreateImageFromResource(assembly, c_resourcePath + "DaySunday.gif");
        m_dayOfWeek[0] = new KScaledImage(img);

        img = KCommon.CreateImageFromResource(assembly, c_resourcePath + "DayMonday.gif");
        m_dayOfWeek[1] = new KScaledImage(img);

        img = KCommon.CreateImageFromResource(assembly, c_resourcePath + "DayTuesday.gif");
        m_dayOfWeek[2] = new KScaledImage(img);

        img = KCommon.CreateImageFromResource(assembly, c_resourcePath + "DayWednesday.gif");
        m_dayOfWeek[3] = new KScaledImage(img);

        img = KCommon.CreateImageFromResource(assembly, c_resourcePath + "DayThursday.gif");
        m_dayOfWeek[4] = new KScaledImage(img);

        img = KCommon.CreateImageFromResource(assembly, c_resourcePath + "DayFriday.gif");
        m_dayOfWeek[5] = new KScaledImage(img);

        img = KCommon.CreateImageFromResource(assembly, c_resourcePath + "DaySaturday.gif");
        m_dayOfWeek[6] = new KScaledImage(img);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    //-------------------------------------------------------------------------
  }
}