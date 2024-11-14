using Microsoft.Extensions.Configuration;
using Microsoft.Reporting.WinForms;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Royalty_Turbo
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show the splash screen
            SplashScreen splash = new SplashScreen();
            splash.Show();
            splash.Refresh(); // Ensure the splash screen gets drawn

            // Wait for 5 seconds (5000 milliseconds)
            Thread.Sleep(8000);

            // Close the splash screen
            splash.Close();

            // Read the connection string from App.config
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
         

            Application.Run(new Form1(connectionString));
        }
    }
}
