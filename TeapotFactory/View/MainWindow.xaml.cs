using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using TeapotFactory.Exceptions;
using TeapotFactory.ViewModel;

namespace TeapotFactory.View
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.Dispatcher.UnhandledException += Dispatcher_UnhandledException;
            InitializeComponent();
            Closed += closed;
        }

        private void closed(object sender, System.EventArgs e)
        {
            this.Dispatcher.UnhandledException -= Dispatcher_UnhandledException;
        }

        public void Dispatcher_UnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs args)
        {
            ExceptionHandling.ExceptionRoutine(args, closeAction:this.Close);

        }

        public enum StatusKind
        {
            Error,
            Good,
            Warning
        }


        public void ShowStatus(string msg, StatusKind kind)
        {
            switch (kind)
            {
                case StatusKind.Error:
                    lblStatusText.Foreground = new SolidColorBrush(Colors.OrangeRed);
                    break;
                case StatusKind.Good:
                    lblStatusText.Foreground = new SolidColorBrush(Colors.LawnGreen);
                    break;
                case StatusKind.Warning:
                    lblStatusText.Foreground = new SolidColorBrush(Colors.Yellow);
                    break;
            }
            lblStatusText.Text = msg;
            ((Storyboard)FindResource("animate")).Begin(theStatusBar);
        }


        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NullReferenceException();
        }


        private void TestWarning(object sender, RoutedEventArgs e)
        {
            Interactions.Warningpopup("some warnings!");
        }


        private void TestError(object sender, RoutedEventArgs e)
        {
            Interactions.Errorpopup("Some error!");
        }


        private void CreateTeapot(object sender, RoutedEventArgs e)
        {
            Interactions.CreateTeapot();
        }
    }
}
