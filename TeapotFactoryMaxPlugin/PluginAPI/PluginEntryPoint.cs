using System;
using System.IO;
using System.Reflection;
using System.Windows;
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

    /// <summary>
    /// This is just needed, when you want to place your dll inside bin/assembly folder. That way the plugin can be loaded. 
    /// But be carefull the maxscript struct possibly won't be there. So I am not sure if this is really of any use.
    /// </summary>
    public class PluginEntryPoint : AbstractCustomCuiActionCommandAdapter
    {
        public override string CustomActionText => "TeapotFactory";


        public override void CustomExecute(object parameter)
        {
            MaxPortal.OpenMainWindow();
        }

    }
}