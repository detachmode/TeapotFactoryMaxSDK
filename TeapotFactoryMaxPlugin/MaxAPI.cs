using System;
using System.Windows;
using Autodesk.Max;
using UiViewModels.Actions;

namespace TeapotFactoryMaxPlugin
{
    public abstract class AbstractCustomCuiActionCommandAdapter : CuiActionCommandAdapter
    {
        public override string ActionText => InternalActionText;
        public override string Category => InternalCategory;
        public override string InternalActionText => CustomActionText;
        public override string InternalCategory => "Detachmode";
        public override void Execute(object parameter)
        {
            try
            {
                CustomExecute(parameter);
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception occurred: " + e.Message);
            }
        }

        public abstract string CustomActionText { get; }
        public abstract void CustomExecute(object parameter);
    }

    public static class Kernel
    {
        public static IGlobal Global = GlobalInterface.Instance;
        public static IInterface13 Interface = Global.COREInterface13;

    }
}