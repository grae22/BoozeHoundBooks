using System.Reflection;
using System.Resources;

namespace BoozeHoundBooks
{
  public class KCommon
  {
    //---------------------------------------------------------------

    public static string GetFilenameFromPath(string path)
    {
      string name = path;

      // find the last path separator
      int lastBackSlash = path.LastIndexOf("\\");
      int lastDoubleBackSlash = path.LastIndexOf("\\\\");
      int lastForwardSlash = path.LastIndexOf("/");
      int lastDoubleForwardSlash = path.LastIndexOf("//"); // just in case...

      int lastSeparator = lastBackSlash;

      if (lastSeparator < lastDoubleBackSlash)
      {
        lastSeparator = lastDoubleBackSlash;
      }

      if (lastSeparator < lastForwardSlash)
      {
        lastSeparator = lastForwardSlash;
      }

      if (lastSeparator < lastDoubleForwardSlash)
      {
        lastSeparator = lastDoubleForwardSlash;
      }

      // find file extension (if any)
      int ext = path.LastIndexOf(".");

      if (ext != -1)
      {
        name = path.Substring(0, ext);
      }

      // strip the path info
      name = name.Substring(lastSeparator + 1);

      return name;
    }

    //---------------------------------------------------------------

    public static string GetRgbString(Color colour)
    {
      return colour.R + "," + colour.G + "," + colour.B;
    }

    //---------------------------------------------------------------

    public static Color GetColourFromRgbString(string rgb)
    {
      Color col = Color.Black;
      String[] s = rgb.Split(',');

      if (s.Length == 3)
      {
        col = Color.FromArgb(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]));
      }

      return col;
    }

    //---------------------------------------------------------------

    public static Image CreateImageFromResource(Assembly assembly, string resourceName)
    {
      var resourceManager = new ResourceManager("BoozeHoundBooks.Icons", assembly);

      return resourceManager.GetObject(resourceName) as Image;
    }

    //---------------------------------------------------------------

    public static bool IsNumeric(string text)
    {
      try
      {
        Double.Parse(text);

        return true;
      }
      catch
      {
        return false;
      }
    }

    //---------------------------------------------------------------
  }
}