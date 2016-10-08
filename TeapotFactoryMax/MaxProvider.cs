using TeapotFactory.Provider;
using TeapotFactoryMax.Helper;

namespace TeapotFactoryMax
{
    /// <summary>
    /// Interaction from C# with 3dsmax. Every call you make to a 3dsMax API needs to be wrapped inside a method in the class.
    /// Be sure to define new methods inside the IProvider interface, that way you can easily use mockdata for the standalone version.
    /// </summary>
    public class MaxProvider : IProvider
    {
        public void CreateTeapot()
        {
            MaxscriptHelper.FormatFunctionCall("CreateTeapot", str => MaxscriptHelper.Execute(str));
        }
    }
}
