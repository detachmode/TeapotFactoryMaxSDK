using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeapotFactory.Provider;
using static TeapotFactoryMaxPlugin.MaxscriptHelper;

namespace TeapotFactoryMaxPlugin.Provider
{
    public class MaxProvider : IProvider
    {
        public void CreateTeapot()
        {
            FormatFunctionCall("CreateTeapot", str => Execute(str));
        }
    }
}
