using LibraryManagementSystemWF.services;
using LibraryManagementSystemWF.views;

namespace LibraryManagementSystemWF
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

            // Initialize Database and other services
            SetupService.Ready();

            // Application.Run(new Form1());
            Application.Run(new Welcome());
        }
    }
}