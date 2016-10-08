using System.Windows;
using TeapotFactory.Provider;

namespace TeapotFactoryStandalone
{

    public class DefaultProvider : IProvider
    {
        public void CreateTeapot()
        {
            MessageBox.Show("Created some imaginary teapots!");
        }
    }

}