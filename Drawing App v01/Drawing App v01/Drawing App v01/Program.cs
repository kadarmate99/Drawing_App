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
            frmMainWindow mainWindow = new frmMainWindow();
            mainWindow.Enabled = false;
            mainWindow.Show();

            // Open Welcome Form as a modal dialog
            using (frmWelcomeForm welcomeForm = new frmWelcomeForm())
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
                //test 02 comment
                // maybe here should unsubsribe from FileSelectedToLoad
                // test
                welcomeForm.FileSelectedToLoad -= mainWindow.OnFileSelectedToLoad;
            }

            Application.Run(mainWindow);
        }
    }
}