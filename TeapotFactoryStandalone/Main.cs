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
            theApplication.DispatcherUnhandledException += AppOnDispatcherUnhandledException;
            theApplication.Run(dialog);

        }


        private static void AppOnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs args)
        {

            args.Handled = true;
            if (args.Exception.GetType() == typeof(WarningException))
            {
                Interactions.Warningpopup(args.Exception.Message);
            }
            else if (args.Exception.GetType() == typeof(ErrorException))
            {
                Interactions.Errorpopup(args.Exception.Message);
            }
            else
            {
                UnkownErrorDialog inputDialog = new UnkownErrorDialog(args.Exception.ToString());
                if (inputDialog.ShowDialog() == true)
                    theApplication.Shutdown();

                //MessageBox.Show(" !!  Make Screenshot !! - For helping me fixing this bug\n\n" + args.Exception.ToString(), caption:"Unknow Error");
               
            }

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
