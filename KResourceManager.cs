using System.Reflection;

namespace BoozeHoundBooks
{
  public class KResourceManager
  {
    // statics ----------------------------------------------------------------

    public static string c_resourcePath = string.Empty;// "BoozeHoundBooks.Icons.";

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

        img = KCommon.CreateImageFromResource(assembly, c_resourcePath + "DaySunday");
        m_dayOfWeek[0] = new KScaledImage(img);

        img = KCommon.CreateImageFromResource(assembly, c_resourcePath + "DayMonday");
        m_dayOfWeek[1] = new KScaledImage(img);

        img = KCommon.CreateImageFromResource(assembly, c_resourcePath + "DayTuesday");
        m_dayOfWeek[2] = new KScaledImage(img);

        img = KCommon.CreateImageFromResource(assembly, c_resourcePath + "DayWednesday");
        m_dayOfWeek[3] = new KScaledImage(img);

        img = KCommon.CreateImageFromResource(assembly, c_resourcePath + "DayThursday");
        m_dayOfWeek[4] = new KScaledImage(img);

        img = KCommon.CreateImageFromResource(assembly, c_resourcePath + "DayFriday");
        m_dayOfWeek[5] = new KScaledImage(img);

        img = KCommon.CreateImageFromResource(assembly, c_resourcePath + "DaySaturday");
        m_dayOfWeek[6] = new KScaledImage(img);
      }
      catch
      {
        throw;
      }
    }

    //-------------------------------------------------------------------------
  }
}