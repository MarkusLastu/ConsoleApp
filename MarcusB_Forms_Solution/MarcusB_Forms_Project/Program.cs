using System.Diagnostics;

namespace MarcusB_Forms_Project
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
            Debug.WriteLine("Starting MarcusB_Forms_Project...");
            Debug.WriteLine("Hello World!");
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}