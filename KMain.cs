﻿namespace BoozeHoundBooks
{
    public class KMain
    {
        internal const int c_build = 21;
        internal const int c_buildRevision = 2;

        internal static KResourceManager m_resourceManager;
        internal static KSettingFile m_appSetting;

        private const string c_settingsFilename = "settings";

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