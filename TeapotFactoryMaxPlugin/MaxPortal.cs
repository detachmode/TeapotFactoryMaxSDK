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

            mainWindow.Show();
           
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