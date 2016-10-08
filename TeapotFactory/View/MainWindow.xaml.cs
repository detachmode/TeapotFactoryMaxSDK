using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
            InitializeComponent();
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
                default:
                    break;
            }
            lblStatusText.Text = msg;
            ((Storyboard)FindResource("animate")).Begin(theStatusBar);
        }


        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
