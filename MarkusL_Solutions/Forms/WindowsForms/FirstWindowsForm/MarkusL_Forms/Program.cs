using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MarkusL_Forms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Debug.WriteLine("Hello World!");
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}