using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using Autodesk.Max;
using ManagedServices;
using TeapotFactory;
using TeapotFactory.Exceptions;
using TeapotFactory.View;

namespace TeapotFactoryMaxPlugin
{
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

            //AppDomain.CurrentDomain.UnhandledException +=
            //    CurrentDomain_UnhandledException;
            mainWindow.Dispatcher.UnhandledException += Dispatcher_UnhandledException;
            mainWindow.Show();
           

        }

        private static void Dispatcher_UnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs args)
        {
            args.Handled = true;
            try
            {
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
                    UnkownErrorDialog errorDialog = new UnkownErrorDialog(args.Exception.ToString());
                    if (errorDialog.ShowDialog() != true) return;
                    mainWindow.Close();
                }
            }
            catch (Exception)
            {
                    
            }
            
        }



        public static void OnError(string errormsg)
        {
            MessageBox.Show(errormsg);
        }


        public static void Execute(string mxs)
        {
            try
            {
                MaxscriptSDK.ExecuteMaxscriptCommand(mxs);
            }
            catch
            {
                OnError("Couldn't Execute: " + mxs);
            }
        }

        public static ITab<string> CallFunction(string fn)
        {
            try
            {
                string mxsCode = fn + "()";
                IFPValue mxsRetVal = Kernel.Global.FPValue.Create();
                Kernel.Global.ExecuteMAXScriptScript(mxsCode, true, mxsRetVal);
                return mxsRetVal.STab;
            }
            catch
            {

                OnError("Couldn't Execute Function: " + fn);
                return null;
            }
            
        }


        public static void CallMyGUIFunction(string fn, string parameter = null)
        {
            if (parameter == null)
            {
                Execute("MyGUIDotnet." + fn + "()");
            }
            else
            {
                Execute("MyGUIDotnet." + fn + " " + parameter);
            }
           
        }

    }
}