using System;
using System.Windows;
using Autodesk.Max;
using UiViewModels.Actions;

namespace TeapotFactoryMaxPlugin
{

    public static class Kernel
    {
        public static IGlobal Global = GlobalInterface.Instance;
        public static IInterface13 Interface = Global.COREInterface13;

    }
}