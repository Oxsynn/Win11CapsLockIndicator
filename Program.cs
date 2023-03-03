using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CapsLockIndicator
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //only changes to this file are the using at the top, and the things below this line
            //below lines are likely for visual assistance
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new CapsLockIndicatorContext());
        }
    }
}