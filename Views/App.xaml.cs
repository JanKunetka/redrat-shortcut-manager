using System.Windows;
using RedRatShortcuts.ViewModels;

namespace RedRatShortcuts.Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow();
            MainWindow.DataContext = new MainVM();
            MainWindow.Show();
            
            base.OnStartup(e);
        }

    }
}