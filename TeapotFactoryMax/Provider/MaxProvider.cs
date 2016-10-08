using TeapotFactory.Provider;

namespace TeapotFactoryMax.Provider
{
    public class MaxProvider : IProvider
    {
        public void CreateTeapot()
        {
            MaxscriptHelper.FormatFunctionCall("CreateTeapot", str => MaxscriptHelper.Execute(str));
        }
    }
}
