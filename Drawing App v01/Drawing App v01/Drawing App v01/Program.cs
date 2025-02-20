namespace Drawing_App_v01
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();


            // Create Main Window (disabled at first)
            MainWindow mainWindow = new MainWindow(new DrawingManager());
            mainWindow.Enabled = false;
            mainWindow.Show();

            // Open Welcome Form as a modal dialog
            using (WelcomeForm welcomeForm = new WelcomeForm())
            {
                // Subscribe to the Load event inside mainWindow
                welcomeForm.FileSelectedToLoad += mainWindow.OnFileSelectedToLoad;

                if (welcomeForm.ShowDialog() == DialogResult.OK)
                {
                    // Enable Main Window once file is selected
                    mainWindow.Enabled = true;
                }
                else
                {
                    // Exit if the user cancels the welcome form
                    mainWindow.Close();
                    return;
                }
                
                // maybe here should unsubsribe from FileSelectedToLoad
                welcomeForm.FileSelectedToLoad -= mainWindow.OnFileSelectedToLoad;
            }

            Application.Run(mainWindow);
        }
    }
}