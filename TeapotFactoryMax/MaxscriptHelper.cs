using System;
using System.Windows;
using Autodesk.Max;
using ManagedServices;

namespace TeapotFactoryMax
{
    public static class MaxscriptHelper
    {
        private static readonly string StructName = "TeapotFactory";

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


        public static ITab<string> Excute(string mxsCode)
        {
            try
            {
                IFPValue mxsRetVal = Kernel.Global.FPValue.Create();
                Kernel.Global.ExecuteMAXScriptScript(mxsCode, true, mxsRetVal);
                return mxsRetVal.STab;
            }
            catch
            {
                OnError("Couldn't Execute Function: " + mxsCode);
                return null;
            }
            
        }


        public static void FormatFunctionCall(string functionName, Action<string> continueWith, string parameter = null)
        {
            if (parameter == null)
                continueWith(string.Format("{0}.{1}()", StructName, functionName));
            else
                continueWith(string.Format("{0}.{1} {2}", StructName, functionName, parameter));
        }
    }
}