using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LinesScr
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            if (args.Length > 0)
            {
                // Get the 2 character command line argument
                string arg = args[0].ToLowerInvariant().Trim().Substring(0, 2);
                switch (arg)
                {
                    case "/c":
                        // Show the options dialog
                        ShowOptions();
                        break;
                    case "/p":
                        // Don't do anything for preview
                        break;
                    case "/s":
                        // Show screensaver form
                        ShowScreenSaver();
                        break;
                    case "/d":
                        // Show screensver in debug mode
                        break;
                    default:
                        MessageBox.Show("Invalid command line argument: " + arg, "Invalid Command Line Argument", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            else
            {
                // If no arguments were passed in, show the screensaver
                ShowScreenSaver();
            }
        }

        static void ShowOptions()
        {
            MessageBox.Show("I hate forms.  No options.  Go away.",
                "Jo's Sqwiggly Lines Screensaver",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        static void ShowScreenSaver()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                LinesScr screenSaver = new LinesScr(screen.Bounds);
                screenSaver.Show();
            }
            Application.Run();
        }
    }
}

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LinesScr());
