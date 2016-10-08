using System;
using TeapotFactory.Provider;
using TeapotFactory.View;
using TeapotFactory.ViewModel;

namespace TeapotFactory
{

    public static class Interactions
    {
        

        public static void Successpopup(string msg)
        {
            window.ShowStatus(msg , MainWindow.StatusKind.Good);
        }

        public static void UnknownErrorpopup(string msg)
        {
            window.ShowStatus("Unknown Error: " + msg , MainWindow.StatusKind.Error);
        }

        public static void Errorpopup(string msg)
        {
            window.ShowStatus("Error: " + msg + @"  (゜-゜) ", MainWindow.StatusKind.Error);
        }

        public static void Warningpopup(string msg)
        {
            window.ShowStatus(msg + @"  ¯\_(ツ)_/¯", MainWindow.StatusKind.Warning);
        }

        public static event Action<string> OnError;


        public static void CallEventErrorMessage(string errorMsg)
        {
            OnError?.Invoke(errorMsg);
        }


        public static event Action<string> OnWarning;


        public static void CallEventWarningMessage(string msg)
        {
            OnWarning?.Invoke(msg);
        }



        #region Config Interactions

        private static readonly IProvider provider;
        private static MainWindow window;

        public static void Setup(MainWindow theWindow)
        {
            window = theWindow;
        }

        #endregion

       
    }


}