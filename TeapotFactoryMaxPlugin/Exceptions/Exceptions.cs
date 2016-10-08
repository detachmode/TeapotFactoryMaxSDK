using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeapotFactory.View;

namespace TeapotFactory.Exceptions
{
    public class ErrorException : Exception
    {
        public ErrorException(string s) : base(s)
        {

        }
    }


    public class WarningException : Exception
    {
        public WarningException(string s) : base(s)
        {

        }
    }


    public class ExceptionsHandling
    {
        public void Dispatcher_UnhandledException(object sender,
            System.Windows.Threading.DispatcherUnhandledExceptionEventArgs args)
        {
            args.Handled = true;
            try
            {
                if (args.Exception.GetType() == typeof (WarningException))
                {
                    Interactions.Warningpopup(args.Exception.Message);
                }
                else if (args.Exception.GetType() == typeof (ErrorException))
                {
                    Interactions.Errorpopup(args.Exception.Message);
                }
                else
                {
                    UnkownErrorDialog errorDialog = new UnkownErrorDialog(args.Exception.ToString());
                    if (errorDialog.ShowDialog() != true) return;

                }
            }
            catch (Exception)
            {

            }
        }
    }
}
