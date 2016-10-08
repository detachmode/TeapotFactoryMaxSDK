using System;
using System.IO;
using System.Reflection;

namespace TeapotFactoryMaxPlugin
{
    public class EntryPoint : AbstractCustomCuiActionCommandAdapter
    {
        public override string CustomActionText => "MyGUI2";


        public override void CustomExecute(object parameter)
        {
            MaxScriptPortal.OpenMainWindow();
        }

    }
}