using System;
using System.Windows.Forms;

namespace BoozeHoundBooks
{
  public class KMain
  {
    // statics ------------------------------------------------------

    public static int c_build = 19;
    public static int c_buildRevision = 5;

    // constants ----------------------------------------------------

    private string c_settingsFilename = "settings";

    // class vars ---------------------------------------------------

    public static KResourceManager m_resourceManager;
    public static KSettingFile m_appSetting;

    //---------------------------------------------------------------

    [STAThread]
    public static void Main(string[] args)
    {
      try
      {
        // args
        string bookPath = string.Empty;

        if (args.Length > 0)
        {
          bookPath = args[0];
        }

        // start the app
        new KMain(bookPath);
      }
      catch (Exception ex)
      {
        KMain.HandleException(ex, true);
      }
    }

    //-------------------------------------------------------------------------

    public KMain(string bookPath)
    {
      try
      {
        // set up the app settings ob
        m_appSetting = new KSettingFile(c_settingsFilename);

        // load resource manager
        m_resourceManager = new KResourceManager();

        // run main form
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new KMainForm(bookPath));
      }
      catch (Exception ex)
      {
        HandleException(ex, true);
      }
    }

    //-------------------------------------------------------------------------

    public static void HandleException(Exception ex, bool msgBox)
    {
      // message
      if (msgBox)
      {
        MessageBox.Show(
          ex.Message +
            Environment.NewLine +
            Environment.NewLine +
            ex.Source,
          "Error",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
      }
    }

    //-------------------------------------------------------------------------

    public static void SimpleMsgBox(string msg, string header)
    {
      MessageBox.Show(msg, header);
    }

    //-------------------------------------------------------------------------
  }
}