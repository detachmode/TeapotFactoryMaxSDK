using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;
using TeapotFactory;
using TeapotFactory.Exceptions;
using TeapotFactory.View;
using WarningException = System.ComponentModel.WarningException;

namespace TeapotFactoryStandalone
{
    class App
    {
        private static Application theApplication;
        [STAThread]
        public static void OpenMainWindow()
        {

            var dialog = new TeapotFactory.View.MainWindow();
            theApplication = new Application();
            theApplication.Run(dialog);

        }



        [STAThread]
        public static void Main()
        {
            Interactions.OnError += s => Debug.WriteLine(s);
            Interactions.OnWarning += s => Debug.WriteLine(s);
            Interactions.OnError += Interactions.Errorpopup;
            Interactions.OnWarning += Interactions.Warningpopup;
            OpenMainWindow();
        }

    }
}
