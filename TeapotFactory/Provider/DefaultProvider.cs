using System;
using System.Windows;
using TeapotFactory.Provider;

namespace TeapotFactory
{
    public class DefaultProvider : IProvider
    {
        public void CreateTeapot()
        {
            MessageBox.Show("Created some imaginary teapots!");
        }
    }
}