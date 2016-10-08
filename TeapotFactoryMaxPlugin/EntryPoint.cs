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
            
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            MaxScriptPortal.OpenMainWindow();


        }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            byte[] ba = null;
            string resource = "TeapotFactoryMaxPlugin.TeapotFactory.dll";
            Assembly curAsm = Assembly.GetExecutingAssembly();
            using (Stream stm = curAsm.GetManifestResourceStream(resource))
            {
                ba = new byte[(int)stm.Length];
                stm.Read(ba, 0, (int)stm.Length);

                return Assembly.Load(ba);
            }
        }
    }
}