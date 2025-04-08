using Drawing_App_v01.Model;
using Drawing_App_v01.Presenter;
using Drawing_App_v01.View;

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

            // Create dependencies
            DrawingModel drawingModel = new DrawingModel();
            MainWindowPresenter mainWindowPresenter = new MainWindowPresenter(drawingModel);
            MainWindow mainWindow = new MainWindow(mainWindowPresenter);

            // Diable Main Window initially
            mainWindow.Enabled = false;
            mainWindow.Show();

            // Open Welcome Form
            using (WelcomeForm welcomeForm = new WelcomeForm())
            {
                // Subscribe to the File Open/Create event inside mainWindow
                welcomeForm.FileSelectedToOpen += mainWindowPresenter.OnFileSelectedToOpen;
                welcomeForm.FileSelectedToCreate += mainWindowPresenter.OnFileSelectedToCreate;

                if (welcomeForm.ShowDialog() == DialogResult.OK)
                {
                    mainWindowPresenter.ShowUserDataForm();
                    // Enable Main Window once file is selected
                    mainWindow.Enabled = true;
                }
                else
                {
                    // Exit if the user cancels the welcome form
                    mainWindow.Close();
                    return;
                }

                //unsubsribe from File Open/Create event
                welcomeForm.FileSelectedToOpen -= mainWindowPresenter.OnFileSelectedToOpen;
                welcomeForm.FileSelectedToCreate -= mainWindowPresenter.OnFileSelectedToCreate;
            }

            Application.Run(mainWindow);
        }
    }
}