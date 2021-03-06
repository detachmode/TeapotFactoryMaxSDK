﻿using System;
using TeapotFactory.Provider;
using TeapotFactory.View;
using TeapotFactory.ViewModel;

namespace TeapotFactory
{

    /// <summary>
    /// Events from the UI (Views) will call a method inside the Interactions class.
    /// The behaviors of the Interactions can be controlled by "Inversion of Control" - the IProvider interface decouples the UI from the MaxAPI
    /// </summary>
    public static class Interactions
    {
        #region Config Interactions

        private static IProvider provider;
        private static MainWindow window;

        public static void Setup(MainWindow theWindow, IProvider aProvider)
        {
            window = theWindow;
            provider = aProvider;
        }

        #endregion

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


        public static void CreateTeapot()
        {
            provider.CreateTeapot();
        }

    }
}