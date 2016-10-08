using System.Windows.Interop;
using ManagedServices;
using TeapotFactory;
using TeapotFactory.View;
using TeapotFactoryMax.Provider;

namespace TeapotFactoryMax
{
    /// <summary>
    /// this is the entrance for the max side to interact with our app
    /// If you want to call a method inside of our app, define a wrapper method here
    /// </summary>
    public static class MaxPortal
    {
        private static MainWindow mainWindow;
        public static void OpenMainWindow()
        {
            
            mainWindow = new MainWindow();         
            mainWindow.ShowInTaskbar = false;

            // ReSharper disable once ObjectCreationAsStatement
            new WindowInteropHelper(mainWindow) { Owner = AppSDK.GetMaxHWND() };
            
            AppSDK.ConfigureWindowForMax(mainWindow);

            Interactions.Setup(mainWindow, new MaxProvider());
            mainWindow.Show();

        }


        public static void TeapotCreatedFeedback()
        {
            Interactions.Successpopup("Created new Teapot :)");
        }
    }
}